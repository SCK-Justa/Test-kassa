using System;
using System.Windows.Forms;
using Logic;
using Logic.Classes;

namespace Kassasysteem
{
    public partial class NieuweGebruikerScherm : Form
    {
        public KassaApp App { get; private set; }
        public NieuweGebruikerScherm(KassaApp app)
        {
            InitializeComponent();
            App = app;
            UpdateGegevens();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btOpslaan_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbGebruikersnaam.Text == "")
                {
                    throw new Exception("Gebruikersnaam mag niet leeg zijn.");
                }
                if (tbVolledigenaam.Text == "")
                {
                    throw new Exception("Volledige naam mag niet leeg zijn.");
                }
                if (tbWachtwoord.Text == "")
                {
                    throw new Exception("Wachtwoord mag niet leeg zijn.");
                }
                App.AddGebruiker(tbGebruikersnaam.Text, tbWachtwoord.Text, tbVolledigenaam.Text, cbMachtiging.Checked);
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
                lvGebruikers.Items.Clear();
                foreach (Authentication auth in App.GetGebruikers())
                {
                    ListViewItem _item = new ListViewItem(auth.Id.ToString());
                    _item.SubItems.Add(auth.Username);
                    _item.SubItems.Add(auth.Password);
                    _item.SubItems.Add(auth.FullName);
                    _item.SubItems.Add(auth.Gemachtigd.ToString());
                    lvGebruikers.Items.Add(_item);
                }
            }
            catch

            (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }

        private void lvGebruikers_Click(object sender, EventArgs e)
        {
            try
            {
                var gebruiker = lvGebruikers.SelectedItems[0].Text;
                foreach (Authentication auth in App.GetGebruikers())
                {
                    if (auth.Id == Convert.ToInt32(gebruiker))
                    {
                        tbGebruikersnaam.Text = auth.Username;
                        tbWachtwoord.Text = auth.Password;
                        tbVolledigenaam.Text = auth.FullName;
                        cbMachtiging.Checked = auth.Gemachtigd;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Een error is opgetreden!" + Environment.NewLine + Environment.NewLine + exception.Message);
            }
        }
    }
}
