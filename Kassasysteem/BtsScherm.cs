using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Logic;
using Logic.Classes;

namespace Kassasysteem
{
    public partial class BtsScherm : Form
    {
        private List<Bestelling> _orders;
        
        private bool allOrders;
        private bool paidOrders;
        private bool unpaidOrders;
        private bool ordersBetweenDates;
        private bool paidBySsg;
        private DateTime beginDate;
        private DateTime endDate;

        public KassaApp App { get; }
        public BtsScherm(KassaApp app)
        {
            InitializeComponent();
            App = app;
            _orders = new List<Bestelling>();
        }

        public void InitialLoad()
        {
            _orders = App.GetAllOrders();
        }

        private List<Bestelling> GetPaidOrders()
        {
            return App.GetPaidOrders();
        }

        private List<Bestelling> GetOrdersFromDate()
        {
            return App.GetOrdersBetweenDates(beginDate, endDate);
        }

        private List<Bestelling> GetUnpaidOrders()
        {
            return App.GetUnpaidOrders();
        }

        private List<Bestelling> GetPaidOrdersBySsg()
        {
            return App.GetPaidOrdersBySsg();
        }

        private List<Bestelling> GetAllOrders()
        {
            return App.GetAllOrders();
        }

        private void FillListView(List<Bestelling> orders)
        {
            lvOrders.Items.Clear();
            foreach (Bestelling b in orders)
            {
                ListViewItem lvi = new ListViewItem(b.Id.ToString());
                lvi.SubItems.Add(b.GetBesteller()); // Naam besteller
                lvi.SubItems.Add(b.GetLidId().ToString()); // Lid Id
                lvi.SubItems.Add(b.Datum.ToShortTimeString() + " - " + b.Datum.ToShortDateString()); // Aanmaakdatum
                lvi.SubItems.Add(b.Betaald.ToString()); // Is bestelling betaald
                lvi.SubItems.Add(b.DatumBetaald.ToShortTimeString() + " - " + b.DatumBetaald.ToShortDateString()); // Betaaldatum
                lvi.SubItems.Add(b.BetaaldMetMunten.ToString()); // Is met munten betaald
                lvi.SubItems.Add("€ " + b.BetaaldBedrag); // Bedrag
                lvi.SubItems.Add(b.BetaaldBestuur.ToString()); // Is betaald door het bestuur
                lvi.SubItems.Add(b.GetOpmerking()); // Opmerking
                lvi.Tag = b;
                lvOrders.Items.Add(lvi);
            }
        }

        private void cbPaidOrders_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCheckboxes(false, true, false, false, false);
        }

        private void cbUnpaidOrders_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCheckboxes(false, false, true, false, false);
        }

        private void cbByBestuur_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCheckboxes(false, false, false, false, true);
        }

        private void cbBetweenDates_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCheckboxes(false, false, false, true, false);
        }
        private void cbAllOrders_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCheckboxes(true, false, false, false, false);
        }

        private void ChangeCheckboxes(bool all, bool paid, bool unpaid, bool dates, bool ssg)
        {
            allOrders = all;
            paidOrders = paid;
            unpaidOrders = unpaid;
            ordersBetweenDates = dates;
            paidBySsg = ssg;
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                lvOrders.Items.Clear();
                CheckCheckboxes();
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine +
                                exception.Message);
            }
        }

        private void CheckCheckboxes()
        {
            if (allOrders)
            {
                _orders = GetAllOrders();
            }
            else
            {
                if (paidOrders)
                {
                    _orders.AddRange(GetPaidOrders());
                }

                if (unpaidOrders)
                {
                    _orders.AddRange(GetUnpaidOrders());
                }

                if (ordersBetweenDates)
                {
                    beginDate = new DateTime(dtBeginDate.Value.Year, dtBeginDate.Value.Month, dtBeginDate.Value.Day);
                    endDate = new DateTime(dtEndDate.Value.Year, dtEndDate.Value.Month, dtEndDate.Value.Day);
                    _orders.AddRange(GetOrdersFromDate());
                }

                if (paidBySsg)
                {
                    _orders.AddRange(GetPaidOrdersBySsg());
                }
            }
            FillListView(_orders);
        }
    }
}
