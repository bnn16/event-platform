namespace event_platform_backendwinform
{
    partial class AddEventForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Event = new TabControl();
            AddEventPage = new TabPage();
            label15 = new Label();
            checkedListBox1 = new CheckedListBox();
            label7 = new Label();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            Capacity = new TextBox();
            numPrice = new NumericUpDown();
            dateTimePicker1 = new DateTimePicker();
            rbTxtBoxDescription = new RichTextBox();
            txtBoxName = new TextBox();
            txtBoxID = new TextBox();
            tabPage2 = new TabPage();
            txtBoxVenue = new TextBox();
            txtBoxArtist = new TextBox();
            label14 = new Label();
            label13 = new Label();
            label6 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            button2 = new Button();
            CapacityConcert = new TextBox();
            numPriceConcert = new NumericUpDown();
            dateTimePicker2 = new DateTimePicker();
            rtxtBoxConcertDescription = new RichTextBox();
            txtBoxConcertName = new TextBox();
            txtBoxConcertID = new TextBox();
            label16 = new Label();
            checkedListBox2 = new CheckedListBox();
            Event.SuspendLayout();
            AddEventPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPriceConcert).BeginInit();
            SuspendLayout();
            // 
            // Event
            // 
            Event.Controls.Add(AddEventPage);
            Event.Controls.Add(tabPage2);
            Event.Location = new Point(0, 2);
            Event.Margin = new Padding(6);
            Event.Name = "Event";
            Event.SelectedIndex = 0;
            Event.Size = new Size(1072, 1143);
            Event.TabIndex = 0;
            // 
            // AddEventPage
            // 
            AddEventPage.BackColor = SystemColors.ActiveCaption;
            AddEventPage.Controls.Add(label15);
            AddEventPage.Controls.Add(checkedListBox1);
            AddEventPage.Controls.Add(label7);
            AddEventPage.Controls.Add(label5);
            AddEventPage.Controls.Add(label3);
            AddEventPage.Controls.Add(label4);
            AddEventPage.Controls.Add(label2);
            AddEventPage.Controls.Add(label1);
            AddEventPage.Controls.Add(button1);
            AddEventPage.Controls.Add(Capacity);
            AddEventPage.Controls.Add(numPrice);
            AddEventPage.Controls.Add(dateTimePicker1);
            AddEventPage.Controls.Add(rbTxtBoxDescription);
            AddEventPage.Controls.Add(txtBoxName);
            AddEventPage.Controls.Add(txtBoxID);
            AddEventPage.Location = new Point(8, 46);
            AddEventPage.Margin = new Padding(6);
            AddEventPage.Name = "AddEventPage";
            AddEventPage.Padding = new Padding(6);
            AddEventPage.Size = new Size(1056, 1089);
            AddEventPage.TabIndex = 0;
            AddEventPage.Text = "Add Event";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(706, 534);
            label15.Name = "label15";
            label15.Size = new Size(60, 32);
            label15.TabIndex = 18;
            label15.Text = "Tags";
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(712, 574);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(300, 436);
            checkedListBox1.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(124, 710);
            label7.Margin = new Padding(6, 0, 6, 0);
            label7.Name = "label7";
            label7.Size = new Size(128, 32);
            label7.TabIndex = 16;
            label7.Text = "Capacity - ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(124, 574);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(159, 32);
            label5.TabIndex = 14;
            label5.Text = "Ticket Price - ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(124, 239);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(152, 64);
            label3.TabIndex = 12;
            label3.Text = "Event \r\nDescription -";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(124, 486);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(147, 32);
            label4.TabIndex = 11;
            label4.Text = "Event Date -";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(474, 141);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(168, 32);
            label2.TabIndex = 10;
            label2.Text = "Event Name - ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(124, 141);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(127, 32);
            label1.TabIndex = 9;
            label1.Text = "Event ID - ";
            // 
            // button1
            // 
            button1.Location = new Point(277, 791);
            button1.Margin = new Padding(6);
            button1.Name = "button1";
            button1.Size = new Size(223, 70);
            button1.TabIndex = 8;
            button1.Text = "Add Event to DB!";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_ClickAsync;
            // 
            // Capacity
            // 
            Capacity.Location = new Point(277, 693);
            Capacity.Margin = new Padding(6);
            Capacity.Name = "Capacity";
            Capacity.Size = new Size(182, 39);
            Capacity.TabIndex = 7;
            // 
            // numPrice
            // 
            numPrice.Location = new Point(277, 570);
            numPrice.Margin = new Padding(6);
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(223, 39);
            numPrice.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(277, 486);
            dateTimePicker1.Margin = new Padding(6);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(368, 39);
            dateTimePicker1.TabIndex = 3;
            // 
            // rbTxtBoxDescription
            // 
            rbTxtBoxDescription.Location = new Point(277, 233);
            rbTxtBoxDescription.Margin = new Padding(6);
            rbTxtBoxDescription.Name = "rbTxtBoxDescription";
            rbTxtBoxDescription.Size = new Size(543, 200);
            rbTxtBoxDescription.TabIndex = 2;
            rbTxtBoxDescription.Text = "";
            // 
            // txtBoxName
            // 
            txtBoxName.Location = new Point(637, 141);
            txtBoxName.Margin = new Padding(6);
            txtBoxName.Name = "txtBoxName";
            txtBoxName.Size = new Size(182, 39);
            txtBoxName.TabIndex = 1;
            // 
            // txtBoxID
            // 
            txtBoxID.Location = new Point(277, 134);
            txtBoxID.Margin = new Padding(6);
            txtBoxID.Name = "txtBoxID";
            txtBoxID.Size = new Size(182, 39);
            txtBoxID.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.ActiveCaption;
            tabPage2.Controls.Add(label16);
            tabPage2.Controls.Add(checkedListBox2);
            tabPage2.Controls.Add(txtBoxVenue);
            tabPage2.Controls.Add(txtBoxArtist);
            tabPage2.Controls.Add(label14);
            tabPage2.Controls.Add(label13);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(CapacityConcert);
            tabPage2.Controls.Add(numPriceConcert);
            tabPage2.Controls.Add(dateTimePicker2);
            tabPage2.Controls.Add(rtxtBoxConcertDescription);
            tabPage2.Controls.Add(txtBoxConcertName);
            tabPage2.Controls.Add(txtBoxConcertID);
            tabPage2.Location = new Point(8, 46);
            tabPage2.Margin = new Padding(6);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(6);
            tabPage2.Size = new Size(1056, 1089);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Add Concert";
            // 
            // txtBoxVenue
            // 
            txtBoxVenue.Location = new Point(279, 830);
            txtBoxVenue.Margin = new Padding(6);
            txtBoxVenue.Name = "txtBoxVenue";
            txtBoxVenue.Size = new Size(182, 39);
            txtBoxVenue.TabIndex = 33;
            // 
            // txtBoxArtist
            // 
            txtBoxArtist.Location = new Point(279, 757);
            txtBoxArtist.Margin = new Padding(6);
            txtBoxArtist.Name = "txtBoxArtist";
            txtBoxArtist.Size = new Size(182, 39);
            txtBoxArtist.TabIndex = 32;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(126, 836);
            label14.Margin = new Padding(6, 0, 6, 0);
            label14.Name = "label14";
            label14.Size = new Size(105, 32);
            label14.TabIndex = 31;
            label14.Text = "Venue - ";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(126, 764);
            label13.Margin = new Padding(6, 0, 6, 0);
            label13.Name = "label13";
            label13.Size = new Size(86, 32);
            label13.TabIndex = 30;
            label13.Text = "Artist -";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(126, 674);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(128, 32);
            label6.TabIndex = 29;
            label6.Text = "Capacity - ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(126, 580);
            label8.Margin = new Padding(6, 0, 6, 0);
            label8.Name = "label8";
            label8.Size = new Size(159, 32);
            label8.TabIndex = 28;
            label8.Text = "Ticket Price - ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(126, 245);
            label9.Margin = new Padding(6, 0, 6, 0);
            label9.Name = "label9";
            label9.Size = new Size(152, 64);
            label9.TabIndex = 27;
            label9.Text = "Concert \r\nDescription -";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(108, 506);
            label10.Margin = new Padding(6, 0, 6, 0);
            label10.Name = "label10";
            label10.Size = new Size(171, 32);
            label10.TabIndex = 26;
            label10.Text = "Concert Date -";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(507, 132);
            label11.Margin = new Padding(6, 0, 6, 0);
            label11.Name = "label11";
            label11.Size = new Size(104, 64);
            label11.TabIndex = 25;
            label11.Text = "Concert \r\nName - ";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(126, 147);
            label12.Margin = new Padding(6, 0, 6, 0);
            label12.Name = "label12";
            label12.Size = new Size(151, 32);
            label12.TabIndex = 24;
            label12.Text = "Concert ID - ";
            // 
            // button2
            // 
            button2.Location = new Point(279, 924);
            button2.Margin = new Padding(6);
            button2.Name = "button2";
            button2.Size = new Size(223, 70);
            button2.TabIndex = 23;
            button2.Text = "Add Concert to DB!";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // CapacityConcert
            // 
            CapacityConcert.Location = new Point(279, 674);
            CapacityConcert.Margin = new Padding(6);
            CapacityConcert.Name = "CapacityConcert";
            CapacityConcert.Size = new Size(182, 39);
            CapacityConcert.TabIndex = 22;
            // 
            // numPriceConcert
            // 
            numPriceConcert.Location = new Point(279, 576);
            numPriceConcert.Margin = new Padding(6);
            numPriceConcert.Name = "numPriceConcert";
            numPriceConcert.Size = new Size(223, 39);
            numPriceConcert.TabIndex = 21;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(279, 493);
            dateTimePicker2.Margin = new Padding(6);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(368, 39);
            dateTimePicker2.TabIndex = 20;
            // 
            // rtxtBoxConcertDescription
            // 
            rtxtBoxConcertDescription.Location = new Point(279, 239);
            rtxtBoxConcertDescription.Margin = new Padding(6);
            rtxtBoxConcertDescription.Name = "rtxtBoxConcertDescription";
            rtxtBoxConcertDescription.Size = new Size(543, 200);
            rtxtBoxConcertDescription.TabIndex = 19;
            rtxtBoxConcertDescription.Text = "";
            // 
            // txtBoxConcertName
            // 
            txtBoxConcertName.Location = new Point(639, 147);
            txtBoxConcertName.Margin = new Padding(6);
            txtBoxConcertName.Name = "txtBoxConcertName";
            txtBoxConcertName.Size = new Size(182, 39);
            txtBoxConcertName.TabIndex = 18;
            // 
            // txtBoxConcertID
            // 
            txtBoxConcertID.Location = new Point(279, 141);
            txtBoxConcertID.Margin = new Padding(6);
            txtBoxConcertID.Name = "txtBoxConcertID";
            txtBoxConcertID.Size = new Size(182, 39);
            txtBoxConcertID.TabIndex = 17;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(706, 536);
            label16.Name = "label16";
            label16.Size = new Size(60, 32);
            label16.TabIndex = 35;
            label16.Text = "Tags";
            // 
            // checkedListBox2
            // 
            checkedListBox2.FormattingEnabled = true;
            checkedListBox2.Location = new Point(712, 576);
            checkedListBox2.Name = "checkedListBox2";
            checkedListBox2.Size = new Size(300, 436);
            checkedListBox2.TabIndex = 34;
            // 
            // AddEventForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1073, 1141);
            Controls.Add(Event);
            Margin = new Padding(6);
            Name = "AddEventForm";
            Text = "AddEventForm";
            Load += AddEventForm_Load;
            Event.ResumeLayout(false);
            AddEventPage.ResumeLayout(false);
            AddEventPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPriceConcert).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl Event;
        private TabPage AddEventPage;
        private TextBox Capacity;
        private NumericUpDown numPrice;
        private DateTimePicker dateTimePicker1;
        private RichTextBox rbTxtBoxDescription;
        private TextBox txtBoxName;
        private TextBox txtBoxID;
        private TabPage tabPage2;
        private Button button1;
        private Label label7;
        private Label label5;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label label1;
        private Label label6;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Button button2;
        private TextBox CapacityConcert;
        private NumericUpDown numPriceConcert;
        private DateTimePicker dateTimePicker2;
        private RichTextBox rtxtBoxConcertDescription;
        private TextBox txtBoxConcertName;
        private TextBox txtBoxConcertID;
        private TextBox txtBoxVenue;
        private TextBox txtBoxArtist;
        private Label label14;
        private Label label13;
        private Label label15;
        private CheckedListBox checkedListBox1;
        private Label label16;
        private CheckedListBox checkedListBox2;
    }
}