using Logic;
using Logic.Classes;
using System;
using System.Threading;
using System.Windows.Forms;
using Logic.Classes.Enums;

namespace Kassasysteem
{
    public partial class LeveringScherm : Form
    {
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
            tbIceTeaVoorraad.Text = App.Voorraad.VindProductOpNaam("Ice Tea").Voorraad.ToString();
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
            Product product;
            int hoeveelheid = 0;
            try
            {
                if (tbAADrinkAantal.Text != "" && tbAADrinkColli.Text != "")
                {
                    product = App.Voorraad.VindProductOpNaam("AA-Drink");
                    hoeveelheid = Convert.ToInt32(tbAADrinkAantal.Text) * Convert.ToInt32(tbAADrinkColli.Text);
                    if (hoeveelheid > 0)
                    {
                        AddSupplies(product, hoeveelheid);
                    }
                }
                if (tbAquariusAantal.Text != "" && tbAquariusColli.Text != "")
                {
                    product = App.Voorraad.VindProductOpNaam("Aquarius");
                    hoeveelheid = Convert.ToInt32(tbAquariusAantal.Text) * Convert.ToInt32(tbAquariusColli.Text);
                    if (hoeveelheid > 0)
                    {
                        AddSupplies(product, hoeveelheid);
                    }
                }
                if (tbBitterlemonAantal.Text != "" && tbBitterlemonColli.Text != "")
                {
                    product = App.Voorraad.VindProductOpNaam("Bitter Lemon");
                    hoeveelheid = Convert.ToInt32(tbBitterlemonAantal.Text) * Convert.ToInt32(tbBitterlemonColli.Text);
                    if (hoeveelheid > 0)
                    {
                        AddSupplies(product, hoeveelheid);
                    }
                }
                if (tbCassisAantal.Text != "" && tbCassisColli.Text != "")
                {
                    product = App.Voorraad.VindProductOpNaam("Fanta Cassis");
                    hoeveelheid = Convert.ToInt32(tbCassisAantal.Text) * Convert.ToInt32(tbCassisColli.Text);
                    if (hoeveelheid > 0)
                    {
                        AddSupplies(product, hoeveelheid);
                    }
                }
                if (tbChocomelAantal.Text != "" && tbChocomelColli.Text != "")
                {
                    product = App.Voorraad.VindProductOpNaam("Chocomel");
                    hoeveelheid = Convert.ToInt32(tbChocomelAantal.Text) * Convert.ToInt32(tbChocomelColli.Text);
                    if (hoeveelheid > 0)
                    {
                        AddSupplies(product, hoeveelheid);
                    }
                }
                if (tbCocaColaAantal.Text != "" && tbCocaColaColli.Text != "")
                {
                    product = App.Voorraad.VindProductOpNaam("Coca Cola");
                    hoeveelheid = Convert.ToInt32(tbCocaColaAantal.Text) * Convert.ToInt32(tbCocaColaColli.Text);
                    if (hoeveelheid > 0)
                    {
                        AddSupplies(product, hoeveelheid);
                    }
                }
                if (tbColaZeroAantal.Text != "" && tbColaZeroColli.Text != "")
                {
                    product = App.Voorraad.VindProductOpNaam("Coca Cola Zero");
                    hoeveelheid = Convert.ToInt32(tbColaZeroAantal.Text) * Convert.ToInt32(tbColaZeroColli.Text);
                    if (hoeveelheid > 0)
                    {
                        AddSupplies(product, hoeveelheid);
                    }
                }
                if (tbFantaAantal.Text != "" && tbFantaColli.Text != "")
                {
                    product = App.Voorraad.VindProductOpNaam("Fanta");
                    hoeveelheid = Convert.ToInt32(tbFantaAantal.Text) * Convert.ToInt32(tbFantaColli.Text);
                    if (hoeveelheid > 0)
                    {
                        AddSupplies(product, hoeveelheid);
                    }
                }
                if (tbHertogJanAantal.Text != "" && tbHertogJanColli.Text != "")
                {
                    product = App.Voorraad.VindProductOpNaam("Hertog-Jan");
                    hoeveelheid = Convert.ToInt32(tbHertogJanAantal.Text) * Convert.ToInt32(tbHertogJanColli.Text);
                    if (hoeveelheid > 0)
                    {
                        AddSupplies(product, hoeveelheid);
                    }
                }
                if (tbIceTeaAantal.Text != "" && tbIceTeaColli.Text != "")
                {
                    product = App.Voorraad.VindProductOpNaam("Ice Tea");
                    hoeveelheid = Convert.ToInt32(tbIceTeaAantal.Text) * Convert.ToInt32(tbIceTeaColli.Text);
                    if (hoeveelheid > 0)
                    {
                        AddSupplies(product, hoeveelheid);
                    }
                }
                if (tbJupilerAantal.Text != "" && tbJupilerColli.Text != "")
                {
                    product = App.Voorraad.VindProductOpNaam("Jupiler Alcoholvrij");
                    hoeveelheid = Convert.ToInt32(tbJupilerAantal.Text) * Convert.ToInt32(tbJupilerColli.Text);
                    if (hoeveelheid > 0)
                    {
                        AddSupplies(product, hoeveelheid);
                    }
                }
                if (tbLeffeAantal.Text != "" && tbLeffeColli.Text != "")
                {
                    product = App.Voorraad.VindProductOpNaam("Leffe Bruin");
                    hoeveelheid = Convert.ToInt32(tbLeffeAantal.Text) * Convert.ToInt32(tbLeffeColli.Text);
                    if (hoeveelheid > 0)
                    {
                        AddSupplies(product, hoeveelheid);
                    }
                }
                if (tbMarsAantal.Text != "" && tbMarsColli.Text != "")
                {
                    product = App.Voorraad.VindProductOpNaam("Mars");
                    hoeveelheid = Convert.ToInt32(tbMarsAantal.Text) * Convert.ToInt32(tbMarsColli.Text);
                    if (hoeveelheid > 0)
                    {
                        AddSupplies(product, hoeveelheid);
                    }
                }
                if (tbNaturelChipsAantal.Text != "" && tbNaturelChipsColli.Text != "")
                {
                    product = App.Voorraad.VindProductOpNaam("Naturel Chips");
                    hoeveelheid = Convert.ToInt32(tbNaturelChipsAantal.Text) * Convert.ToInt32(tbNaturelChipsColli.Text);
                    if (hoeveelheid > 0)
                    {
                        AddSupplies(product, hoeveelheid);
                    }
                }
                if (tbPaprikaChipsAantal.Text != "" && tbPaprikaChipsColli.Text != "")
                {
                    product = App.Voorraad.VindProductOpNaam("Paprika Chips");
                    hoeveelheid = Convert.ToInt32(tbPaprikaChipsAantal.Text) * Convert.ToInt32(tbPaprikaChipsColli.Text);
                    if (hoeveelheid > 0)
                    {
                        AddSupplies(product, hoeveelheid);
                    }
                }
                //if (tbRodeWijnAantal.Text != "" && tbRodeWijnColli.Text != "")
                //{
                //    product = App.Voorraad.VindProductOpNaam("Rode Wijn");
                //    hoeveelheid = Convert.ToInt32(tbRodeWijnAantal.Text) * Convert.ToInt32(tbRodeWijnColli.Text);
                //    if (hoeveelheid > 0)
                //    {
                //        AddSupplies(product, hoeveelheid);
                //    }
                //}
                if (tbSchrobbelerAantal.Text != "" && tbSchrobbelerColli.Text != "")
                {
                    product = App.Voorraad.VindProductOpNaam("Schrobbeler");
                    hoeveelheid = Convert.ToInt32(tbSchrobbelerAantal.Text) * Convert.ToInt32(tbSchrobbelerColli.Text);
                    if (hoeveelheid > 0)
                    {
                        AddSupplies(product, hoeveelheid);
                    }
                }
                if (tbSnickersAantal.Text != "" && tbSnickersColli.Text != "")
                {
                    product = App.Voorraad.VindProductOpNaam("Snickers");
                    hoeveelheid = Convert.ToInt32(tbSnickersAantal.Text) * Convert.ToInt32(tbSnickersColli.Text);
                    if (hoeveelheid > 0)
                    {
                        AddSupplies(product, hoeveelheid);
                    }
                }
                if (tbSpaRoodAantal.Text != "" && tbSpaRoodColli.Text != "")
                {
                    product = App.Voorraad.VindProductOpNaam("Spa Rood");
                    hoeveelheid = Convert.ToInt32(tbSpaRoodAantal.Text) * Convert.ToInt32(tbSpaRoodColli.Text);
                    if (hoeveelheid > 0)
                    {
                        AddSupplies(product, hoeveelheid);
                    }
                }
                //if (tbWitteWijnAantal.Text != "" && tbWitteWijnColli.Text != "")
                //{
                //    product = App.Voorraad.VindProductOpNaam("Witte Wijn");
                //    hoeveelheid = Convert.ToInt32(tbWitteWijnAantal.Text) * Convert.ToInt32(tbWitteWijnColli.Text);
                //    if (hoeveelheid > 0)
                //    {
                //        AddSupplies(product, hoeveelheid);
                //    }
                //}
                SetAllToZero();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                                exception.Message);
            }
        }


        private void AddSupplies(Product product, int hoeveelheid)
        {
            App.VoegVoorraadToe(product, hoeveelheid);
            decimal inkoopprijs = 0.70m * hoeveelheid;
            App.Database.KassaLogRepo.AddLogString(App.Id, inkoopprijs + " euro uit kas voor inkoop", KassaSoortEnum.INKOOP);
        }

        private void SetAllToZero()
        {
            tbCocaColaAantal.Text = "0";
            tbColaZeroAantal.Text = "0";
            tbFantaAantal.Text = "0";
            tbCassisAantal.Text = "0";
            tbChocomelAantal.Text = "0";
            tbBitterlemonAantal.Text = "0";
            tbAquariusAantal.Text = "0";
            tbAADrinkAantal.Text = "0";
            tbHertogJanAantal.Text = "0";
            tbIceTeaAantal.Text = "0";
            tbJupilerAantal.Text = "0";
            tbLeffeAantal.Text = "0";
            tbSchrobbelerAantal.Text = "0";
            tbSpaRoodAantal.Text = "0";
            tbWitteWijnAantal.Text = "0";
            tbRodeWijnAantal.Text = "0";
            tbSnickersAantal.Text = "0";
            tbMarsAantal.Text = "0";
            tbNaturelChipsAantal.Text = "0";
            tbPaprikaChipsAantal.Text = "0";
        }
    }
}