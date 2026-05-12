# Azubi Einsatzplanungstool

Einsatzplanungstool der Auszubildenden der Investitionsbank Berlin

Abschlussprüfung Sommer 2024 Fachinformatiker für Anwendungsentwicklung

Dokumentation zur betrieblichen Projektarbeit

**Abgabedatum:** Berlin 04.06.2024

**Prüfungsbewerber:**  
Hanna Krusch  
Am Bogen 31  
13589 Berlin  

**Ausbildungsbetrieb:**  
Investitionsbank Berlin  
Bundesallee 210  
10719 Berlin

## Inhaltsverzeichnis
- [Abbildungsverzeichnis](#abbildungsverzeichnis)
- [Tabellenverzeichnis](#tabellenverzeichnis)
- [Glossar](#glossar)
- [1. Einleitung](#1-einleitung)
  - [1.1. Projektbeschreibung](#11-projektbeschreibung)
  - [1.2. Projektumfeld](#12-projektumfeld)
  - [1.3. Projektziel](#13-projektziel)
  - [1.4. Projektbegründung](#14-projektbegründung)
  - [1.5. Projektschnittstellen](#15-projektschnittstellen)
  - [1.6. Projektabgrenzung](#16-projektabgrenzung)
- [2. Projektplanung](#2-projektplanung)
  - [2.1. Projektphasen](#21-projektphasen)
  - [2.2. Abweichungen vom Projektantrag](#22-abweichungen-vom-projektantrag)
  - [2.3. Ressourcenplanung](#23-ressourcenplanung)
  - [2.4. Entwicklungsprozess](#24-entwicklungsprozess)
- [3. Analysephase](#3-analysephase)
  - [3.1. Ist-Analyse](#31-ist-analyse)
  - [3.2. Wirtschaftlichkeitsanalyse](#32-wirtschaftlichkeitsanalyse)
  - [3.3. Nutzwertanalyse](#33-nutzwertanalyse)
  - [3.4. Qualitätsanforderungen](#34-qualitätsanforderungen)
  - [3.5. Kundenanforderung](#35-kundenanforderung)
- [4. Entwurfsphase](#4-entwurfsphase)
  - [4.1. Zielplattform](#41-zielplattform)
  - [4.2. Architekturdesign](#42-architekturdesign)
  - [4.3. Datenschutz](#43-datenschutz)
  - [4.4. Entwurf der Benutzeroberfläche](#44-entwurf-der-benutzeroberfläche)
  - [4.5. Maßnahmen zur Qualitätssicherung](#45-maßnahmen-zur-qualitätssicherung)
- [5. Implementierungsphase](#5-implementierungsphase)
  - [5.1. Implementierung der Datenstrukturen](#51-implementierung-der-datenstrukturen)
  - [5.2. Implementierung der Benutzeroberfläche](#52-implementierung-der-benutzeroberfläche)
  - [5.3. Implementierung der Logik](#53-implementierung-der-logik)
- [6. Abnahmephase](#6-abnahmephase)
- [7. Dokumentation](#7-dokumentation)
- [8. Fazit](#8-fazit)
  - [8.1. Soll-/Ist-Vergleich](#81-soll-ist-vergleich)
  - [8.2. Lessons Learned](#82-lessons-learned)
  - [8.3. Ausblick](#83-ausblick)
- [Literaturverzeichnis](#literaturverzeichnis)
- [A Anhang](#a-anhang)
- [B Quellcode](#b-quellcode)

## Abbildungsverzeichnis
- [Funktionale Anforderungen](#kundenanforderung)
- [Benutzerrollen der Anwendung](#benutzerollen)
- [Zusammenfassung der Schutzbedarfsanalyse](#ad-hoc-schutzbedarfsanalyse)
- [Startseite-MockUp](#startseite-mockup)
- [Jahresansicht-MockUp](#jahresansicht-mockup)
- [Detailansicht-MockUp](#detailansicht-mockup)
- [ER-Diagramm Beziehungen](#datenbankmodell)
- [Benutzeroberfläche Gesamtansicht](#startseite)
- [Benutzeroberfläche Jahresansicht](#jahresansicht)
- [Benutzeroberfläche Detailansicht](#detailansicht)
- [Auszug aus der Entwicklerdokumentation](#dokumentation)
- Berechtigungsklasse
- Checkeinsatz-Methode der Einsatzklasse
- Methode für den Report aller Azubis der Exportklasse
- Importklasse und Methode zum Auslesen von Zeiträumen
- Initialisierung der Gesamtansicht
- Erstellen der Auszubildendenübersicht in der Gesamtansichtklasse Nr. 1
- Erstellen der Auszubildendenübersicht in der Gesamtansichtklasse Nr. 2
- Initialisierung der Jahresansicht
- Erstellen der Kalender in der Jahresansicht
- Auslesen des Einsatzes für die Bearbeitung in der Detailansicht
- Speichern eines neuen Einsatzes in der Detailansicht Nr. 1
- Speichern eines neuen Einsatzes in der Detailansicht Nr. 2
- Speichern eines neuen Einsatzes in der Detailansicht Nr. 3

## Tabellenverzeichnis
- [Tabelle 1: Grobe Zeitplanung](#tabelle-1-grobe-zeitplanung)
- [Tabelle 2: Kostenaufstellung](#tabelle-2-kostenaufstellung)
- [Tabelle 3: Prozesszeiten](#tabelle-3-prozesszeiten)
- [Tabelle 4: Nutzwertanalyse](#tabelle-4-nutzerwertanalyse)
- [Tabelle 5: Detaillierte Zeitplanung](#tabelle-5-detaillierte-zeitplanung)
- [Tabelle 6: Planung der Tests](#tabelle-6-planung-der-tests)

## Glossar
| Abkürzung | Bedeutung |
|-----------|------------|
| IBB       | Investitionsbank Berlin |
| PE        | Personal Abteilung |
| ABB       | Ausbildungsbeauftragter |
| ASP.NET   | Eine Web-Framework-Technologie von Microsoft |
| ER-Diagramm | Entity-Relationship-Diagramm, ein Datenbankmodell |
| NuGet-Paket | Ein Paket für die Verwaltung und den Austausch von Code in .NET |
| ClosedXML | Eine .NET-Bibliothek zum Arbeiten mit Excel-Dateien |
| SQL-Abfrage | Structured Query Language, eine Sprache zur Verwaltung von Datenbanken |
| OnClick-Event | Ein Ereignis, das auftritt, wenn auf ein Element geklickt wird |
| DropDown-Liste | Ein interaktives Element in der Benutzeroberfläche, welches eine Liste von Auswahlmöglichkeiten anzeigt |
| .aspx.cs | Eine Datei in ASP.NET, die serverseitigen Code für Webseiten enthält |
| Property | Eine Eigenschaft in der Programmierung, die den Zustand eines Objekts beschreibt |

# 1. Einleitung

## 1.1 Projektbeschreibung
Es soll im Rahmen des IHK-Abschlussprojekts ein Auszubildenden Einsatzplanungstool erstellt werden, welches die Einsatzplanung für den Ausbilder der Investitionsbank Berlin (IBB) vereinfachen, vereinheitlichen und übersichtlicher machen soll. Die Software soll die Einsatzplanung erleichtern, da die Berufszweige, Urlaube und andere Abwesenheiten der Azubis berücksichtigt werden können, weil diese von den Azubis selbst im Tool gepflegt werden. Außerdem soll für jeden Einsatzort ein automatisiertes Reporting erstellt werden können. Die gesamten Daten werden nicht mehr in einer Excel Tabelle gespeichert, sondern in einer zentralen Datenbank.

## 1.2 Projektumfeld
Die Investitionsbank Berlin ist die Förderbank des Landes Berlin. Es ist eine von 16 Landesförderinstituten und stehen nicht im Wettbewerb mit anderen Banken, sondern Arbeiten aktiv mit diesen zusammen.  Die IBB hat ungefähr 800 Mitarbeiter von denen ca. 100 in der IT tätig sind. Jedes Jahr bildet die IBB neue IT-Auszubildende aus und übernimmt diese. Für das Projekt sind die IT-Auszubildenden und die verschiedenen Einsatzorte in der IT von Bedeutung. Der Ausbildungsverantwortliche der Azubis muss die verschiedenen Einsätze planen und mit den anderen IT-Abteilungen abstimmen. Auf Wunsch des Ausbilders wird nun eine Einsatzplanungssoftware erstellt.

## 1.3 Projektziel
Das Hauptziel ist es, ein Tool zu entwickeln, welches die Einsatzplanung für den Ausbilder vereinfacht und effizienter gestaltet. Außerdem werden so die Einsatzpläne und deren Ansichten vereinheitlicht und übersichtlicher für die Auszubildenden und Ausbilder. Neben der Planung soll das Tool auch das Reporting effizienter gestalten, indem die Übersicht nicht mehr per Hand angefertigt werden muss, sondern automatisch auf Knopfdruck entsteht.

## 1.4 Projektbegründung
Die Entwicklung des Einsatzplanungstools für Auszubildende als Webanwendung ist aus der Notwendigkeit entstanden, ineffiziente und manuelle Planungs- und Reportingprozesse zu verbessern. Derzeitig sind die auf Excel basierenden Tabellen fehleranfällig, unübersichtlich und erfordern einen erheblichen Zeitaufwand beim Reporting. Durch die Einführung eines automatisierten Tools streben wir eine Reihe von Zielen an:
Das Hauptziel ist die Steigerung der Effizienz. Das automatisierte Tool ermöglicht eine schnelle und präzise Zuweisung von Einsätzen an Auszubildende. Zudem verbessert es die Transparenz und Nachvollziehbarkeit der Einsatzplanung, indem es allen Beteiligten eine klare Übersicht über Einsatzzeiten, Abwesenheiten und andere relevante Informationen bietet. Dies trägt zu einer besseren Kommunikation und Planungssicherheit bei. Darüber hinaus trägt die Automatisierung dazu bei, menschliche Fehler bei der Planung zu minimieren, was die Genauigkeit und Verlässlichkeit der Einsatzplanung erhöht. Schließlich führen die Zentralisierung und Automatisierung der Planungs- und Reportingprozesse zu einer erheblichen Zeitersparnis, die für andere wichtige Aufgaben genutzt werden kann.


## 1.5 Projektschnittstellen
Das Tool wird mit externen Datenquellen wie Kalendersystemen und Datenbank integriert, um automatisch Feiertage und individuelle Abwesenheiten der Auszubildenden zu berücksichtigen. Zudem werden Schnittstellen für Auszubildende und Ausbilder implementiert, die es diesen ermöglichen, ihre Abwesenheiten zu erfassen und zu verwalten, den Einsatzplan einzusehen. Des Weiteren ist der Austausch von Daten mittels automatisch erstellten Reportings für die Ausbildungsverantwortlichen oder Verwaltungsstellen, vorgesehen.

## 1.6 Projektabgrenzung
Das Tool wird keine vollständige Personalverwaltung umfassen, sondern sich auf die Einsatzplanung und Abwesenheitsverwaltung konzentrieren. Zudem ist die Integration von externen Systemen wie HR-Systemen nicht vorgesehen. Es werden keine individuellen Anpassungen für spezifische Berufszweige vorgenommen, sondern allgemeine Funktionen zur Einsatzplanung bereitgestellt. Darüber hinaus wird das Tool grundlegende Berichtsfunktionen für Ausbildungsverantwortliche bieten, jedoch keine komplexen Analysemöglichkeiten umfassen.

# 2. Projektplanung

## 2.1 Projektphasen
Das Projekt "Entwicklung eines Einsatzplanungstools für Azubis als Webapplikation" umfasst mehrere Phasen unter üblichen Büroarbeitszeiten der IBB wo die Rahmenarbeitszeit eine 38 Stunden Woche ist. Zunächst erfolgt eine Ist-Analyse der aktuellen manuellen Einsatzplanung der Auszubildenden, gefolgt von der Planung und dem Entwurf der Webanwendung. In dieser Phase werden Datenbankstrukturen definiert, Benutzerprofile entworfen und eine benutzerfreundliche Kalenderansicht gestaltet.
Die eigentliche Entwicklung beinhaltet die Implementierung von Benutzerprofilen, Authentifizierung, Datenbankanbindung und der gesamten ASP.NET-Anwendung mit Fokus auf einer intuitiven Oberflächengestaltung und Fehlerbehandlung. Ein automatisiertes Reporting für Ausbildungsbeauftragte wird ebenfalls integriert.
Nach der Entwicklung folgen umfangreiche Tests, um Fehler zu identifizieren und zu beheben. Die Projektdokumentation wird erstellt, um den gesamten Verlauf und die Funktionalitäten des Projekts dokumentiert.
##### Tabelle 1: Grobe Zeitplanung
| Projektphase          | Geplante Zeit |
|-----------------------|---------------|
| Analyse               | 10 h          |
| Planung und Entwurf   | 6 h           |
| Entwicklung           | 46 h          |
| Tests                 | 8 h           |
| Dokumentation         | 10 h          |

## 2.2 Abweichungen vom Projektantrag
Im Projektantragt wurden die folgenden Anforderungen definiert: 
- Personalisierte Benutzerprofile für Auszubildende (Turnus-Woche, Berufszweig) 
- Pflegemöglichkeiten für Ausbilder und Auszubildende 
- Automatische Eintragung von Feiertagen und Wochenenden. 
- Erfassung und Anzeige von Abwesenheiten, Berufsschulwochen, Prüfungen, Urlaub und Praxiseinsätzen. 
- Automatisiertes Erstellen von Reports für die Ausbildungsbeauftragen

Von diesen Anforderungen wurde die Erfassung von Abwesenheiten und Prüfungen nicht fristgerecht zum Projektabschluss umgesetzt. Außerdem hat sich während der Projekt Umsetzung eine neue Anforderung ergeben, sodass auch die Auszubildenden einen automatisierten Report von ihren Einsätzen erstellen können und nicht nur der Ausbildungsbeauftragte.

## 2.3 Ressourcenplanung
Für die Hardware werden Arbeitsplatzrechner für die Entwicklerin und die Tester sowie ein Server für das Hosting der Webanwendung benötigt. Die Software umfasst Tools wie Visual Studio für die Entwicklung in ASP.NET und C# und eine Access-Datenbank. Das Versionskontrollsystem TortoiseSVN wird ebenfalls benötigt.
Die Räumlichkeiten umfassen ein Büro für die Entwicklerin mit entsprechender Ausstattung sowie Büros für die Tester. 
Personelle Ressourcen umfassen verschiedene Rollen: einen Projektmanager zur Koordination des Projekts, Entwickler für Backend und Frontend, einen Datenbankadministrator für die Datenmodellierung und -implementierung, einen UI/UX-Designer für das Benutzererlebnis und Tester.

## 2.4 Entwicklungsprozess
In diesem Projekt wird agil gearbeitet, um die Flexibilität und Anpassungsfähigkeit zu bewahren. Die agile Methodik erlaubt es, das Projekt in kleinere, handhabbare Sprints zu unterteilen, wodurch kontinuierlich funktionsfähige Teile des Systems geliefert und direkt getestet werden können. Dies ermöglicht frühzeitiges Feedback und schnelle Anpassungen.
Die agile Vorgehensweise ermöglicht es, auf unvorhergesehene technische Herausforderungen flexibel zu reagieren und kontinuierlich Verbesserungen vorzunehmen. Dadurch wird das Projekt effizient abgeschlossen und eine benutzerfreundliche, hochwertige Webanwendung bereitgestellt werden.

# 3. Analysephase

## 3.1 Ist-Analyse
Derzeit erfolgt die Einsatzplanung für jeden der Auszubildenden noch manuell und aufwändig in einer unübersichtlichen Excel Tabelle. Die Auszubildenden müssen ihre Abwesenheiten, wie zum Beispiel Berufsschule oder Urlaub, manuell in ihre zugehörige Excel Tabelle eintragen. Um den zuständigen Ausbildungsbeauftragen jeder Abteilung eine Planung zu übermitteln, ist diese zurzeit noch von Hand vom Ausbilder zu erstellen. Außerdem kann die Urlausplanung der Azubis bei der Einsatzplanung und beim Reporting nur schwer berücksichtigt werden, da diese in einer anderen Excel Tabelle separat gepflegt wird. Die ganze Prozedur ist sehr Zeitintensiv und kann schnell unübersichtlich werden durch die vielen verschiedenen Tabellen.

## 3.2 Wirtschaftlichkeitsanalyse
### 3.2.1 Make- or Buy-Entscheidung
Basierend auf der Wirtschaftlichkeitsanalyse und den spezifischen Anforderungen des Unternehmens empfehlen wir die Entwicklung einer maßgeschneiderten Lösung (Make) für das Einsatzplanungstool für Azubis. Obwohl die Entwicklung mit höheren anfänglichen Investitionen und Risiken verbunden sein kann, bietet sie die Möglichkeit, eine Lösung zu schaffen, die genau auf die Bedürfnisse des Unternehmens zugeschnitten ist und langfristig Skalierbarkeit und Flexibilität bietet.

### 3.2.2 Projektkosten
Die Kosten des Projekts setzen sich aus Personal- und Ressourcenkosten zusammen. Laut Tarifvertrag für Beschäftigte in öffentlichen Banken verdient ein Auszubildender ab August 2022 im dritten Ausbildungsjahr 1.270€ brutto pro Monat.
Ein Auszubildender im dritten Lehrjahr in der IBB bekommt ca. 8,43€ pro Stunde. Für weitere Mitarbeiter in der IBB wird ein Kostensatz von 139.759,55€ pro Jahr berechnet. In diesem Kostensatz sind schon die Ressourcen wie Räumlichkeit, Hardware und Strom miteinkalkuliert. Der vorgegebene Stundensatz in der IBB für 2024 ist 83,21€.
##### Tabelle 2: Kostenaufstellung
| Vorgang        | Zeit in h | Kosten pro h | Kosten     |
|----------------|-----------|--------------|------------|
| Entwicklung    | 80h       | 8,43 €       | 674,40 €   |
| Fachgespräch   | 3h        | 83,21 €      | 249,63 €   |
| Abnahme        | 1h        | 83,21 €      | 83,21 €    |
|                |           |              | **1.007,24 €** |

### 3.2.3 Amortisationsdauer
Die Amortisationsdauer dient dazu den Zeitraum zu ermitteln, den eine Investition in ein Projekt oder ein Produkt benötigt bis ihre Kosten wieder ausgeglichen werden. Für den Stundenlohn des Anwenders (den Ausbilder) wird wieder der vorgegebene Stundensatz der IBB genommen
##### Tabelle 3: Prozesszeiten
| Prozessschritt                                       | Dauer Vorher | Dauer Nachher | Häufigkeit im Jahr |
|------------------------------------------------------|--------------|---------------|--------------------|
| Abstimmung und Report für die Abteilungen            | 38h          | 30h           | 2 mal              |
| Eine Planung erstellen                               | 1,5h         | 1h            | 2 mal              |
| Anpassung der Planung an die Auszubildenden          | 76h          | 65h           | 1 mal              |
| Abstimmung und Weitergabe der Planung an PE und ABBs | 7,6h         | 7,6h          | 3 mal              |
| Abgleich der detaillierten Ausbildungsziele          | 152h         | 152h          | 1 mal              |
| **Gesamt**                                           | **329,8h**   | **301,8h**    |                    |

gesparte Zeit=329,8h-301,8=28h

Die Zeitersparnis des Projekts beläuft sich auf 28h pro Jahr.

gespartes Geld=28h*83,21€=2.329,88€

Pro Jahr würde man mit den gesparten Stunden auch 2.329,88€ einsparen.

Amortisationsdauer=1007,24/2.329,88 €=0,43 Jahre 

Die Amortisation beläuft sich auf weniger als ein halbes Jahr.


## 3.3 Nutzwertanalyse
Da Planday  und Deputy  hauptsächlich als Schichtenplaner und eher für Unternehmensweite Nutzung erstellt wurden, haben die beiden Lösungen viele Funktionen die für die Erfüllung dieses Projekts nicht benötigt werden würden, wie zum Beispiel: Schichtenplanung, Analysen des Sales, Kommunikationsmöglichkeiten für Teams und Zeiterfassung. Sie sind daher zu umfangreich für die Ziele die das Projekt definiert hat.
##### Tabelle 4: Nutzwertanalyse
| Nr. | Kriterium        | Gewichtung | Eigenentwicklung | Punkte | Planday | Punkte | Deputy | Punkte |
|-----|------------------|------------|------------------|--------|---------|--------|--------|--------|
|     |                  |            | Wertung          | Punkte | Wertung | Punkte | Wertung | Punkte |
| 1   | Kosten           | 30         | 3                | 90     | 2       | 60     | 1      | 30     |
| 2   | Usability        | 30         | 3                | 90     | 1       | 30     | 2      | 60     |
| 3   | Maintainability  | 20         | 3                | 60     | 2       | 40     | 1      | 20     |
| 4   | Zeitrahmen       | 20         | 3                | 60     | 3       | 60     | 3      | 60     |
|     | **Nutzwert**     | **100**    |                  | **300**|         | **190**|        | **170**|

## 3.4 Qualitätsanforderungen
Zunächst ist die Benutzerfreundlichkeit von großer Bedeutung. Die Benutzeroberfläche sollte intuitiv gestaltet sein, sodass Auszubildende und Ausbilder die Funktionen leicht verstehen und nutzen können. Klare Anweisungen, einfache Navigation und eine übersichtliche Darstellung der Daten sind hierbei entscheidend. Die Skalierbarkeit des Einsatzplanungstools ist ein weiterer wichtiger Faktor. Die Anwendung sollte in der Lage sein, mit einem wachsenden Benutzerstamm und steigenden Datenmengen umzugehen, ohne dass die Leistung darunter leidet. Die Wartbarkeit der Anwendung spielt eine Rolle für langfristigen Erfolg und Erweiterbarkeit. Gut strukturierter und dokumentierter Code erleichtert zukünftige Anpassungen und Erweiterungen der Anwendung. Des Weiteren sollte die Anwendung auf dem Standard Browser der IBB ohne Probleme funktionsfähig sein, um eine breite Benutzerbasis zu erreichen.

## 3.5 Kundenanforderung
Die Kundenanforderungen, die während des Gesprächs mit dem Auftraggeber, dem Ausbilder, entstanden sind, sind unter Abbildung 1: Funktionale Anforderungen definiert. Dabei ist ersichtlich, dass viel Wert auf die Benutzerrollen gelegt wird, welche unter Abbildung 2: Benutzerrollen der Anwendung zu finden sind. Darauf ist zusehen, dass der Admin beziehungsweise der Ausbilder alle Funktionen nutzen kann und alle Einsätze und Urlaube bearbeiten darf. Der Auszubildende hat daher nur eingeschränkte Funktionen. Dieser darf nur seinen und freigegeben Kalender sehen und nur die Urlaube bearbeiten.

# 4. Entwurfsphase

## 4.1 Zielplattform
Für die Entwicklung des Einsatzplanungstools für Auszubildende wird die Programmiersprache C# auf der ASP.NET-Plattform gewählt. Als Datenbanklösung wird Microsoft SQL Server verwendet. Das Tool wird als Webanwendung im Client/Server-Modell entwickelt, was eine zentrale Datenverwaltung, einfache Wartung und flexible Zugänglichkeit von verschiedenen Standorten aus ermöglicht. Auf der Client-Seite ist lediglich ein moderner Webbrowser und eine stabile Internetverbindung notwendig. Diese Plattformwahl gewährleistet eine robuste, skalierbare und sichere Lösung für die effiziente Einsatzplanung der Auszubildenden.

## 4.2 Architekturdesign
Die gewählte Anwendungsarchitektur für das Einsatzplanungstool ist eine Client/Server-Architektur, umgesetzt als Webanwendung mit ASP.NET .NET-Framework. Diese zentrale Architektur ermöglicht eine einfache Verwaltung und Sicherung der Daten auf dem Server, was konsistente und sichere Daten gewährleistet. Die zentrale Struktur erleichtert auch Wartung und Updates, die ohne Eingriffe auf Client-Geräten durchgeführt werden können, wodurch der administrative Aufwand reduziert wird und alle Benutzer stets die aktuelle Version der Software nutzen.
Die Webanwendung bietet hohe Flexibilität und Zugänglichkeit, da Benutzer von verschiedenen Standorten und Geräten aus auf die Anwendung zugreifen können. Zudem ist die Architektur skalierbar, sodass die Anwendung und die Datenbank bei steigenden Anforderungen problemlos erweitert werden können, um eine nachhaltige Leistungsfähigkeit sicherzustellen.


## 4.3 Datenschutz
Im Rahmen der Schutzbedarfsanalyse für die Web-Anwendung wurden spezifische Schutzbedarfsstufen für die Bereiche Vertraulichkeit, Integrität/Authentizität und Verfügbarkeit ermittelt. Dabei ergab sich eine Schutzbedarfseinstufung von 2 für Vertraulichkeit und Verfügbarkeit, was auf eine erhöhte Sensibilität und Notwendigkeit besonderer Schutzmaßnahmen hinweist. Die Integrität und Authentizität wurde mit einer Schutzbedarfseinstufung von 1 bewertet, was eine mittlere Sensibilität darstellt. Um den Schutz der Daten zu gewährleisten, muss eine Art von Berechtigungssystem erschaffen werden, bei dem andere IBB-Mitarbeiter oder Auszubildenden nicht ohne Freigabe die Einsatzplanung der einzelnen Auszubildenden einsehen können. Abbildung 3: Zusammenfassung der Schutzbedarfsanalyse

## 4.4 Entwurf der Benutzeroberfläche
Da das Projekt als Webanwendung realisiert werden soll, wurde ein Webinterface als Benutzeroberfläche gewählt. Dabei ist die „Startseite“ eine Liste der gesamten Auszubildenden. Als Seitenkopf ist immer eine Auswahl zusehen die jederzeit zur Verfügung steht. In der Auswahl kann man zwischen der Ansicht von allen Auszubildenden, den neu Kommenden, dem ersten, zweiten und dritten Lehrjahr wählen. Am rechten oberen Rand sind die gewünschten Import- und Export-Buttons. Abbildung 4: Startseite-MockUp
Bei dem Klick auf einen der Auszubildenden, erscheint eine Übersicht der gesamten Ausbildungszeit, wobei diese nach den Jahren eingeteilt ist und darunter die einzelnen Monate zu sehen sind. Hinter den Monaten steht in Klammern welcher Einsatzort in dieser Zeit geplant ist. In dieser Übersicht kann man auch eine grobe Einsatzplanung machen, da über der tabellarischen Übersicht eine Dropdown-Liste und ein Speicher-Button verbaut sind. Abbildung 5: Jahresansicht-MockUp
Wenn nun auf eines der Verfügbaren Jahren geklickt wird, öffnet sich eine Detailansicht des entsprechenden Jahres. Das Jahr, sowie zwei Buttons die zum vorherigen und nächsten Jahr führen, stehen über der detaillierten Ansicht. In dieser kann man die einzelnen Berufsschulwochen, Urlaub und auch Einsätze sehen. Neben dem Kalender ist eine kleine Informationsspalte, in der alle Informationen zum Auszubildenden sowie zum Kalender (Farblegende) stehen. Zwischen den beiden Informationsblöcken gibt es eine Auswahl zum Speichern und löschen von Einsätzen sowie Urlaub. Abbildung 6: Detailansicht-MockUp

## 4.5 Maßnahmen zur Qualitätssicherung
Um die Qualitätsanforderungen zu erfüllen, werden Benutzerakzeptanztests mit einigen der zukünftigen User durchgeführt, um die intuitive und leichte Bedienung zu gewährleisten. Dafür werden verschiedene Testfälle für die Funktionen geschrieben und den Usern zum Testen bereitgestellt. 
Dabei wird beobachtet, ob durch die steigenden Datenmengen die Leistung abnimmt und es zu nicht akzeptablen Wartezeiten kommt. Dafür wird in Visual Studio beim Starten der Anwendung und Testen der einzelnen Funktionen vom Entwickler auf den Prozessspeicher und die Auslastung der CPU geachtet.
Als nächstes wird den Testern nahegelegt, Feedback zur Anwendung zu äußern um die kontinuierliche Verbesserung zu gewährleisten und die Anwendung stetig zu optimieren. Dabei spielt auch die Wartbarkeit der Anwendung eine große Rolle. Denn um die kontinuierliche Verbesserung durchzuführen, muss der Code gut kommentiert und verständlich sein. Um das sicherzustellen, wird der Entwickler beim Programmieren und auch danach den Code so kommentieren, dass jede Methode verständlich für andere Personen ist. Außerdem wird eine Entwicklerdokumentation verfasst um für spätere Verbesserungsmaßnahmen einen leichten und schnellen Einstieg zu gewährleisten.

# 5. Implementierungsphase

## 5.1 Implementierung der Datenstrukturen
Die verwendete Datenbank ist eine Access-Datenbank mit dem Access 2007 – 2016 Dateiformat, dessen Tabellen händisch erzeugt worden sind mit der Benutzeroberfläche von Access, aber die verwendeten Daten werden über die Anwendung mit SQL-Befehlen eingepflegt. Die Datenbank besteht aus neun Tabellen: 
- Einsatz: Hier werden die Einsatzdaten von Auszubildenden erfasst, inklusive des Anfangs- und Enddatums sowie der zugehörigen Abteilung und des Auszubildenden.
- Abteilung: Hier werden die Abteilungen der Ausbildungsstätte mit einer eindeutigen ID und einem Kürzel für den Auszubildenden festgehalten. Zusätzlich wird das Kürzel des Ausbildungsbeauftragten gespeichert.
- Ausbildungsbeauftragter: Diese Tabelle enthält die persönlichen Daten des Ausbildungsbeauftragten, wie Name und Vorname.
- Berechtigung: Hier werden die Berechtigungen des Auszubildenden erfasst. Dazu gehört das Kürzel des Auszubildenden, der Ausbildenden und die zugehörigen Daten.
- Auszubildender: Die Tabelle beschreibt den Auszubildenden. Sie enthält sein Kürzel, seinen Namen, Vornamen, Jahrgang, Fachrichtung und Turnus.
- Urlaub: Hier werden Urlaubstage mit Anfangs- und Enddatum sowie dem Kürzel des Auszubildenden gespeichert.
- Brückentag: Diese Tabelle verwaltet die Brückentage mit Anfangs- und Enddatum und der Bezeichnung.
- Ferien: Ferientage werden hier mit Anfangs- und Enddatum sowie der Bezeichnung gespeichert.
- Berufsschule: Die Berufsschule wird mit Anfangs- und Enddatum und der Bezeichnung abgebildet.

## 5.2 Implementierung der Benutzeroberfläche
Bei der Implementierung der Benutzeroberfläche wurde sich an die zuvor erstellten MockUps orientiert. Die Oberflächen wurden hauptsächlich mit dynamischen HTML-Elementen gearbeitet, damit sich die Elemente dynamisch und automatisch an die Datenmengen anpassen können. Dafür wurden hauptsächlich dynamische Tabellen, Dropdown-Listen, TextBoxen, Buttons und Labels verwendet. Bei der Farbgebung wurde sich am Corporate Design orientiert und die vorgegebenen Farben des Logos, Sekundärfarben und Tertiärfarben wurden verwendet. Häufig für die Tabellenköpfe oder auch für die Farblegende eines Kalenders.
Es gibt drei verschiedene Oberflächen die erstellt wurden: Die „Startseite“ – die Seite wo alle Auszubildenden aufgelistet sind und man auswählen kann welches Lehrjahr man anzeigt bekommen möchte. Siehe Abbildung 8: Benutzeroberfläche Gesamtansicht
Die Jahresansicht ist die Darstellung von allen Ausbildungsjahren, nach normalem Durchlaufen, und den dazugehörigen Monaten der Jahre. Siehe Abbildung 9: Benutzeroberfläche Jahresansicht
Und zum Schluss die Detailansicht, welche sich über die Jahresanzeige in der Jahresansicht erreichen lässt. In die Detailansicht wird für das ausgewählte Jahr alle Einsätze, Urlaube und Berufsschultage angezeigt. Siehe Abbildung 10: Benutzeroberfläche Detailansicht


## 5.3 Implementierung der Logik
Die Implementierung der Logik erfolgte für jede Benutzeroberfläche separat, da die verschiedenen Ansichten unterschiedliche Anforderungen und Darstellungen benötigten. Neben den Klassen die für die Darstellung und Logik der Benutzeroberflächen zuständig waren, gibt es noch unterstützende Klassen die die Logiken sauberer und Übersichtlicher halten soll, indem einige wiederkehrende Methoden ausgelagert wurden. Insgesamt hab es sieben Klassen die für die Logik implementiert wurden. 

### 5.3.1.	Einsatz-Klasse
Die Einsatz-Klasse war zuständig um die verschiedenen Einsätze besser überprüfen und zu löschen können. Wenn man ein Objekt der Klasse erzeugt, dann kann man mittels Datenbank Zugriff überprüfen, ob an diesem Tag ein anderer Einsatz stattfindet. Diese Methode ist besonders wichtig um zu überprüfen, ob neue Einsatzzeiträume gespeichert werden dürfen oder nicht. Außerdem kann diese Klasse auch den Einsatz aus der Datenbank löschen, wenn das Datum des Einsatztages zwischen das Anfangs- und Enddatum eines der Einsätze/Urlaube fällt.

### 5.3.2.	Berechtigungsklasse
Die nächste unterstützende Klasse ist die Berechtigungsklasse. Objekte dieser Klasse können nur überprüfen, ob der User die Rechte hat auf bestimmte Kalender einzusehen. Dafür wird das Kürzel des Auszubildenden auf dessen Kalender zugegriffen werden soll und die User-ID in der Datenbank abgefragt. Der Ausbilder der Auszubildenden darf alle Kalender einsehen. Seine User-ID wurde als Property in der Anwendung hinterlegt.

### 5.3.3.	Export- & Import-Klasse
Für die Export-Klasse und die Import-Klasse wurde aus der Paketquelle „IBB-Feed“ das NuGet-Paket ClosedXML installiert.  Welches es ermöglicht Excel Dateien zu lesen und zu erstellen. Die Export-Klasse erstellt die Reporte für die Ausbildungsverantwortlichen in den verschiedenen Abteilungen. Eine Methode gibt die Einsätze aller Auszubildenden aus und eine weitere nur die eines Einzelnen. Dafür werden alle gespeicherten Einsätze ausgelesen und dann werden die Einsätze für das derzeitige und das nächste Jahr in die Excel Datei ausgegeben. Diese Excel Datei wird dann auf dem Server in einem Exportordner gespeichert. 
Bei der Import-Klasse werden Daten wie Berufsschultage, Ferien und Brückentage importiert. Da es ziemlich aufwendig ist, diese Daten einzeln in die Datenbank zu schreiben, wurde eine Excel Vorlage erstellt in der die Daten stehen. Man kann diese Daten mit zwei verfügbaren Methoden auslesen. Bei beiden Methoden muss man jedoch die Startzeile, Startspalte und die nötige Tabelle in der Datenbank angeben. Die eine Methode liest die Daten eines Zeitraums ein und speichert diese in der zugehörigen Tabelle und die andere liest nur einen Tag ein und speichert diesen.

### 5.3.4.	Gesamtansicht
Als nächstes die GesamtAnsicht.aspx.cs Klasse: Diese Klasse ist die zusammenhängende Klasse für die Startseitenansicht. Bei der Initialisierung der Startseite wird zuerst die Ansicht der Auszubildenden erzeugt. Je nachdem welche Zahl übergeben wurde, wird eine bestimme SQL-Abfrage erzeugt. Danach werden dann einfach die Daten dargestellt. Eine Zahl wird bei der Adresse nur mit übergeben, wenn vorher ein Lehrjahr von der Benutzeroberfläche ausgewählt wurde. Wenn keine Zahl übergeben wurde, dann werden alle Auszubildenden geladen. 
Während diese geladen werden, werden sie mit einem OnClick-Event hinterlegt, die sie zur Jahresansicht weiterleitet und dabei übergibt die Adresse den ausgewählten Auszubildenden. Als nächstes wird bei der Initialisierung abgefragt, ob die User-ID des Users, der gerade die Anwendung offen hat, mit der ID des Admins übereinstimmt. Falls sie nicht übereinstimmen, wird der Import- und Exportbutton deaktiviert.

### 5.3.5.	Jahresansicht
In der Jahresansicht.aspx.cs wird zuerst überprüft, ob ein Auszubildendenkürzel in der Adresse übergeben wurde, falls nicht wird man wieder auf die Startseite geleitet. Als nächstes wird überprüft, ob der User überhaupt auf den Kalender zugreifen darf. Das wird mittels der Berechtigungsklasse abgefragt und falls die Rechte nicht vorhanden sind, wird ein Label aktiviert, welches bestätigt, dass man keine Rechte für diesen Kalender hat. Andernfalls werden die Auszubildendendaten aus der Datenbank geladen und die Fachbereiche werden in die Dropdown-Liste geschrieben, falls ein Admin den Kalender aufruft. 
In der Methode in der die Auszubildendendaten geladen werden, wird zum Schluss noch der Kalender generiert. Die aufgerufene Methode erstellt für jedes Lehrjahr eine Spalte mit den Monaten des Jahres. Jeder Monat erhält eine Checkbox zum Speichern von Einsätzen für den Ausbilder. Hinter den Monaten werden die zu der Zeit stattfinden Abteilungseinsätze des Auszubildenden geschrieben. Dafür wird zuerst eine Liste erstellt mit allen Einsätzen des Auszubildenden die in der Datenbank gespeichert sind. Danach wird diese Liste für jeden Monat durchgegangen und überprüft, ob ein Einsatz in der Liste mit dem derzeitigen Monat und Jahr übereinstimmt. Wenn das der Fall ist wird der Einsatz zu diesem Monat geschrieben. Wenn nun der Ausbilder für einige Monate einen neuen Einsatz grob planen möchte, dann kann er die Monate mittels Checkboxen auswählen, die Abteilung festlegen und auf speichern klicken. Falls die Abteilung leer bleibt, werden alle Einsätze die in diesem Zeitraum stattfinden gelöscht. Zuerst wird das Startdatum ermittelt. Dafür werden alle angeklickten Monate durchgegangen und der jeweils kleinste und größte Monat werden gespeichert. Anschließend wird überprüft, ob in diesem Zeitraum schon ein Einsatz geplant ist, denn dann wird eine Fehlermeldung erscheinen. Wenn der Zeitraum noch frei ist, dann wird der Einsatz mit dem Anfangs-, Enddatum und der Abteilung für diesen Auszubildenden gespeichert.

### 5.3.6.	Detailansicht
Wenn in der Jahresansicht auf eins der verfügbaren Jahre geklickt wird, dann wird man zu der Detailansicht des in der Adresse übergebenen Jahres weitergeleitet. Dort wird bei der Initialisierung auch zuerst überprüft, ob die benötigten Parameter in der Adresse übergeben worden sind. Wenn diese vorhanden sind, dann werden wieder zuerst die Daten des Auszubildenden ausgelesen und dargestellt. 
Dabei wird dann auch der Kalender erzeugt wo alle Einträge mit verschiedenen Farben angezeigt werden. Dafür werden verschiedene Listen erstellt, die dann während der Erstellung des Kalenders durchgegangen werden und für jeden Eintrag in den Listen der zugehörige Text und Farbe dem Tag zugewiesen werden. Dabei bekommen die Urlaube und Einsätze noch ein OnClick-Event. Die Liste der Feiertage ist schon im Code programmiert, da die meisten Tage davon entweder feste Feiertage sind oder sich berechnen lassen. Um die zu berechnenden Feiertage zu ermitteln, wurde zuerst Ostersonntag mit einer Rechenmethode  berechnet. Somit konnte dann nur mit hinzufügen oder abziehen von Tagen der Rest der Feiertage ermittelt werden. 
Sobald das abgeschlossen ist, werden auch das Abteilungsdropdown und die Legende erstellt. In der Detailansicht kann man auch Monate mit Checkboxen auswählen. Die funktionieren genauso wie in der Jahresansicht. Außerdem kann man auch mittels TextBoxen ein Start-, Enddatum und Abteilung auswählen um neue Einsätze oder Urlaube zu speichern. Das hängt aber je nach Berechtigungen ab, denn nur der Ausbilder kann die Einsätze bearbeiten und speichern. Währenddessen die Auszubildenden nur ihre Urlaube bearbeiten und speichern können. 
Wenn ein neuer Einsatz oder Urlaub gespeichert werden soll, wird wieder überprüft, ob zu dieser Zeit schon etwas Anderes geplant ist, wie in der Jahresansicht. Außerdem kann man wieder einen Zeitraum auswählen, entweder mit selbsteingetragenen Datumangaben oder mit den Checkboxen, und die Abteilung leer lassen, dann wird wie in der Jahresansicht auch alle Einsätze die zu der Zeit geplant sind aus der Datenbank gelöscht. 
 
Sobald ein Einsatz oder Urlaub bearbeitet werden soll, dann kann man einfach auf den Tag drücken und das OnClick-Event wird aktiviert. Diese Methode bekommt dann die ID des Linkbuttons auf den geklickt wurde und kann somit die ID des Eintrags bestimmen. Dieser Eintrag wird dann ausgelesen und das Anfangs-, Enddatum und Abteilung werden in die TextBoxen und Dropdown-Liste geschrieben. Außerdem wird ein neuer Button sichtbar der nur für Speicherung von Änderungen vorhanden ist. Dieser speichert dann die Änderungen. In der Datenbank und überprüft vorher, welche Änderungen gespeichert werden müssen. Denn wenn ein Abteilungseinsatz zu Urlaub verändert wird, dann muss der Eintrag vorher aus der Einsatz-Tabelle gelöscht werden und neu in der Urlaubstabelle gespeichert werden.


# 6. Abnahmephase
Für die Abnahme wurden Tests mit den zukünftigen Anwendern durchgeführt. Dafür wurden zwei Auszubildende und der Ausbilder gefragt an diesen Tests teilzunehmen. Es wurden verschiedene Tests, zugeschnitten auf Auszubildender und Ausbilder, erstellt. Diese sind unter Tabelle 6: Planung der Tests nachzuvollziehen. Wie man auch aus der Tabelle entnehmen kann, wurden die Tests des Ausbilders noch nicht erfolgreich zurückgereicht, da seine Tests noch nicht erfolgreich abgeschlossen worden sind und daher das Projekt noch nicht den Kundenanforderungen entspricht. Es müssen noch einige kleinere Funktionen nachgerüstet werden um die Benutzerfreundlichkeit und die Usererfahrung weiter auszubauen. Daher fand noch keine offizielle Abnahme des Projekts statt.

# 7. Dokumentation
Da das Projekt voraussichtlich weiter als Auszubildenden-Projekt angesehen und vielleicht durch die zukünftigen Auszubildenden noch erweitert und ausgebaut wird, wurde deshalb eine Entwicklerdokumentation erstellt, um den Einstieg und spätere Erweiterungen zu erleichtern, da dort die Abhängigkeiten Stichpunktartig dokumentiert worden sind. Abbildung 11: Auszug aus der Entwicklerdokumentation

# 8. Fazit

## 8.1 Soll-/Ist-Vergleich
Das Projekt zielte darauf ab, eine Web-Anwendung zu entwickeln, das die Einsatzplanung für den Ausbilder vereinfacht und effizienter gestaltet. Dafür sollten personalisierte Benutzerprofile für Auszubildende erstellt werden, die Informationen wie Turnus-Wochen und Fachrichtung enthalten. Ausbilder und Auszubildende sollten Pflegemöglichkeiten für ihre Daten haben und die Anwendung sollte außerdem Feiertage und Wochenenden automatisch eintragen. Zudem sollte das Tool die Erfassung und Anzeige von Abwesenheiten, Berufsschulwochen, Prüfungen, Urlaub und Praxiseinsätzen ermöglichen. Ein weiteres Ziel war die automatisierte Erstellung von Reports für die Ausbildungsbeauftragten.
Die Web-Anwendung zur Einsatzplanung wurde erfolgreich entwickelt und bietet eine übersichtliche Benutzeroberfläche. Die Benutzerprofile für Auszubildende, inklusive Informationen zu Turnus-Wochen und Berufszweigen, wurden implementiert und werden bei der Darstellung der Berufsschulwochen berücksichtigt. Sowohl Ausbilder als auch Auszubildende können ihre Daten pflegen. Feiertage und Wochenenden werden automatisch eingetragen. Die Erfassung und Anzeige von Abwesenheiten und Prüfungen konnte jedoch nicht fristgerecht umgesetzt werden. Die automatische Erstellung von Reports für die Ausbildungsbeauftragten wurde erfolgreich realisiert. Darüber hinaus wurde die Funktionalität erweitert, sodass nun auch Auszubildende ihre Einsatzberichte automatisiert erstellen können.


## 8.2 Lessons Learned
Während der Projektdurchführung wurden die Erkenntnisse zum Priorisieren von Funktionen und Anforderungen gewonnen, da die Zeit sehr begrenzt war und nicht jede Anforderung so umgesetzt werden kann, wie sie definiert worden war. Des Weiteren war die Erfahrung Tests zu organisieren und das Projekt eigenständig zu managen auch sehr hilfreich für die zukünftige Laufbahn der Autorin.

## 8.3 Ausblick
Neben dem Feedback welches die Auszubildenden beim Testen geäußert haben, werden noch die nicht umgesetzten Anforderungen vom Kunden umgesetzt, sodass die Auszubildenden auch andere Abwesenheiten (Prüfungen oder Sonstiges) eintragen können. Außerdem soll noch das Speichern und Löschen der Einsätze verfeinert werden, damit nicht immer die Einsätze, sondern wenn gewünscht nur der Monat geleert wird. Oder bei der Auswahl der Einsatzzeiten man keine Monate bei der Auswahl mehr leer lassen kann und dieser Zeitraum trotzdem berücksichtigt wird bei der Speicherung.
Das Feedback der Auszubildenden waren Punkte wie zum Beispiel: 
- bei der Filterung nach den Lehrjahren, dass das ausgewählte Lehrjahr angezeigt wird
- bei dem Eintragen der Daten für einen neuen Eintrag soll man zukünftig nur Daten angeben die im Ausbildungszeitraum stattfinden.


# Literaturverzeichnis
- Deputy. (13. Mai 2024). Von https://www.deputy.com/ abgerufen
- Hans, T. (08. Mai 2024). Dot.Net Snippets. Von https://dotnet-snippets.de/snippet/ermittlung-von-feiertagen-feiertaglogic/763 abgerufen
- Investitionsbank Berlin. (02. Mai 2024). Von https://www.ibb.de/de/ueber-uns/die-ibb/die-ibb.html abgerufen
- Planday. (13. Mai 2024). Von https://www.planday.com/de/ abgerufen

# A Anhang
## Detaillierte Zeitplanung
##### Tabelle 5: Detaillierte Zeitplanung
| Projektphase    | Zeit | Teilaufgabe                                                            | Zeit |
|-----------------|------|-----------------------------------------------------------------------|------|
| Analyse         | 10 h | Ist-Analyse durchführen (Systeme und Schnittstellen evaluieren)       | 1 h  |
|                 |      | Analyse und Dokumentation des Planungsprozesses                        | 2 h  |
|                 |      | Kostenplanung und Projektkalkulation                                   | 2 h  |
|                 |      | Definition Use-Cases                                                   | 2 h  |
|                 |      | Erstellung eines Lastenheftes                                          | 3 h  |
| Planung und Entwurf | 6 h | ER-Diagramm                                                      | 1 h  |
|                 |      | Definition der Benutzerprofile und ihrer Berechtigungen.               | 1,5 h|
|                 |      | Entwurf einer übersichtlichen Kalenderansicht.                         | 0,5 h|
|                 |      | Pflichtenheft anlegen                                                  | 3 h  |
| Entwicklung     | 46 h | Implementierung der Benutzerprofile und Authentifizierung              | 4 h  |
|                 |      | Erstellung Datenbank                                                   | 3 h  |
|                 |      | Webanwendung erstellen                                                 | 36 h |
|                 |      | - Erstellung Oberfläche (Kalender & Pflegemasken)                      | 14 h |
|                 |      | - Erstellung Datenbankzugriffe                                         | 14 h |
|                 |      | - Erstellung Fehlerhandling                                            | 8 h  |
|                 |      | Erstellen des Reportings                                               | 3 h  |
| Tests           | 8 h  | Blackbox-Test durch Kollegen                                           | 3 h  |
|                 |      | Testevaluation, Fehlerbehebung                                         | 5 h  |
| Dokumentation   | 10 h | Erstellen der Entwicklerdokumentation                                  | 1 h  |
|                 |      | Fertigstellen der Projektdokumentation                                 | 9 h  |

## Kundenanforderung
![Kundenanforderung](Anhänge/Kundenanforderungen/Funktionale%20Anforderungen.PNG)

## Benutzerrollen
![Benutzerrollen](Anhänge/Kundenanforderungen/Benutzerrollen.PNG)

## Ad-hoc Schutzbedarfsanalyse
![Schutzbedarfsanalyse](Anhänge/Schutzbedarf/SBA_Auswertung.png)

## MockUps
##### Startseite Mockup
![Gesamtansicht](Anhänge/MockUp/AlleAzubisMockUp.PNG)
##### Jahresansicht Mockup
![Jahresansicht](Anhänge/MockUp/JahresAnsichtMockUp.PNG)
##### Detailansicht Mockup
![Detailansicht](Anhänge/MockUp/DetailAnsichtMockUp.PNG)

## Datenbankmodell
![Datenbankenmodell Beziehungen](Anhänge/Datenbank/ER-Diagramm_Datenbank.png)

## Benutzeroberfläche
##### Startseite
![Gesamtansicht](Anhänge/HTML/GesamtAnsichtServer.PNG)
##### Jahresansicht
![Jahresansicht](Anhänge/HTML/JahresAnsichtServer.PNG)
##### Detailansicht
![Detailansicht](Anhänge/HTML/DetailansichtServer.PNG)

## Planung der Tests
##### Tabelle 6: Planung der Tests
| Test                                   | Auszubildender 1 | Auszubildender 2 | Ausbilder |
|----------------------------------------|-------------------|-------------------|-----------|
| 1_Aufrufen der Startseite             | Erfolgreich      | Erfolgreich      |           |
| 2_Zugriff auf die Jahresansicht_Azubi | Erfolgreich      | Erfolgreich      |           |
| 2_Zugriff auf die Jahresansicht_Ausbilder|                   |                   |           |
| 3_Einsatz in der Jahresansicht eintragen_Ausbilder|             |                   |           |
| 4_Zugriff auf die Detailansicht       | Erfolgreich      | Erfolgreich      |           |
| 5_Urlaub in die Detailansicht eintragen_Azubi  | Erfolgreich | Erfolgreich      |           |
| 5_Einsatz in die Detailansicht eintragen_Ausbilder|               |                   |           |
| 6_Verändern eines Urlaubs_Azubi       | Erfolgreich      | Erfolgreich      |           |
| 6_Verändern eines Einsatzes_Ausbilder |                   |                   |           |
| 7_Einsatz in der Jahresansicht löschen_Ausbilder|               |                   |           |
| 8_Urlaub in der Detailansicht löschen_Azubi| Erfolgreich   | Erfolgreich      |           |
| 8_Einsatz in der Detailansicht löschen_Ausbilder|             |                   |           |
| 9_Export_Azubi                        | Erfolgreich      | Erfolgreich      |           |
| 9_Export_Ausbilder                    |                   |                   |           |
| 10_Import_Ausbilder                   |                   |                   |           |

## Dokumentation
![Auszug Entwicklerdokumentation](Anhänge/Dokumentation/Entwicklerdoku.png)

# B Quellcode
```csharp

