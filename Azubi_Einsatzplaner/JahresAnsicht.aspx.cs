using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Globalization;
using System.Web.UI.HtmlControls;

namespace Azubi_Einsatzplaner
{
    public partial class JahresAnsicht : System.Web.UI.Page
    {
        // Datenbank Connection
        readonly string _gConnectStr = Properties.Settings.Default.DBConnectionString;
        readonly string logonUser = Properties.Settings.Default.logonUser;
        readonly ADODB.Connection _conn1 = new ADODB.Connection();
        private int jahrgang;

        Berechtigungen berechtigung = new Berechtigungen();
        // Admin darf alles
        string admin = Properties.Settings.Default.admin;

        protected void Page_Init(object sender, EventArgs e)
        {
            // User holen
            //string logonUser = Request.LogonUserIdentity.Name.ToLower().Replace(@"ibbads\", "");

            // Überprüfen, ob ein Azubi ordnungsgemäß ausgewählt wurde
            if (Request.QueryString["azubi"] != null)
            {
                Berechtigungen berechtigung = new Berechtigungen();

                //Berechtigungen des Users überprüfen
                if (berechtigung.CheckUserRights(Request.QueryString["azubi"], logonUser))
                {
                    // Ansichtselemente laden
                    Azubi_Load();
                    Fachbereiche_Load();
                }
                // Fehlermeldung anzeigen wenn nicht die nötigen Rechte vorhanden sind
                else
                {
                    ux_FehlermeldungLabel.Visible = true;
                    ux_FehlermeldungLabel.Text = "Sie haben keine Rechte um auf diesen Kalender zuzugreifen.";
                    ux_FehlermeldungLabel.ForeColor = Color.Red;
                    ux_AzubiNameLabel.Visible = false;
                    ux_FachbereicheDropDown.Enabled = false;
                    ux_EinsatzSpeichernButton.Enabled = false;
                }
            }
            else
            {
                // Kein Azubi ausgewählt, dann zurück auf die "Startseite"
                Response.Redirect("GesamtAnsicht.aspx");
            }


        }

        // Ausgewählten Azubi auslesen 
        private void Azubi_Load()
        {
            _conn1.Open(_gConnectStr);
            ADODB.Recordset rs1 = new ADODB.Recordset();

            // Informationen des Azubis auslesen und darstellen
            rs1.Open("SELECT * FROM Auszubildender WHERE kuerzel ='" + Request.QueryString["azubi"] + "'", _conn1, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly);
            ux_AzubiNameLabel.Text = rs1.Fields["Nachname"].Value.ToString();
            jahrgang = Convert.ToInt32(rs1.Fields["Jahrgang"].Value.ToString());

            // Schließen der Datenbankverbindung
            rs1.Close();
            _conn1.Close();

            // Kalender aller Ausbildungsjahre darstellen
            CreateYearlyCalendar(jahrgang);
        }

        // Fachbereiche in das DropDown schreiben
        private void Fachbereiche_Load()
        {
            ux_FachbereicheDropDown.Items.Clear();
            _conn1.Open(_gConnectStr);
            ADODB.Recordset rs1 = new ADODB.Recordset();

            //string logonUser = Request.LogonUserIdentity.Name.ToLower().Replace(@"ibbads\", "");

            // Alle Abteilungen auslesen und in Dropdown schreiben
            rs1.Open("SELECT * FROM Abteilung;", _conn1, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly);

            ux_FachbereicheDropDown.Items.Add(new ListItem(""));
            if (logonUser == admin)
            {
                while (!rs1.EOF)
                {
                    ux_FachbereicheDropDown.Items.Add(new ListItem(rs1.Fields["Abteilung"].Value.ToString()));
                    rs1.MoveNext();
                }
            }
            // Schließen der Datenbankverbindung
            rs1.Close();
            _conn1.Close();
        }

        // Kalender aller Ausbildungsjahre darstellen
        private void CreateYearlyCalendar(int lehrjahr)
        {
            // Vorherige Anzeigen löschen
            ux_yearlyCalendarTable.Rows.Clear();

            // Überschriften für die Spalten der Jahre
            TableRow headerRow = new TableRow();
            for (int i = 0; i <= 3; i++)
            {

                int year = lehrjahr + i;
                TableHeaderCell headerCell = new TableHeaderCell();
                headerCell.HorizontalAlign = HorizontalAlign.Center;
                headerCell.BackColor = Color.FromArgb(4, 149, 197);

                Button ansichtButton = new Button();
                ansichtButton.Font.Bold = true;
                ansichtButton.BackColor = Color.FromArgb(4, 149, 197);
                ansichtButton.Text = year.ToString();
                ansichtButton.Attributes.CssStyle.Add(HtmlTextWriterStyle.Width, "100%");
                ansichtButton.PostBackUrl = $"Calender.aspx?year={year}&azubi={Request.QueryString["azubi"]}";
                headerCell.Controls.Add(ansichtButton);
                headerRow.Cells.Add(headerCell);
            }
            ux_yearlyCalendarTable.Rows.Add(headerRow);

            List<Einsatz> einsaetze = GetEinsaetze();

            // Reihen für jeden Monat erstellen
            for (int month = 1; month <= 12; month++)
            {
                TableRow monthRow = new TableRow();


                // Jede Reihe der Monate durchgehen für jedes Ausbildungsjahr
                for (int header = 0; header <= 3; header++)
                {
                    TableCell monthCell = new TableCell();
                    Panel container = new Panel();
                    HtmlInputCheckBox checkBox = new HtmlInputCheckBox();
                    Label label = new Label();

                    checkBox.ID = lehrjahr + header + "_" + month;
                    label.Text = GetMonthName(month);
                    int headerYear = lehrjahr + header;

                    checkBox.Attributes["onclick"] = "SetInfotext(this,'" + GetMonthName(month) + "_" + headerYear + "');";

                    // Einsätze beschriften
                    foreach (Einsatz einsatz in einsaetze)
                    {
                        if (einsatz.Datum.Month == month && einsatz.Datum.Year == headerYear)
                        {
                            label.Text += " (" + einsatz.Abteilung + ")";
                        }
                    }

                    container.Controls.Add(checkBox);
                    container.Controls.Add(label);

                    monthCell.Controls.Add(container);
                    monthCell.HorizontalAlign = HorizontalAlign.Center;
                    monthRow.Cells.Add(monthCell);
                }
                ux_yearlyCalendarTable.Rows.Add(monthRow);
            }
        }

        // Liste der Einsätze erstellen
        private List<Einsatz> GetEinsaetze()
        {
            List<Einsatz> einsaetze = new List<Einsatz>();
            DateTime anfangsdatum;
            DateTime enddatum;

            _conn1.Open(_gConnectStr);
            ADODB.Recordset rs1 = new ADODB.Recordset();

            // Alle Einsätze des ausgewählten Azubis abrufen
            rs1.Open("SELECT * FROM Einsatz WHERE kuerzel_Auszubildender = '" + Request.QueryString["azubi"] + "';", _conn1, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly);

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
                    einsaetze.Add(einsatz);
                }
                rs1.MoveNext();
            }

            // Schließen der Datenbankverbindung
            rs1.Close();
            _conn1.Close();

            // Liste so ausdünnen
            List<Einsatz> einsatzMonate = IsolateEinsatzMonate(einsaetze);

            return einsatzMonate;
        }

        // Liste ausdünnen, sodass nur noch ein Eintrag pro Abteilung und Monat entstehen
        // Bei wechselnen Einsätze im Monat werden einige Monate doppelt vorkommen
        private List<Einsatz> IsolateEinsatzMonate(List<Einsatz> einsaetze)
        {
            List<Einsatz> einsatzMonate = new List<Einsatz>();
            int vorMonat = 0;
            int vorJahr = 0;
            string vorAbteilung = "";

            foreach (Einsatz einsatz in einsaetze)
            {
                //Eintrag schreiben, wenn der Monat oder die Abteilung von davor abweichen
                if (vorMonat != einsatz.Datum.Month || vorJahr != einsatz.Datum.Year || vorAbteilung != einsatz.Abteilung)
                {

                    Einsatz monatsEinsatz = new Einsatz();
                    monatsEinsatz.Datum = einsatz.Datum;
                    monatsEinsatz.Abteilung = einsatz.Abteilung;
                    einsatzMonate.Add(einsatz);
                    vorAbteilung = einsatz.Abteilung;
                    vorMonat = einsatz.Datum.Month;
                    vorJahr = einsatz.Datum.Year;
                }
            }

            return einsatzMonate;
        }

        private void SaveEinsatz(DateTime anfang, DateTime ende, string abteilung)
        {
            _conn1.Open(_gConnectStr);
            ADODB.Recordset rs1 = new ADODB.Recordset();
            string anfrage;

            // Die richtige Datenbank aufrufen
            switch (abteilung)
            {
                case "Urlaub":
                    anfrage = "SELECT * FROM Urlaub WHERE Anfangsdatum IS NULL;";
                    break;
                default:
                    anfrage = "SELECT * FROM Einsatz WHERE Anfangsdatum IS NULL;";
                    break;
            }

            // Leeren Datensatz erzeugen
            rs1.Open(anfrage, _conn1, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic);

            // Daten in den leeren Satz schreiben
            rs1.AddNew();
            rs1.Fields["Anfangsdatum"].Value = anfang;
            rs1.Fields["Enddatum"].Value = ende;

            // Felder den Datenbanken angepasst speichern
            switch (abteilung)
            {
                case "Urlaub":
                    rs1.Fields["kuerzel_Auszubildender"].Value = Request.QueryString["azubi"];
                    break;
                default:
                    rs1.Fields["ID_Abteilung"].Value = abteilung;
                    rs1.Fields["kuerzel_Auszubildender"].Value = Request.QueryString["azubi"];
                    break;
            }

            // Updaten und schließen der Datenbankverbindung
            rs1.Update();
            rs1.Close();
            _conn1.Close();
        }

        // Die Checkboxen überprüfen
        private List<(DateTime, DateTime)> ReadCheckBoxes()
        {
            string textBoxContent = Request.Form.Get("ux_Info");

            string[] monateStrings = textBoxContent.Split(' ');

            List<(DateTime Anfang, DateTime Ende)> monatEintraege = new List<(DateTime, DateTime)>();
            foreach (string stringMonat in monateStrings)
            {
                if (stringMonat != "")
                {
                    string[] monateUndJahrString = stringMonat.Split('_');

                    int monat = DateTime.ParseExact(monateUndJahrString[0], "MMMM", CultureInfo.GetCultureInfo("de-DE"), DateTimeStyles.None).Month;
                    int jahr = DateTime.ParseExact(monateUndJahrString[1], "yyyy", CultureInfo.GetCultureInfo("de-DE"), DateTimeStyles.None).Year;

                    // Daten darstellen
                    DateTime anfang = new DateTime(jahr, monat, 1);
                    int tageImMonat = DateTime.DaysInMonth(jahr, monat);
                    DateTime ende = new DateTime(jahr, monat, tageImMonat);

                    monatEintraege.Add((anfang, ende));
                }
            }
            return monatEintraege;
        }


        private string CheckEinsatzStatus(DateTime anfangsdatum, DateTime enddatum, string abteilung)
        {
            //string logonUser = Request.LogonUserIdentity.Name.ToLower().Replace(@"ibbads\", "");
            List<Einsatz> alleDaten = new List<Einsatz>();

            if (logonUser == admin)
            {
                // Zeitraum befüllen
                alleDaten = FillTage(anfangsdatum, enddatum, "Einsatz");
            }
            else
            {
                // Zeitraum befüllen
                alleDaten = FillTage(anfangsdatum, enddatum, "Urlaub");
            }

            // Überprüfen ob kein anderer Einsatz in den Zeitraum stattfindet
            alleDaten = CheckAllDays(alleDaten);

            // falls ein anderer Einsatz sich überschneidet ist bei der Liste min 1 Element
            if (alleDaten.Count >= 1)
            {
                // Wenn die Abteilung leer ist soll der Zeitraum bzw stattfindende Einsätze gelöscht werden
                if (abteilung == "" && logonUser == admin)
                {
                    foreach (Einsatz einsatz in alleDaten)
                    {
                        einsatz.DeleteEinsatz(einsatz.Datum, "Einsatz");
                    }
                    ux_FehlermeldungLabel.Visible = false;
                    return "";
                }
                else if (abteilung == "" && logonUser != admin)
                {
                    foreach (Einsatz einsatz in alleDaten)
                    {
                        einsatz.DeleteEinsatz(einsatz.Datum, "Urlaub");
                    }
                    ux_FehlermeldungLabel.Visible = false;
                    return "";
                }
                // Falls nicht dann könnt eine Fehlermeldung für den User
                else
                {
                    return "Zu der Zeit findet ein anderer Einsatz statt.";
                }
            }
            // wenn keine anderen Einsätze in dem Zeitraum sind dann wird der Einsatz gespeichert
            else
            {
                // Überprüfen ob eine Abteilung ausgewählt wurde
                if (abteilung != "")
                {
                    SaveEinsatz(anfangsdatum, enddatum, abteilung);
                    ux_FehlermeldungLabel.Enabled = false;
                    return "";
                }
                // Bei keiner ausgewählten Abteilung kommt Fehlermeldung für den User
                else if (abteilung == "")
                {
                    return "Zu diesem Zeitpunkt findet kein Einsatz statt der gelöscht werden könnte.";
                }
                return "";
            }
        }

        // den Kalender unserer Kultur verwenden, um den richtig Monat zu bekommen
        private string GetMonthName(int month)
        {
            return CultureInfo.GetCultureInfo("de-DE").DateTimeFormat.GetMonthName(month);
        }

        // Exportiert die Einsatzdaten aller Azubis der nächsten zwei Jahre
        protected void ux_exportButton_Click(object sender, EventArgs e)
        {
            Export export = new Export();
            export.SingleExportxlsx(Request.QueryString["azubi"]);
            Response.Redirect(@"Export\" + Request.QueryString["azubi"] + ".xlsx");
        }

        // Speichert den Einsatz 
        protected void ux_EinsatzSpeichernButton_Click(object sender, EventArgs e)
        {
            List<(DateTime, DateTime)> monatsListe = ReadCheckBoxes();
            string abteilung = ux_FachbereicheDropDown.SelectedValue;

            if (monatsListe.Count != 0)
            {
                string meldungen = "";
                foreach (var eintrag in monatsListe)
                {
                    meldungen += GetMonthName(eintrag.Item1.Month) + " " + eintrag.Item1.Year + ": ";
                    string monthMeldung = CheckEinsatzStatus(eintrag.Item1, eintrag.Item2, abteilung);

                    // ## Umbruch noch besser darstellen
                    if (monthMeldung == "")
                    {
                        meldungen += "Speichern war erfolgreich.<br />";
                    }
                    else
                    {
                        meldungen += monthMeldung + "<br />";
                    }
                }
                ux_FehlermeldungLabel.Text = meldungen;
                ux_FehlermeldungLabel.Visible = true;
                ux_FehlermeldungLabel.ForeColor = Color.Red;
            }
            // Kalender und Azubi werden neu geladen        
            CreateYearlyCalendar(jahrgang);
        }

        // Die Tage der Range erzeugen
        private List<Einsatz> FillTage(DateTime anfangsdatum, DateTime enddatum, string abteilung)
        {
            List<Einsatz> allTagesEinsaetze = new List<Einsatz>();

            // Die Tage zwischen Anfangs- und Enddatum erstellen und zu einer Liste hinzufügen
            // So können alle Tage des Einsatzes markiert werden
            for (DateTime date = anfangsdatum; date <= enddatum; date = date.AddDays(1))
            {
                Einsatz tagesEinsatz = new Einsatz();
                tagesEinsatz.Datum = date;
                tagesEinsatz.Abteilung = abteilung;
                tagesEinsatz.Kuerzel = Request.QueryString["azubi"];
                allTagesEinsaetze.Add(tagesEinsatz);
            }
            return allTagesEinsaetze;
        }

        // Überprüft ob die Einsätze in einen anderen Einsatz fallen
        // gbt die Datumsangaben zurück wo das der fall ist
        private List<Einsatz> CheckAllDays(List<Einsatz> einsaetze)
        {
            List<Einsatz> belegteEinsaetze = new List<Einsatz>();

            foreach (Einsatz einsatz in einsaetze)
            {
                if (einsatz.CheckEinsatz())
                {
                    belegteEinsaetze.Add(einsatz);
                }
            }
            return belegteEinsaetze;
        }

    }
}