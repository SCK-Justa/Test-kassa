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
                _item.SubItems.Add(l.GetTussenvoegsel());
                _item.SubItems.Add(l.Achternaam);
                _item.SubItems.Add(l.GetEmailadres());
                _item.SubItems.Add(l.Adres.Straatnaam + ", " + l.Adres.Huisnummer);
                _item.SubItems.Add(l.Adres.Postcode);
                _item.SubItems.Add(l.Adres.Plaats);
                _item.SubItems.Add(l.GetTelefoonnummer());
                _item.SubItems.Add(l.GetMobielnummer());
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
                _item.SubItems.Add(l.GetNHBKlasseNaam());
                _item.SubItems.Add(l.Klasse.Naam);
                _item.SubItems.Add(l.Geslacht);
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

        private void btLogboek_Click(object sender, EventArgs e)
        {
            LedenLogScherm logScherm = new LedenLogScherm(App);
            logScherm.Show();
        }
    }
}
