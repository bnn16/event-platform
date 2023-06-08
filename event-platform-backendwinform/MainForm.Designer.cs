namespace event_platform_backendwinform
{
    partial class MainForm
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
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            addEventToolStripMenuItem = new ToolStripMenuItem();
            viewAllEventsToolStripMenuItem = new ToolStripMenuItem();
            checkBookingToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveCaption;
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, checkBookingToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(11, 4, 0, 4);
            menuStrip1.Size = new Size(1486, 44);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { addEventToolStripMenuItem, viewAllEventsToolStripMenuItem });
            toolStripMenuItem1.Image = Properties.Resources.icons8_events_32;
            toolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(135, 38);
            toolStripMenuItem1.Text = "Events";
            // 
            // addEventToolStripMenuItem
            // 
            addEventToolStripMenuItem.Image = Properties.Resources.icons8_add_32;
            addEventToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            addEventToolStripMenuItem.Name = "addEventToolStripMenuItem";
            addEventToolStripMenuItem.Size = new Size(306, 44);
            addEventToolStripMenuItem.Text = "Add Event";
            addEventToolStripMenuItem.Click += addEventToolStripMenuItem_Click;
            // 
            // viewAllEventsToolStripMenuItem
            // 
            viewAllEventsToolStripMenuItem.Image = Properties.Resources.icons8_spreadsheet_32;
            viewAllEventsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            viewAllEventsToolStripMenuItem.Name = "viewAllEventsToolStripMenuItem";
            viewAllEventsToolStripMenuItem.Size = new Size(306, 44);
            viewAllEventsToolStripMenuItem.Text = "View all events";
            viewAllEventsToolStripMenuItem.Click += viewAllEventsToolStripMenuItem_Click;
            // 
            // checkBookingToolStripMenuItem
            // 
            checkBookingToolStripMenuItem.Image = Properties.Resources.icons8_spreadsheet_32;
            checkBookingToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            checkBookingToolStripMenuItem.Name = "checkBookingToolStripMenuItem";
            checkBookingToolStripMenuItem.Size = new Size(226, 38);
            checkBookingToolStripMenuItem.Text = "Check Booking";
            checkBookingToolStripMenuItem.Click += checkBookingToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._1600x600_events_background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1486, 960);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(6);
            Name = "MainForm";
            Text = "Home";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem addEventToolStripMenuItem;
        private ToolStripMenuItem viewAllEventsToolStripMenuItem;
        private ToolStripMenuItem checkBookingToolStripMenuItem;
    }
}