using event_platform_classLibrary;
using event_platform_classLibrary.EventHandlers;
using System.Diagnostics;
using System.Xml.Linq;

namespace event_platform_backendwinform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void addEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEventForm abs = new AddEventForm();
            abs.Show();
        }
    }
}