using System.Windows.Forms;
using Logic;

namespace Kassasysteem
{
    public partial class PenningmeesterScherm : Form
    {
        public KassaApp App { get; private set; }
        public PenningmeesterScherm(KassaApp app)
        {
            InitializeComponent();
            App = app;
        }
    }
}
