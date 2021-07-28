using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerischeTypen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CmdListString_Click(object sender, EventArgs e)
        {
            List<string> li = new List<string>();

            LstAusgabe.Items.Clear();

            li.Add("Spanien");
            li.Add("Belgien");
            li.Add("Schweiz");
            AusListString("Zu Beginn ", li);

            if (li.Contains("Belgien"))
                LstAusgabe.Items.Add("Enthält Belgien");

            LstAusgabe.Items.Add("Schweiz an Position: " + li.IndexOf("Schweiz"));
            LstAusgabe.Items.Add("Estland an Position: " + li.IndexOf("Estland"));

            if (li.Count >= 2)
                li.Insert(2, "Polen");

            AusListString("Nach einfügen an Position", li);

            if (li.Count >= 2)
                li.RemoveAt(1);
            AusListString("Nach löschen an Position", li);

            bool geloescht;
            do
                geloescht = li.Remove("Spanien"); //die Methode Remove() liefert den Wert true wenn erfolgreich gelöscht wurde, ansonsten false;
            while (geloescht);
            AusListString("Nach (mehrfachem) " + "Löschen eines Wertes", li);
        }


        private void AusListString(string s, List<string> lx)
        {
            string aus = s + ": ";
            foreach (string x in lx)
                aus += x + " ";
            /*for(int i=0; i<lx.Count; i++)
             * aus += lx[i]+" ";*/
            LstAusgabe.Items.Add(aus);
        }


        private void CmdListLand_Click(object sender, EventArgs e)
        {
            List<Land> li = new List<Land>();

            LstAusgabe.Items.Clear();

            li.Add(new Land("Spanien", "Madrid"));
            li.Add(new Land("Schweiz", "Bern"));
            AusListLand("Zu Beginn", li);

            if (li.Contains(new Land("Schweiz", "Bern")))
                LstAusgabe.Items.Add("Enthält Schweiz/Bern");

            LstAusgabe.Items.Add("Schweiz/Bern an Position: " + li.IndexOf(new Land("Schweiz", "Bern")));
            LstAusgabe.Items.Add("Estland/Tallinn an Position " + li.IndexOf(new Land("Estland", "Tallinn")));

            if (li.Count >= 1)
                li.Insert(1, new Land("Polen", "Warschau"));
            AusListLand("Nach einfügen an Position", li);

            if (li.Count >= 1)
                li.RemoveAt(0);
            AusListLand("Nach löschen an Position:", li);

            bool geloescht;
            do
                geloescht = li.Remove(new Land("Schweiz", "Bern"));
            while (geloescht);
            AusListLand("Nach (mehrfachem) löschen eines Wertes", li);

        }


        private void AusListLand(string s, List<Land>lx)
        {
            string aus = s + ": ";
            foreach (Land x in lx)
                aus += x + " ";
            LstAusgabe.Items.Add(aus);
        }


        private void CmdDictionary_Click(object sender, EventArgs e)
        {
            Dictionary<string, Land> dc = new Dictionary<string, Land>();

            LstAusgabe.Items.Clear();

            dc["E"] = new Land("Spanien", "Madrid");
            dc["CH"] = new Land("Schweiz", "Bern");

            LstAusgabe.Items.Add("Anzahl: " + dc.Count);
            AusDictKeys("Schlüssel", dc);
            AusDictValues("Werte", dc);
            AusDict("Zu Beginn", dc);

            if (dc.ContainsKey("CH"))
                LstAusgabe.Items.Add("Enthält Schlüssel CH");
            if (dc.ContainsValue(new Land("Schweiz", "Bern")))
                LstAusgabe.Items.Add("Enthält Wert Schweiz/Bern");

            dc["E"] = new Land("Ecuador", "Quito");
            AusDict("Nach ersetzen über Schlüssel", dc);

            dc.Remove("E");
            AusDict("Nach Löschen über Schlüssel", dc);
        }


        private void AusDictKeys(string s, Dictionary<string, Land> dx)
        {
            string aus = s + ": ";
            foreach (string sx in dx.Keys)
                aus += sx + " ";
            LstAusgabe.Items.Add(aus);
        }

        private void AusDictValues(string s, Dictionary<string, Land> dx)
        {
            string aus = s + ": ";
            foreach (Land sx in dx.Values)
                aus += sx + " ";
            LstAusgabe.Items.Add(aus);
        }

        private void AusDict(string s, Dictionary<string, Land> dx)
        {
            string aus = s + ": ";
            foreach (string sx in dx.Keys)
                aus += sx + "#"+dx[sx]+" ";
            LstAusgabe.Items.Add(aus);
        }
    }
}
