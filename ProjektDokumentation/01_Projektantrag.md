# Antrag für die betriebliche Projektarbeit

## 1. Projektbezeichnung
**Entwicklung eines Einsatzplanungstools für Azubis als Webapplikation**

---

## 2. Kurzform der Aufgabenstellung
Entwicklung einer datenbankgestützten **ASP.NET‑Webanwendung in C#** zur Einsatzplanung von Auszubildenden. Vereinfachung der Einsatzplanung unter Berücksichtigung der Berufszweige, Erstellung eines Reportings für Ausbildungsbeauftragte und Implementierung einer Funktion zur selbstständigen Verwaltung von Urlaub und Abwesenheiten durch die Azubis.

---

## 3. Zielsetzung entwickeln

### 3.1. Ist‑Analyse
Derzeit erfolgt die Einsatzplanung der Azubis manuell in einer unübersichtlichen Excel‑Tabelle. Die Planung für die Ausbildungsbeauftragten muss händisch erstellt werden. Urlaubs- und Abwesenheitsdaten werden separat gepflegt, was die Berücksichtigung erschwert.

### 3.2. Soll‑Konzept
Das Einsatzplanungstool soll die Planung vereinfachen, indem **Berufszweige, Urlaube und Abwesenheiten** zentral gepflegt und automatisch berücksichtigt werden. Für jeden Einsatzort soll ein **automatisiertes Reporting** generiert werden. Alle Daten werden künftig in einer **zentralen Datenbank** gespeichert.

### 3.3. Anforderungen
Das Tool soll folgende funktionale Anforderungen erfüllen:

- Personalisierte Benutzerprofile — Turnus‑Woche, Berufszweig  
- Pflegemöglichkeiten — für Ausbilder und Auszubildende  
- Automatische Feiertage — automatische Eintragung von Feiertagen & Wochenenden  
- Abwesenheitsverwaltung — Berufsschule, Prüfungen, Urlaub, Praxiseinsätze  
- Reportingfunktion — automatisierte Reports für Ausbildungsbeauftragte

### 3.4. Schwierigkeiten und Zusammenarbeit
Mögliche Herausforderungen:

- Technische Komplexität bei der **Datenbankintegration**
- Gestaltung einer **intuitiven Benutzeroberfläche**
- Abstimmung mit **Ausbildungsverantwortlichen** und **Azubis**, um Anforderungen vollständig zu erfassen

### 3.5. Nutzen des Projektes

- Effiziente Datenverwaltung  
- Transparente Pflege für Auszubildende und Ausbilder  
- Reduzierung von Eingabefehlern  
- Zeitersparnis durch automatisierte Prozesse  

---

## 4. Projektstrukturplan

### 4.1. Aufgabenliste

#### Analyse
- Ist‑Analyse der aktuellen Einsatzplanung  
- Analyse & Dokumentation des Planungsprozesses  
- Kostenplanung & Projektkalkulation  
- Definition von Use‑Cases  
- Erstellung eines Lastenhefts  

#### Planung & Entwurf
- Erstellung eines Entity‑Relationship‑Models (ERM)  
- Erstellung eines Klassendiagramms  
- Definition der Benutzerprofile & Berechtigungen  
- Entwurf einer Kalenderansicht  
- Erstellung eines Pflichtenhefts  

#### Entwicklung
- Implementierung der Benutzerprofile & Authentifizierung  
- Erstellung der Datenbank  
- Entwicklung der Webanwendung  
  - Oberfläche (Kalender & Pflegemasken)  
  - Datenbankzugriffe  
  - Fehlerhandling  
- Erstellung des Reportings  

#### Systemtests
- Organisation eines Testsystems  
- Planung & Organisation von Tests  
- Erstellung von Testfällen  
- Durchführung von Tests  
- Fehlerbehebung  

#### Dokumentation
- Erstellung der Entwicklerdokumentation  
- Fertigstellung der Projektdokumentation  

---

## 4.2. Zeitplanung

| Projektphase / Aufgabe | Zeit |
|------------------------|------|
| **Analyse** | **10 h** |
| - Ist‑Analyse | 1 h |
| - Prozessanalyse | 2 h |
| - Kostenplanung | 2 h |
| - Use‑Cases | 2 h |
| - Lastenheft | 3 h |
| **Planung & Entwurf** | **6 h** |
| - Komponentendiagramm | 1 h |
| - Aktivitätsdiagramm | 1 h |
| - Benutzerprofile | 0,5 h |
| - Kalenderentwurf | 0,5 h |
| - Pflichtenheft | 3 h |
| **Entwicklung** | **46 h** |
| - Benutzerprofile & Authentifizierung | 4 h |
| - Datenbank | 3 h |
| - Webanwendung | 36 h |
| - Reporting | 3 h |
| **Systemtests** | **8 h** |
| - Blackbox‑Test | 3 h |
| - Fehlerbehebung | 5 h |
| **Dokumentation** | **10 h** |
| - Entwicklerdokumentation | 4 h |
| - Projektdokumentation | 6 h |
