using System;
using System.Windows.Forms;
using Logic;
using Logic.Classes;

namespace Kassasysteem
{
    public partial class LidToevoegenScherm : Form
    {
        private string voornaam;
        private string tussenvoegsel;
        private string achternaam;
        private string straatnaam;
        private string huisnummer;
        private string postcode;
        private string woonplaats;
        private string bankrekening;
        private string geslacht;
        private string emailadres;
        private string telefoonnummer;
        private string mobielnummer;
        private DateTime geboortedatum;
        private DateTime lidvanaf;

        private int counter;

        public KassaApp App { get; private set; }
        public LidToevoegenScherm(KassaApp app)
        {
            InitializeComponent();
            App = app;
        }

        private void btOpslaan_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbVoornaam.Text != "")
                {
                    voornaam = tbVoornaam.Text;
                    if (tbTussenvoegsel.Text != "")
                    {
                        tussenvoegsel = tbTussenvoegsel.Text;
                    }
                    else
                    {
                        tussenvoegsel = null;
                    }
                    if (tbAchternaam.Text != "")
                    {
                        achternaam = tbAchternaam.Text;
                        if (tbStraatnaam.Text != "")
                        {
                            straatnaam = tbStraatnaam.Text;
                            if (tbHuisnummer.Text != "")
                            {
                                huisnummer = tbHuisnummer.Text;
                                if (tbPostcode.Text != "")
                                {
                                    postcode = tbPostcode.Text;
                                    if (tbWoonplaats.Text != "")
                                    {
                                        woonplaats = tbWoonplaats.Text;
                                        if (tbBankrekening.Text != "")
                                        {
                                            bankrekening = tbBankrekening.Text;
                                            if (cbGeslacht.Text != "")
                                            {
                                                geslacht = cbGeslacht.Text;
                                                if (tbEmailadres.Text != "")
                                                {
                                                    emailadres = tbEmailadres.Text;
                                                    if (tbTelefoonnummer.Text != "")
                                                    {
                                                        telefoonnummer = tbTelefoonnummer.Text;
                                                    }
                                                    else
                                                    {
                                                        telefoonnummer = "";
                                                    }
                                                    if (tbMobielnummer.Text != "")
                                                    {
                                                        mobielnummer = tbMobielnummer.Text;
                                                    }
                                                    if (dtGebdatum.Value < DateTime.Now)
                                                    {
                                                        geboortedatum = dtGebdatum.Value;
                                                        lidvanaf = dtLidVanafDatum.Value;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                Adres adres = new Adres(straatnaam, huisnummer, postcode, woonplaats);
                adres.SetEmail("Geen Email");
                Bank bank = new Bank("INGBank", tbBankrekening.Text);
                Oudercontact oc = new Oudercontact(tbOVoornaam.Text, tbOTussenvoegsel.Text, tbOAchternaam.Text, tbOTel1.Text, tbOTel2.Text, tbOEmail1.Text, tbOTel2.Text);
                Lid lid = new Lid(lidvanaf, null, null, 0, voornaam, tussenvoegsel, achternaam, emailadres, geslacht,
                                    geboortedatum, adres, telefoonnummer, mobielnummer);
                lid.SetBank(bank);
                lid.SetOuderContact(oc);
                App.AddLid(lid);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (counter)
            {
                case 0:
                    Width = 684;
                    btOuder.Text = "Cancel";
                    counter++;
                    break;
                case 1:
                    Width = 493;
                    btOuder.Text = "Oudercontact toevoegen";
                    counter = 0;
                    break;
            }
        }
    }
}
