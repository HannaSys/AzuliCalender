using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Azubi_Einsatzplaner
{
    public class Einsatz
    {
        // Datenbank Connection
        readonly string _gConnectStr = Properties.Settings.Default.DBConnectionString;
        readonly ADODB.Connection _conn1 = new ADODB.Connection();

        // Getter und Setter
        public DateTime Datum { get; set; }
        public string Abteilung { get; set; }
        public string Nachname { get; set; }
        public string Kuerzel { get; set; }
        public int ID { get; set; }

        // Überprüft ob das Einsatzdatum in einen anderen IBB-Einsatz fällt
        public Boolean CheckEinsatz()
        {
            Boolean einsatzExistiert = true;
            string anfrage;
            string formatDatum = Datum.ToString("yyyy-MM-dd");

            _conn1.Open(_gConnectStr);
            ADODB.Recordset rs1 = new ADODB.Recordset();

            // Informationen des Azubis auslesen und darstellen
            switch (Abteilung)
            {
                case "Urlaub":
                    anfrage = "SELECT * FROM Urlaub WHERE kuerzel_Auszubildender = '" + Kuerzel + "' AND #" + formatDatum + "# BETWEEN Anfangsdatum AND Enddatum ;";
                    break;
                default:
                    anfrage = "SELECT * FROM Einsatz WHERE kuerzel_Auszubildender = '" + Kuerzel + "' AND #" + formatDatum + "# BETWEEN Anfangsdatum AND Enddatum ;";
                    break;
            }
            
            rs1.Open(anfrage, _conn1, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic);
            if (rs1.EOF && rs1.BOF)
            {
                einsatzExistiert = false;
            }
            // Schließen der Datenbankverbindung
            rs1.Close();
            _conn1.Close();
            return einsatzExistiert;
        }

        // Löscht den gesamten Einsatz mit dem entsprechenden Datum
        public void DeleteEinsatz(DateTime date, string art)
        {
            string anfrage;
            string formatDate = date.ToString("yyyy-MM-dd");

            _conn1.Open(_gConnectStr);
            ADODB.Recordset rs1 = new ADODB.Recordset();

            anfrage = "SELECT * FROM " + art + " WHERE kuerzel_Auszubildender = '" + Kuerzel + "' AND #" + formatDate + "# BETWEEN Anfangsdatum AND Enddatum ;";
            rs1.Open(anfrage, _conn1, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic);

            while (!rs1.EOF)
            {
                rs1.Delete();
                rs1.Update();
                rs1.MoveNext();
            }

            // Schließen der Datenbankverbindung
            rs1.Close();
            _conn1.Close();
        }
    }

}