namespace event_platform_backendwinform
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            id = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            txtBoxID = new TextBox();
            txtBoxName = new TextBox();
            Capacity = new TextBox();
            label5 = new Label();
            txtBoxEventType = new TextBox();
            label1 = new Label();
            numPrice = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(184, 343);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_ClickAsync;
            // 
            // id
            // 
            id.AutoSize = true;
            id.Location = new Point(156, 74);
            id.Name = "id";
            id.Size = new Size(17, 15);
            id.TabIndex = 1;
            id.Text = "id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(156, 111);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 2;
            label2.Text = "date";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(367, 71);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 3;
            label3.Text = "name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(158, 177);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 4;
            label4.Text = "EventType";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(235, 111);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 5;
            // 
            // txtBoxID
            // 
            txtBoxID.Location = new Point(235, 71);
            txtBoxID.Name = "txtBoxID";
            txtBoxID.Size = new Size(100, 23);
            txtBoxID.TabIndex = 6;
            // 
            // txtBoxName
            // 
            txtBoxName.Location = new Point(444, 71);
            txtBoxName.Name = "txtBoxName";
            txtBoxName.Size = new Size(100, 23);
            txtBoxName.TabIndex = 7;
            // 
            // Capacity
            // 
            Capacity.Location = new Point(235, 209);
            Capacity.Name = "Capacity";
            Capacity.Size = new Size(100, 23);
            Capacity.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(158, 209);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 8;
            label5.Text = "Capacity";
            // 
            // txtBoxEventType
            // 
            txtBoxEventType.Location = new Point(235, 180);
            txtBoxEventType.Name = "txtBoxEventType";
            txtBoxEventType.Size = new Size(100, 23);
            txtBoxEventType.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(158, 151);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 11;
            label1.Text = "price";
            // 
            // numPrice
            // 
            numPrice.Location = new Point(235, 143);
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(120, 23);
            numPrice.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(numPrice);
            Controls.Add(label1);
            Controls.Add(txtBoxEventType);
            Controls.Add(Capacity);
            Controls.Add(label5);
            Controls.Add(txtBoxName);
            Controls.Add(txtBoxID);
            Controls.Add(dateTimePicker1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(id);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label id;
        private Label label2;
        private Label label3;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private TextBox txtBoxID;
        private TextBox txtBoxName;
        private TextBox Capacity;
        private Label label5;
        private TextBox txtBoxEventType;
        private Label label1;
        private NumericUpDown numPrice;
    }
}