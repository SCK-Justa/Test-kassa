using System;
using System.Windows.Forms;
using Logic;
using Logic.Classes;

namespace Kassasysteem
{
    public partial class LidToevoegenScherm : Form
    {
        private Lid lid;
        private int bondsnummer;
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

        private bool _counterOudercontact;

        public KassaApp App { get; private set; }
        public LidToevoegenScherm(KassaApp app)
        {
            InitializeComponent();
            App = app;
            SetOudercontactVisable(false);
            _counterOudercontact = false;
        }

        public LidToevoegenScherm(KassaApp app, Lid lid)
        {
            InitializeComponent();
            App = app;
            this.lid = lid;
            FillForm();
        }

        private void btOpslaan_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckFields())
                {
                    if (this.lid == null)
                    {
                        Adres adres = new Adres(straatnaam, huisnummer, postcode, woonplaats);
                        adres.SetEmail("Geen Email");
                        string str = bankrekening.Substring(4, 4);
                        BankNaamEnum bankNaam = (BankNaamEnum)Enum.Parse(typeof(BankNaamEnum), str);
                        Bank bank = new Bank(CheckBankCode(bankNaam), tbBankrekening.Text);
                        tbBankrekening.Text = CheckBankCode(bankNaam);
                        Oudercontact oc;
                        if (tbOVoornaam.Text == "" && tbOAchternaam.Text == "")
                        {
                            oc = null;
                        }
                        else
                        {
                            oc = new Oudercontact(tbOVoornaam.Text, tbOTussenvoegsel.Text, tbOAchternaam.Text,
                                tbOTel1.Text,
                                tbOTel2.Text, tbOEmail1.Text, tbOTel2.Text);
                        }
                        Lid lid = new Lid(lidvanaf, bondsnummer, voornaam, tussenvoegsel, achternaam, emailadres, geslacht,
                            geboortedatum, adres, telefoonnummer, mobielnummer);
                        lid.SetBank(bank);
                        lid.SetOuderContact(oc);
                        App.AddLid(lid);
                    }
                    else
                    {
                        Adres adres = new Adres(straatnaam, huisnummer, postcode, woonplaats);
                        adres.SetEmail("Geen Email");
                        string str = bankrekening.Substring(4, 4);
                        BankNaamEnum bankNaam = (BankNaamEnum)Enum.Parse(typeof(BankNaamEnum), str);
                        Bank bank = new Bank(CheckBankCode(bankNaam), tbBankrekening.Text);
                        tbBankrekening.Text = CheckBankCode(bankNaam);
                        Oudercontact oc;
                        if (tbOVoornaam.Text == "" && tbOAchternaam.Text == "")
                        {
                            oc = null;
                        }
                        else
                        {
                            oc = new Oudercontact(tbOVoornaam.Text, tbOTussenvoegsel.Text, tbOAchternaam.Text,
                                tbOTel1.Text,
                                tbOTel2.Text, tbOEmail1.Text, tbOTel2.Text);
                        }
                        Lid nieuwLid = new Lid(lidvanaf, bondsnummer, voornaam, tussenvoegsel, achternaam, emailadres, geslacht, geboortedatum, adres, telefoonnummer, mobielnummer);
                        lid.SetBank(bank);
                        lid.SetOuderContact(oc);
                        App.EditLid(nieuwLid, lid);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetOudercontactVisable(!_counterOudercontact);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetOudercontactVisable(bool value)
        {
            if (value)
            {
                Width = 684;
                btOuder.Text = "Cancel";
                _counterOudercontact = true;
            }
            else
            {
                Width = 493;
                btOuder.Text = "Oudercontact toevoegen";
                _counterOudercontact = false;
            }
        }

        private bool CheckFields()
        {
            if (tbBondsnummer.Text != "")
            {
                bondsnummer = Convert.ToInt32(tbBondsnummer.Text);
            }
            else
            {
                bondsnummer = Convert.ToInt32(bondsnummer);
            }
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
                                                    return true;
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
            throw new Exception("Niet alle verplichte velden zijn ingevuld.");
        }

        private void FillForm()
        {
            tbVoornaam.Text = lid.Voornaam;
            tbTussenvoegsel.Text = lid.GetTussenvoegsel();
            tbAchternaam.Text = lid.Achternaam;
            if (lid.Bank != null)
            {
                tbBankrekening.Text = lid.Bank.Rekeningnummer;
            }
            tbBondsnummer.Text = lid.Bondsnummer.ToString();
            tbEmailadres.Text = lid.Emailadres;
            tbHuisnummer.Text = lid.Adres.Huisnummer;
            tbMobielnummer.Text = lid.GetMobielnummer();
            tbTelefoonnummer.Text = lid.GetTelefoonnummer();
            tbStraatnaam.Text = lid.Adres.Straatnaam;
            tbPostcode.Text = lid.Adres.Postcode;
            tbWoonplaats.Text = lid.Adres.Plaats;
            cbGeslacht.Text = lid.Geslacht;
            dtGebdatum.Value = lid.Geboortedatum;
            dtLidVanafDatum.Value = lid.LidVanaf;

            if (lid.GetOudercontact() != null)
            {
                SetOudercontactVisable(true);
                _counterOudercontact = true;
                tbOVoornaam.Text = lid.Oudercontact.Voornaam;
                tbOAchternaam.Text = lid.Oudercontact.Achternaam;
                tbOTussenvoegsel.Text = lid.Oudercontact.Tussenvoegsel;
                tbOEmail1.Text = lid.Oudercontact.Telefoonnummer1;
                tbOEmail2.Text = lid.Oudercontact.Telefoonnummer2;
                tbOTel1.Text = lid.Oudercontact.Telefoonnummer1;
                tbOTel2.Text = lid.Oudercontact.Telefoonnummer2;
            }
            else
            {
                SetOudercontactVisable(false);
                _counterOudercontact = false;
            }
        }

        public string CheckBankCode(BankNaamEnum bankString)
        {
            string bankNaam = "Geen bank";
            switch (bankString)
            {
                case BankNaamEnum.ABNA: return "ABNA AMRO";
                case BankNaamEnum.FTSB: return "ABNA AMRO FORTIS BANK";
                case BankNaamEnum.ADYB: return "ADYEN";
                case BankNaamEnum.AEGO: return "AEGON BANK";
                case BankNaamEnum.ANAA: return "BRAND NEW DAY ALLIANZ BANK";
                case BankNaamEnum.ANDL: return "ANADOLUBANK";
                case BankNaamEnum.ARBN: return "ACHMEABANK";
                case BankNaamEnum.ARSN: return "ARGENTA SPAARBANK";
                case BankNaamEnum.ASNB: return "ASN BANK";
                case BankNaamEnum.ARBA: return "AMSTERDAM TRADE BANK";
                case BankNaamEnum.BCDM: return "BANQUE CHAABI DU MAROC";
                case BankNaamEnum.BCIT: return "INTESA SANPAOLO";
                case BankNaamEnum.BICK: return "BINCKBANK";
                case BankNaamEnum.BINK: return "BINCKBANK, PROF";
                case BankNaamEnum.BKCH: return "BANK OF CHINA";
                case BankNaamEnum.BKMG: return "BANK MENDES GANG";
                case BankNaamEnum.BLGW: return "BLG WONEN";
                case BankNaamEnum.BMEU: return "BMCE EUROSERVICES";
                case BankNaamEnum.BNDA: return "BRAND NEW DAY BANK";
                case BankNaamEnum.BNGH: return "BANK NEDERLANDSE GEMEENTEN";
                case BankNaamEnum.BNPA: return "BNP PARIBAS BANK";
                case BankNaamEnum.BOFA: return "BANK OF AMERICA";
                case BankNaamEnum.BOFS: return "BANK OF SCOTLANG";
                case BankNaamEnum.BOTK: return "MUFG BANK";
                case BankNaamEnum.BUNQ: return "BUNQ BANK";
                case BankNaamEnum.CHAS: return "JPMORGAN CHASE BANK";
                case BankNaamEnum.CITC: return "CITCO BANK";
                case BankNaamEnum.CITI: return "CITIBANK INTERNATIONAL";
                case BankNaamEnum.COBA: return "COMMERZBANK";
                case BankNaamEnum.DEUT: return "DEUTSCHE BANK";
                case BankNaamEnum.DHBN: return "DEMIR-HALK BANK";
                case BankNaamEnum.DLBK: return "DELTA LLOYD BANK";
                case BankNaamEnum.DNIB: return "NIBC BANK";
                case BankNaamEnum.FBHL: return "CREDIT EUROPE BANK";
                case BankNaamEnum.FLOR: return "DE NEDERLANDSCHE BANK";
                case BankNaamEnum.FRGH: return "FGH BANK";
                case BankNaamEnum.FVLB: return "VAN LANGDSCHOT BANK";
                case BankNaamEnum.GILL: return "INSINGERGILISSEN";
                case BankNaamEnum.HAND: return "SVENSKA HANDELSBANKEN";
                case BankNaamEnum.HHBA: return "HOF HOORNEMAN BANKIERS";
                case BankNaamEnum.HSBC: return "HSBC BANK";
                case BankNaamEnum.ICBK: return "INDUSTRIAL & COMMERCIAL BANK OF CHINA";
                case BankNaamEnum.INGB: return "ING BANK";
                case BankNaamEnum.ISBK: return "ISBANK";
                case BankNaamEnum.KABA: return "YAPI KREDI BANK";
                case BankNaamEnum.KASA: return "KAS BANK";
                case BankNaamEnum.KNAB: return "KNAB BANK";
                case BankNaamEnum.KOEX: return "KOREA EXCHANGE BANK";
                case BankNaamEnum.KRED: return "KBC BANK";
                case BankNaamEnum.LOCY: return "LOMBARD ODIER DARIER HENTSCH & CIE";
                case BankNaamEnum.LOYD: return "LLOYDS TSB BANK";
                case BankNaamEnum.LPLN: return "LEASEPLAN CORPORATION BANK";
                case BankNaamEnum.MHCB: return "MIZUHO BANK EUROPE";
                case BankNaamEnum.MOYO: return "MONEYOU BANK";
                case BankNaamEnum.NNBA: return "NATIONALE-NEDERLANDEN BANK";
                case BankNaamEnum.NWAB: return "NEDERLANDSE WATERSCHAPSBANK";
                case BankNaamEnum.PCBC: return "CHINA CONSTRUCTION BANK";
                case BankNaamEnum.RABO: return "RABOBANK";
                case BankNaamEnum.RBRB: return "REGIOBANK";
                case BankNaamEnum.SNSB: return "SNS BANK";
                case BankNaamEnum.SOGE: return "SOCIETE GENERALE BANK";
                case BankNaamEnum.TEBU: return "THE ECONOMY BANK";
                case BankNaamEnum.TRIO: return "TRIODOS BANK";
                case BankNaamEnum.UBSW: return "UBS EUROPE SE BANK";
                case BankNaamEnum.UGBI: return "GARANTIEBANK INTERNATIONAL";
                case BankNaamEnum.VOWA: return "VOLKSWAGEN BANK";
                case BankNaamEnum.ZWLB: return "ZWITSERLEVENBANK";
            }
            return bankNaam;
        }
    }
}
