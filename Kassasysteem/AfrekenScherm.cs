using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Logic;
using Logic.Classes;

namespace Kassasysteem
{
    public partial class AfrekenScherm : Form
    {
        private KassaApp _app;
        public bool Betaald { get; private set; }
        public Bestelling Bestelling { get; private set; }

        public AfrekenScherm(KassaApp app, Bestelling bestelling)
        {
            InitializeComponent();
            Betaald = bestelling.Betaald;
            _app = app;
            Bestelling = bestelling;
            CheckGegevens();
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

        private void SetGegevens(bool bonnen, bool button, bool lbbonnen)
        {
            if (Bestelling.Persoon != null)
            {
                lbNaam.Text = Bestelling.Persoon.Voornaam + " " + Bestelling.Persoon.Tussenvoegsel + " " +
                              Bestelling.Persoon.Achternaam;
            }
            else
            {
                lbNaam.Text = Bestelling.Naam;
            }
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
                lvi.SubItems.Add("€" + p.Prijs);
                lvi.SubItems.Add("€" + p.Ledenprijs);
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
                if (cbIsLid.Checked)
                {
                    if (bonnen)
                    {
                        Bestelling.SetBetaaldMetBonnen(true);
                        betaaldBedrag = 0;
                    }
                    else
                    {
                        Bestelling.SetBetaaldMetBonnen(false);
                        betaaldBedrag = Bestelling.TotaalLedenPrijs;
                    }
                }
                else
                {
                    Bestelling.SetBetaaldMetBonnen(false);
                    betaaldBedrag = Bestelling.TotaalPrijs;
                }
                _app.BestellingAfrekenen(Bestelling, betaaldBedrag);
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                                exception.Message);
            }
        }
    }
}
