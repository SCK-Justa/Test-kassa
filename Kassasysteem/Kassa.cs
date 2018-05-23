using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
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
                    gegevensWijzigenToolStripMenuItem.Visible = false;
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
                    if (today.Day < 10)
                    {
                        ChangeLbDagReden("Schutter van de maand");
                    }
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
            string specialDate = GetSpecialDate();
            if (specialDate != "")
            {
                lbBirthdaylb.Visible = true;
                ChangeLbDagReden(specialDate);
            }
        }

        private string GetSpecialDate()
        {
            return App.GetSpecialDate(DateTime.Now);
        }

        private string CheckForBirthdays()
        {
            string bdays = App.CheckForBirthdays();
            if (bdays == "")
            {
                lbBirthdaylb.Visible = false;
            }
            return App.CheckForBirthdays();
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
                    if (App.Authentication.Username == "Admin")
                    {
                        developerToolStripMenuItem.Visible = true;
                    }
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
                lbSpecialDate.Visible = false;
                developerToolStripMenuItem.Visible = false;
                string birthdays = CheckForBirthdays();
                if (birthdays != "")
                {
                    lbSpecialDate.Text = birthdays;
                    lbSpecialDate.Visible = true;
                }
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
                if (App.CheckDbConnection())
                {
                    foreach (LosseVerkoop p in App.GetLosseVerkopen(DateTime.Today.AddDays(-8), DateTime.Today))
                    {
                        if (p.IsLid)
                        {
                            UpdateListViewKlantBestelling(p, "€ 0,-",
                                "€" + p.Ledenprijs.ToString(CultureInfo.InvariantCulture), lvProductenInBestelling);
                        }
                        else
                        {
                            UpdateListViewKlantBestelling(p, "€ " + p.Prijs, "€ 0,-", lvProductenInBestelling);
                        }
                    }

                    BerekenPrijsLosseVerkopen();
                }
            }
        }

        private void AddProductToBestelling(string productnaam)
        {
            // Als er een product meteen verkocht wordt, zonder bestelling, wordt de if uitgevoerd.
            // Bij het toevogen van en product aan een bestelling, wordt de else uitgevoerd.
            if (!CheckIfBestelling())
            {
                if (_contanteVerkoop) // Losse verkoop als niet lid
                {
                    AddProductToSales(productnaam, false);
                }
                else // Losse verkoop als lid
                {
                    AddProductToSales(productnaam, true);
                }
            }
            else
            {
                AddOrder(productnaam);
            }
        }

        private bool CheckIfProductIsMunten(string productnaam)
        {
            if (productnaam.Equals("Munten"))
            {
                return true;
            }
            return false;
        }

        private void AddProductToSales(string productnaam, bool isAMember)
        {
            LosseVerkoop verkoop = null;
            Product product = App.VindProduct(productnaam);
            bool betalingBonnen = false;
            if (isAMember)
            {
                if (productnaam != "Munten")
                {
                    betalingBonnen = ShowBonnenScreen();
                }
            }
            verkoop = new LosseVerkoop(DateTime.Now, false, betalingBonnen, product.Id, product.Naam, product.Soort, product.Voorraad, product.Ledenprijs, product.Prijs);
            App.AddLosseVerkoop(verkoop);
            UpdateKlantBestelling(null);
        }

        private void AddOrder(string productnaam)
        {
            try
            {
                var bestelling = lvBestellingen.SelectedItems[0].Tag as Bestelling;
                List<Bestelling> bestellingen = App.GetBestellingen();
                if (bestelling != null && bestellingen != null)
                {
                    foreach (Bestelling b in bestellingen)
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
                SetKassaBonInfo(bestelling.GetBesteller(), "", "", "", true, true);
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
            AddProductToBestelling("Wolf 7");
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
            if (!_contanteVerkoop || _contanteVerkoopLid)
            {
                if (!CheckIfBestelling())
                {
                    AddProductToBestelling("Munten");
                }
                else
                {
                    MessageBox.Show("Munten kunnen alleen als losse verkoop worden verkocht.");
                }
            }
            else
            {
                MessageBox.Show("Alleen leden kunnen bonnen bestellen, zowel voor losse verkoop, als voor bestellingen.");
            }
        }

        private void btBoordjeFrikandel_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Broodje Frikandel");
        }

        private void btBroodjeKaas_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Broodje Kaas");
        }

        private void btBroodjeHam_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Broodje Ham");
        }

        private void btBroodjeKroket_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Broodje Kroket");
        }

        private void btMiniSnacks_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Mini Snacks");
        }

        private void btFrikandel_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Frikandel");
        }

        private void btKroket_Click(object sender, EventArgs e)
        {
            AddProductToBestelling("Kroket");
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
                try
                {
                    bestelling = lvBestellingen.SelectedItems[0].Tag as Bestelling;
                }
                catch (Exception) { }

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
                        MessageBox.Show($@"{verkoop.Naam} wordt als losse verkoop verwijderd.");
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
            Afmelden(true);
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
                if (App.Authentication != null)
                {
                    BestelgeschiedenisScherm geschiedenis = new BestelgeschiedenisScherm(App);
                    geschiedenis.ShowDialog();
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

        private void btEten_Click(object sender, EventArgs e)
        {
            // Gaat naar het menu eten
            SetMenu(true, false, false, false);
        }

        private void btDrinken_Click(object sender, EventArgs e)
        {
            // Gaat naar het menu dranken
            SetMenu(false, true, false, false);
        }

        private void btSterkeDranken_Click(object sender, EventArgs e)
        {
            // Gaat naar het menu sterke dranken
            SetMenu(false, false, false, true);
        }

        private void btTerug1_Click(object sender, EventArgs e)
        {
            // Gaat terug naar hoofdmenu
            SetMenu(false, false, true, false);
        }

        private void btTerug2_Click(object sender, EventArgs e)
        {
            // Gaat terug naar hoofdmenu
            SetMenu(false, false, true, false);
        }
        private void btTerug3_Click(object sender, EventArgs e)
        {
            // Gaat terug naar menu dranken
            SetMenu(false, true, false, false);
        }

        private void SetMenu(bool eten, bool drinken, bool menu, bool sterke)
        {
            gpEten.Visible = eten;
            gpDrinken.Visible = drinken;
            gpMenu.Visible = menu;
            gpSterkeDrank.Visible = sterke;

        }

        private void afmeldenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (App.Authentication != null)
            {
                Afmelden(false);
            }
        }

        private void Afmelden(bool afsluiten)
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
                    gegevensWijzigenToolStripMenuItem.Visible = false;
                    if (afsluiten)
                    {
                        Close();
                    }
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
            try
            {
                if (App.Authentication != null)
                {
                    ProductenScherm scherm = new ProductenScherm(App, null);
                    scherm.Show();
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
                    timer.Stop();
                    break;
                case BestellingSoortEnum.Losse_verkoop_niet_lid:
                    SelectSellMethod(false, false);
                    timer.Start();
                    break;
                case BestellingSoortEnum.Losse_verkoop_wel_lid:
                    SelectSellMethod(false, true);
                    timer.Start();
                    break;
            }
        }

        private void SelectSellMethod(bool isBestelling, bool isLid)
        {
            if (isBestelling)
            {
                gpNieuweKlant.Visible = true;
                _contanteVerkoop = false;
                _contanteVerkoopLid = false;
                btAfrekenen.Enabled = true;
            }
            else
            {
                SetKassaBonInfo("Losse bestellingen", "", "", "", false, false);
                UpdateKlantBestelling(null);
                if (isLid)
                {
                    _contanteVerkoop = false;
                    _contanteVerkoopLid = true;
                }
                else
                {
                    _contanteVerkoop = true;
                    _contanteVerkoopLid = false;
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            SelectSellMethod(true, true);
            cbSoortVerkoop.Text = "Bestelling";
            SetMenu(false, false, true, false);
        }

        private void SetKassaBonInfo(string klantnaam, string prijs, string ledenprijs, string datum, bool afrekenknop, bool verwijderknop)
        {
            lbKlantnaam.Text = klantnaam;
            lbDatumklant.Text = datum;
            lbTotaalPrijs.Text = prijs;
            lbLedenprijs.Text = ledenprijs;
            btAfrekenen.Enabled = afrekenknop;
            gpNieuweKlant.Visible = verwijderknop;
            lvProductenInBestelling.Items.Clear();
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
                if (App.Authentication != null)
                {
                    _omzetScherm = new PenningmeesterScherm(App);
                    _omzetScherm.ShowDialog();
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

        private void aanmeldenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                InlogScherm scherm = new InlogScherm(this, App, MessageType.LOGIN);
                aanmeldenToolStripMenuItem.Visible = false;
                afmeldenToolStripMenuItem1.Visible = true;
                gegevensWijzigenToolStripMenuItem.Visible = true;
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
            List<LosseVerkoop> losseVerkopen = App.GetLosseVerkopen(DateTime.Today.AddDays(-8), DateTime.Today);
            if (losseVerkopen != null && losseVerkopen.Count > 1)
            {
                SetKassaBonInfo("Losse verkopen", "", "", "Van " + DateTime.Now.AddDays(-8).ToShortDateString() + " tot " + DateTime.Now.ToShortDateString(), false, true);
                foreach (LosseVerkoop p in losseVerkopen)
                {
                    if (p.IsLid)
                    {
                        UpdateListViewKlantBestelling(p, "€ 0,-", "€ " + p.Ledenprijs.ToString(CultureInfo.InvariantCulture), lvProductenInBestelling);
                    }
                    else
                    {
                        UpdateListViewKlantBestelling(p, "€ " + p.Prijs, "€ 0,-", lvProductenInBestelling);
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
            foreach (LosseVerkoop lv in App.GetLosseVerkopen(DateTime.Today.AddDays(-8), DateTime.Today))
            {
                if (lv.IsLid)
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

        private void rekenmachineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = System.Diagnostics.Process.Start("calc.exe");
            p.WaitForInputIdle();
        }

        private bool ShowBonnenScreen()
        {
            DialogResult dialogResult = MessageBox.Show(@"Wordt er met bonnen betaald?", @"", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }

        private void updatesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UpdatesScreen scherm = new UpdatesScreen(App);
            scherm.Show();
        }

        private void vCRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (App.GetIsGemachtigd())
                {
                    VoorraadControleScherm scherm = new VoorraadControleScherm(App);
                    scherm.Show();
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

        private bool CheckIfBestelling()
        {
            if (_contanteVerkoop == false && _contanteVerkoopLid == false)
            {
                return true;
            }
            return false;
        }

        private bool testingValue = false;
        private void testingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!testingValue)
            {
                App.Database.SetConnection(false);
                testingToolStripMenuItem.Text = "Testing [on]";
            }
            else
            {
                App.Database.SetConnection(true);
                testingToolStripMenuItem.Text = "Testing [off]";
            }
            testingValue = !testingValue;
        }
    }
}