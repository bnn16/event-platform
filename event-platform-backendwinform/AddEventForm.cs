using event_platform_classLibrary.EventHandlers;
using event_platform_classLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace event_platform_backendwinform
{
    public partial class AddEventForm : Form
    {
        private TextBox[] textBoxes;
        public AddEventForm()
        {
            InitializeComponent();
            textBoxes = new TextBox[] { txtBoxArtist, txtBoxConcertID, Capacity, txtBoxConcertName, txtBoxID, txtBoxName, txtBoxName, txtBoxVenue };
        }

        public DBController dBController = new DBController();

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            var _eventManager = new EventManager(new EventStrategy());

            var concertEvent = _eventManager.CreateEvent(Convert.ToInt32(txtBoxID.Text), txtBoxName.Text, rbTxtBoxDescription.Text, dateTimePicker1.Value, Convert.ToInt32(numPrice.Text), "Event", Convert.ToInt32(Capacity.Text));

            try
            {
                bool a = await dBController.AddEventAsync(concertEvent);
                if (a == true)
                {
                    foreach (TextBox textBox in textBoxes)
                    {
                        rtxtBoxConcertDescription.Clear();
                        rbTxtBoxDescription.Clear();
                        textBox.Clear();
                    }
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
            var _eventManager = new EventManager(new ConcertEventStrategy());
            var concertEvent = _eventManager.CreateConcertEvent(Convert.ToInt32(txtBoxConcertID.Text), txtBoxConcertName.Text, rtxtBoxConcertDescription.Text, dateTimePicker2.Value, Convert.ToInt32(numPriceConcert.Text), "Concert", Convert.ToInt32(CapacityConcert.Text), txtBoxArtist.Text, txtBoxVenue.Text);

            try
            {
                bool a = await dBController.AddConcertAsync(concertEvent);
                if (a == true)
                {
                    foreach (TextBox textBox in textBoxes)
                    {
                        rtxtBoxConcertDescription.Clear();
                        rbTxtBoxDescription.Clear();
                        textBox.Clear();
                    }
                    MessageBox.Show("Concert added!", "Congrats!!!! Let's rock and roll!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}