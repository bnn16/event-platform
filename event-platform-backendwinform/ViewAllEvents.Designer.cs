namespace event_platform_backendwinform
{
    partial class ViewAllEvents
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
            Filter = new TextBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            label6 = new Label();
            txtBoxVenue = new TextBox();
            label2 = new Label();
            txtBoxArtist = new TextBox();
            txtBoxPrice = new TextBox();
            btnDelete = new Button();
            label9 = new Label();
            btnEditEvent = new Button();
            txtBoxID = new TextBox();
            label3 = new Label();
            txtBoxCapacity = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            txtBoxName = new TextBox();
            label4 = new Label();
            txtBoxDescription = new TextBox();
            label8 = new Label();
            label5 = new Label();
            asd = new Label();
            asdasd = new Label();
            txtBoxEventType = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Filter
            // 
            Filter.Location = new Point(341, 22);
            Filter.Name = "Filter";
            Filter.Size = new Size(100, 23);
            Filter.TabIndex = 7;
            Filter.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(269, 22);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 6;
            label1.Text = "Filter";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 69);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(776, 229);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(108, 145, 194);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtBoxVenue);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtBoxArtist);
            panel1.Controls.Add(txtBoxPrice);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(btnEditEvent);
            panel1.Controls.Add(txtBoxID);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtBoxCapacity);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(txtBoxName);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtBoxDescription);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(asd);
            panel1.Controls.Add(asdasd);
            panel1.Controls.Add(txtBoxEventType);
            panel1.Location = new Point(12, 316);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 192);
            panel1.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ControlLight;
            label6.Location = new Point(317, 123);
            label6.Name = "label6";
            label6.Size = new Size(45, 17);
            label6.TabIndex = 41;
            label6.Text = "venue";
            // 
            // txtBoxVenue
            // 
            txtBoxVenue.Location = new Point(399, 121);
            txtBoxVenue.Name = "txtBoxVenue";
            txtBoxVenue.Size = new Size(204, 23);
            txtBoxVenue.TabIndex = 42;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlLight;
            label2.Location = new Point(17, 155);
            label2.Name = "label2";
            label2.Size = new Size(41, 17);
            label2.TabIndex = 39;
            label2.Text = "Artist";
            // 
            // txtBoxArtist
            // 
            txtBoxArtist.Location = new Point(99, 153);
            txtBoxArtist.Name = "txtBoxArtist";
            txtBoxArtist.Size = new Size(204, 23);
            txtBoxArtist.TabIndex = 40;
            // 
            // txtBoxPrice
            // 
            txtBoxPrice.Location = new Point(399, 17);
            txtBoxPrice.Name = "txtBoxPrice";
            txtBoxPrice.Size = new Size(204, 23);
            txtBoxPrice.TabIndex = 38;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(656, 86);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(83, 58);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete\r";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_ClickAsync;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.ControlLight;
            label9.Location = new Point(318, 86);
            label9.Name = "label9";
            label9.Size = new Size(59, 17);
            label9.TabIndex = 33;
            label9.Text = "Capacity";
            // 
            // btnEditEvent
            // 
            btnEditEvent.Location = new Point(656, 12);
            btnEditEvent.Name = "btnEditEvent";
            btnEditEvent.Size = new Size(83, 58);
            btnEditEvent.TabIndex = 1;
            btnEditEvent.Text = "Edit";
            btnEditEvent.UseVisualStyleBackColor = true;
            btnEditEvent.Click += btnEditEvent_Click;
            // 
            // txtBoxID
            // 
            txtBoxID.Location = new Point(98, 20);
            txtBoxID.Name = "txtBoxID";
            txtBoxID.Size = new Size(204, 23);
            txtBoxID.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(25, 23);
            label3.Name = "label3";
            label3.Size = new Size(24, 20);
            label3.TabIndex = 22;
            label3.Text = "ID";
            // 
            // txtBoxCapacity
            // 
            txtBoxCapacity.Location = new Point(400, 82);
            txtBoxCapacity.Name = "txtBoxCapacity";
            txtBoxCapacity.Size = new Size(204, 23);
            txtBoxCapacity.TabIndex = 34;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(98, 111);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(205, 23);
            dateTimePicker1.TabIndex = 35;
            // 
            // txtBoxName
            // 
            txtBoxName.Location = new Point(98, 49);
            txtBoxName.Name = "txtBoxName";
            txtBoxName.Size = new Size(204, 23);
            txtBoxName.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(25, 49);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 24;
            label4.Text = "Name";
            // 
            // txtBoxDescription
            // 
            txtBoxDescription.Location = new Point(98, 78);
            txtBoxDescription.Name = "txtBoxDescription";
            txtBoxDescription.Size = new Size(204, 23);
            txtBoxDescription.TabIndex = 27;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.ControlLight;
            label8.Location = new Point(318, 53);
            label8.Name = "label8";
            label8.Size = new Size(74, 17);
            label8.TabIndex = 32;
            label8.Text = "Event Type";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(5, 78);
            label5.Name = "label5";
            label5.Size = new Size(87, 20);
            label5.TabIndex = 26;
            label5.Text = "Description";
            // 
            // asd
            // 
            asd.AutoSize = true;
            asd.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            asd.ForeColor = SystemColors.ControlLight;
            asd.Location = new Point(318, 23);
            asd.Name = "asd";
            asd.Size = new Size(37, 17);
            asd.TabIndex = 30;
            asd.Text = "Price";
            // 
            // asdasd
            // 
            asdasd.AutoSize = true;
            asdasd.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            asdasd.ForeColor = SystemColors.ControlLightLight;
            asdasd.Location = new Point(25, 110);
            asdasd.Name = "asdasd";
            asdasd.Size = new Size(41, 20);
            asdasd.TabIndex = 28;
            asdasd.Text = "Date";
            // 
            // txtBoxEventType
            // 
            txtBoxEventType.Location = new Point(399, 49);
            txtBoxEventType.Name = "txtBoxEventType";
            txtBoxEventType.Size = new Size(204, 23);
            txtBoxEventType.TabIndex = 29;
            // 
            // ViewAllEvents
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(814, 520);
            Controls.Add(Filter);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "ViewAllEvents";
            Text = "ViewAllEvents";
            Load += ViewAllEvents_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Filter;
        private Label label1;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Button btnDelete;
        private Label label9;
        private Button btnEditEvent;
        private TextBox txtBoxID;
        private Label label3;
        private TextBox txtBoxCapacity;
        private DateTimePicker dateTimePicker1;
        private TextBox txtBoxName;
        private Label label4;
        private TextBox txtBoxDescription;
        private Label label8;
        private Label label5;
        private Label asd;
        private Label asdasd;
        private TextBox txtBoxEventType;
        private TextBox txtBoxPrice;
        private Label label6;
        private TextBox txtBoxVenue;
        private Label label2;
        private TextBox txtBoxArtist;
    }
}