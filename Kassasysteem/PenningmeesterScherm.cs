using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Logic;

namespace Kassasysteem
{
    public partial class PenningmeesterScherm : Form
    {
        List<decimal> _weekOmzet = new List<decimal>();
        public KassaApp App { get; private set; }
        public PenningmeesterScherm(KassaApp app)
        {
            InitializeComponent();
            App = app;
            UpdateScreenOnFirstLoad();
        }

        public void UpdateScreenOnFirstLoad()
        {
            FillComboBox();
        }

        private void FillComboBox()
        {
            // Vult de combobox met weeknummers 1 t/m 52.
            for (int i = 1; i < 53; i++)
            {
                cbWeekNrs.Items.Add("Week " + i);
            }
        }

        private void btOpenWeekOmzet_Click(object sender, System.EventArgs e)
        {
            // Scheidt tekst in week en het weeknummer, weeknummer wordt doorgespeeld om de omzet van die week op te halen.
            try
            {
                int weeknr;
                string[] week = cbWeekNrs.SelectedText.Split(' ');
                weeknr = Convert.ToInt32(week[1]);
                _weekOmzet = App.GetOmzetPerDag(weeknr);

                tbMaandag.Text = "€ " + _weekOmzet[0];
                tbDinsdag.Text = "€ " + _weekOmzet[1];
                tbWoensdag.Text = "€ " + _weekOmzet[2];
                tbDonderdag.Text = "€ " + _weekOmzet[3];
                tbVrijdag.Text = "€ " + _weekOmzet[4];
                tbZaterdag.Text = "€ " + _weekOmzet[5];
                tbZondag.Text = "€ " + _weekOmzet[6];
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
