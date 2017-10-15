using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using Kassasysteem;
using Logic;
using Logic.Classes;
using Microsoft.Win32;

namespace GUI
{
    public partial class Kassa : Form
    {
        public KassaApp App { get; }
        private AfrekenScherm _afrekenScherm;
        private ListViewItem _item;
        private VoorraadScherm _voorraadScherm;
        private PenningmeesterScherm _omzetScherm;
        private KasInUitScherm _kasinuitScherm;

        public Kassa(KassaApp app)
        {
            try
            {
                InitializeComponent();
                App = app;
                if (App.CheckDbConnection())
                {
                    UpdateKassaGegevens();
                    UpdateBestellingen();
                }
                else
                {
                    lbKassaNaam.Text = App.Lokatie;
                    lbDagDatum.Text = DateTime.Now.ToShortDateString();
                    lbOpenstaandeRekeningen.Text = "0";
                    lbLoginnaam.Text = App.Authentication.FullName;
                    lbKlantnaam.Text = "";
                    lbDatumklant.Text = "";
                    lbTotaalPrijs.Text = "";
                    lbLedenprijs.Text = "";
                    tbKlantnaam.Text = "";
                    cbLidNaam.Text = "";
                    btContant.Enabled = false;
                }
                cbLidNaam.Enabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                                exception.Message);
            }
        }

        private void btMaakBestelling_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbKlantnaam.Text != "" && cbLidNaam.Text != "")
                {
                    throw new Exception("Je kunt geen 2 namen tegelijk invoeren voor een klant.");
                }
                if (tbKlantnaam.Text != "")
                {
                    App.AddBestelling(tbKlantnaam.Text, DateTime.Now);
                    UpdateBestellingen();
                    UpdateKassaGegevens();
                }
                if (cbLidNaam.Text != "")
                {
                    Lid lid = App.GetLidByName(cbLidNaam.Text);
                    App.AddBestelling(lid, DateTime.Now);
                    UpdateBestellingen();
                    UpdateKassaGegevens();
                }
                if (tbKlantnaam.Text == "" && cbLidNaam.Text == "")
                {
                    // Do nothing
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                                exception.Message);
            }
        }

        private void UpdateAllesNaBetalen()
        {
            UpdateBestellingen();
            UpdateKassaGegevens();
            lbKlantnaam.Text = "";
            lbDatumklant.Text = "";
            lbTotaalPrijs.Text = "";
            lbLedenprijs.Text = "";
            lvProductenInBestelling.Items.Clear();
        }

        private void UpdateBestellingen()
        {
            lvBestellingen.Items.Clear();
            foreach (Bestelling b in App.GetBestellingen())
            {
                if (b.Betaald == false)
                {
                    if (b.Lid != null)
                    {
                        _item = new ListViewItem
                        {
                            Text = b.Lid.Voornaam + " " + b.Lid.Achternaam,
                            Tag = b
                        };
                        lvBestellingen.Items.Add(_item);
                    }
                    else
                    {
                        _item = new ListViewItem
                        {
                            Text = b.Naam,
                            Tag = b
                        };
                        lvBestellingen.Items.Add(_item);
                    }
                }
            }
        }

        private void UpdateLeden()
        {
            List<Lid> leden = App.GetLeden();
            cbLidNaam.Items.Clear();
            if (leden != null)
            {
                foreach (Lid lid in leden)
                {
                    if (lid.Tussenvoegsel != null || lid.Tussenvoegsel != "")
                    {
                        cbLidNaam.Items.Add(lid.Voornaam + " " + lid.Tussenvoegsel + " " + lid.Achternaam);
                    }
                    else
                    {
                        cbLidNaam.Items.Add(lid.Voornaam + " " + lid.Achternaam);
                    }
                }
            }
        }

        private void UpdateKassaGegevens()
        {
            try
            {
                lbKassaNaam.Text = App.Lokatie;
                UpdateLeden();
                lbOpenstaandeRekeningen.Text = App.GetBestellingen().Count.ToString();
                lbDagDatum.Text = DateTime.Now.ToShortDateString();
                lbLoginnaam.Text = App.Authentication.FullName;
                lbKlantnaam.Text = "";
                lbDatumklant.Text = "";
                lbTotaalPrijs.Text = "";
                lbLedenprijs.Text = "";
                tbKlantnaam.Text = "";
                cbLidNaam.Text = "";
                btContant.Enabled = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }

        private void UpdateKlantBestelling(Bestelling bestelling)
        {
            lvProductenInBestelling.Items.Clear();
            if (bestelling != null)
            {
                foreach (Product p in bestelling.GetProducten())
                {
                    ListViewItem lvi = new ListViewItem(p.Naam);
                    lvi.SubItems.Add("€" + p.Prijs);
                    lvi.SubItems.Add("€" + p.Ledenprijs.ToString(CultureInfo.InvariantCulture));
                    lvi.Tag = p;
                    lvProductenInBestelling.Items.Add(lvi);
                }
                lbTotaalPrijs.Text = @"€" + bestelling.TotaalPrijs.ToString(CultureInfo.InvariantCulture);
                lbLedenprijs.Text = @"€" + bestelling.TotaalLedenPrijs.ToString(CultureInfo.InvariantCulture);
                lbDatumklant.Text = bestelling.Datum.ToShortDateString() + @" - " + bestelling.Datum.ToShortTimeString();
            }
        }

        private void AddProductToBestelling(string productnaam)
        {
            try
            {
                var bestelling = lvBestellingen.SelectedItems[0].Tag as Bestelling;
                if (bestelling != null)
                {
                    foreach (Bestelling b in App.GetBestellingen())
                    {
                        if (b.Id == bestelling.Id)
                        {
                            lvProductenInBestelling.Items.Clear();
                            Product product = App.VindProduct(productnaam);
                            if (product != null)
                            {
                                App.AddProductToBestelling(b, product);
                                UpdateKlantBestelling(b);
                            }
                            else
                            {
                                MessageBox.Show(
                                    @"Het systeem kent dit product niet, raadpleeg uw nerd voor verdere hulp.");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("U doet een losse verkoop");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden! Mogelijke oplossing: selecteer een bestelling. "
                    + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }

        private void btAfrekenen_Click(object sender, EventArgs e)
        {
            try
            {
                var bestelling = lvBestellingen.SelectedItems[0].Tag as Bestelling;
                foreach (Bestelling b in App.GetBestellingen())
                {
                    if (b.Naam == bestelling.Naam || b.Lid == bestelling.Lid)
                    {
                        _afrekenScherm = new AfrekenScherm(App, b);
                        _afrekenScherm.ShowDialog();
                        UpdateAllesNaBetalen();
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }

        private void lvBestellingen_Click(object sender, EventArgs e)
        {
            var bestelling = lvBestellingen.SelectedItems[0].Tag as Bestelling;
            foreach (Bestelling b in App.GetBestellingen())
            {
                if (b.Lid != null)
                {
                    if (b.Lid.Id == bestelling.Lid.Id)
                    {
                        if (b.Lid.Tussenvoegsel != "")
                        {
                            lbKlantnaam.Text = b.Lid.Voornaam + " " + b.Lid.Tussenvoegsel + " " + b.Lid.Achternaam;
                        }
                        else
                        {
                            lbKlantnaam.Text = b.Lid.Voornaam + " " + b.Lid.Achternaam;
                        }
                        lvProductenInBestelling.Items.Clear();
                        UpdateKlantBestelling(b);
                        btVerwijderProduct.Enabled = true;
                        btAfrekenen.Enabled = true;
                        groupBox4.Enabled = true;
                        break;
                    }
                }
                else
                {
                    if (b.Naam == bestelling.Naam)
                    {
                        lbKlantnaam.Text = b.Naam;
                        lvProductenInBestelling.Items.Clear();
                        UpdateKlantBestelling(b);
                        btVerwijderProduct.Enabled = true;
                        btAfrekenen.Enabled = true;
                        groupBox4.Enabled = true;
                        break;
                    }
                }
            }
        }
        #region buttonclicks
        private void btKoffie_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Koffie");
        }

        private void btThee_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Thee");
        }

        private void btCocaCola_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Coca Cola");
        }

        private void btCocaColaZero_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Coca Cola Zero");
        }

        private void btFantaSinas_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Fanta");
        }

        private void btFantaCassis_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Fanta Cassis");
        }

        private void btSpaRood_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Spa Rood");
        }

        private void btBitterLemon_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Bitter Lemon");
        }

        private void btIceTea_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Ice Tea");
        }

        private void btChocomel_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Chocomel");
        }

        private void btAaDrink_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("AA-Drink");
        }

        private void btAquarius_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Aquarius");
        }

        private void btHertogJan_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Hertog-Jan");
        }

        private void btJupiler_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Jupiler Alcoholvrij");
        }

        private void btAmstelRadler_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Amstel Radler");
        }

        private void btLeffeBruin_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Leffe Bruin");
        }

        private void btWisselendSpeciaalBier_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Barbar Blond");
        }

        private void btAndereSpeciaal_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Joope Witbier");
        }

        private void btRodeWijn_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Rode Wijn");
        }

        private void btWitteWijn_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Witte Wijn");
        }

        private void btMars_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Mars");
        }

        private void btSnickers_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Snickers");
        }

        private void btCrokyNaturel_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Naturel Chips");
        }

        private void btCrokyPaprika_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Paprika Chips");
        }

        private void btBiFi_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("BiFi");
        }

        private void btBonnenkaart_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Bonnenkaart");
        }

        private void btSchrobbeler_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Schrobbeler");
        }
        #endregion

        private void btVerwijderProduct_Click(object sender, EventArgs e)
        {
            try
            {
                var bestelling = lvBestellingen.SelectedItems[0].Tag as Bestelling;

                if (bestelling != null)
                {
                    var product = lvProductenInBestelling.SelectedItems[0].Tag as Product;
                    if (product != null)
                    {
                        MessageBox.Show($@"{product.Naam} wordt uit de bestelling van {bestelling.Lid.Voornaam} verwijderd.");
                        App.RemoveProductVanBestelling(bestelling, product);
                        UpdateKlantBestelling(bestelling);
                    }
                    else
                    {
                        MessageBox.Show(@"Product is niet uit bestelling verwijderd.");
                    }
                }
                else
                {
                    MessageBox.Show(@"Een error is opgetreden!");
                }
                UpdateBestellingen();
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                                exception.Message);
            }
        }

        private void afmeldenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show(@"Weet u zeker dat u wilt afmelden?", @"Afmelden",
                    MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    // Alle bestellingen updaten in DB
                    Close();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                              exception.Message);
            }
        }

        private void gegevensWijzigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                InlogScherm login = new InlogScherm(this, App);
                login.ShowDialog();
                UpdateBestellingen();
                UpdateKassaGegevens();
                UpdateKlantBestelling(null);
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                                exception.Message);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _voorraadScherm = new VoorraadScherm(App);
            _voorraadScherm.ShowDialog();
        }

        private void andereInkomstenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _kasinuitScherm = new KasInUitScherm(App);
                _kasinuitScherm.Show();
                UpdateKassaGegevens();
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                                exception.Message);
            }
        }

        private void omzetInzienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _omzetScherm = new PenningmeesterScherm(App);
                _omzetScherm.ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                                exception.Message);
            }
        }

        private void bestelgeschiedenisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BestelgeschiedenisScherm geschiedenis = new BestelgeschiedenisScherm(App);
                geschiedenis.ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                                exception.Message);
            }
        }

        private void ledenlijstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LedenScherm leden = new LedenScherm(App);
            leden.ShowDialog();
        }

        private void btContant_Click(object sender, EventArgs e)
        {
            lvBestellingen.SelectedItems.Clear();
        }
    }
}