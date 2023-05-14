using event_platform_classLibrary;


namespace event_platform_backendwinform
{
    public partial class AddEventForm : Form
    {
        private TextBox[] textBoxes;
        private readonly IDBController _dbController;
        private readonly EventManager _eventManager;

        public AddEventForm(IDBController dbController)
        {
            InitializeComponent();
            textBoxes = new TextBox[] { txtBoxArtist, txtBoxConcertID, Capacity, txtBoxConcertName, txtBoxID, txtBoxName, txtBoxName, txtBoxVenue };
            _dbController = dbController;
            _eventManager = new EventManager(_dbController);
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            var eventObj = _eventManager.CreateEvent(Convert.ToInt32(txtBoxID.Text), txtBoxName.Text, rbTxtBoxDescription.Text, dateTimePicker1.Value, Convert.ToInt32(numPrice.Text), "Event", Convert.ToInt32(Capacity.Text));

            try
            {
                bool a = await _eventManager.AddEventAsync(eventObj);
                if (a == true)
                {
                    ClearTextBoxes();
                    MessageBox.Show("Event added!", "Congrats!!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var concertEvent = _eventManager.CreateConcertEvent(Convert.ToInt32(txtBoxConcertID.Text), txtBoxConcertName.Text, rtxtBoxConcertDescription.Text, dateTimePicker2.Value, Convert.ToInt32(numPriceConcert.Text), "Concert", Convert.ToInt32(CapacityConcert.Text), txtBoxArtist.Text, txtBoxVenue.Text);

            try
            {
                bool a = await _eventManager.AddConcertAsync(concertEvent);
                if (a == true)
                {
                    ClearTextBoxes();
                    MessageBox.Show("Concert added!", "Congrats!!!! Let's rock and roll!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearTextBoxes()
        {
            foreach (TextBox textBox in textBoxes)
            {
                textBox.Clear();
            }
            rtxtBoxConcertDescription.Clear();
            rbTxtBoxDescription.Clear();
        }
    }
}
