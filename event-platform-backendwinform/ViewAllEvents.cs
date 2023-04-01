using event_platform_classLibrary;
using event_platform_classLibrary.EventHandlers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace event_platform_backendwinform
{
    public partial class ViewAllEvents : Form
    {
        private TextBox[] textBoxes;
        public ViewAllEvents()
        {
            InitializeComponent();
            textBoxes = new TextBox[] { txtBoxArtist,txtBoxCapacity,txtBoxDescription,txtBoxEventType,txtBoxID,txtBoxName,txtBoxPrice,txtBoxVenue };

        }
        private DBController dbController = new DBController();

        private void ViewAllEvents_Load(object sender, EventArgs e)
        {
            var datatable = dbController.GetAllEvents();

            dataGridView1.DataSource = datatable;
        }
        int rid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1)
            {
                MessageBox.Show("Column Header clicked.");
            }

            else
            {
                //populate the datagrid view.
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                var dataSet = dbController.GetEventById(id);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    CultureInfo provider = new CultureInfo("en-US");
                    rid = int.Parse(dataSet.Tables[0].Rows[0][0].ToString());
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
                    if (txtBoxVenue.Text == "" && txtBoxArtist.Text == "")
                    {
                        txtBoxVenue.Enabled = false;
                        txtBoxArtist.Enabled = false;
                    }
                    else
                    {
                        txtBoxVenue.Enabled = true;
                        txtBoxArtist.Enabled = true;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Filter.Text != "")
            {
                var filter = dbController.GetEventByFilter(Filter.Text);
                dataGridView1.DataSource = filter;
            }
            else
            {
                var datatable = dbController.GetAllEvents();
                dataGridView1.DataSource = datatable;
            }
        }

        private async void btnEditEvent_Click(object sender, EventArgs e)
        {
            if (txtBoxEventType.Text == "Concert") 
            {
                try
                {
                    //todo bug -> decimal to int wrong format??? need to fix asap
                    var Price = Convert.ToInt32(txtBoxPrice.Text);
                    var _eventManager = new EventManager(new ConcertEventStrategy());
                    var updatedEvent = _eventManager.CreateConcertEvent(Int32.Parse(txtBoxID.Text), txtBoxName.Text, txtBoxDescription.Text, dateTimePicker1.Value, Price, txtBoxEventType.Text, Int32.Parse(txtBoxCapacity.Text),txtBoxArtist.Text,txtBoxVenue.Text); ;

                    //clear the txtBoxes
                    var updatedBool = await dbController.UpdateConcertEventAsync(updatedEvent, rid);
                    foreach (TextBox textBox in textBoxes)
                    {
                        textBox.Clear();
                    }
                    //update the datagridview 
                    var datatable = dbController.GetAllEvents();
                    dataGridView1.DataSource = datatable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (txtBoxEventType.Text == "Event") { 
                //todo
            }
        }
    }
}
