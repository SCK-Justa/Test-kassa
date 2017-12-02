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
        private List<string> log;
        public KassaApp App { get; private set; }
        public LedenLogScherm(KassaApp app)
        {
            InitializeComponent();
            App = app;
            OpenOnFirstLoad();
        }

        private void OpenOnFirstLoad()
        {
            log = new List<string>();
            if (App.DBConnection)
            {
                log = App.GetLedenLog();
            }
            foreach (string l in log)
            {
                ListViewItem item = new ListViewItem(l);
                item.BackColor = Color.DarkGreen;
                listView1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
