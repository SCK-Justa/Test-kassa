using Logic;
using System.IO;
using System.Windows.Forms;

namespace Kassasysteem
{
    public partial class UpdatesScreen : Form
    {
        public KassaApp App { get; private set; }
        public UpdatesScreen(KassaApp app)
        {
            InitializeComponent();
            App = app;
            InitialUpdate("Updates.txt");
        }

        private void InitialUpdate(string path)
        {
            try
            {
                string text = "";
                using (StreamReader reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        string input = reader.ReadLine();
                        text += (input + System.Environment.NewLine);
                    }
                }
                tbUpdates.Text = text;
            }
            catch (IOException)
            {
                MessageBox.Show("Filelokatie kan niet worden gevonden.");
            }
        }
    }
}
