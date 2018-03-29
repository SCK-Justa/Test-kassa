using System;
using System.Windows.Forms;
using Logic;
using Logic.Classes;

namespace Kassasysteem
{
    public partial class VoorraadScherm : Form
    {
        ListViewItem _item;
        private Product _product;
        public KassaApp App { get; }
        public VoorraadScherm(KassaApp app)
        {
            InitializeComponent();
            App = app;
            Width = 719;
            SetAble(App.GetIsGemachtigd());
            RefreshGegevens();
        }

        private void SetAble(bool ableChange)
        {
            groupBox2.Enabled = ableChange;
            groupBox3.Enabled = ableChange;
            gpVoorraadOpbouw.Visible = ableChange;
            if (ableChange)
            {
                Width = 1008;
            }

            btSluiten.Enabled = true;
        }

        private void RefreshGegevens()
        {
            lvProducten.Items.Clear();
            foreach (Product product in App.Voorraad.GetProducten())
            {
                _item = new ListViewItem(product.Id.ToString());
                _item.SubItems.Add(product.Naam);
                _item.SubItems.Add(product.Soort);
                _item.SubItems.Add(product.Voorraad.ToString());
                _item.SubItems.Add("€ " + product.Prijs);
                _item.SubItems.Add("€ " + product.Ledenprijs);
                lvProducten.Items.Add(_item);
            }
        }

        private void lvProducten_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = Convert.ToInt32(lvProducten.SelectedItems[0].Text);
                foreach (Product product in App.Voorraad.GetProducten())
                {
                    if (product.Id == selected)
                    {
                        UpdateProductForEdit(product);
                        UpdateVoorraadOpbouw(product);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }

        private void btOpslaan_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbNaam.Text == "")
                {
                    throw new Exception(@"U moet een naam invullen.");
                }
                if (tbSoort.Text == "")
                {
                    throw new Exception(@"U moet een soort invullen.");
                }
                if (nudVoorraad.Value == 0)
                {
                    throw new Exception(@"U moet een voorraad invullen.");
                }
                if (nudPrijs.Value == 0)
                {
                    throw new Exception(@"U moet een prijs invullen.");
                }
                if (nudLedenprijs.Value == 0)
                {
                    throw new Exception(@"U moet een ledenprijs invullen.");
                }
                int oudeVoorraad = _product.Voorraad;
                int nieuweVoorraad;
                _product.SetNaam(tbNaam.Text);
                _product.SetSoort(tbSoort.Text);
                _product.SetVoorraad(Convert.ToInt32(nudVoorraad.Value));
                _product.SetPrijs(nudPrijs.Value);
                _product.SetLedenprijs(nudLedenprijs.Value);
                nieuweVoorraad = _product.Voorraad;
                App.EditProduct(_product, oudeVoorraad, nieuweVoorraad);
                UpdateProductForEdit(_product);
                RefreshGegevens();
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }

        private void btSluiten_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btNOpslaan_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbNProductnaam.Text == "")
                {
                    throw new Exception(@"U moet een naam invullen.");
                }
                if (tbNSoort.Text == "")
                {
                    throw new Exception(@"U moet een soort invullen.");
                }
                if (nudNVoorraad.Value == 0)
                {
                    throw new Exception(@"U moet een voorraad invullen.");
                }
                if (nudNPrijs.Value == 0)
                {
                    throw new Exception(@"U moet een prijs invullen.");
                }
                if (nudNLedenprijs.Value == 0)
                {
                    throw new Exception(@"U moet een ledenprijs invullen.");
                }
                int id = lvProducten.Items.Count + 1;
                _item = new ListViewItem(id.ToString());
                _item.SubItems.Add(tbNProductnaam.Text);
                _item.SubItems.Add(tbNSoort.Text);
                _item.SubItems.Add(nudNVoorraad.Value.ToString());
                _item.SubItems.Add("€ " + nudNPrijs.Value);
                _item.SubItems.Add("€ " + nudNLedenprijs.Value);
                lvProducten.Items.Add(_item);
                App.AddNewProduct(id, tbNaam.Text, tbSoort.Text, Convert.ToInt32(nudVoorraad.Value), nudLedenprijs.Value, nudPrijs.Value);
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }

        private void UpdateProductForEdit(Product product)
        {
            _product = product;
            SetAble(App.GetIsGemachtigd());
            btOpslaan.Enabled = App.GetIsGemachtigd();
            tbNaam.Text = product.Naam;
            tbSoort.Text = product.Soort;
            nudVoorraad.Value = product.Voorraad;
            nudPrijs.Value = product.Prijs;
            nudLedenprijs.Value = product.Ledenprijs;
            if (App.GetIsGemachtigd())
            {
                UpdateVoorraadOpbouw(product);
            }
        }

        private void UpdateVoorraadOpbouw(Product product)
        {
            lvVoorraadOpbouw.Items.Clear();
            foreach (VoorraadControle controle in product.GetVoorraadOpbouw())
            {
                int voorraad = controle.NieuweVoorraad - controle.OudeVoorraad;
                ListViewItem lvi = new ListViewItem(controle.Opmerking.ToString());
                lvi.SubItems.Add(controle.DatumControle.ToShortDateString());
                lvi.SubItems.Add(voorraad.ToString());
                lvi.Tag = controle;
                lvVoorraadOpbouw.Items.Add(lvi);
            }
        }
    }
}
