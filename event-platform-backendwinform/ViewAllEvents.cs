using event_platform_classLibrary;
using System.Globalization;
using System.Text.RegularExpressions;
using TextBox = System.Windows.Forms.TextBox;

namespace event_platform_backendwinform
{
    public partial class ViewAllEvents : Form
    {
        private readonly IDBController _dbController;
        private TextBox[] textBoxes;
        private readonly EventManager _eventManager;

        public ViewAllEvents(IDBController dbController)
        {
            _dbController = dbController;
            InitializeComponent();
            textBoxes = new TextBox[] { txtBoxArtist, txtBoxCapacity, txtBoxDescription, txtBoxEventType, txtBoxID, txtBoxName, txtBoxPrice, txtBoxVenue };
            txtBoxVenue.Enabled = false;
            txtBoxArtist.Enabled = false;
            _eventManager = new EventManager(_dbController);
        }

        private void ViewAllEvents_Load(object sender, EventArgs e)
        {
            var datatable = _eventManager.GetAllEvents();
            dataGridView1.DataSource = datatable;
        }

        private string oldEventType;

        private void TxtBoxEventType_TextChanged(object? sender, EventArgs e)
        {
            string newText = txtBoxEventType.Text;

            if (oldEventType == "Event" && newText == "Concert")
            {
                txtBoxVenue.Enabled = true;
                txtBoxArtist.Enabled = true;
            }
            else if (newText == "Concert")
            {
                txtBoxVenue.Enabled = true;
                txtBoxArtist.Enabled = true;
            }
            else
            {
                txtBoxVenue.Enabled = false;
                txtBoxArtist.Enabled = false;
            }
            oldEventType = newText;
        }

        int selectedEventId;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                MessageBox.Show("Column Header clicked.");
            }
            else
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                var dataSet = _eventManager.GetEventById(id);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    CultureInfo provider = new CultureInfo("en-US");
                    selectedEventId = int.Parse(dataSet.Tables[0].Rows[0][0].ToString());
                    txtBoxID.Text = dataSet.Tables[0].Rows[0][0].ToString();
                    txtBoxName.Text = dataSet.Tables[0].Rows[0][1].ToString();
                    txtBoxDescription.Text = dataSet.Tables[0].Rows[0][2].ToString();

                    DateTime dateTime;
                    if (DateTime.TryParse(dataSet.Tables[0].Rows[0][3].ToString(), out dateTime))
                    {
                        dateTimePicker1.Text = dateTime.ToString();
                    }
                    else
                    {
                        dateTimePicker1.Text = DateTime.ParseExact(dataSet.Tables[0].Rows[0][3].ToString(), "dd/MM/yyyy", provider).ToString();
                    }

                    txtBoxPrice.Text = dataSet.Tables[0].Rows[0][4].ToString();
                    txtBoxEventType.Text = dataSet.Tables[0].Rows[0][5].ToString();
                    txtBoxCapacity.Text = dataSet.Tables[0].Rows[0][6].ToString();
                    txtBoxArtist.Text = dataSet.Tables[0].Rows[0][7].ToString();
                    txtBoxVenue.Text = dataSet.Tables[0].Rows[0][8].ToString();

                    txtBoxEventType.TextChanged += TxtBoxEventType_TextChanged;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Filter.Text != "")
            {
                var filter = _eventManager.GetEventByFilter(Filter.Text);
                dataGridView1.DataSource = filter;
            }
            else
            {
                var datatable = _eventManager.GetAllEvents();
                dataGridView1.DataSource = datatable;
            }
        }

        private async void btnEditEvent_Click(object sender, EventArgs e)
        {
            if (txtBoxEventType.Text == "Concert")
            {
                try
                {
                    var Price = Convert.ToInt32(Regex.Replace(txtBoxPrice.Text, @"\..*$", ""));
                    var updatedConcert = _eventManager.CreateConcertEvent(Int32.Parse(txtBoxID.Text), txtBoxName.Text, txtBoxDescription.Text, dateTimePicker1.Value, Price, txtBoxEventType.Text, Int32.Parse(txtBoxCapacity.Text), txtBoxArtist.Text, txtBoxVenue.Text);

                    var updatedBoolConcert = await _eventManager.UpdateConcertEventAsync(updatedConcert, selectedEventId);
                    if (updatedBoolConcert)
                    {
                        MessageBox.Show("Success!", "Gratz you edited the Concert!");
                        ClearTextBoxes();
                        var datatable = _eventManager.GetAllEvents();
                        dataGridView1.DataSource = datatable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (txtBoxEventType.Text == "Event")
            {
                try
                {
                    var Price = Convert.ToInt32(Regex.Replace(txtBoxPrice.Text, @"\..*$", ""));
                    var updatedEvent = _eventManager.CreateEvent(Int32.Parse(txtBoxID.Text), txtBoxName.Text, txtBoxDescription.Text, dateTimePicker1.Value, Price, txtBoxEventType.Text, Int32.Parse(txtBoxCapacity.Text));

                    var updateBoolEvent = await _eventManager.UpdateEventAsync(updatedEvent, selectedEventId);

                    if (updateBoolEvent)
                    {
                        MessageBox.Show("Success!", "Gratz you edited the Event!");
                        ClearTextBoxes();
                        var datatable = _eventManager.GetAllEvents();
                        dataGridView1.DataSource = datatable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void btnDelete_ClickAsync(object sender, EventArgs e)
        {
            DialogResult dresult = MessageBox.Show("Are you sure you want to delete the event?!", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dresult == DialogResult.OK)
            {
                try
                {
                    var deleteBoolEvent = _eventManager.DeleteEvent(selectedEventId);

                    MessageBox.Show("Event Successfully Deleted", "Success");

                    ClearTextBoxes();
                    var datatable = _eventManager.GetAllEvents();
                    dataGridView1.DataSource = datatable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ClearTextBoxes()
        {
            foreach (TextBox textBox in textBoxes)
            {
                textBox.Clear();
            }
        }
    }
}