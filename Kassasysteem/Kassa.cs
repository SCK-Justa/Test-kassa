using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Kassasysteem;
using Logic;
using Logic.Classes;
using Logic.Classes.Enums;

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

        private bool _contanteVerkoop;
        private bool _contanteVerkoopLid;

        public Kassa()
        {
            try
            {
                InitializeComponent();
                App = new KassaApp("Barkassa");
                _contanteVerkoop = false;
                _contanteVerkoopLid = false;
                timer.Start();
                CheckDay();
                if (App.CheckDbConnection())
                {
                    aanmeldenToolStripMenuItem.Visible = true;
                    afmeldenToolStripMenuItem1.Visible = false;
                    UpdateKassaGegevens();
                    UpdateBestellingen();
                }
                else
                {
                    lbKassaNaam.Text = App.Lokatie;
                    lbDagDatum.Text = DateTime.Now.ToShortDateString();
                    lbOpenstaandeRekeningen.Text = @"0";
                    lbLoginnaam.Text = @"Admin";
                    lbKlantnaam.Text = "";
                    lbDatumklant.Text = "";
                    lbTotaalPrijs.Text = "";
                    lbLedenprijs.Text = "";
                    tbKlantnaam.Text = "";
                    cbLidNaam.Enabled = false;
                    lbConnectie.Text = @"mislukt";
                    lbConnectie.ForeColor = Color.Red;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                                exception.Message);
            }
        }

        private void CheckDay()
        {
            DateTime today = DateTime.Now;
            switch (today.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    ChangeLbDagReden("");
                    break;
                case DayOfWeek.Tuesday:
                    ChangeLbDagReden("Clubtraining");
                    break;
                case DayOfWeek.Wednesday:
                    ChangeLbDagReden("");
                    break;
                case DayOfWeek.Thursday:
                    ChangeLbDagReden("Training");
                    break;
                case DayOfWeek.Friday:
                    ChangeLbDagReden("Jeugdtraining");
                    break;
                case DayOfWeek.Saturday:
                    ChangeLbDagReden("");
                    break;
                case DayOfWeek.Sunday:
                    ChangeLbDagReden("Training");
                    break;
            }
        }

        private void ChangeLbDagReden(string text)
        {
            lbDagReden.Text = text;
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
                    _item = new ListViewItem
                    {
                        Text = b.GetBesteller(),
                        Tag = b
                    };
                    lvBestellingen.Items.Add(_item);
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
                    cbLidNaam.Items.Add(lid.GetLidNaam());
                }
            }
        }

        private void UpdateKassaGegevens()
        {
            try
            {
                if (App.Database.GetIsConnected())
                {
                    UpdateLeden();
                }
                lbKassaNaam.Text = App.Lokatie;
                lbOpenstaandeRekeningen.Text = App.GetBestellingen().Count.ToString();
                lbDagDatum.Text = DateTime.Now.DayOfWeek + " " + DateTime.Now.ToShortDateString();
                if (App.Authentication != null)
                {
                    label4.Visible = true;
                    lbLoginnaam.Visible = true;
                    lbLoginnaam.Text = App.Authentication.GetFullName();
                }
                else
                {
                    label4.Visible = false;
                    lbLoginnaam.Visible = false;
                }
                lbKlantnaam.Text = "";
                lbDatumklant.Text = "";
                lbTotaalPrijs.Text = "";
                lbLedenprijs.Text = "";
                tbKlantnaam.Text = "";
                cbLidNaam.Text = "";
                if (App.Database.GetIsConnected())
                {
                    lbConnectie.Text = @"gelukt";
                    lbConnectie.ForeColor = Color.Green;
                }
                gpDrinken.Visible = false;
                gpEten.Visible = false;
                gpMenu.Visible = true;
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
                    UpdateListViewKlantBestelling(p, "€" + p.Prijs, "€" + p.Ledenprijs.ToString(CultureInfo.InvariantCulture), lvProductenInBestelling);
                }
                lbTotaalPrijs.Text = @"€" + bestelling.TotaalPrijs.ToString(CultureInfo.InvariantCulture);
                lbLedenprijs.Text = @"€" + bestelling.TotaalLedenPrijs.ToString(CultureInfo.InvariantCulture);
                lbDatumklant.Text = bestelling.Datum.ToShortDateString() + @" - " + bestelling.Datum.ToShortTimeString();
            }
            else
            {
                foreach (LosseVerkoop p in App.GetLosseVerkopen())
                {
                    if (p.IsLid)
                    {
                        UpdateListViewKlantBestelling(p, "€ 0,-", "€" + p.Ledenprijs.ToString(CultureInfo.InvariantCulture), lvProductenInBestelling);
                    }
                    else
                    {
                        UpdateListViewKlantBestelling(p, "€ " + p.Prijs, "€ 0,-", lvProductenInBestelling);
                    }
                }
                BerekenPrijsLosseVerkopen();
            }
        }

        private void AddProductToBestelling(string productnaam)
        {
            // Als er een product meteen verkocht wordt, zonder bestelling, wordt de if uitgevoerd.
            // Bij het toevogen van en product aan een bestelling, wordt de else uitgevoerd.
            LosseVerkoop verkoop = null;
            if (_contanteVerkoop || _contanteVerkoopLid)
            {
                if (_contanteVerkoop) // Losse verkoop als niet lid
                {
                    Product product = App.VindProduct(productnaam);
                    verkoop = new LosseVerkoop(DateTime.Now, false, product.Id, product.Naam, product.Soort, product.Voorraad, product.Ledenprijs, product.Prijs);
                    App.AddLosseVerkoop(verkoop);
                    UpdateKlantBestelling(null);
                }
                else // Losse verkoop als lid
                {
                    Product product = App.VindProduct(productnaam);
                    verkoop = new LosseVerkoop(DateTime.Now, true, product.Id, product.Naam, product.Soort, product.Voorraad, product.Ledenprijs, product.Prijs);
                    App.AddLosseVerkoop(verkoop);
                    UpdateKlantBestelling(null);
                }
            }
            else
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
                        MessageBox.Show(@"U doet een losse verkoop");
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(@"Een error is opgetreden! Mogelijke oplossing: selecteer een bestelling. "
                                    + Environment.NewLine + Environment.NewLine + exception.Message);
                }
            }
        }

        private void btAfrekenen_Click(object sender, EventArgs e)
        {
            try
            {
                var bestelling = lvBestellingen.SelectedItems[0].Tag as Bestelling;
                if (bestelling != null)
                {
                    _afrekenScherm = new AfrekenScherm(App, bestelling);
                    _afrekenScherm.ShowDialog();
                    UpdateAllesNaBetalen();
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
            if (bestelling != null)
            {
                lbKlantnaam.Text = bestelling.GetBesteller();
                lvProductenInBestelling.Items.Clear();
                UpdateKlantBestelling(bestelling);
                btVerwijderProduct.Enabled = true;
                btAfrekenen.Enabled = true;
            }
            else
            {
                MessageBox.Show(@"Er is geen bestelling geselecteerd.");
            }
        }
        #region buttonclicks_producten
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
            AddProductToBestelling("Munten");
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
                Bestelling bestelling = null;
                try{
                     bestelling = lvBestellingen.SelectedItems[0].Tag as Bestelling;
                } catch(Exception) { }

                if (bestelling != null)
                {
                    var product = lvProductenInBestelling.SelectedItems[0].Tag as Product;
                    if (product != null)
                    {
                        App.RemoveProductVanBestelling(bestelling, product, null);
                        MessageBox.Show($@"{product.Naam} wordt uit de bestelling van {bestelling.GetBesteller()} verwijderd.");
                        UpdateKlantBestelling(bestelling);
                    }
                    else
                    {
                        MessageBox.Show(@"Product is niet uit bestelling verwijderd.");
                    }
                }
                else
                {
                    var verkoop = lvProductenInBestelling.SelectedItems[0].Tag as LosseVerkoop;
                    if (verkoop != null)
                    {
                        App.RemoveProductVanBestelling(null, null, verkoop);
                        MessageBox.Show($@"{verkoop.Naam} wordt als losse verkoop.");
                        UpdateKlantBestelling(null);
                    }
                    else
                    {
                        throw new Exception("Selecteer eerst een bestelling of losse verkoop.");
                    }
                }
                UpdateBestellingen();
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                                exception.Message);
                UpdateBestellingen();
            }
        }

        private void afmeldenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Afmelden();
            Close();
        }

        private void gegevensWijzigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                InlogScherm login = new InlogScherm(this, App, MessageType.EDIT_ACCOUNT);
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

        private void btEten_Click(object sender, EventArgs e)
        {
            gpEten.Visible = true;
            gpDrinken.Visible = false;
            gpMenu.Visible = false;
        }

        private void btDrinken_Click(object sender, EventArgs e)
        {
            gpDrinken.Visible = true;
            gpEten.Visible = false;
            gpMenu.Visible = false;
        }

        private void btTerug1_Click(object sender, EventArgs e)
        {
            gpMenu.Visible = true;
            gpEten.Visible = false;
            gpDrinken.Visible = false;
        }

        private void btTerug2_Click(object sender, EventArgs e)
        {
            gpMenu.Visible = true;
            gpDrinken.Visible = false;
            gpEten.Visible = false;
        }

        private void afmeldenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (App.Authentication != null)
            {
                Afmelden();
            }
        }

        private void Afmelden()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show(@"Weet u zeker dat u wilt afmelden?", @"Afmelden",
                    MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    App.SetAuthentication(null);
                    UpdateKassaGegevens();
                    aanmeldenToolStripMenuItem.Visible = true;
                    afmeldenToolStripMenuItem1.Visible = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                                exception.Message);
            }
        }

        private void verkoopgeschiedenisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: losse verkopen weergave 
        }

        private void sUKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (App.GetIsGemachtigd())
                {
                    _kasinuitScherm = new KasInUitScherm(App);
                    _kasinuitScherm.Show();
                }
                else
                {
                    throw new Exception("U heeft geen toegang tot deze pagina.");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                    exception.Message);
            }
        }

        private void cbSoortVerkoop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selected = cbSoortVerkoop.SelectedItem.ToString();
                if (selected == null)
                {
                    throw new Exception("Er is niets geselecteerd.");
                }
                if (selected == "Losse verkoop wel lid")
                {
                    BestellingSoortEnum soort = BestellingSoortEnum.Losse_verkoop_wel_lid;
                    SelectCorrectSellMethod(soort);
                }
                else
                {
                    if (selected == "Losse verkoop niet lid")
                    {
                        BestellingSoortEnum soort = BestellingSoortEnum.Losse_verkoop_niet_lid;
                        SelectCorrectSellMethod(soort);
                    }
                    else
                    {
                        BestellingSoortEnum soort = (BestellingSoortEnum)Enum.Parse(typeof(BestellingSoortEnum), selected);
                        SelectCorrectSellMethod(soort);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }

        private void SelectCorrectSellMethod(BestellingSoortEnum sellMethod)
        {
            switch (sellMethod)
            {
                case BestellingSoortEnum.Bestelling:
                    SelectSellMethod(true, true);
                    break;
                case BestellingSoortEnum.Losse_verkoop_niet_lid:
                    SelectSellMethod(false, false);
                    break;
                case BestellingSoortEnum.Losse_verkoop_wel_lid:
                    SelectSellMethod(false, true);
                    break;
            }
        }

        private void SelectSellMethod(bool isBestelling, bool isLid)
        {
            if (isBestelling)
            {
                groupBox6.Visible = true;
                _contanteVerkoop = false;
                _contanteVerkoopLid = false;
            }
            else
            {
                lvProductenInBestelling.Items.Clear();
                UpdateKlantBestelling(null);
                if (isLid)
                {
                    groupBox6.Visible = false;
                    _contanteVerkoop = false;
                    _contanteVerkoopLid = true;
                }
                else
                {
                    groupBox6.Visible = false;
                    _contanteVerkoop = true;
                    _contanteVerkoopLid = false;
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            SelectSellMethod(true, true);
            cbSoortVerkoop.Text = "Bestelling";
        }

        private void voorraadToevoegenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (App.GetIsGemachtigd())
                {
                    LeveringScherm scherm = new LeveringScherm(App);
                    scherm.Show();
                }
                else
                {
                    throw new Exception("U heeft geen toegang tot deze pagina.");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void aanmeldenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                InlogScherm scherm = new InlogScherm(this, App, MessageType.LOGIN);
                aanmeldenToolStripMenuItem.Visible = false;
                afmeldenToolStripMenuItem1.Visible = true;
                scherm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateKassaGegevensEvent(object sender, EventArgs e)
        {
            UpdateKassaGegevens();
        }

        private void openToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (App.Authentication != null)
                {
                    LedenScherm leden = new LedenScherm(App);
                    leden.ShowDialog();
                    UpdateLeden();
                }
                else
                {
                    throw new Exception("U heeft geen toegang tot deze pagina." + Environment.NewLine +
                        "Log in voor toegang tot deze pagina.");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                                exception.Message);
            }
        }

        private void btLosseVerkopen_Click(object sender, EventArgs e)
        {
            lvProductenInBestelling.Items.Clear();
            List<LosseVerkoop> losseVerkopen = App.GetLosseVerkopen();
            if (losseVerkopen != null && losseVerkopen.Count > 1)
            {
                lbKlantnaam.Text = "Losse verkopen";
                lbTotaalPrijs.Text = "";
                lbLedenprijs.Text = "";
                lbDatumklant.Text = "Van " + DateTime.Now.AddDays(-8).ToShortDateString() + " tot " + DateTime.Now.ToShortDateString();
                foreach (LosseVerkoop p in losseVerkopen)
                {
                    if (p.IsLid)
                    {
                        UpdateListViewKlantBestelling(p, "€ 0,-", "€ "+ p.Ledenprijs.ToString(CultureInfo.InvariantCulture), lvProductenInBestelling);
                    }
                    else
                    {
                        UpdateListViewKlantBestelling(p, "€ "+p.Prijs, "€ 0,-", lvProductenInBestelling);
                    }
                }
                BerekenPrijsLosseVerkopen();
            }
        }

        private void UpdateListViewKlantBestelling(Product p, string prijs, string ledenprijs, ListView listView)
        {
            ListViewItem lvi = new ListViewItem(p.Naam);
            lvi.SubItems.Add(prijs);
            lvi.SubItems.Add(ledenprijs);
            lvi.Tag = p;
            listView.Items.Add(lvi);
        }

        private void BerekenPrijsLosseVerkopen()
        {
            decimal prijs = 0.00m;
            decimal ledenprijs = 0.00m;
            foreach (LosseVerkoop lv in App.GetLosseVerkopen())
            {
                if(lv.IsLid)
                {
                    ledenprijs += lv.Ledenprijs;
                }
                else
                {
                    prijs += lv.Prijs;
                }
            }
            lbTotaalPrijs.Text = @"€ " + prijs;
            lbLedenprijs.Text = @"€ " + ledenprijs;
            lbDatumklant.Text = DateTime.Today.ToShortDateString();
        }
    }
}