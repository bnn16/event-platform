using event_platform_classLibrary;

namespace event_platform_backendwinform
{
    public partial class MainForm : Form
    {
        private readonly IDBController _dbController;
        public MainForm(IDBController dbController)
        {
            InitializeComponent();
            _dbController = new DBController();
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