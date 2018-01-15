using System;
using System.Drawing;
using System.Windows.Forms;
using GUI;
using Logic;

namespace Kassasysteem
{
    public partial class InlogScherm : Form
    {
        public KassaApp App { get; private set; }
        public Kassa Kassa { get; private set; }

        public InlogScherm()
        {
            try
            {
                InitializeComponent();
                App = new KassaApp(SetKassaName());
                ShowDbConnection();
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }

        public InlogScherm(Kassa kassa, KassaApp app)
        {
            InitializeComponent();
            App = app;
            Kassa = kassa;
        }

        public void ShowDbConnection()
        {
            if (App.Database.GetIsConnected())
            {
                lbConnectie.Text = @"gelukt";
                lbConnectie.ForeColor = Color.Green;
            }
            else
            {
                lbConnectie.Text = @"mislukt";
                lbConnectie.ForeColor = Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            string name = tbUsername.Text;
            string ww = tbWachtwoord.Text;
            if (name != "")
            {
                if (ww != "")
                {
                    if (App.Login(name, ww))
                    {
                        tbUsername.Text = "";
                        tbWachtwoord.Text = "";
                        if (Kassa != null)
                        {
                            GebruikerScherm scherm = new GebruikerScherm(App);
                            Close();
                            Console.WriteLine("Ingelogd als: " + App.Authentication.GetFullName());
                            Console.WriteLine("Bestuursfunctie = " + App.Authentication.Lid.GetBestuursfunctie());
                            scherm.ShowDialog();
                        }
                        else
                        {
                            Kassa = new Kassa(App);
                            Console.WriteLine("Ingelogd als: " + App.Authentication.GetFullName());
                            Console.WriteLine("Bestuursfunctie = " + App.Authentication.Lid.GetBestuursfunctie());
                            Kassa.ShowDialog();
                            Kassa = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"Uw gebruikersnaam/wachtwoord klopt niet.");
                    }
                }
                else
                {
                    MessageBox.Show(@"Vul een wachtwoord in.");
                }
            }
            else
            {
                MessageBox.Show(@"Vul een gebruikersnaam in.");
            }
        }

        private void tbWachtwoord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        private string SetKassaName()
        {
            string name = "Barkassa";
            // TODO: Hier moet nog iets leuks op gevonden worden
            //string name = Environment.MachineName;
            //if(name == "SSGPC")
            //{
            //    name = "Barkassa";
            //}
            //else
            //{
            //    name = "Testkassa van Jelle";
            //}
            return name;
        }
    }
}
