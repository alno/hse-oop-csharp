namespace Anim1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.movingTimer = new System.Windows.Forms.Timer(this.components);
            this.movingObj = new System.Windows.Forms.Button();
            this.center = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // movingTimer
            // 
            this.movingTimer.Enabled = true;
            this.movingTimer.Tick += new System.EventHandler(this.movingTimer_Tick);
            // 
            // movingObj
            // 
            this.movingObj.Enabled = false;
            this.movingObj.Location = new System.Drawing.Point(70, 58);
            this.movingObj.Name = "movingObj";
            this.movingObj.Size = new System.Drawing.Size(29, 29);
            this.movingObj.TabIndex = 0;
            this.movingObj.Text = "O";
            this.movingObj.UseVisualStyleBackColor = true;
            // 
            // center
            // 
            this.center.Location = new System.Drawing.Point(199, 182);
            this.center.Name = "center";
            this.center.Size = new System.Drawing.Size(29, 29);
            this.center.TabIndex = 1;
            this.center.Text = "C";
            this.center.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 458);
            this.Controls.Add(this.center);
            this.Controls.Add(this.movingObj);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer movingTimer;
        private System.Windows.Forms.Button movingObj;
        private System.Windows.Forms.Button center;
    }
}

