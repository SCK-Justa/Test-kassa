using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Logic;
using Logic.Classes;

namespace Kassasysteem
{
    public partial class KasInUitScherm : Form
    {
        private FormulierSoort _formulierSoort;
        private DateTime _datum;
        private string _naam;
        private string _bankrekeningNummer;
        private string _redenUitgaven;
        private string _route;
        private decimal _geredenKm;
        private bool _contant;
        private decimal _bedrag;
        private string _getekendDoor;
        private ListViewItem _item;

        public List<Formulier> Formulieren { get; private set; }
        public KassaApp App { get; private set; }
        public KasInUitScherm(KassaApp app)
        {
            try
            {
                InitializeComponent();
                App = app;
                Formulieren = new List<Formulier>();
                SetFormulierVisable(false);
                LaadFormulierenSoortInCb();
                LaadFormulierSoort(FormulierSoort.Geenformulier);
                GetFormulieren();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        private void GetFormulieren()
        {
            Formulieren = App.GetFormulieren();
        }

        private void LaadFormulierenSoortInCb()
        {
            foreach (var item in Enum.GetValues(typeof(FormulierSoort)))
            {
                cbSoortFormulier.Items.Add(item);
            }
        }

        private void UpdateFormulierenLijst()
        {
            try
            {
                lvFormulieren.Items.Clear();
                foreach (Formulier formulier in App.GetFormulieren())
                {
                    _item = new ListViewItem(formulier.Id.ToString());
                    _item.SubItems.Add(formulier.Datum.ToShortDateString());
                    _item.SubItems.Add(formulier.Naam);
                    _item.SubItems.Add(formulier.Soort.ToString());
                    _item.SubItems.Add("€" + formulier.GeleendBedrag);
                    _item.SubItems.Add(formulier.GetekendDoor);
                    _item.SubItems.Add(formulier.BankrekeningNummer);
                    _item.SubItems.Add(formulier.Reden);
                    _item.SubItems.Add(formulier.Contant.ToString());
                    _item.SubItems.Add(formulier.GeredenRoute);
                    _item.SubItems.Add("€" + formulier.GemaakteKm);
                    lvFormulieren.Items.Add(_item);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }

        private void SetFormulierVisable(bool isVisable)
        {
            gbDeclaratie.Visible = isVisable;
            gbVoorschot.Visible = isVisable;
        }

        private void LaadFormulierSoort(FormulierSoort soort)
        {
            try
            {
                if (soort == FormulierSoort.Declaratieformulier)
                {
                    Width = 910;
                    gbVoorschot.Visible = false;
                    gbDeclaratie.Visible = true;
                    gbOverzichtFormulieren.Visible = false;
                }
                if (soort == FormulierSoort.Voorschotformulier)
                {
                    Width = 910;
                    gbDeclaratie.Visible = false;
                    gbVoorschot.Visible = true;
                    gbOverzichtFormulieren.Visible = false;
                }
                if (soort == FormulierSoort.Uitgifteoverzicht)
                {
                    if (App.Authentication.Gemachtigd)
                    {
                        Width = 1179;
                        gbDeclaratie.Visible = false;
                        gbVoorschot.Visible = false;
                        gbOverzichtFormulieren.Visible = true;
                        UpdateFormulierenLijst();
                    }
                    else
                    {
                        throw new Exception("U heeft hier geen rechten voor.");
                    }
                }
                if (soort == FormulierSoort.Geenformulier)
                {
                    Width = 293;
                    gbDeclaratie.Visible = false;
                    gbVoorschot.Visible = false;
                    gbOverzichtFormulieren.Visible = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }

        private void cbSoortFormulier_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selected = cbSoortFormulier.SelectedItem.ToString();
                FormulierSoort soort = (FormulierSoort)Enum.Parse(typeof(FormulierSoort), selected);
                LaadFormulierSoort(soort);
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }

        private bool CheckVerplichteVelden(FormulierSoort soort)
        {
            if (soort == FormulierSoort.Declaratieformulier)
            {
                if (tbDNaamDeclarant.Text != "")
                {
                    if (tbDNaamBestuurdlid1.Text != "")
                    {
                        if (tbDNaambestuurslid2.Text != "")
                        {
                            return true;
                        }
                    }
                }
                throw new Exception("De declarant en 2 bestuursleden moeten dit formulier tekenen.");
            }
            if (soort == FormulierSoort.Voorschotformulier)
            {
                if (tbDNaamDeclarant.Text != "")
                {
                    if (tbDNaamBestuurdlid1.Text != "")
                    {
                        if (tbDNaambestuurslid2.Text != "")
                        {
                            return true;
                        }
                    }
                }
                throw new Exception("De declarant en 2 bestuursleden moeten dit formulier tekenen.");
            }
            return false;
        }

        private void btOpslaanVoorschot_Click(object sender, EventArgs e)
        {
            try
            {
                FormulierSoort formulier = (FormulierSoort)Enum.Parse(typeof(FormulierSoort), cbSoortFormulier.Text);
                DateTime datum = dtVoorschot.Value;
                string naam = tbVNaam.Text;
                string bankrekeningNummer = tbVBankrekening.Text;
                string redenUitgaven = tbVOmschrijvingR1.Text + " " + tbVOmschrijvingR2.Text + " " +
                                       tbVOmschrijvingR3.Text +
                                       " " + tbVOmschrijvingR4.Text + " " + tbVOmschrijvingR5.Text + " " +
                                       tbVOmschrijvingR6.Text;
                bool contant = cbVContant.Enabled;
                string route = tbVRoute.Text;
                decimal geredenKm = nudVKm.Value;
                decimal bedrag = nudVB1.Value + nudVB2.Value + nudVB3.Value + nudVB4.Value + nudVB5.Value + nudVB6.Value;
                string getekendDoor = tbVNaamDeclarant.Text + ";" + tbVNaamBestuurslid1.Text + ";" + tbVNaamBestuurslid2.Text;
                if (CheckVerplichteVelden(formulier))
                {
                    FormulierInvullen(formulier, datum, naam, bankrekeningNummer, redenUitgaven, contant, route,
                        geredenKm, bedrag, getekendDoor);
                    LaadFormulierSoort(FormulierSoort.Uitgifteoverzicht);
                    ResetValues(formulier);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }

        private void btOpslaanDeclaratie_Click(object sender, EventArgs e)
        {
            try
            {
                FormulierSoort formulier = (FormulierSoort)Enum.Parse(typeof(FormulierSoort), cbSoortFormulier.Text);
                DateTime datum = dtDeclaratie.Value;
                string naam = tbDNaam.Text;
                string bankrekeningNummer = tbDBankrekening.Text;
                string redenUitgaven = tbBOmschrijvingR1.Text + " " + tbBOmschrijvingR2.Text + " " +
                                       tbBOmschrijvingR3.Text +
                                       " " + tbBOmschrijvingR4.Text + " " + tbBOmschrijvingR5.Text + " " +
                                       tbBOmschrijvingR6.Text;
                bool contant = cbDContant.Enabled;
                string route = tbDRoute.Text;
                decimal geredenKm = nudDKm.Value;
                decimal bedrag = nudDO1.Value + nudDO2.Value + nudDO3.Value + nudDO4.Value + nudDO5.Value + nudDO6.Value;
                string getekendDoor = tbDNaamDeclarant.Text + ";" + tbDNaamBestuurdlid1.Text + ";" + tbDNaambestuurslid2.Text;
                if (CheckVerplichteVelden(formulier))
                {
                    FormulierInvullen(formulier, datum, naam, bankrekeningNummer, redenUitgaven, contant, route,
                        geredenKm, bedrag, getekendDoor);
                    ResetValues(formulier);
                    LaadFormulierSoort(FormulierSoort.Uitgifteoverzicht);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }

        private void ResetValues(FormulierSoort input)
        {
            if (input == FormulierSoort.Declaratieformulier)
            {
                dtDeclaratie.Value = DateTime.Today;
                tbDNaam.Text = "";
                tbDBankrekening.Text = "";
                tbBOmschrijvingR1.Text = "";
                tbBOmschrijvingR2.Text = "";
                tbBOmschrijvingR3.Text = "";
                tbBOmschrijvingR4.Text = "";
                tbBOmschrijvingR5.Text = "";
                tbBOmschrijvingR6.Text = "";
                cbDContant.Enabled = false;
                tbDRoute.Text = "";
                nudDKm.Text = @"0,00";
                nudDO1.Text = @"0.00";
                nudDO2.Text = @"0.00";
                nudDO3.Text = @"0.00";
                nudDO4.Text = @"0.00";
                nudDO5.Text = @"0.00";
                nudDO6.Text = @"0.00";
                tbDNaam.Text = "";
                tbDNaamBestuurdlid1.Text = "";
                tbDNaambestuurslid2.Text = "";
            }
            if (input == FormulierSoort.Voorschotformulier)
            {
                dtVoorschot.Value = DateTime.Today;
                tbVNaam.Text = "";
                tbVBankrekening.Text = "";
                tbVOmschrijvingR1.Text = "";
                tbVOmschrijvingR2.Text = "";
                tbVOmschrijvingR3.Text = "";
                tbVOmschrijvingR4.Text = "";
                tbVOmschrijvingR5.Text = "";
                tbVOmschrijvingR6.Text = "";
                cbVContant.Enabled = false;
                tbVRoute.Text = "";
                nudVKm.Text = @"0,00";
                nudVB1.Text = @"0.00";
                nudVB2.Text = @"0.00";
                nudVB3.Text = @"0.00";
                nudVB4.Text = @"0.00";
                nudVB5.Text = @"0.00";
                nudVB6.Text = @"0.00";
                tbVNaam.Text = "";
                tbVNaamBestuurslid1.Text = "";
                tbVNaamBestuurslid2.Text = "";
            }
        }

        private void FormulierInvullen(FormulierSoort soort, DateTime datum, string naam, string bankrekening, string reden, bool contant, string route, decimal bedrag, decimal geredenKm, string getekendDoor)
        {
            try
            {
                _formulierSoort = soort;
                _datum = datum;
                _naam = naam;
                _bankrekeningNummer = bankrekening;
                _redenUitgaven = reden;
                _contant = contant;
                _route = route;
                _geredenKm = geredenKm;
                _bedrag = bedrag;
                _getekendDoor = getekendDoor;
                App.FormulierInvullen(_formulierSoort, _datum, _naam, _bankrekeningNummer, _redenUitgaven, _contant,
                    _route, _geredenKm, bedrag, getekendDoor);
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btBetalenAanKas_Click(object sender, EventArgs e)
        {
            try
            {
                if (nudTraningskaartInkomsten.Value > 0)
                {
                    App.AddAndereInkomsten(nudTraningskaartInkomsten.Value);
                    MessageBox.Show(@"Betaling trainingskaart is voldaan.");
                    Close();
                }
                if (nudFooiInkomsten.Value > 0)
                {
                    App.AddAndereInkomsten(nudFooiInkomsten.Value);
                    MessageBox.Show(@"Betaling fooi is voldaan.");
                    Close();
                }
                if (nudDemoInkomsten.Value > 0)
                {
                    App.AddAndereInkomsten(nudDemoInkomsten.Value);
                    MessageBox.Show(@"Betaling demo is voldaan.");
                    Close();
                }
                if (nudAndereInkomsten.Value > 0)
                {
                    App.AddAndereInkomsten(nudAndereInkomsten.Value);
                    MessageBox.Show(@"Betaling andere inkomsten is voldaan.");
                    Close();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }
    }
}
