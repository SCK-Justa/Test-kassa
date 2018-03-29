using System.Collections.Generic;
using System.Windows.Forms;
using Logic;
using Logic.Classes;

namespace Kassasysteem
{
    public partial class VoorraadControleScherm : Form
    {
        public KassaApp App { get; }
        public VoorraadControleScherm(KassaApp app)
        {
            InitializeComponent();
            App = app;
            InitialLoad();
        }

        private void InitialLoad()
        {
            lvVoorraadControles.Items.Clear();
            List<VoorraadControle> controles = new List<VoorraadControle>();
            foreach (Product product in App.Voorraad.GetProducten())
            {
                controles.AddRange(product.GetVoorraadOpbouw());
            }
            controles.Sort((x, y) => -x.DatumControle.CompareTo(y.DatumControle));
            foreach (VoorraadControle controle in controles)
            {
                ListViewItem lvi = new ListViewItem(controle.Product.Naam);
                lvi.SubItems.Add(controle.GetControleur());
                lvi.SubItems.Add(controle.DatumControle.ToShortTimeString() + " - " + controle.DatumControle.ToShortDateString());
                lvi.SubItems.Add(controle.OudeVoorraad.ToString());
                lvi.SubItems.Add(controle.NieuweVoorraad.ToString());
                int verschil = controle.NieuweVoorraad - controle.OudeVoorraad;
                lvi.SubItems.Add(verschil.ToString());
                lvi.SubItems.Add(controle.Opmerking.ToString());
                lvi.Tag = controle;
                lvVoorraadControles.Items.Add(lvi);
            }
        }
    }
}
