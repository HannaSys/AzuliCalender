# Inhaltsverzeichnis
- [Einleitung](#einleitung)
- [1. Allgemeines](#1-allgemeines)
  - [1.1. Ziel und Zweck des Dokuments](#11-ziel-und-zweck-des-dokuments)
  - [1.2. Ausgangssituation](#12-ausgangssituation)
  - [1.3. Projektbezug](#13-projektbezug)
  - [1.4. Abkürzungen](#14-abkürzungen)
  - [1.5. Teams und Schnittstellen](#15-teams-und-schnittstellen)
- [2. Konzept](#2-konzept)
  - [2.1. Ziele der Anbieter:innen](#21-ziele-der-anbieterinnen)
  - [2.2. Ziele und Nutzen der Anwender:innen](#22-ziele-und-nutzen-der-anwenderinnen)
  - [2.3. Zielgruppen](#23-zielgruppen)
- [3. Benutzerrollen](#3-benutzerrollen)
- [4. Funktionale Anforderungen](#4-funktionale-anforderungen)
  - [4.1. Personalisierte Benutzerprofile](#41-personalisierte-benutzerprofile)
  - [4.2. Datenpflegemöglichkeiten](#42-datenpflegemöglichkeiten)
  - [4.3. Automatisierte Eintragung von Feiertagen und Wochenenden](#43-automatisierte-eintragung-von-feiertagen-und-wochenenden)
  - [4.4. Erfassung und Anzeige von Abwesenheiten](#44-erfassung-und-anzeige-von-abwesenheiten)
  - [4.5. Automatisiertes Erstellen von Reports](#45-automatisiertes-erstellen-von-reports)
- [5. Nichtfunktionale Anforderungen](#5-nichtfunktionale-anforderungen)
  - [5.1. Allgemeine Anforderungen](#51-allgemeine-anforderungen)
  - [5.2. Gesetzliche Anforderungen](#52-gesetzliche-anforderungen)
  - [5.3. Technische Anforderungen](#53-technische-anforderungen)
- [6. Rahmenbedingungen](#6-rahmenbedingungen)
  - [6.1. Zeitplan](#61-zeitplan)
  - [6.2. Technische Anforderungen](#62-technische-anforderungen)
  - [6.3. Problemanalyse](#63-problemanalyse)
  - [6.4. Qualität](#64-qualität)
- [7. Lieferumfang](#7-lieferumfang)
- [8. Liefer- und Abnahmebedingungen](#8-liefer--und-abnahmebedingungen)
- [9. Anhang](#9-anhang)

---

# Einleitung
Das vorliegende Dokument vereint die funktionalen und nicht-funktionalen Anforderungen sowie die Ziele und Rahmenbedingungen für die Entwicklung eines Einsatzplanungstools für Auszubildende als ASP.NET-Webapplikation. Es bildet die Grundlage für Ausschreibung, Vertragsgestaltung und Angebotserstellung und ist rechtlich bindend nach Vertragsabschluss.

---

# 1. Allgemeines

## 1.1. Ziel und Zweck des Dokuments
Dieses Dokument definiert die Anforderungen für eine datenbankgestützte ASP.NET-Webanwendung zur Einsatzplanung von Auszubildenden. Es soll eine klare Struktur und ein gemeinsames Verständnis über Ziele und Funktionen des geplanten Einsatzplanungstools schaffen.

## 1.2. Ausgangssituation
Die bisherige Einsatzplanung erfolgt manuell in Excel-Tabellen. Diese Vorgehensweise ist fehleranfällig, unübersichtlich und ineffizient. Das Projekt soll eine automatisierte, transparente und zuverlässige Lösung schaffen.

## 1.3. Projektbezug
Das Projekt umfasst die eigenständige Entwicklung einer Webanwendung zur Einsatzplanung von Auszubildenden, um bestehende manuelle Prozesse zu optimieren.

## 1.4. Abkürzungen
| Abkürzung | Beschreibung |
|----------|--------------|
| IBB      | Investitionsbank Berlin |

## 1.5. Teams und Schnittstellen
| Rolle          | Name       | Telefon | E-Mail                 |
|----------------|------------|---------|-------------------------|
| Projektleitung | H. Krusch  | 5278    | Hanna.krusch@ibb.de    |

---

# 2. Konzept

## 2.1. Ziele der Anbieter:innen
Entwicklung einer benutzerfreundlichen Webapplikation zur automatisierten Einsatzplanung von Auszubildenden. Das Tool soll manuelle Planungsprozesse ersetzen und optimieren.

## 2.2. Ziele und Nutzen der Anwender:innen
Anwender:innen profitieren von:
- vereinfachter Einsatzplanung  
- transparenter Datenpflege  
- Zeitersparnis  
- klarer Strukturierung von Einsätzen und Abwesenheiten  

## 2.3. Zielgruppen
Die Zielgruppe umfasst Ausbilder:innen und Auszubildende verschiedener Berufszweige.

---

# 3. Benutzerrollen
| Rolle         | Beschreibung |
|---------------|--------------|
| Auszubildende | Aktualisierung der eigenen Einsatzpläne |
| Ausbilder     | Pflege eigener Abwesenheiten |

---

# 4. Funktionale Anforderungen

## 4.1. Personalisierte Benutzerprofile
Das System soll personalisierte Profile für Auszubildende und Ausbilder bereitstellen, inklusive Berechtigungen und Zugriffsrechten.

## 4.2. Datenpflegemöglichkeiten
Auszubildende und Ausbilder sollen Abwesenheiten, Berufsschulwochen, Prüfungen, Urlaub und Praxiseinsätze pflegen können.

## 4.3. Automatisierte Eintragung von Feiertagen und Wochenenden
Das System berücksichtigt automatisch gesetzliche Feiertage und Wochenenden.

## 4.4. Erfassung und Anzeige von Abwesenheiten
Alle Abwesenheiten sollen erfasst, gespeichert und übersichtlich dargestellt werden.

## 4.5. Automatisiertes Erstellen von Reports
Das System generiert automatisch Reports für Ausbildungsbeauftragte.

---

# 5. Nichtfunktionale Anforderungen

## 5.1. Allgemeine Anforderungen
Das System muss benutzerfreundlich, sicher, zuverlässig und performant sein.

## 5.2. Gesetzliche Anforderungen
Einhaltung aller relevanten Datenschutzrichtlinien und gesetzlichen Bestimmungen.

## 5.3. Technische Anforderungen
Die Webapplikation basiert auf ASP.NET und nutzt eine stabile, skalierbare Datenbank.

---

# 6. Rahmenbedingungen

## 6.1. Zeitplan
- Projektabschluss: **05.06.2024**  
- Geplante Abnahme: **31.05.2024**

## 6.2. Technische Anforderungen
Verwendete Technologien:
- ASP.NET  
- C#  
- Datenbanklösung (z. B. SQL Server)

## 6.3. Problemanalyse
Mögliche Herausforderungen:
- Datenbankintegration  
- Benutzeroberflächengestaltung  

## 6.4. Qualität
Hohe Qualitätsstandards sind erforderlich, um eine stabile und zuverlässige Webapplikation sicherzustellen.

---

# 7. Lieferumfang
- Vollständig entwickelte Webapplikation  
- Projektdokumentation  
- Technische Dokumentation  

---

# 8. Liefer- und Abnahmebedingungen
Die Lieferung erfolgt gemäß definierten Qualitätskriterien und Abnahmeprozessen.

---

# 9. Anhang
Alle relevanten Dokumente, Zahlen, Fakten und Unterlagen befinden sich im Anhang.
