using System;
using System.Windows.Forms;
using Logic;

namespace Kassasysteem
{
    public partial class GebruikerScherm : Form
    {
        public KassaApp App { get; private set; }
        public GebruikerScherm(KassaApp app)
        {
            try
            {
                InitializeComponent();
                App = app;
                UpdateGegevens();
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }

        private void UpdateGegevens()
        {
            try
            {
                lbGebruikersnaam.Text = App.Authentication.Username;
                lbVolledigeNaam.Text = App.Authentication.GetFullName();
                if (!App.Authentication.Lid.Type.Bestuur)
                {
                    btResetBestellingen.Visible = false;
                    btWijzigGebruikers.Visible = false;
                    btWijzigProducten.Visible = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }

        private void btSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                string username;
                string password;
                string fullname;
                if ((tbPassword.Text != "" && tbConfirmPassword.Text != "") ||
                    (tbPassword.Text != "" && tbConfirmPassword.Text == "") ||
                    (tbPassword.Text == "" && tbConfirmPassword.Text != ""))
                {
                    if (tbPassword.Text != tbConfirmPassword.Text)
                    {
                        throw new Exception("Voer een geldig wachtwoord in.");
                    }
                }
                if (tbUsername.Text == "")
                {
                    username = App.Authentication.Username;
                }
                else
                {
                    username = tbUsername.Text;
                }
                if (tbPassword.Text == "")
                {
                    password = App.Authentication.Password;
                }
                else
                {
                    password = tbPassword.Text;
                }
                if (tbFullName.Text == "")
                {
                    // Uuuuh
                }
                else
                {
                    fullname = tbFullName.Text;
                }
                App.Authentication.SetUsername(username);
                App.Authentication.SetPassword(password);
                MessageBox.Show(@"Uw gegevens zijn opgeslagen!","", MessageBoxButtons.OK);
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }

        private void btResetBestellingen_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show(@"Weet u zeker dat u alle bestellingen wilt resetten?", @"Reset bestellingen", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (App.SetOpenstaandeBestellingen())
                    {
                        MessageBox.Show(@"Alle openstaande bestellingen zijn succesvol gereset.");
                    }
                    else
                    {
                        MessageBox.Show(@"Er is iets fout gegaan, bestellingen konden niet gereset worden.");
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }

        private void btWijzigProducten_Click(object sender, EventArgs e)
        {
            try
            {
                VoorraadScherm scherm = new VoorraadScherm(App);
                scherm.ShowDialog();
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

        private void btWijzigGebruikers_Click(object sender, EventArgs e)
        {
            try
            {
                NieuweGebruikerScherm newUser = new NieuweGebruikerScherm(App);
                newUser.ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }
    }
}
