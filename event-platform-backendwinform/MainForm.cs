using event_platform_classLibrary;
using event_platform_classLibrary.EventHandlers;
using System.Diagnostics;
using System.Xml.Linq;

namespace event_platform_backendwinform
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void addEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEventForm newForm = new AddEventForm();
            newForm.Show();
        }

        private void viewAllEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewAllEvents newForm = new ViewAllEvents();
            newForm.Show();
        }
    }
}