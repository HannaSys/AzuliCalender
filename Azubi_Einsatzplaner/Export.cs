using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;



namespace Azubi_Einsatzplaner
{
    public class Export
    {
        // Datenbank Connection
        readonly string _gConnectStr = Properties.Settings.Default.DBConnectionString;
        readonly ADODB.Connection _conn1 = new ADODB.Connection();



        // Exportiert alle Azubidaten in eine Excel
        public void GesamtExportxlsx()
        {
            string vorherigerAzubi = "";
            int spalte = -2;
            int zeile = 1;

            // für jeden Einsatz den Monat holen
            List<Einsatz> einsaetze = GetAllEinsaetze();

            XLWorkbook workBook = new XLWorkbook();
            IXLWorksheet workSheet = workBook.AddWorksheet("Export");

            // Liste durchgehen und in Excel schreiben
            foreach (Einsatz einsatz in einsaetze)
            {                
                // Bei neuem Azubi neue Spalte suchen
                if (vorherigerAzubi != einsatz.Kuerzel)
                {
                    spalte = spalte + 3;
                    zeile = 1;

                    // Kopfzeile designen
                    workSheet.Cell(zeile, spalte).Value = einsatz.Nachname;
                    workSheet.Range(workSheet.Cell(zeile, spalte), workSheet.Cell(zeile, spalte + 1)).Merge();
                    workSheet.Cell(zeile, spalte).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    workSheet.Cell(zeile, spalte).Style.Font.SetBold();

                    zeile++;

                    // Einsätze für zwei Jahre anzeigen - beginnend ab dem aktuellen Jahr
                    for (int jahr = 0; jahr < 2; jahr++)
                    {
                        // Jeden Monat durchgehen
                        for (int monat = 1; monat <= 12; monat++)
                        {
                            // Monat und Jahr schreiben
                            workSheet.Cell(zeile, spalte + 1).Value = monat.ToString() + " " + DateTime.Now.AddYears(jahr).Year;
                            workSheet.Cell(zeile, spalte + 1 ).Style.NumberFormat.Format = "MMM-YY";

                            // Einsätze nach möglichen Datumstreffern durchgehen
                            foreach (Einsatz einsatzMonat in einsaetze)
                            {
                                // Überprüfen, ob der Jahr und der Monat mit dem Einsatzdatum übereinstimmen
                                if (einsatz.Kuerzel == einsatzMonat.Kuerzel && einsatzMonat.Datum.Month == monat && einsatzMonat.Datum.Year == DateTime.Now.Year + jahr)
                                {
                                    // Abteilung in Zelle schreiben
                                    workSheet.Cell(zeile, spalte).Value = einsatzMonat.Abteilung;
                                }
                            }

                            // Nach Dezember eine dicke Linie ziehen - Visuelle Jahres Trennung
                            if (monat == 12)
                            {
                                workSheet.Cell(zeile, spalte).Style.Border.BottomBorder = XLBorderStyleValues.Thick;
                                workSheet.Cell(zeile, spalte + 1).Style.Border.BottomBorder = XLBorderStyleValues.Thick;
                            }
                            zeile++;
                        }
                    }
                    
                    vorherigerAzubi = einsatz.Kuerzel;
                }
                zeile++;
            }
            // Zellen breite auf 15 festlegen damit genug Platz für die Daten sind
            workSheet.Columns().Width = 15;

            // Speichert die Datei im Server
            //workBook.SaveAs(HttpContext.Current.Server.MapPath("Export/ExportAll.xlsx"));
            workBook.SaveAs(@"C:\Users\Hanna\source\repos\AzuliCalender\Azubi_Einsatzplaner\ExportAll.xlsx");
        }

        // Exportiert einen bestimmten Azubi in eine Excel
        public void SingleExportxlsx(string azubiKuerzel)
        {
            int spalte = 1;
            int zeile = 1;

            // für jeden Einsatz den Monat holen
            List<Einsatz> einsaetze = GetAllEinsaetze();

            XLWorkbook workBook = new XLWorkbook();
            IXLWorksheet workSheet = workBook.AddWorksheet("Export");

            // Kopfzeile designen
            workSheet.Cell(zeile, spalte).Value = azubiKuerzel;
            workSheet.Range(workSheet.Cell(zeile, spalte), workSheet.Cell(zeile, spalte + 1)).Merge();
            workSheet.Cell(zeile, spalte).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            workSheet.Cell(zeile, spalte).Style.Font.SetBold();

            zeile++;
            // Einsätze für zwei Jahre anzeigen - beginnend ab dem aktuellen Jahr
            for (int jahr = 0; jahr < 2; jahr++)
            {
                // Jeden Monat durchgehen
                for (int monat = 1; monat <= 12; monat++)
                {
                    // Monat und Jahr schreiben
                    workSheet.Cell(zeile, spalte + 1).Value = monat.ToString() + " " + DateTime.Now.AddYears(jahr).Year;
                    workSheet.Cell(zeile, spalte + 1).Style.NumberFormat.Format = "MMM-YY";

                    // Einsätze nach möglichen Datumstreffern durchgehen
                    foreach (Einsatz einsatzMonat in einsaetze)
                    {
                        // Überprüfen, ob der Jahr und der Monat mit dem Einsatzdatum übereinstimmen
                        if (azubiKuerzel == einsatzMonat.Kuerzel && einsatzMonat.Datum.Month == monat && einsatzMonat.Datum.Year == DateTime.Now.Year + jahr)
                        {
                            // Abteilung in Zelle schreiben
                            workSheet.Cell(zeile, spalte).Value = einsatzMonat.Abteilung;
                        }
                    }

                    // Nach Dezember eine dicke Linie ziehen - Visuelle Jahres Trennung
                    if (monat == 12)
                    {
                        workSheet.Cell(zeile, spalte).Style.Border.BottomBorder = XLBorderStyleValues.Thick;
                        workSheet.Cell(zeile, spalte + 1).Style.Border.BottomBorder = XLBorderStyleValues.Thick;
                    }
                    zeile++;
                }
                zeile++;
            }
            // Zellen breite auf 15 festlegen damit genug Platz für die Daten sind
            workSheet.Columns().Width = 15;

            // Speichert die Datei im Server
            workBook.SaveAs(HttpContext.Current.Server.MapPath("Export/" + azubiKuerzel + ".xlsx"));
            workBook.SaveAs(@"C:\Users\Hanna\source\repos\AzuliCalender\Azubi_Einsatzplaner\" + azubiKuerzel + ".xlsx");
        }

        // Liste der Einsätze erstellen
        private List<Einsatz> GetAllEinsaetze()
        {
            List<Einsatz> einsaetze = new List<Einsatz>();
            DateTime anfangsdatum;
            DateTime enddatum;

            _conn1.Open(_gConnectStr);
            ADODB.Recordset rs1 = new ADODB.Recordset();

            // Alle Einsätze des ausgewählten Azubis abrufen
            string anfrage = "SELECT * FROM Auszubildender INNER JOIN Einsatz ON Auszubildender.kuerzel = Einsatz.kuerzel_Auszubildender WHERE Year(Date()) <= Year(Einsatz.Anfangsdatum) ORDER BY Einsatz.kuerzel_Auszubildender, Einsatz.Anfangsdatum;";
            rs1.Open(anfrage, _conn1, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic);

            while (!rs1.EOF)
            {
                anfangsdatum = rs1.Fields["Anfangsdatum"].Value;
                enddatum = rs1.Fields["Enddatum"].Value;
                string abteilung = rs1.Fields["ID_Abteilung"].Value.ToString();

                // Die Tage zwischen Anfangs- und Enddatum erstellen und zu einer Liste hinzufügen
                // So können alle Tage des Einsatzes markiert werden
                for (DateTime date = anfangsdatum; date <= enddatum; date = date.AddDays(1))
                {
                    Einsatz einsatz = new Einsatz();
                    einsatz.Datum = date;
                    einsatz.Abteilung = abteilung;
                    einsatz.Nachname = rs1.Fields["Nachname"].Value.ToString();
                    einsatz.Kuerzel = rs1.Fields["kuerzel"].Value.ToString();
                    einsaetze.Add(einsatz);
                }

                rs1.MoveNext();
            }

            // Schließen der Datenbankverbindung
            rs1.Close();
            _conn1.Close();

            // Liste so ausdünnen
            List<Einsatz> einsatzMonate = IsolateAllEinsatzMonate(einsaetze);

            return einsatzMonate;
        }

        // Liste ausdünnen, sodass nur noch ein Eintrag pro Abteilung und Monat entstehen
        // Bei wechselnen Einsätze im Monat werden einige Monate doppelt vorkommen
        private List<Einsatz> IsolateAllEinsatzMonate(List<Einsatz> einsaetze)
        {
            List<Einsatz> einsatzMonate = new List<Einsatz>();
            int vorMonat = 0;

            foreach (Einsatz einsatz in einsaetze)
            {
                //Eintrag schreiben, wenn der Monat von davor abweicht
                if (vorMonat != einsatz.Datum.Month)
                {
                    Einsatz monatsEinsatz = new Einsatz();
                    monatsEinsatz.Datum = einsatz.Datum;
                    monatsEinsatz.Abteilung = einsatz.Abteilung;
                    monatsEinsatz.Nachname = einsatz.Nachname;
                    monatsEinsatz.Kuerzel = einsatz.Kuerzel;
                    einsatzMonate.Add(einsatz);
                    vorMonat = einsatz.Datum.Month;
                }
            }
            return einsatzMonate;
        }
    }
}