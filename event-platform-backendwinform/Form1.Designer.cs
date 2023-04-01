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
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            addEventToolStripMenuItem = new ToolStripMenuItem();
            viewAllEventsToolStripMenuItem = new ToolStripMenuItem();
            usersToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveCaption;
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, usersToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 40);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { addEventToolStripMenuItem, viewAllEventsToolStripMenuItem });
            toolStripMenuItem1.Image = Properties.Resources.icons8_events_32;
            toolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(85, 36);
            toolStripMenuItem1.Text = "Events";
            // 
            // addEventToolStripMenuItem
            // 
            addEventToolStripMenuItem.Image = Properties.Resources.icons8_add_32;
            addEventToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            addEventToolStripMenuItem.Name = "addEventToolStripMenuItem";
            addEventToolStripMenuItem.Size = new Size(196, 38);
            addEventToolStripMenuItem.Text = "Add Event";
            addEventToolStripMenuItem.Click += addEventToolStripMenuItem_Click;
            // 
            // viewAllEventsToolStripMenuItem
            // 
            viewAllEventsToolStripMenuItem.Image = Properties.Resources.icons8_spreadsheet_32;
            viewAllEventsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            viewAllEventsToolStripMenuItem.Name = "viewAllEventsToolStripMenuItem";
            viewAllEventsToolStripMenuItem.Size = new Size(196, 38);
            viewAllEventsToolStripMenuItem.Text = "View all events";
            // 
            // usersToolStripMenuItem
            // 
            usersToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            usersToolStripMenuItem.Image = Properties.Resources.icons8_google_groups_32;
            usersToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            usersToolStripMenuItem.Size = new Size(79, 36);
            usersToolStripMenuItem.Text = "Users";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._1600x600_events_background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
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
        private ToolStripMenuItem usersToolStripMenuItem;
    }
}