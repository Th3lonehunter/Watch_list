
namespace Watch_list
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.tVListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.login = new System.Windows.Forms.ToolStripMenuItem();
            this.logout = new System.Windows.Forms.ToolStripMenuItem();
            this.storedDataCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu,
            this.closeToolStripMenuItem,
            this.login,
            this.logout,
            this.storedDataCheckToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1085, 29);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu
            // 
            this.Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tVListToolStripMenuItem});
            this.Menu.Font = new System.Drawing.Font("Poor Richard", 13F);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(61, 25);
            this.Menu.Text = "Menu";
            // 
            // tVListToolStripMenuItem
            // 
            this.tVListToolStripMenuItem.Name = "tVListToolStripMenuItem";
            this.tVListToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.tVListToolStripMenuItem.Text = "TV List";
            this.tVListToolStripMenuItem.Click += new System.EventHandler(this.tVListToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.closeToolStripMenuItem.Font = new System.Drawing.Font("Poor Richard", 13F);
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(60, 25);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // login
            // 
            this.login.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.login.Font = new System.Drawing.Font("Poor Richard", 13F);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(61, 25);
            this.login.Text = "Login";
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // logout
            // 
            this.logout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.logout.Enabled = false;
            this.logout.Font = new System.Drawing.Font("Poor Richard", 13F);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(70, 25);
            this.logout.Text = "Logout";
            this.logout.Visible = false;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // storedDataCheckToolStripMenuItem
            // 
            this.storedDataCheckToolStripMenuItem.Font = new System.Drawing.Font("Poor Richard", 13F);
            this.storedDataCheckToolStripMenuItem.Name = "storedDataCheckToolStripMenuItem";
            this.storedDataCheckToolStripMenuItem.Size = new System.Drawing.Size(139, 25);
            this.storedDataCheckToolStripMenuItem.Text = "stored data check";
            this.storedDataCheckToolStripMenuItem.Click += new System.EventHandler(this.storedDataCheckToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1085, 643);
            this.ControlBox = false;
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Watch List Application ";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu;
        private System.Windows.Forms.ToolStripMenuItem tVListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem login;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logout;
        private System.Windows.Forms.ToolStripMenuItem storedDataCheckToolStripMenuItem;
    }
}

