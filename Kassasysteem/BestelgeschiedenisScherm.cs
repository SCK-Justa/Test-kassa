using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Logic;
using Logic.Classes;

namespace Kassasysteem
{
    public partial class BestelgeschiedenisScherm : Form
    {
        private List<Bestelling> _afgerekendeBestellingen = new List<Bestelling>();
        public KassaApp App { get; }

        public BestelgeschiedenisScherm(KassaApp app)
        {
            try
            {
                InitializeComponent();
                App = app;
                UpdateAfgerekendeBestellingen();
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                                exception.Message);
            }
        }

        public void UpdateAfgerekendeBestellingen()
        {
            try
            {
                _afgerekendeBestellingen = App.GetAfgerekendeBestellingen();
                lvAfgerekendeBestellingen.Items.Clear();
                if (_afgerekendeBestellingen != null)
                {
                    foreach (Bestelling b in _afgerekendeBestellingen)
                    {
                        ListViewItem lvi;
                        lvi = new ListViewItem(b.GetBesteller());
                        SuppUpdate(lvi, b);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }

        private void SuppUpdate(ListViewItem lvi, Bestelling b)
        {
            if (b.BetaaldMetMunten)
            {
                lvi.SubItems.Add("€,-");
                lvi.SubItems.Add(b.DatumBetaald.ToShortDateString() + " - " +
                                 b.DatumBetaald.ToShortTimeString());
                lvi.SubItems.Add(b.BetaaldMetMunten.ToString());
                lvi.Tag = b;
                lvAfgerekendeBestellingen.Items.Add(lvi);
            }
            else
            {
                lvi.SubItems.Add("€ " + b.BetaaldBedrag.ToString(CultureInfo.CurrentCulture));
                lvi.SubItems.Add(b.DatumBetaald.ToShortDateString() + " - " +
                                 b.DatumBetaald.ToShortTimeString());
                lvi.SubItems.Add(b.BetaaldMetMunten.ToString());
                lvi.Tag = b;
                lvAfgerekendeBestellingen.Items.Add(lvi);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SortBy(string sort)
        {
            try
            {
                switch (sort)
                {
                    case "Naam":
                        _afgerekendeBestellingen.Sort((x, y) =>
                            String.Compare(x.GetBesteller(), y.GetBesteller(), StringComparison.Ordinal));
                        break;
                    case "Datum":
                        _afgerekendeBestellingen.Sort((x, y) => -x.DatumBetaald.CompareTo(y.DatumBetaald));
                        break;
                    case "Totaalprijs":
                        _afgerekendeBestellingen.Sort((x, y) => -x.BetaaldBedrag.CompareTo(y.BetaaldBedrag));
                        break;
                    case "Munten":
                        _afgerekendeBestellingen.Sort((x, y) => x.BetaaldMetMunten.CompareTo(y.BetaaldMetMunten));
                        break;
                }
                UpdateAfgerekendeBestellingen();
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }

        private void lvAfgerekendeBestellingen_Click(object sender, EventArgs e)
        {
            try
            {
                var bestelling = lvAfgerekendeBestellingen.SelectedItems[0].Tag as Bestelling;
                if (bestelling != null)
                {
                    ProductenScherm productenScherm = new ProductenScherm(App, bestelling);
                    productenScherm.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }

        private void lvAfgerekendeBestellingen_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            string clicked = lvAfgerekendeBestellingen.Columns[e.Column].Text;
            switch (clicked)
            {
                case "Klantnaam":
                    SortBy("Naam");
                    break;
                case "Totaalprijs":
                    SortBy("Totaalprijs");
                    break;
                case "Datum/tijd":
                    SortBy("Datum");
                    break;
                case "Betaald met munten":
                    SortBy("Munten");
                    break;
            }
        }
    }
}
