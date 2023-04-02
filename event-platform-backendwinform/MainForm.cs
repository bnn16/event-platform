using event_platform_classLibrary;
using event_platform_classLibrary.EventHandlers;
using System.Diagnostics;
using System.Xml.Linq;

namespace event_platform_backendwinform
{
    public partial class MainForm : Form
    {
        private readonly DBController _dbController;
        public MainForm(DBController dbController)
        {
            InitializeComponent();
            _dbController = dbController;
        }
        private void addEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEventForm newForm = new AddEventForm(_dbController);
            newForm.Show();
        }

        private void viewAllEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewAllEvents newForm = new ViewAllEvents(_dbController);
            newForm.Show();
        }
    }
}