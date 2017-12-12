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
            FillComboBox();
            try
            {
                string omzet = App.GetOmzetPerJaar(DateTime.Now).ToString();
                tbJaaromzet.Text = omzet;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Een error is opgetreden! Het is niet mogelijk de jaaromzet op te halen" + Environment.NewLine + Environment.NewLine +
                                exception.Message);
            }
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
    }
}
