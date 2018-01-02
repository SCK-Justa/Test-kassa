using Logic;
using Logic.Classes;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Kassasysteem
{
    public partial class LeveringScherm : Form
    {
        int cocacola;
        int colazero;
        int fanta;
        int cassis;
        int chocomel;
        int bitterlemon;
        int aquarius;
        int aadrink;
        int hertogjan;
        int icetea;
        int jupiler;
        int leffe;
        int schrobbeler;
        int sparood;
        int wittewijn;
        int rodewijn;
        int snickers;
        int mars;
        int naturelchips;
        int paprikachips;

        public KassaApp App { get; private set; }

        public LeveringScherm(KassaApp app)
        {
            InitializeComponent();
            App = app;
            InitialLoad();
        }

        private void btClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void InitialLoad()
        {
            tbColaVoorraad.Text = App.Voorraad.VindProductOpNaam("Coca Cola").Voorraad.ToString();
            tbColaZeroVoorraad.Text = App.Voorraad.VindProductOpNaam("Coca Cola Zero").Voorraad.ToString();
            tbFantaVoorraad.Text = App.Voorraad.VindProductOpNaam("Fanta").Voorraad.ToString();
            tbCassisVoorraad.Text = App.Voorraad.VindProductOpNaam("Fanta Cassis").Voorraad.ToString();
            tbChocomelVoorraad.Text = App.Voorraad.VindProductOpNaam("Chocomel").Voorraad.ToString();
            tbBitterlemonVoorraad.Text = App.Voorraad.VindProductOpNaam("Bitter Lemon").Voorraad.ToString();
            tbAquariusVoorraad.Text = App.Voorraad.VindProductOpNaam("Aquarius").Voorraad.ToString();
            tbAADrinkVoorraad.Text = App.Voorraad.VindProductOpNaam("AA-Drink").Voorraad.ToString();
            tbHertogJanVoorraad.Text = App.Voorraad.VindProductOpNaam("Hertog-Jan").Voorraad.ToString();
            tbIceTeaVoorraad.Text=  App.Voorraad.VindProductOpNaam("Ice Tea").Voorraad.ToString();
            tbJupilerVoorraad.Text = App.Voorraad.VindProductOpNaam("Jupiler Alcoholvrij").Voorraad.ToString();
            tbLeffeVoorraad.Text = App.Voorraad.VindProductOpNaam("Leffe Bruin").Voorraad.ToString();
            tbSchrobbelerVoorraad.Text = App.Voorraad.VindProductOpNaam("Schrobbeler").Voorraad.ToString();
            tbSpaRoodVoorraad.Text = App.Voorraad.VindProductOpNaam("Spa Rood").Voorraad.ToString();
            //tbWitteWijnVoorraad.Text = App.Voorraad.VindProductOpNaam("Witte Wijn").Voorraad.ToString();
            //tbRodeWijnVoorraad.Text = App.Voorraad.VindProductOpNaam("Rode Wijn").Voorraad.ToString();
            tbSnickersVoorraad.Text = App.Voorraad.VindProductOpNaam("Snickers").Voorraad.ToString();
            tbMarsVoorraad.Text = App.Voorraad.VindProductOpNaam("Mars").Voorraad.ToString();
            tbNaturelChipsVoorraad.Text = App.Voorraad.VindProductOpNaam("Naturel Chips").Voorraad.ToString();
            tbPaprikaChipsVoorraad.Text = App.Voorraad.VindProductOpNaam("Paprika Chips").Voorraad.ToString();
        }

        private void btToevoegen_Click(object sender, System.EventArgs e)
        {
            if(tbAADrinkAantal.Text != "" && tbAADrinkColli.Text != "")
            {
                Product product = App.Voorraad.VindProductOpNaam("AA-Drink");
                int hoeveelheid = Convert.ToInt32(tbAADrinkAantal.Text) * Convert.ToInt32(tbAADrinkColli.Text);
                AddSupplies(product, hoeveelheid);
            }
        }

        public void AddSupplies(Product product, int hoeveelheid)
        {

        }
    }
}