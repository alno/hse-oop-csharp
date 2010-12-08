namespace StarSystem.UI
{
    partial class PlanetViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorButton = new System.Windows.Forms.Button();
            this.createSatelliteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // colorButton
            // 
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
            this.createSatelliteButton.Location = new System.Drawing.Point(18, 110);
            this.createSatelliteButton.Name = "createSatelliteButton";
            this.createSatelliteButton.Size = new System.Drawing.Size(110, 26);
            this.createSatelliteButton.TabIndex = 1;
            this.createSatelliteButton.Text = "Create satellite";
            this.createSatelliteButton.UseVisualStyleBackColor = true;
            this.createSatelliteButton.Click += new System.EventHandler(this.createSatelliteButton_Click);
            // 
            // PlanetViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.createSatelliteButton);
            this.Controls.Add(this.colorButton);
            this.Name = "PlanetViewer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Button createSatelliteButton;
    }
}
