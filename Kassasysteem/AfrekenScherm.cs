using System;
using System.Media;
using System.Windows.Forms;
using Logic;
using Logic.Classes;

namespace Kassasysteem
{
    public partial class AfrekenScherm : Form
    {
        private SoundPlayer player;
        private bool _speciaalAfrekenen = false;
        private KassaApp _app;
        public bool Betaald { get; private set; }
        public Bestelling Bestelling { get; private set; }

        public AfrekenScherm(KassaApp app, Bestelling bestelling)
        {
            InitializeComponent();
            Betaald = bestelling.Betaald;
            _app = app;
            Bestelling = bestelling;
            CheckBestuur();
            CheckGegevens();
            player = new SoundPlayer(@"Afrekenen.wav");
        }

        private void CheckGegevens()
        {
            lvProducten.Items.Clear();
            if (cbIsLid.Checked)
            {
                SetGegevens(true, true, true);
            }
            else
            {
                SetGegevens(false, false, false);
            }
        }

        private void CheckBestuur()
        {
            bool gemachtigd = false;
            if (_app.Authentication != null)
            {
                gemachtigd = _app.GetIsGemachtigd();
            }
            if (gemachtigd)
            {
                Height = 550;
                btBestuurAfrekenen.Visible = gemachtigd;
                tbOpmerking.Visible = gemachtigd;
                lbOpmerking.Visible = gemachtigd;
            }
            else
            {
                Height = 465;
                btBestuurAfrekenen.Visible = gemachtigd;
                tbOpmerking.Visible = gemachtigd;
                lbOpmerking.Visible = gemachtigd;
            }
        }

        private void SetGegevens(bool bonnen, bool button, bool lbbonnen)
        {
            lbNaam.Text = Bestelling.GetBesteller();
            lbDatum.Text = Bestelling.Datum.ToString();
            lbTotaalPrijs.Text = "€ " + Bestelling.TotaalPrijs;
            if (cbIsLid.Checked)
            {
                lbBonnen.Text = (Bestelling.TotaalLedenPrijs / 0.70m).ToString();
                lbTotaalPrijs.Text = "€ " + Bestelling.TotaalLedenPrijs;
            }
            lbBonnen.Visible = bonnen;
            btAfrekenenBonnen.Visible = button;
            label4.Visible = lbbonnen;
            foreach (Product p in Bestelling.GetProducten())
            {
                ListViewItem lvi = new ListViewItem(p.Naam);
                lvi.SubItems.Add("€ " + p.Prijs);
                lvi.SubItems.Add("€ " + p.Ledenprijs);
                lvProducten.Items.Add(lvi);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Afrekenen(false);
        }

        private void cbIsLid_CheckedChanged(object sender, EventArgs e)
        {
            CheckGegevens();
        }

        private void btAfrekenenBonnen_Click(object sender, EventArgs e)
        {
            Afrekenen(true);
        }

        private void Afrekenen(bool bonnen)
        {
            try
            {
                decimal betaaldBedrag;
                if (!_speciaalAfrekenen) // Normaal afrekenen
                {
                    if (cbIsLid.Checked)
                    {
                        if (bonnen)
                        {
                            betaaldBedrag = 0.00m;
                        }
                        else
                        {
                            betaaldBedrag = Bestelling.TotaalLedenPrijs;
                        }
                    }
                    else
                    {
                        betaaldBedrag = Bestelling.TotaalPrijs;
                    }
                    Bestelling.SetBetaaldMetMunten(bonnen);
                    Bestelling.SetBetaaldBestuur(false);
                    SetOpmerking(tbOpmerking.Text);
                }
                else // Als bestuur het bedrag vergoedt
                {
                    betaaldBedrag = Bestelling.TotaalLedenPrijs;
                    Bestelling.SetBetaaldMetMunten(false);
                    Bestelling.SetBetaaldBestuur(true);
                    SetOpmerking(tbOpmerking.Text);
                }
                _app.BestellingAfrekenen(Bestelling, betaaldBedrag);
                player.Play();

                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                                exception.Message);
            }
        }

        private void SetOpmerking(string text)
        {
            if (text != "")
            {
                if (_speciaalAfrekenen)
                {
                    Bestelling.SetOpmerking("Betaling door bestuur: " + text);
                }
                else
                {
                    Bestelling.SetOpmerking("");
                }
            }
            else
            {
                Bestelling.SetOpmerking("");
            }
        }

        private void btBestuurAfrekenen_Click(object sender, EventArgs e)
        {
            if (tbOpmerking.Text != "")
            {
                _speciaalAfrekenen = true;
                Afrekenen(true);
            }
            else
            {
                MessageBox.Show("Vul een reden van bestuursvergoeding in.");
            }
        }
    }
}
