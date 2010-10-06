namespace Editor1
{
    partial class EditorForm
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.elementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newRectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newEllipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.mainMenu.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.elementToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(517, 26);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // elementToolStripMenuItem
            // 
            this.elementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newRectangleToolStripMenuItem,
            this.newEllipseToolStripMenuItem});
            this.elementToolStripMenuItem.Name = "elementToolStripMenuItem";
            this.elementToolStripMenuItem.Size = new System.Drawing.Size(72, 22);
            this.elementToolStripMenuItem.Text = "Element";
            // 
            // newRectangleToolStripMenuItem
            // 
            this.newRectangleToolStripMenuItem.Name = "newRectangleToolStripMenuItem";
            this.newRectangleToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.newRectangleToolStripMenuItem.Text = "New rectangle";
            this.newRectangleToolStripMenuItem.Click += new System.EventHandler(this.newRectangleToolStripMenuItem_Click);
            // 
            // newEllipseToolStripMenuItem
            // 
            this.newEllipseToolStripMenuItem.Name = "newEllipseToolStripMenuItem";
            this.newEllipseToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.newEllipseToolStripMenuItem.Text = "New circle";
            this.newEllipseToolStripMenuItem.Click += new System.EventHandler(this.newEllipseToolStripMenuItem_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 26);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            this.splitContainer.Panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_Panel1_MouseClick);
            this.splitContainer.Size = new System.Drawing.Size(517, 348);
            this.splitContainer.SplitterDistance = 358;
            this.splitContainer.TabIndex = 1;
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 374);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "EditorForm";
            this.Text = "Editor";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem elementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newRectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newEllipseToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
    }
}

