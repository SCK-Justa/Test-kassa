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
            SetButtonsForBestuur(App.Authentication.Lid.GetBestuursfunctie());
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
                _item.SubItems.Add(l.GetLidTypesAsString());
                _item.SubItems.Add(l.Geboortedatum.ToShortDateString());
                _item.SubItems.Add(l.GetNHBKlasseNaam());
                _item.SubItems.Add(l.Klasse.Naam);
                _item.SubItems.Add(l.Geslacht);
                _item.Tag = l;
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
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                                exception.Message);
            }
        }

        private void btLogboek_Click(object sender, EventArgs e)
        {
            LedenLogScherm logScherm = new LedenLogScherm(App);
            logScherm.Show();
        }

        private void Cancel(object sender, EventArgs e)
        {
            Close();
        }

        private void btVerwijderen_Click(object sender, EventArgs e)
        {
            try
            {
                Lid selectedLid = lvLeden.SelectedItems[0].Tag as Lid;
                if (selectedLid != null)
                {
                    DateTime olddate = DateTime.Now.AddMonths(1);
                    DateTime newDate = new DateTime(olddate.Year, olddate.Month, 1);
                    App.RemoveLidFromLedenlijst(selectedLid, newDate);
                    MessageBox.Show(selectedLid.GetLidNaam() + " is van de ledenlijst verwijderd.");
                }
                else
                {
                    throw new Exception("U moet een lid selecteren. Selecteer het bondsnummer van dit lid.");
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                                exception.Message);
            }
        }

        private void SetButtonsForBestuur(bool set)
        {
            btToevoegen.Enabled = set;
            btVerwijderen.Enabled = set;
            btBewerken.Enabled = set;
        }

        private void btBewerken_Click(object sender, EventArgs e)
        {
            try
            {
                Lid selectedLid = lvLeden.SelectedItems[0].Tag as Lid;
                LidToevoegenScherm scherm = new LidToevoegenScherm(App, selectedLid);
                scherm.Show();
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                                exception.Message);
            }
        }
    }
}
