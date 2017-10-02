using System;
using System.Windows.Forms;
using Logic;
using Logic.Classes;

namespace Kassasysteem
{
    public partial class LedenScherm : Form
    {
        private ListViewItem _item;
        public KassaApp App { get; private set; }
        public LedenScherm(KassaApp app)
        {
            InitializeComponent();
            App = app;
            UpdateLedenlijst();
        }

        private void UpdateLedenlijst()
        {
            lvLeden.Items.Clear();
            foreach (Lid l in App.GetLeden())
            {
                _item = new ListViewItem(l.Bondsnummer.ToString());
                _item.SubItems.Add(l.Voornaam);
                if (l.Tussenvoegsel != "")
                {
                    _item.SubItems.Add(l.Tussenvoegsel);
                }
                else
                {
                    _item.SubItems.Add("");
                }
                _item.SubItems.Add(l.Achternaam);
                if (l.Emailadres != "")
                {
                    _item.SubItems.Add(l.Emailadres);
                }
                else
                {
                    _item.SubItems.Add("");
                }
                _item.SubItems.Add(l.Adres.Straatnaam + ", " + l.Adres.Huisnummer);
                _item.SubItems.Add(l.Adres.Postcode);
                _item.SubItems.Add(l.Adres.Plaats);
                if (l.Telefoonnummer != "")
                {
                    _item.SubItems.Add(l.Telefoonnummer.ToString());
                }
                else
                {
                    _item.SubItems.Add("");
                }
                if (l.Mobielnummer != "")
                {
                    _item.SubItems.Add(l.Mobielnummer.ToString());
                }
                else
                {
                    _item.SubItems.Add("");
                }
                _item.SubItems.Add(l.LidVanaf.ToShortDateString());
                if (l.Functie != "")
                {
                    _item.SubItems.Add(l.Functie);
                }
                else
                {
                    _item.SubItems.Add("");
                }
                _item.SubItems.Add(l.Geboortedatum.ToShortDateString());
                if (l.NhbKlasse != null)
                {
                    _item.SubItems.Add(l.NhbKlasse.Naam);
                }
                else
                {
                    _item.SubItems.Add("");
                }
                _item.SubItems.Add(l.Klasse.Naam);
                lvLeden.Items.Add(_item);
            }
        }

        private void btToevoegen_Click(object sender, System.EventArgs e)
        {
            try
            {
                LidToevoegenScherm scherm = new LidToevoegenScherm(App);
                scherm.ShowDialog();
                UpdateLedenlijst();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
