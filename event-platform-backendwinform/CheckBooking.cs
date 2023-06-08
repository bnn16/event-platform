using event_platform_classLibrary;
using System.Text.RegularExpressions;

namespace event_platform_backendwinform
{
    public partial class CheckBooking : Form
    {
        private readonly IDBController _dbController;
        private readonly EventManager eventManager;
        public CheckBooking(IDBController dbController)
        {
            InitializeComponent();
            _dbController = dbController;
            eventManager = new EventManager(_dbController);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = textBox1.Text != string.Empty ? textBox1.Text : "";

            string pattern = @"^(?!#)";
            string patternRes = Regex.Replace(code, pattern, "#");

            bool result = eventManager.CheckBooking(patternRes);
            if (result)
            {
                MessageBox.Show("Let them through, they shall enter.", "Success");
                eventManager.DeleteBooking(patternRes);
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Don't let them pass!, Kill them", "Execute");
            }
        }
    }
}
