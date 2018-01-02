using System;
using System.Windows.Forms;
using Logic;
using System.Globalization;

namespace Kassasysteem
{
    public partial class PenningmeesterScherm : Form
    {

        public KassaApp App { get; private set; }
        public PenningmeesterScherm(KassaApp app)
        {
            InitializeComponent();
            App = app;
            UpdateScreenOnFirstLoad();
        }

        public void UpdateScreenOnFirstLoad()
        {
            lbOmzetToday.Text = "Datum vandaag: " + DateTime.Today.DayOfWeek + ", " + DateTime.Today.ToShortDateString();
            FillComboBox();
            ShowJaarOmzet(DateTime.Now);
        }

        private void FillComboBox()
        {
            // Vult de combobox met weeknummers 1 t/m 52.
            for (int i = 1; i < 53; i++)
            {
                cbWeekNrs.Items.Add("Week " + i);
            }

            // Vult de combobox met jaarnummers van 2016 tot het huidige jaar
            for (int i = 2016; i <= DateTime.Now.Year; i++)
            {
                cbJaarNr.Items.Add(i);
            }
        }

        private void btOpenWeekOmzet_Click(object sender, System.EventArgs e)
        {
            // Scheidt tekst in week en het weeknummer, weeknummer wordt doorgespeeld om de omzet van die week op te halen.
            try
            {
                string s = (string)cbWeekNrs.SelectedItem;
                string[] week = s.Split(' ');
                decimal[] _weekOmzet = new decimal[7];
                DateTime eerstedagvandeweek = FirstDateOfWeekISO8601(DateTime.Now.Year, Convert.ToInt32(week[1]));
                for (int i = 0; i < 7; i++)
                {
                    _weekOmzet[i] = App.GetOmzetPerDag(eerstedagvandeweek);
                    Console.WriteLine(i + ": " + _weekOmzet[i]);
                    eerstedagvandeweek = eerstedagvandeweek.AddDays(1);
                    Console.WriteLine(eerstedagvandeweek.Day);
                }

                tbMaandag.Text = "€ " + _weekOmzet[0];
                tbDinsdag.Text = "€ " + _weekOmzet[1];
                tbWoensdag.Text = "€ " + _weekOmzet[2];
                tbDonderdag.Text = "€ " + _weekOmzet[3];
                tbVrijdag.Text = "€ " + _weekOmzet[4];
                tbZaterdag.Text = "€ " + _weekOmzet[5];
                tbZondag.Text = "€ " + _weekOmzet[6];

                DateTime dag = FirstDateOfWeekISO8601(DateTime.Now.Year, Convert.ToInt32(week[1]));
                lbDatumDag1.Text = dag.Date.ToShortDateString();
                lbDatumDag2.Text = dag.AddDays(1).Date.ToShortDateString();
                lbDatumDag3.Text = dag.AddDays(2).Date.ToShortDateString();
                lbDatumDag4.Text = dag.AddDays(3).Date.ToShortDateString();
                lbDatumDag5.Text = dag.AddDays(4).Date.ToShortDateString();
                lbDatumDag6.Text = dag.AddDays(5).Date.ToShortDateString();
                lbDatumDag7.Text = dag.AddDays(6).Date.ToShortDateString();

                decimal omzetWeek = 0;
                for (int i = 0; i < 7; i++)
                {
                    omzetWeek += _weekOmzet[i];
                }
                tbWeekomzet.Text = "€ " + omzetWeek;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public DateTime FirstDateOfWeekISO8601(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }
            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btOpenJaarOmzet_Click(object sender, EventArgs e)
        {
            int selected = (int)cbJaarNr.SelectedItem;
            if (selected >= 0)
            {
                ShowJaarOmzet(new DateTime(selected, 1, 1));
            }
        }

        private void ShowDagOmzet()
        {

        }

        private void ShowJaarOmzet(DateTime date)
        {
            try
            {
                tbJaaromzet.Text = "€ " + App.GetOmzetPerJaar(date);
                tbJanuari.Text = "€ " + App.GetOmzetPerMaand(new DateTime(date.Year, 1, 1));
                tbFebruari.Text = "€ " + App.GetOmzetPerMaand(new DateTime(date.Year, 2, 1));
                tbMaart.Text = "€ " + App.GetOmzetPerMaand(new DateTime(date.Year, 3, 1));
                tbApril.Text = "€ " + App.GetOmzetPerMaand(new DateTime(date.Year, 4, 1));
                tbMei.Text = "€ " + App.GetOmzetPerMaand(new DateTime(date.Year, 5, 1));
                tbJuni.Text = "€ " + App.GetOmzetPerMaand(new DateTime(date.Year, 6, 1));
                tbJuli.Text = "€ " + App.GetOmzetPerMaand(new DateTime(date.Year, 7, 1));
                tbAugustus.Text = "€ " + App.GetOmzetPerMaand(new DateTime(date.Year, 8, 1));
                tbSeptember.Text = "€ " + App.GetOmzetPerMaand(new DateTime(date.Year, 9, 1));
                tbOktober.Text = "€ " + App.GetOmzetPerMaand(new DateTime(date.Year, 10, 1));
                tbNovember.Text = "€ " + App.GetOmzetPerMaand(new DateTime(date.Year, 11, 1));
                tbDecember.Text = "€ " + App.GetOmzetPerMaand(new DateTime(date.Year, 12, 1));
            }
            catch (Exception exception)
            {
                MessageBox.Show("Een error is opgetreden! Het is niet mogelijk de jaaromzet op te halen" + Environment.NewLine + Environment.NewLine +
                                exception.Message);
            }
        }
    }
}
