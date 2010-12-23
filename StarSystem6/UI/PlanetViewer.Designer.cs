namespace StarSystem.UI
{
    partial class PlanetViewer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorButton = new System.Windows.Forms.Button();
            this.createSatelliteButton = new System.Windows.Forms.Button();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.moveButton = new System.Windows.Forms.Button();
            this.showPlanetSystemButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // colorButton
            // 
            this.colorButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.colorButton.Location = new System.Drawing.Point(18, 14);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(110, 31);
            this.colorButton.TabIndex = 0;
            this.colorButton.Text = "Color";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // createSatelliteButton
            // 
            this.createSatelliteButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.createSatelliteButton.Location = new System.Drawing.Point(18, 136);
            this.createSatelliteButton.Name = "createSatelliteButton";
            this.createSatelliteButton.Size = new System.Drawing.Size(110, 26);
            this.createSatelliteButton.TabIndex = 1;
            this.createSatelliteButton.Text = "Create satellite";
            this.createSatelliteButton.UseVisualStyleBackColor = true;
            this.createSatelliteButton.Click += new System.EventHandler(this.createSatelliteButton_Click);
            // 
            // xTextBox
            // 
            this.xTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xTextBox.Location = new System.Drawing.Point(18, 51);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(110, 22);
            this.xTextBox.TabIndex = 2;
            // 
            // yTextBox
            // 
            this.yTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.yTextBox.Location = new System.Drawing.Point(18, 79);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(110, 22);
            this.yTextBox.TabIndex = 3;
            // 
            // moveButton
            // 
            this.moveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.moveButton.Location = new System.Drawing.Point(18, 107);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(110, 23);
            this.moveButton.TabIndex = 4;
            this.moveButton.Text = "Move";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // showPlanetSystemButton
            // 
            this.showPlanetSystemButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.showPlanetSystemButton.Location = new System.Drawing.Point(18, 193);
            this.showPlanetSystemButton.Name = "showPlanetSystemButton";
            this.showPlanetSystemButton.Size = new System.Drawing.Size(110, 23);
            this.showPlanetSystemButton.TabIndex = 5;
            this.showPlanetSystemButton.Text = "Planet system";
            this.showPlanetSystemButton.UseVisualStyleBackColor = true;
            this.showPlanetSystemButton.Click += new System.EventHandler(this.showPlanetSystemButton_Click);
            // 
            // PlanetViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.showPlanetSystemButton);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.yTextBox);
            this.Controls.Add(this.xTextBox);
            this.Controls.Add(this.createSatelliteButton);
            this.Controls.Add(this.colorButton);
            this.Name = "PlanetViewer";
            this.Size = new System.Drawing.Size(150, 229);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Button createSatelliteButton;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Button showPlanetSystemButton;
    }
}
