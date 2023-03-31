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
        public DBController dBController = new DBController();

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            var _eventManager = new EventManager(new EventStrategy());
            
            var concertEvent = _eventManager.CreateEvent(Convert.ToInt32(txtBoxID.Text), txtBoxName.Text, dateTimePicker1.Value, Convert.ToInt32(numPrice.Text), txtBoxEventType.Text, Convert.ToInt32(Capacity.Text));

            try
            {
                bool a = await dBController.AddEventAsync(concertEvent);
                if (a == true)
                {
                    MessageBox.Show("Event added!", "Congrats!!!!");
                }
                else { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}