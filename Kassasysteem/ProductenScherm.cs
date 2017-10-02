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
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
