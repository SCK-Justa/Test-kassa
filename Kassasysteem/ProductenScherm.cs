using System;
using System.Globalization;
using System.Windows.Forms;
using Logic;
using Logic.Classes;

namespace Kassasysteem
{
    public partial class ProductenScherm : Form
    {
        public KassaApp App { get; private set; }
        public ProductenScherm(KassaApp app, Bestelling bestelling)
        {
            InitializeComponent();
            App = app;
            if (App.GetIsGemachtigd())
            {
                if (bestelling == null)
                {
                    btRemove.Enabled = true;
                }
                else
                {
                    btRemove.Enabled = false;
                }
            }
            UpdateProducten(bestelling);
        }

        public void UpdateProducten(Bestelling bestelling)
        {
            lvProducten.Items.Clear();
            if (bestelling != null)
            {
                foreach (Product p in bestelling.GetProducten())
                {
                    ListViewItem lvi = new ListViewItem(p.Naam);
                    lvi.SubItems.Add(p.Soort);
                    lvi.SubItems.Add("€" + p.Prijs);
                    lvi.SubItems.Add("€" + p.Ledenprijs.ToString(CultureInfo.InvariantCulture));
                    lvProducten.Items.Add(lvi);
                }
            }
            else
            {
                foreach (LosseVerkoop p in App.GetLosseVerkopen(new DateTime(2000, 1, 1), DateTime.Today))
                {
                    ListViewItem lvi = new ListViewItem(p.Naam);
                    lvi.SubItems.Add(p.Soort);
                    lvi.SubItems.Add("€ " + p.Prijs);
                    lvi.SubItems.Add("€ " + p.Ledenprijs.ToString(CultureInfo.InvariantCulture));
                    lvi.SubItems.Add(p.BestelDatum.ToShortTimeString() + " - " + p.BestelDatum.ToShortDateString());
                    lvProducten.Items.Add(lvi);
                }
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            try
            {
                var verkoop = lvProducten.SelectedItems[0].Tag as LosseVerkoop;
                if (verkoop != null)
                {
                    App.RemoveProductVanBestelling(null, null, verkoop);
                }
                else
                {
                    throw new Exception("Selecteer eerst een verkoop.");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                                exception.Message);
            }
        }
    }
}
