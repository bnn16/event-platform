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

            List<string> selectedTags = new List<string>();

            foreach (var tag in checkedListBox1.CheckedItems)
            {
                selectedTags.Add(tag.ToString());
            }

            try
            {
                bool a = await _eventManager.AddEventAsync(eventObj);
                if (a == true)
                {
                    foreach (var tag in selectedTags)
                    {
                        await _eventManager.AddEventTagAsync(eventObj.Id, tag);
                    }

                    ClearTextBoxes();
                    checkedListBox1.ClearSelected();
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

            List<string> selectedTags = new List<string>();
            foreach (var tag in checkedListBox2.CheckedItems)
            {
                selectedTags.Add(tag.ToString());
            }

            try
            {
                bool a = await _eventManager.AddConcertAsync(concertEvent);
                if (a == true)
                {
                    foreach (var tag in selectedTags)
                    {
                        await _eventManager.AddEventTagAsync(concertEvent.Id, tag);
                    }

                    ClearTextBoxes();
                    checkedListBox1.ClearSelected();
                    MessageBox.Show("Concert Added!", "Congrats!!!!");
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

        private void AddEventForm_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> eventTags = new Dictionary<int, string>()
    {
        { 1, "Art" },
        { 2, "Business" },
        { 3, "Celebrity" },
        { 4, "Charity" },
        { 5, "Concert" },
        { 6, "Conference" },
        { 7, "Cultural" },
        { 8, "Entertainment" },
        { 9, "Fashion" },
        { 10, "Festival" },
        { 11, "Film" },
        { 12, "Food" },
        { 13, "Music" },
        { 14, "Networking" },
        { 15, "Performing Arts" },
        { 16, "Sports" },
        { 17, "Technology" },
        { 18, "Theater" },
        { 19, "Travel" },
        { 20, "Comedy" }
    };

            foreach (var tag in eventTags)
            {
                checkedListBox1.Items.Add(tag.Value);
            }
        }
    }
}
