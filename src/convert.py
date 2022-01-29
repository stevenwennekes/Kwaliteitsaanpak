#!/bin/env python

"""Main program to convert Markdown files to different possible output formats."""

import datetime
import json
import logging
import os
import pathlib
import pprint
import shutil
from typing import cast, List
from xml.etree.ElementTree import ElementTree

from cli import parse_cli_arguments
from converter import Converter
from builder import DocxBuilder, HTMLBuilder, HTMLCoverBuilder, PptxBuilder, XlsxBuilder
from markdown_converter import MarkdownConverter
from custom_types import JSON, Settings, Variables


def convert(settings_filename: str, version: str) -> None:
    """Convert the input document to the specified output formats."""
    # pylint: disable=unsubscriptable-object,unsupported-assignment-operation
    settings = cast(Settings, read_json(settings_filename))
    variables = cast(Variables, {})
    for variable_file in settings["VariablesFiles"]:
        variables.update(cast(Variables, read_json(variable_file)))
    variables["VERSIE"] = settings["Version"] = version
    variables["DATUM"] = settings["Date"] = datetime.date.today().strftime("%d-%m-%Y")
    logging.info("Converting with settings:\n%s", pprint.pformat(settings))
    xml = MarkdownConverter(variables).convert(settings)
    write_xml(xml, settings)
    converter = Converter(xml)
    if "docx" in settings["OutputFormats"]:
        convert_docx(converter, settings)
    if "pdf" in settings["OutputFormats"]:
        copy_files(settings, "pdf")
        convert_pdf(converter, settings, variables)
    if "pptx" in settings["OutputFormats"]:
        convert_pptx(converter, settings)
    if "xlsx" in settings["OutputFormats"]:
        convert_xlsx(converter, settings)
    if "html" in settings["OutputFormats"]:
        copy_files(settings, "html")
        convert_html(converter, settings)


def read_json(json_filename: str) -> JSON:
    """Read JSON from the specified filename."""
    with open(json_filename, encoding="utf-8") as json_file:
        return JSON(json.load(json_file))


def write_xml(xml: ElementTree, settings: Settings) -> None:
    """Write the XML to the file specified in the settings."""
    markdown_filename = pathlib.Path(str(settings["InputFile"]))
    xml_filename = get_build_path(settings) / markdown_filename.with_suffix(".xml").name
    xml.write(str(xml_filename), encoding="utf-8")


def copy_files(settings: Settings, format: str) -> None:
    """Copy specified source files (e.g. CSS files) to the specified destinations."""
    for file_to_copy in settings["OutputFormats"][format].get("CopyFiles", []):
        shutil.copy(pathlib.Path(file_to_copy["from"]), pathlib.Path(file_to_copy["to"]))


def convert_html(converter, settings: Settings) -> None:
    """Convert the XML to HTML."""
    html_filename = get_output_path(settings) / settings["OutputFormats"]["html"]["OutputFile"]
    html_builder = HTMLBuilder(html_filename, "")
    converter.convert(html_builder)


def convert_pdf(converter, settings: Settings, variables: Variables) -> None:
    """Convert the XML to PDF."""
    build_path = get_build_path(settings)
    pdf_filename = get_output_filepath(settings, "pdf")
    pdf_build_filename = build_path / pathlib.Path(settings["OutputFormats"]["pdf"]["OutputFile"])
    html_filename = build_path / pathlib.Path(settings["InputFile"]).with_suffix(".html").name
    html_builder = HTMLBuilder(html_filename, build_path)
    converter.convert(html_builder)
    html_cover_filename = build_path / pathlib.Path(settings["InputFile"]).with_suffix(".cover.html").name
    html_cover_builder = HTMLCoverBuilder(html_cover_filename, build_path)
    converter.convert(html_cover_builder)
    with open("DocumentDefinitions/Shared/header.html", encoding="utf-8") as header_template_file:
        header_contents = header_template_file.read() % variables["KWALITEITSAANPAK"]
    header_filename = build_path / "header.html"
    with open(header_filename, mode="w", encoding="utf-8") as header_file:
        header_file.write(header_contents)
    os.system(
        f"""wkhtmltopdf \
        --enable-local-file-access \
        --footer-html DocumentDefinitions/Shared/footer.html --footer-spacing 10 \
        --header-html {header_filename} --header-spacing 10 \
        --margin-bottom 27 --margin-left 34 --margin-right 34 --margin-top 27 \
        --title '{settings["Title"]}' \
        cover {html_cover_filename} \
        {"toc --xsl-style-sheet DocumentDefinitions/Shared/toc.xsl" if settings["IncludeTableOfContents"] else ""} \
        {html_filename} {pdf_build_filename}"""
    )
    os.system(f"gs -o {pdf_filename} -sDEVICE=pdfwrite -dPrinted=false -f {pdf_build_filename} src/pdfmark.txt")


def convert_docx(converter, settings: Settings) -> None:
    """Convert the XML to docx."""
    docx_output_filename = get_output_filepath(settings, "docx")
    docx_builder = DocxBuilder(docx_output_filename, pathlib.Path(settings["OutputFormats"]["docx"]["ReferenceFile"]))
    converter.convert(docx_builder)


def convert_pptx(converter, settings: Settings) -> None:
    """Convert the XML to pptx."""
    pptx_output_filename = get_output_filepath(settings, "pptx")
    pptx_builder = PptxBuilder(pptx_output_filename, pathlib.Path(settings["OutputFormats"]["pptx"]["ReferenceFile"]))
    converter.convert(pptx_builder)


def convert_xlsx(converter, settings: Settings) -> None:
    """Convert the XML to xlsx."""
    xlsx_builder = XlsxBuilder(get_output_filepath(settings, "xlsx"))
    converter.convert(xlsx_builder)


def get_build_path(settings: Settings) -> pathlib.Path:
    """Return, and create if necessary, the build path from the settings."""
    return get_path(settings, "BuildPath")


def get_output_path(settings: Settings) -> pathlib.Path:
    """Return, and create if necessary, the output path from the settings."""
    return get_path(settings, "OutputPath")


def get_path(settings: Settings, pathname: str) -> pathlib.Path:
    """Return, and create if necessary, the specified path from the settings."""
    path = pathlib.Path(settings[pathname])
    path.mkdir(parents=True, exist_ok=True)
    return path


def get_output_filepath(settings: Settings, format: str) -> pathlib.Path:
    """Return the output filepath for the specified format. Create intermediate folders if necessary."""
    return get_output_path(settings) / settings["OutputFormats"][format]["OutputFile"]


def main(settings_filenames: List[str], version: str) -> None:
    """Convert the input documents specified in the list of JSON settings files."""
    for settings_filename in settings_filenames:
        convert(settings_filename, version)


if __name__ == "__main__":
    args = parse_cli_arguments()
    logging.basicConfig(level=getattr(logging, args.log))
    main(args.settings, args.version)
