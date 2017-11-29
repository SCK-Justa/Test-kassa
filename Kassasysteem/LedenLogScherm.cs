using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;
using Logic.Classes;

namespace Kassasysteem
{
    public partial class LedenLogScherm : Form
    {
        private List<Lid> log;
        public KassaApp App { get; private set; }
        public LedenLogScherm(KassaApp app)
        {
            InitializeComponent();
            App = app;
            OpenOnFirstLoad();
        }

        private void OpenOnFirstLoad()
        {
            log = new List<Lid>();
            if (App.DBConnection)
            {
                log = App.GetLedenLog();
            }
            foreach (Lid l in log)
            {
                ListViewItem item = new ListViewItem(l.GetLidNaam() + " is lid geworden van Sint Sebastiaan.");
                item.BackColor = Color.DarkGreen;
                listView1.Items.Add(item);
            }
        }
    }
}
