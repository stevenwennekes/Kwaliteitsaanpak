# Kwaliteitsmaatregelen tijdens het project

De onderstaande kwaliteitsmaatregelen zijn van toepassing gedurende het gehele project, waaronder de voorfase en de realisatiefase. De navolgende hoofdstukken beschrijven aanvullende kwaliteitsmaatregelen voor respectievelijk de voorfase, de realisatiefase en de projectafsluiting. De M-nummers verwijzen naar maatregelen uit de $KWALITEITSAANPAK$, zie [https://www.ictu.nl/kwaliteitsaanpak](https://www.ictu.nl/kwaliteitsaanpak).

## Projectmanagement

### Wekelijks projectoverleg

Het project houdt een wekelijks intern projectoverleg (IPO) waarin planning, voortgang, kwaliteitsrapportage, acties, risico's en overige relevante zaken worden besproken ($M10$). Het doel is om informatie uit te wisselen binnen het project, belemmeringen voor de voortgang die het team niet zelf kan oplossen te melden en eventueel te besluiten over escalaties buiten het project.

De IPO-agenda bevat minimaal: mededelingen, kwaliteit, voortgang, risico's, acties en rondvraag. Aanwezig zijn in ieder geval de projectleider, de software delivery manager, de kwaliteitsmanager, de Scrummaster en een vertegenwoordiger uit elk projectteam.

De kwaliteitsmanager controleert of deze overleggen plaatsvinden.

### Actie- en besluitenlijst

Het project houdt een actie- en besluitenlijst bij. De actie- en besluitenlijst wordt digitaal bijgehouden door de software delivery manager en wordt tijdens het wekelijks projectoverleg besproken. Het kwaliteitssysteem bewaakt de actualiteit van de actie- en besluitenlijst.

### Risicomanagement

Het project houdt een risicolog bij. De risicolog wordt digitaal bijgehouden door de software delivery manager en periodiek besproken tijdens het projectoverleg. Iedere projectmedewerker kan risico's melden bij de software delivery manager. De omvang van risico's wordt ingeschat en indien nodig voorzien van een of meer maatregelen. Het kwaliteitssysteem bewaakt de actualiteit van het risicolog.

### Werkwijze

Voor de realisatiefase wordt de agile ontwikkelmethode Scrum gebruikt ($M05$). Voor de beheerfase wordt gebruik gemaakt van de DevOps-principes. Afwijkingen hierop worden alleen toegestaan met goedkeuring van de software delivery manager en kwaliteitsmanager.

De volgende rapportage/escalatielijnen worden gehanteerd indien kwaliteitsdoelstellingen niet tijdig worden behaald:

1. De kwaliteitsmanager bespreekt de situatie met de software delivery manager;
2. Indien 1. niet tot resultaat leidt, escaleert de kwaliteitsmanager de situatie naar de ICTU-projectleider;
3. Indien 2. niet tot resultaat leidt, escaleert de kwaliteitsmanager de situatie naar het hoofd van de afdeling ICTU Software Expertise (ISE).

## Projectdocumenten

### Versiebeheer documenten

Alle documenten die een deliverable van het project zijn, zoals architectuurdocumenten, functioneel ontwerp en installatiehandleidingen, worden in de digitale samenwerkruimte van het project geplaatst. De opgeleverde documenten worden in pdf-formaat opgeslagen en bevatten een versienummer in de naam. De versies van de bronbestanden van deliverables worden opgeslagen in een online werkomgeving en moeten beschikbaar zijn om later aangepast te kunnen worden. Dit project gebruikt {Git, Sharepoint, Samenwerkingsruimte}.

Bij elk formele release moeten de documenten geactualiseerd zijn en formeel opgeleverd worden.

### Documentreview

Alle deliverables worden gereviewd. De auteur van een deliverable zorgt, in overleg met de software delivery manager, dat de juiste reviewers benoemd zijn; hiertoe behoort in ieder geval de kwaliteitsmanager. De auteur van het document zorgt voor een correct versiebeheer van het document.

Reviewers worden uitgenodigd door de auteur van het document en ontvangen de juiste versie van de auteur. De werkwijze wordt in overleg door de software delivery manager en kwaliteitsmanager bepaald.

De opstellers verwerken het commentaar. Vervolgens sturen de opstellers een toelichting op de wijze waarop het commentaar al dan niet is verwerkt naar de reviewers.

# Kwaliteitsmaatregelen voorfase

Het doel van de voorfase is tweeledig: het voorbereiden van de realisatiefase, zodat ICTU verantwoord een projectovereenkomst kan opstellen voor de realisatiefase, en het identificeren van risico’s die van toepassing zijn op de realisatiefase en het verdere verloop van het project.

De opdrachtgever zorgt dat het project bij de start van de voorfase inzicht heeft in de informatie die typisch wordt vastgelegd in een projectstartarchitectuur, business impact analysis en privacy impact assessment. Waar nodig werkt de opdrachtgever de informatie bij tijdens de voorfase en realisatiefase.

Dit kwaliteitsplan wordt opgesteld tijdens de voorfase, maar is tevens al deels van toepassing, in ieder geval aan het eind van de voorfase. Voor de voorfase gelden de onderstaande kwaliteitsmaatregelen.

## Belanghebbenden

De kwaliteit van de deliverables wordt mede bepaald door de verwachtingen van de belanghebbenden. Het is van belang dat alle belanghebbenden zijn geïdentificeerd en hun verwachtingen zijn vastgelegd, geanalyseerd en vertaald naar de eisen voor het te implementeren systeem. De belanghebbenden worden geïdentificeerd in het projectvoorstel voor de voorfase. De eisen aan het te ontwikkelen systeem worden vastgelegd in Backlog en NFE-document.

De tijdens de voorfase geïdentificeerde eisen vormen het startpunt van de opdrachtgever en kunnen gedurende de vervolgfases in overeenstemming met de opdrachtnemer aangepast worden. De product owner vertegenwoordigt gedurende de vervolgfasen de geïdentificeerde belanghebbenden.

## Verwerking eisen

### Functionele eisen

Het programma van eisen en de projectstartarchitectuur, beide opgesteld door de opdrachtgever, zijn de basis voor de op te leveren ICTU-documenten, zoals architectuur en ontwerpdocumenten.

### Niet-Functionele eisen

Niet-functionele eisen aan het te ontwikkelen systeem worden vastgelegd op basis van de projectstartarchitectuur en aan de hand van de NEN-ISO/IEC 25010-standaard in een NFE-document. De ISO-25010-kwaliteitsattributen worden door de belanghebbenden geprioriteerd in een of meer workshops (PRA – zie ook testen). Voor de kwaliteitsattributen worden SMART-eisen geformuleerd.

Informatiebeveiliging is een essentieel en integraal onderdeel van de werkzaamheden. De eisen worden in een afzonderlijk informatiebeveiligingsplan opgesteld. De software zal zodanig worden voortgebracht dat deze de BIO-compliance van de opdrachtgever niet zal hinderen.

Gebruikskwaliteit (usability) is ingebed in de standaard werkwijze van ICTU voor de realisatie van maatwerksoftware. Dit aspect wordt geborgd door opname in het plan van aanpak, het ontwerp en de testplannen.

Toegankelijkheid is een wettelijke verplichting voor webgebaseerde en mobiele applicaties, zie de EN 301 549 en de WCAG 2.1, niveau A en AA. Toegankelijkheid wordt geborgd via toegankelijkheidstesten, zie de kwaliteitsmaatregelen in paragraaf [Toegankelijkheidstesten](#toegankelijkheidstesten).

Performance- en securityeisen worden via performance- en securitytests geborgd, zie de kwaliteitsmaatregelen in paragraaf [Testen](#testen). Voor de borging van andere niet-functionele eisen moeten projectspecifieke maatregelen getroffen worden. Deze worden in dit kwaliteitsplan opgenomen.

### Compleetheid deliverables voorfase

In aanvulling op de maatregelen met betrekking tot reviews, zie paragraaf [Documentreview](#documentreview), reviewt de kwaliteitsmanager de deliverables van de voorfase op compleetheid. Hiervoor vormt de $KWALITEITSAANPAK$ het referentiekader.

### Tracering eisen

{Als de eisen traceerbaar moeten zijn vanuit de Backlog/NFE-document/Informatiebeveiligingsplan via GFO en SAD naar broncode, beschrijf dan hier de wijze waarop de eisen uniek identificeerbaar zijn gemaakt, hoe de relaties tussen eisen en ontwerp(beslissingen) worden bijgehouden en hoe de relaties tussen ontwerp(beslissingen) en code worden bijgehouden. Beschrijf hier ook wie deze relaties op welke momenten verifieert en hoe de verificatie wordt gedocumenteerd.} 

# Kwaliteitsmaatregelen realisatiefase

De onderstaande kwaliteitsmaatregelen zijn van toepassing gedurende de realisatiefase.

## Entry- en exitcriteria

ICTU volgt een agile aanpak bij het realiseren van software, waarbij gewerkt wordt in korte iteraties (sprints) waarin user stories worden omgezet in werkende software. De resultaten van één of meer sprints worden gebundeld in (major) releases. Hierbij worden entry- en exitcriteria gebruikt om te bepalen of werk kan worden opgepakt of gereed is: Definition of Ready (entry criteria) en Definition of Done (exit criteria) voor user stories en het vrijgaveadvies voor releases (exit criteria).

### Definition of Ready

Het project definieert en hanteert een Definition of Ready (DoR) voor user stories. Een user story kan pas in een sprint worden opgepakt als deze aan de DoR voldoet. De kwaliteitsmanager controleert of er een DoR is gedefinieerd en controleert periodiek of deze wordt gehanteerd.

De Definition Of Ready van het project bevat de volgende criteria ({vul aan en pas aan}):

1. De beschrijving voldoet aan het user story formaat “als <rol> wil ik <actie> zodat <reden>”;
2. De annotaties en screenshots/prototype zijn gereed;
3. Afhankelijkheden met derden zijn in kaart (bijvoorbeeld: een koppelvlakbeschrijving is beschikbaar);
4. De story is ingeschat door het team;
5. De story is goedgekeurd door de product owner;
6. De story is goedgekeurd door de reviewer binnen het team;
7. Het verwachte aantal logische testgevallen is ingevuld;
8. Er is ingeschat of de user story een performance risico, een beveiligingsrisico en/of een infrastructuurwijziging met zich meebrengt.

### Definition of Done

Het project definieert en hanteert een Definition of Done (DoD) voor user stories. De kwaliteitsmanager controleert of er een DoD is gedefinieerd en controleert periodiek of deze wordt gehanteerd.

De Definition Of Done van het project bevat de volgende criteria ({vul aan en pas aan}):

1. De broncode voldoet aan de codeerstandaard,
1. Nieuwe testgevallen zijn gereviewd en geaccordeerd door reviewer,
1. Functionele testen zijn succesvol afgerond,
1. De dekkingsgraad van de functionele testen is minstens 80% (maar meer indien mogelijk),
1. Integratietesten zijn succesvol afgerond,
1. Performancetesten zijn succesvol afgerond,
1. Toegankelijkheidstesten zijn succesvol afgerond,
1. Het GFO is bijgewerkt,
1. De demo van de user story is voorbereid.

### Vrijgaveadvies

Voor elke major release stelt het project (bijvoorbeeld de testmanager) een vrijgaveadvies op. Eventuele afwijkingen in de kwaliteitsrapportage en hieruit voortvloeiende risico's ("rode metrieken") worden in het vrijgaveadvies toegelicht. De kwaliteitsmanager reviewt het vrijgaveadvies.

Het vrijgaveadvies beschrijft ({vul aan en pas aan}):

1. Samenvatting testresultaten,
2. Openstaande bugs,
3. Afwijkingen kwaliteitsrapportage,
4. Overige risico's,
5. Het advies van ICTU wat betreft ingebruikname van de release.

### Release notes

Voor elke release stelt het project release notes op, een overzicht van de wijzigingen in de release. De release notes worden opgesteld door {rol} namens ICTU.

## ICTU-kwaliteitssysteem

Gedurende de realisatiefase hanteert ICTU een kwaliteitssysteem, waarbij automatisch metrieken worden verzameld en samengesteld. Deze metrieken hebben zowel betrekking op het proces als op het product (broncode). De metrieken worden meerdere keer per uur bijgewerkt, zodat er altijd een goed inzicht is in de softwarekwaliteit. Zie het [overzicht van mogelijke metrieken](https://github.com/ICTU/quality-time/blob/master/docs/METRICS_AND_SOURCES.md) en de daarbij horende standaard normen; de kwaliteitsmanager zal in samenwerking met het realisatieteam de te gebruiken metrieken en normen instellen.

De actuele kwaliteitsrapportage wordt dagelijks besproken tijdens team stand-up meetings en wekelijks in het intern projectoverleg (IPO). De kwaliteitsmanager onderhoudt en bewaakt de kwaliteitsrapportage. 

## Kwaliteit van de broncode

{Het project bepaalt bij aanvang van de realisatiefase of, en zo ja welke, codeerstandaard zal worden gehanteerd (ICTU hanteert geen ICTU-brede codeerstandaard). Het project bepaalt daarbij ook hoe de codeerstandaard gecontroleerd zal worden: via tools en/of broncodereviews.}

Het project hanteert de volgende codeerstandaarden:

| Programmeertaal     | Codeerstandaard     | Controle         |
|:--------------------|:--------------------|:-----------------|
| {programmeertaal A} | {codeerstandaard A} | {broncodereview} |
| {programmeertaal B} | {codeerstandaard B} | {tool B}         |

Het project bepaalt bij aanvang van de realisatiefase of en hoe vaak broncodereviews plaatsvinden; dit wordt in het mastertestplan opgenomen. ICTU maakt gebruik van een geautomatiseerd kwaliteitssysteem, waarbij de broncode continu wordt gecontroleerd en gerapporteerd. Voor het beoordelen van de onderhoudbaarheid gebruikt ICTU onder meer de SIG/TüVIT-evaluatiecriteria voor onderhoudbare software.

De keuze van programmeertalen en andere technologie staat beschreven in het SAD.

### Complexiteit van broncode limiteren

Om de onderhoudbaarheid van de software te bevorderen dienen methoden en klassen niet te complex te zijn. Het uitgangspunt is dat de cyclomatische complexiteit van individuele methoden, zoals berekend door SonarQube, niet groter is dan 10. De norm is dat 0% van de methoden een te hoge cyclomatische complexiteit hebben. Het ICTU-kwaliteitssysteem bewaakt de complexiteit van de broncode.

### Duplicatie van broncode beperken

Om de onderhoudbaarheid van de software te bevorderen dient er zo min mogelijk duplicatie van broncode aanwezig te zijn. Het uitgangspunt is dat SonarQube met de standaard instellingen 0% duplicatie rapporteert. Het ICTU-kwaliteitssysteem bewaakt de duplicatie in broncode.

### Omvang van het systeem beperken

Om de onderhoudbaarheid van de software te bevorderen dient de totale omvang beperkt te blijven, gemeten in mensjaren herbouwtijd. De SIG/TüVIT-standaard geeft een maximale herbouwtijd en vertaalt deze in een maximum omvang van de software gemeten in regels code. Die maximale omvang verschilt per programmeertaal. Het ICTU-kwaliteitssysteem bewaakt de totale omvang van het systeem.

Voor dit project gelden de volgende normen:

| Programmeertaal     | Maximale omvang in regels code |
|:--------------------|:-------------------------------|
| {programmeertaal A} | {maximale omvang}              |
| {programmeertaal B} | {maximale omvang}              |

### Omvang van methoden beperken

Om de onderhoudbaarheid van de software te bevorderen dienen methoden niet te groot te zijn. ICTU stelt de norm op maximaal 20 non-comment source statements (NCSS) per methode, zoals gemeten door SonarQube. In het systeem als geheel mag maximaal 0% (afgerond) van de methoden deze norm overschrijden. Het ICTU-kwaliteitssysteem bewaakt de omvang van methoden.

### Omvang van unit interfaces beperken

Om de onderhoudbaarheid van de software te bevorderen, dienen methoden niet te veel parameters te hebben. ICTU stelt de norm op maximaal vijf parameters per methode, zoals gemeten door SonarQube. In het systeem als geheel mag maximaal 0% (afgerond) van de methoden deze norm overschrijden. Het ICTU-kwaliteitssysteem bewaakt de omvang van unit interfaces.

## Versiebeheer broncode

Broncode, zowel van productiesoftware als van geautomatiseerde tests, wordt in een versiebeheersysteem geplaatst. Alleen projectmedewerkers hebben toegang tot de broncode. Het ICTU-kwaliteitssysteem bewaakt of branches worden gemerged met de default branch (meestal *master* of *develop* genoemd).

## Testen

Gedurende de realisatiefase worden de use cases in samenwerking met de product owner vertaald naar user stories. Per user story worden één of meer logische testgevallen opgesteld; per logisch testgeval worden één of meer fysieke testgevallen opgesteld. De user stories, logische testgevallen en fysieke testgevallen zijn expliciet aan elkaar gekoppeld. User stories en logische testgevallen worden vastgelegd in Jira; zie de bijlagen voor de te gebruiken typen en relaties. Afwijkingen op deze standaard aanpak zijn alleen toegestaan met goedkeuring van de kwaliteitsmanager.

Het mastertestplan (MTP) beschrijft welke testsoorten met welke intensiteit voor de realisatie- en beheerfase worden uitgevoerd. Het MTP wordt gebaseerd op in ieder geval PSA, NFE, SAD en GFO. Daarnaast is een product risicoanalyse (PRA) is uitgevoerd als basis voor de vaststelling van de diepgang waarmee de gedefinieerde testsoorten uitgevoerd moeten worden.

## Unit tests

Om de correcte werking van de software te borgen, schrijft het team unit tests. De unit tests draaien als onderdeel van de geautomatiseerde pijplijn en de broncodedekking van de unit tests wordt gemeten. Het ICTU-kwaliteitssysteem rapporteert over het aantal unit tests, het al dan niet slagen van de unit tests en broncodedekking van de unit tests.

De default normen voor broncodedekking met unit tests zijn 90% line coverage en 80% branch coverage. De norm geldt niet voor gegenereerde code, code van derde-partijen die ICTU zelf niet onderhoudt en triviale code zoals getters/setters/framework boilerplate-code.

## Systeemtesten

Om de correcte werking van de software te borgen maakt het team systeemtesten. Deze bestaan uit een combinatie van handmatige eenmalige testen, handmatige regressietesten en automatische regressietesten. De automatische regressietesten draaien als onderdeel van de geautomatiseerde pijplijn en de broncode dekking van de automatische regressietesten wordt gemeten. Het ICTU-kwaliteitssysteem rapporteert over het aantal handmatige regressietesten, de hoeveelheid tijd die het kost de handmatige regressietesten uit te voeren en de laatste datum dat ze zijn uitgevoerd. Het ICTU-kwaliteitssysteem rapporteert ook over het aantal automatische regressietesten, of ze al dan niet falen en de broncodedekking van de geautomatiseerde regressietesten.

De default normen voor broncodedekking met geautomatiseerde regressietesten zijn 80% line coverage en 70% branch coverage. De norm geldt niet voor gegenereerde code, code van derde-partijen die ICTU zelf niet onderhoudt en triviale code zoals getters/setters/framework boiler plate code.

## Unit tests en systeemtesten gecombineerd

Het ICTU-kwaliteitssysteem kan ook de geaggregeerde broncodedekking van unit tests en automatische regressietesten samen rapporteren. In dat geval zijn de default normen voor geaggregeerde broncodedekking 90% line coverage en 85% branch coverage.

Het is, ook als de geaggregeerde dekking gemeten wordt, nog steeds handig te weten welke code de automatische regressietesten (ART) en unit tests elk voor zich raken. Het is aan het project te beslissen welke norm nuttig is ART-dekking en unittest-dekking en of daar überhaupt normen voor nodig zijn.

Het uitgangspunt is dat zoveel mogelijk van de software die ICTU maakt, geautomatiseerd getest wordt en dat daarbij bewuste keuzes zijn gemaakt over de code die niet geautomatiseerd wordt getest. Om die keuzes goed te kunnen maken is het belangrijk dat het deel van de code, dat niet wordt geraakt door geautomatiseerde testen, relatief klein is; daardoor blijft de benodigde hoeveelheid handmatig testwerk beperkt en de risico's van handmatig testen beperkt.

## Performance-testen

Om de performance van de software te borgen kunnen performance-testen uitgevoerd worden. Het MTP beschrijft de gekozen aanpak; de eisen zijn vastgelegd in het NFE-document.

ICTU voert drie soorten performance-testen uit in de eigen testomgeving, die inzicht geven in de volgende facetten:
1. snelheid van handelingen en voldoen aan eisen (loadtest)
2. stabiliteit op langere termijn (duurtest)
3. schaalbaarheid en maximale belastbaarheid (stresstest).

De testen van ICTU kunnen geen uitsluitsel geven over de uiteindelijke performance in de productie-omgeving: ze geven niet meer dan een relatief resultaat ten opzichte van eerdere testen in dezelfde testomgeving. Toch hanteert ICTU ze als een standaard kwaliteitsmaatregel, vóór de oplevering van een nieuwe versie van de software. Want ze geven het inzicht of de performance voor wat betreft de software geen achteruitgang betekent ten opzichte van de bestaande situatie. De uiteindelijke performance in de productieomgeving dient de opdrachtgever zelf te laten testen.

Het ICTU-kwaliteitssysteem rapporteert over geautomatiseerde performance-testen uitgevoerd in de ontwikkelomgeving van ICTU. Als de verantwoordelijke tester performancerisico's ontdekt die ook aanwezig zijn in een versie van de software die reeds is opgeleverd, rapporteert de tester deze risico's aan het ontwikkelteam. Issues die voortkomen uit performance-testen worden opgenomen in Jira met het label "performance_bevinding".

## Security-testen

De eisen aan de beveiliging worden in de documenten projectstartarchitectuur en niet-functionele eisen gedefinieerd. De in te richten testen dienen aan te tonen dat aan de gestelde beveiligingseisen wordt voldaan.

De geautomatiseerde broncodereviews en rapportages uit het ICTU-kwaliteitssysteem bevatten diverse metrieken voor beveiligingsaspecten, zoals de OWASP top-10-criteria. De applicatie wordt gescand met behulp van Checkmarx, OWASP dependency checker, OWASP ZAP en OpenVAS.

Om de beveiliging van de software te testen kan deze met enige regelmaat getest worden door een externe partij. Het MTP beschrijft de gekozen aanpak.

Elke beveiligingstest resulteert in een beveiligingstestrapportage met daarin de aangetroffen beveiligingsissues. Issues die voortkomen uit deze testen worden opgenomen in Jira met het label "security_bevinding". Voor beveiligingsissues gelden de volgende oplostermijnen:

| Kwalificatie beveiligingsissue                    | Oplostermijn bij software die wel in productie is   | Oplostermijn bij software die niet in productie is |
|:--------------------------------------------------|:----------------------------------------------------|:---------------------------------------------------|
| Hoog (hoog risico en/of hoge impact)              | Zo snel mogelijk, resulteert in een bug fix release | Voor de eerste productierelease                    |
| Midden (gemiddeld risico en/of gemiddelde impact) | Voor de eerstvolgende major productierelease        | Voor de eerste productierelease                    |
| Laag (laag risico en lage impact)                 | In overleg met de product owner                     | In overleg met de product owner                    |

Het ICTU-kwaliteitssysteem rapporteert of gevonden beveiligingsissues niet te lang open staan.

Merk op: de beveiliging van de software in de acceptatie- en productieomgeving kan niet door ICTU getest worden. Deze test moet de opdrachtgever of de beheerpartij uitvoeren.

## Toegankelijkheidstesten

Om de toegankelijkheid van webapplicaties te testen gebruikt ICTU Axe; Axe is ingericht in de pijplijn. Het ICTU-kwaliteitssysteem rapporteert over de toegankelijkheidsrapportage van Axe. Daarnaast worden handmatige toegankelijkheidstesten uitgevoerd, door deskundige leden van het ontwikkelteam {of door externe deskundigen}. Het MTP beschrijft de gekozen aanpak voor het testen van WCAG-2.1-richtlijnen die niet geautomatiseerd kunnen worden getest.

## Usability-testen

{Verwijder deze paragraaf indien usability-testen niet van toepassing zijn}

Om de usability van de software te testen worden usability-testen uitgevoerd, door deskundige leden van het ontwikkelteam {of door externe deskundigen}. Het MTP beschrijft de gekozen aanpak.

Issues die voortkomen uit usability-testen worden opgenomen in Jira met het label "usability_bevinding".

## Technische schuld

Technische schuld zijn eigenschappen van de software die de lange-termijninzetbaarheid en onderhoudbaarheid van de software bedreigen; denk hierbij aan hoge complexiteit, lage testdekking, ontbrekende testsoorten en ontbrekende documentatie.

Als het ontwikkelteam of de kwaliteitsmanager constateert dat er technische schuld is, markeert de kwaliteitsmanager deze technische schuld in het kwaliteitssysteem als zodanig om te voorkomen dat de technische schuld ongemerkt verder toeneemt. Vervolgens vraagt de kwaliteitsmanager het team, in overleg met de software delivery manager en de Scrummaster, om de omvang van de technische schuld in te schatten in user-storypunten. Vervolgens wordt een plan gemaakt om de technische schuld in een beheerst tempo - de ontwikkeling/onderhoud van de software moet wel doorgang vinden - weg te werken. Uitgangspunt is ongeveer 10% van de user-storypunten die het team normaal in een sprint realiseert; dit kan in principe zonder overleg met de opdrachtgever, omdat het leveren van kwaliteit onderdeel van het werk is.

## Beheer

Ten behoeve van de beheerfase wordt gedurende de realisatiefase een implementatie- en beheerplan opgesteld. Hierin worden de kaders aangegeven op welke wijze het beheer ingericht, geïmplementeerd en beheerd wordt. Hierbij gaat de voorkeur uit naar beheer op basis van de principes van de DevOps-werkwijze.

{Dit kwaliteitsplan moet bijgewerkt worden indien meer informatie beschikbaar is over de werkwijze ten aanzien van implementatie en beheer.}

## Certificeringen

{Verwijder deze paragraaf indien certificeringen niet van toepassing zijn}

Een certificeringenplan wordt opgesteld indien het op te leveren systeem aan specifieke certificeringseisen moet voldoen. Dit plan bevat de activiteiten op welke wijze de certificatie wordt uitgevoerd. Eisen voor te behalen certificaten moeten in het PvE en/of NFE-document benoemd zijn; bijvoorbeeld ISO 127001 compliancy.

## Projectspecifieke maatregelen

{Verwijder deze paragraaf indien er geen projectspecifieke kwaliteitsmaatregelen nodig zijn}

Deze paragraaf bevat maatregelen voor functionele en niet-functionele eisen, die via de standaardmaatregelen uit de ICTU-kwaliteitsaanpak niet voldoende worden geborgd.

| Eis      | Omschrijving                                                           | Extra maatregelen                        | Hoe controleren         | Verificatie                                                       |
|:---------|:-----------------------------------------------------------------------|:-----------------------------------------|:------------------------|:------------------------------------------------------------------|
| {Nummer} | {voorbeeld: onderdeel A moet kunnen worden vervangen door onderdeel B} | {voorbeeld: scenariotest opnemen in MTP} | {voorbeeld: review MTP} | {voorbeeld: dd/mm/jjjj review MTP, test opgenomen in hoofdstuk x} |
| {Nummer} | {Omschrijving}                                                         | {Maatregelen}                            | {Controle}              | {Verificatie}                                                     |

# Kwaliteitsmaatregelen projectafsluiting

De kwaliteitsmanager controleert of de projectafsluiting conform de afspraken daarover in het plan van aanpak van de voorfase en/of de realisatiefase is uitgevoerd.
