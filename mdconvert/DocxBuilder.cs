﻿using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;

namespace mdconvert.Builders
{
    /// <summary>
    /// Document builder for DOCX documents.
    /// </summary>
    internal class DocxBuilder : IDocumentBuilder
    {
        private readonly WordprocessingDocument doc;
        private readonly MainDocumentPart mainPart;
        private readonly Body body;
        private int listNumId = 1;

        private static readonly Dictionary<int, string> HeadingLevelToStyle = new Dictionary<int, string>()
        {
            [0] = "Kop1",
            [1] = "Kop1",
            [2] = "Kop2",
            [3] = "Kop3",
            [4] = "Kop4",
            [5] = "Kop5",
        };

        private static readonly Dictionary<int, string> AppendixHeadingLevelToStyle = new Dictionary<int, string>()
        {
            [0] = "Kop1Bijlage",
            [1] = "Kop1Bijlage",
            [2] = "Kop2Bijlage",
            [3] = "Kop3Bijlage",
        };

        private const string StyleBulletList = "Lijstopsomteken1";
        private const string StyleNumberedList = "Lijstnummering1";
        private const string StyleTable = "Tabelraster1";
        private const string StyleTitle = "Titel";
        private readonly int BulletListAbstractNumId = 3;
        private readonly int NumberedListAbstractNumId = 0;

        public DocxBuilder(string filename, string referenceDocument)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            File.Copy(referenceDocument, filename);

            doc = WordprocessingDocument.Open(filename, true);
            mainPart = doc.MainDocumentPart;
            if (mainPart == null)
            {
                Program.Error($"mainPart == null");
            }

            body = mainPart.Document.Body;
            if (body == null)
            {
                Program.Error($"body == null");
            }
            body.RemoveAllChildren();
            body.AppendChild(new SectionProperties(new TitlePage() { Val = true }));

            NumberingDefinitionsPart numberingDefinitionsPart = mainPart.NumberingDefinitionsPart;

            foreach (var p in numberingDefinitionsPart.Numbering.Elements<AbstractNum>())
            {
                foreach (var l in p.Elements<Level>())
                {
                    if (l.ParagraphStyleIdInLevel != null)
                    {
                        string s = l.ParagraphStyleIdInLevel.Val;
                        if (s.Equals(StyleNumberedList, StringComparison.OrdinalIgnoreCase))
                        {
                            NumberedListAbstractNumId = p.AbstractNumberId;
                        }
                        else if (s.Equals(StyleBulletList, StringComparison.OrdinalIgnoreCase))
                        {
                            BulletListAbstractNumId = p.AbstractNumberId;
                        }
                    }
                }
            }

            listNumId = numberingDefinitionsPart.Numbering.Elements<NumberingInstance>().Count() + 1;

            // Set auto update
            DocumentSettingsPart settingsPart = mainPart.DocumentSettingsPart;
            if (settingsPart == null)
            {
                settingsPart = mainPart.AddNewPart<DocumentSettingsPart>();
            }
            settingsPart.Settings = new Settings { BordersDoNotSurroundFooter = new BordersDoNotSurroundFooter() { Val = true } };
            settingsPart.Settings.Append(new UpdateFieldsOnOpen() { Val = true });
        }

        public string Extension => "docx";

        public void StartDocument(string title)
        {
        }

        public void EndDocument()
        {
            doc.Close();
        }

        public void BuildHeader(XParagraph header)
        {
            Program.Debug($"creating header {header}");

            mainPart.DeleteParts(mainPart.HeaderParts);

            HeaderPart newHeaderPart = mainPart.AddNewPart<HeaderPart>();
            string headerPartId = mainPart.GetIdOfPart(newHeaderPart);
            Program.Debug($"HeaderId= {headerPartId}");

            Header docxHeader = new Header();
            Format(docxHeader, header, "Header", JustificationValues.Right); // new ParagraphProperties(new ParagraphStyleId() { Val = "Header" }, new Justification() { Val = JustificationValues.Right }));

            newHeaderPart.Header = docxHeader;

            IEnumerable<SectionProperties> sections = body.Elements<SectionProperties>();

            foreach (var section in sections)
            {
                // Delete existing references to headers and footers
                section.RemoveAllChildren<HeaderReference>();

                // Create the new header and footer reference node
                section.PrependChild(new HeaderReference() { Type = HeaderFooterValues.Default, Id = headerPartId });
            }
        }

        public void BuildFooter()
        {
            Program.Debug($"Creating footer");

            mainPart.DeleteParts(mainPart.FooterParts);

            FooterPart newFooterPart = mainPart.AddNewPart<FooterPart>();
            string footerPartId = mainPart.GetIdOfPart(newFooterPart);
            Program.Debug($"FooterId= {footerPartId}");

            Paragraph footerParagraph = new Paragraph(
              new ParagraphProperties(
                  new ParagraphStyleId() { Val = "Footer" },
                  new Justification() { Val = JustificationValues.Center }),
              new Run(
                  new SimpleField() { Instruction = "PAGE" })
            );

            Footer docxFooter = new Footer();

            docxFooter.AppendChild(footerParagraph);
            newFooterPart.Footer = docxFooter;

            IEnumerable<SectionProperties> sections = body.Elements<SectionProperties>();
            foreach (var section in sections)
            {
                // Delete existing references to headers and footers
                section.RemoveAllChildren<FooterReference>();
                // Create the new header and footer reference node
                section.PrependChild(new FooterReference() { Type = HeaderFooterValues.Default, Id = footerPartId });
            }
        }

        public void BuildTableOfContents()
        {
            Program.Debug($"Adding table of contents");

            var sdtBlock = new SdtBlock
            {
                InnerXml = GetTOC("Inhoudsopgave", 11)
            };
            body.AppendChild(sdtBlock);
            InsertPageBreak();
        }

        public void CreateHeading(int level, XParagraph paragraph, bool isAppendix, Context context)
        {
            string styleId = isAppendix
                ? AppendixHeadingLevelToStyle.GetValueOrDefault(level)
                : HeadingLevelToStyle.GetValueOrDefault(level);

            ParagraphProperties pp = new ParagraphProperties(new ParagraphStyleId() { Val = styleId });
            Format(body, paragraph, pp);
        }

        public void StartList(bool numbered)
        {
            NumberingInstance numberingInstance = new NumberingInstance()
            {
                AbstractNumId = new AbstractNumId() { Val = numbered ? NumberedListAbstractNumId : BulletListAbstractNumId },
                NumberID = listNumId,
            };
            numberingInstance.AppendChild(new StartOverrideNumberingValue() { Val = 1 });

            var lastNumbering = mainPart.NumberingDefinitionsPart.Numbering.Elements<NumberingInstance>().Last();

            mainPart.NumberingDefinitionsPart.Numbering.InsertAfter(numberingInstance, lastNumbering);
        }

        public void EndList()
        {
            listNumId++;
        }

        public void CreateListItem(int level, bool numbered, XParagraph paragraph, Context context)
        {
            string styleId = numbered ? StyleNumberedList : StyleBulletList;

            ParagraphProperties pp = new ParagraphProperties(
                new ParagraphStyleId() { Val = styleId },
                new NumberingProperties(
                    new NumberingId() { Val = listNumId },
                    new NumberingLevelReference() { Val = (level - 1) }
                ));
            Format(body, paragraph, pp);
        }

        public void CreateParagraph(XParagraph paragraph, Context context)
        {
            Format(body, paragraph, context == Context.Title ? StyleTitle : null);
        }

        public void CreateTable(XTable<XParagraph> table, Context context)
        {
            Table t = new Table();

            TableProperties tblProp = new TableProperties(
                new TableStyle() { Val = StyleTable },
                new TableWidth() { Width = "5000", Type = TableWidthUnitValues.Pct }
            );
            t.AppendChild(tblProp);

            TableRow headerRow = new TableRow();
            foreach (XParagraph headerCell in table.HeaderCells)
            {
                TableCell c = new TableCell();
                Format(c, headerCell);
                headerRow.Append(c);
            }
            t.Append(headerRow);

            for (int r = 0; r < table.DataRowCount; r++)
            {
                TableRow dataRow = new TableRow();
                foreach (XParagraph dataCell in table.GetRowCells(r))
                {
                    TableCell c = new TableCell();
                    Format(c, dataCell);
                    dataRow.Append(c);
                }
                t.Append(dataRow);
            }

            body.Append(t);
        }

        public void InsertPageBreak()
        {
            body.AppendChild(new Paragraph(new Run(new Break() { Type = BreakValues.Page })));
        }

        public void InsertPicture(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Program.Error($"Image not found '{fileName}'");
                return;
            }

            float imageWidth = 100;
            float imageHeight = 100;
            float horizontalRes = 200;
            float verticalRes = 200;

            using (FileStream pngStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            using (var image = new Bitmap(pngStream))
            {
                imageWidth = image.Width;
                imageHeight = image.Height;
                horizontalRes = image.HorizontalResolution;
                verticalRes = image.VerticalResolution;
            }

            ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Png);

            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                imagePart.FeedData(stream);
            }

            AddImageToBody(mainPart.GetIdOfPart(imagePart), imageWidth, imageHeight, horizontalRes, verticalRes);
        }

        private void Format(OpenXmlCompositeElement parent, XParagraph paragraph, string styleId, JustificationValues justification)
        {
            ParagraphProperties pp = new ParagraphProperties(
                   new ParagraphStyleId() { Val = styleId },
                   new Justification() { Val = justification });
            Format(parent, paragraph, pp);
        }

        private void Format(OpenXmlCompositeElement parent, XParagraph paragraph, string styleId)
        {
            Format(parent, paragraph, styleId, JustificationValues.Left);
        }

        private void Format(OpenXmlCompositeElement parent, XParagraph paragraph, ParagraphProperties properties = null)
        {
            Paragraph p = parent.AppendChild(new Paragraph());
            if (properties != null)
            {
                p.Append(properties);
            }

            for (int i = 0; i < paragraph.NumFragments; i++)
            {
                Format(p, paragraph.Get(i));
            }
        }

        private void Format(Paragraph parent, XFragment fragment)
        {
            Text text = new Text(fragment.ToString()) { Space = SpaceProcessingModeValues.Preserve };
            if (fragment.HasLink)
            {
                var relationship = mainPart.AddHyperlinkRelationship(new Uri(fragment.Link), true);
                Hyperlink hyperlink = new Hyperlink(
                    new Run(new RunProperties(new RunStyle { Val = "Hyperlink" }), text)) { Id = relationship.Id };
                parent.AppendChild(hyperlink);
            }
            else
            {
                Run run = parent.AppendChild(new Run());

                if (fragment.HasStyle)
                {
                    RunProperties props = new RunProperties();
                    if (fragment.Bold)
                    {
                        props.Append(new Bold());
                    }
                    if (fragment.Italic)
                    {
                        props.Append(new Italic());
                    }
                    if (fragment.Strikethrough)
                    {
                        props.Append(new Strike());
                    }
                    if (fragment.Instruction)
                    {
                        props.Append(new Highlight { Val = HighlightColorValues.Yellow });
                    }
                    run.AppendChild(props);
                }

                run.AppendChild(text);
            }
        }

        public string GetStyleIdFromStyleName(string styleName)
        {
            StyleDefinitionsPart stylePart = mainPart.StyleDefinitionsPart;
            string styleId = stylePart.Styles.Descendants<StyleId>()
                .Where(s => s.Val.Value.Equals(styleName, StringComparison.OrdinalIgnoreCase))
                .Select(n => ((Style)n.Parent).StyleId).FirstOrDefault();
            return styleId ?? styleName;
        }

        private void AddImageToBody(string relationshipId, float imageWidthPx, float imageHeightPx,
            float horizontalRes, float verticalRes)
        {
            const int emusPerInch = 914400;
            const int emusPerCm = 360000;
            Int64Value widthEmus = (long)(imageWidthPx / horizontalRes * emusPerInch);
            Int64Value heightEmus = (long)(imageHeightPx / verticalRes * emusPerInch);
            var maxWidthEmus = (long)(20 * emusPerCm);
            if (widthEmus > maxWidthEmus)
            {
                var ratio = (heightEmus * 1.0m) / widthEmus;
                widthEmus = maxWidthEmus;
                heightEmus = (long)(widthEmus * ratio);
            }

            Program.Debug($"image={relationshipId}, width={imageWidthPx}, height={imageHeightPx}, horizontalRes={horizontalRes}, verticalRes={verticalRes}");

            // Define the reference of the image.
            var element =
                 new Drawing(
                     new DW.Inline(
                         new DW.Extent() { Cx = (Int64Value)widthEmus, Cy = (Int64Value)heightEmus },
                         new DW.EffectExtent() { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L },
                         new DW.DocProperties() { Id = 1U, Name = "Picture 1" },
                         new DW.NonVisualGraphicFrameDrawingProperties(new A.GraphicFrameLocks() { NoChangeAspect = true }),
                         new A.Graphic(
                             new A.GraphicData(
                                 new PIC.Picture(
                                     new PIC.NonVisualPictureProperties(
                                         new PIC.NonVisualDrawingProperties()
                                         {
                                             Id = 0U,
                                             Name = "New Bitmap Image.jpg"
                                         },
                                         new PIC.NonVisualPictureDrawingProperties()),
                                     new PIC.BlipFill(
                                         new A.Blip(
                                             new A.BlipExtensionList(
                                                 new A.BlipExtension() { Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}" })
                                         )
                                         {
                                             Embed = relationshipId,
                                             CompressionState =
                                             A.BlipCompressionValues.Print
                                         },
                                         new A.Stretch(
                                             new A.FillRectangle())),
                                     new PIC.ShapeProperties(
                                         new A.Transform2D(
                                             new A.Offset() { X = 0L, Y = 0L },
                                             new A.Extents() { Cx = (Int64Value)widthEmus, Cy = (Int64Value)heightEmus }), // Cx = 990000L, Cy = 792000L }),
                                         new A.PresetGeometry(
                                             new A.AdjustValueList()
                                         )
                                         { Preset = A.ShapeTypeValues.Rectangle }))
                             )
                             { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                     )
                     {
                         DistanceFromTop = 0U,
                         DistanceFromBottom = 0U,
                         DistanceFromLeft = 0U,
                         DistanceFromRight = 0U,
                         EditId = "50D07946"
                     });

            // Append the reference to body, the element should be in a Run.
            body.AppendChild(new Paragraph(new Run(element)));
        }

        private static string GetTOC(string title, int titleFontSize)
        {
            return $@"<w:sdt>
                 <w:sdtPr>
                    <w:id w:val=""-493258456"" />
                    <w:docPartObj>
                       <w:docPartGallery w:val=""Table of Contents"" />
                       <w:docPartUnique />
                    </w:docPartObj>
                 </w:sdtPr>
                 <w:sdtEndPr>
                    <w:rPr>
                       <w:rFonts w:asciiTheme=""minorHAnsi"" w:eastAsiaTheme=""minorHAnsi"" w:hAnsiTheme=""minorHAnsi"" w:cstheme=""minorBidi"" />
                       <w:b />
                       <w:bCs />
                       <w:noProof />
                       <w:color w:val=""auto"" />
                       <w:sz w:val=""22"" />
                       <w:szCs w:val=""22"" />
                    </w:rPr>
                 </w:sdtEndPr>
                 <w:sdtContent>
                    <w:p w:rsidR=""00095C65"" w:rsidRDefault=""00095C65"">
                       <w:pPr>
                          <w:pStyle w:val=""TOCHeading"" />
                          <w:jc w:val=""left"" />
                       </w:pPr>
                       <w:r>
                            <w:rPr>
                              <w:b />
                              <w:color w:val=""2E74B5"" w:themeColor=""accent1"" w:themeShade=""BF"" />
                              <w:sz w:val=""{titleFontSize * 2}"" />
                              <w:szCs w:val=""{titleFontSize * 2}"" />
                          </w:rPr>
                          <w:t>{title}</w:t>
                       </w:r>
                    </w:p>
                    <w:p w:rsidR=""00095C65"" w:rsidRDefault=""00095C65"">
                       <w:r>
                          <w:rPr>
                             <w:b />
                             <w:bCs />
                             <w:noProof />
                          </w:rPr>
                          <w:fldChar w:fldCharType=""begin"" />
                       </w:r>
                       <w:r>
                          <w:rPr>
                             <w:b />
                             <w:bCs />
                             <w:noProof />
                          </w:rPr>
                          <w:instrText xml:space=""preserve""> TOC \o ""1-3"" \h \z \u </w:instrText>
                       </w:r>
                       <w:r>
                          <w:rPr>
                             <w:b />
                             <w:bCs />
                             <w:noProof />
                          </w:rPr>
                          <w:fldChar w:fldCharType=""separate"" />
                       </w:r>
                       <w:r>
                          <w:rPr>
                             <w:noProof />
                          </w:rPr>
                          <w:t>No table of contents entries found.</w:t>
                       </w:r>
                       <w:r>
                          <w:rPr>
                             <w:b />
                             <w:bCs />
                             <w:noProof />
                          </w:rPr>
                          <w:fldChar w:fldCharType=""end"" />
                       </w:r>
                    </w:p>
                 </w:sdtContent>
                </w:sdt>
                ";
        }

        /*
         *
         *Create SdtBlock, and set TOC xml

    var sdtBlock = new SdtBlock();
    sdtBlock.InnerXml = GetTOC(Translations.ResultsBooksTableOfContentsTitle, 16);
//Set UpdateFieldsOnOpen

    var settingsPart = document.MainDocumentPart.AddNewPart<DocumentSettingsPart>();
    settingsPart.Settings = new Settings { BordersDoNotSurroundFooter = new BordersDoNotSurroundFooter() { Val = true } };

    settingsPart.Settings.Append(new UpdateFieldsOnOpen() { Val = true });
         */
    }
}