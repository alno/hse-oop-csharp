namespace Threading1
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
            this.tbOut = new System.Windows.Forms.TextBox();
            this.bt1 = new System.Windows.Forms.Button();
            this.bw1 = new System.ComponentModel.BackgroundWorker();
            this.bt10 = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.bt2 = new System.Windows.Forms.Button();
            this.bt3 = new System.Windows.Forms.Button();
            this.bt4 = new System.Windows.Forms.Button();
            this.btPhilosophers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbOut
            // 
            this.tbOut.Location = new System.Drawing.Point(12, 70);
            this.tbOut.Multiline = true;
            this.tbOut.Name = "tbOut";
            this.tbOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOut.Size = new System.Drawing.Size(260, 147);
            this.tbOut.TabIndex = 0;
            // 
            // bt1
            // 
            this.bt1.Location = new System.Drawing.Point(12, 12);
            this.bt1.Name = "bt1";
            this.bt1.Size = new System.Drawing.Size(28, 23);
            this.bt1.TabIndex = 1;
            this.bt1.Text = "1";
            this.bt1.UseVisualStyleBackColor = true;
            this.bt1.Click += new System.EventHandler(this.bt1_Click);
            // 
            // bw1
            // 
            this.bw1.WorkerReportsProgress = true;
            this.bw1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.bw1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw1_ProgressChanged);
            // 
            // bt10
            // 
            this.bt10.Location = new System.Drawing.Point(244, 12);
            this.bt10.Name = "bt10";
            this.bt10.Size = new System.Drawing.Size(28, 23);
            this.bt10.TabIndex = 2;
            this.bt10.Text = "10";
            this.bt10.UseVisualStyleBackColor = true;
            this.bt10.Click += new System.EventHandler(this.bt10_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 41);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(260, 23);
            this.progressBar.TabIndex = 3;
            // 
            // bt2
            // 
            this.bt2.Location = new System.Drawing.Point(46, 12);
            this.bt2.Name = "bt2";
            this.bt2.Size = new System.Drawing.Size(29, 23);
            this.bt2.TabIndex = 4;
            this.bt2.Text = "2";
            this.bt2.UseVisualStyleBackColor = true;
            this.bt2.Click += new System.EventHandler(this.bt2_Click);
            // 
            // bt3
            // 
            this.bt3.Location = new System.Drawing.Point(81, 12);
            this.bt3.Name = "bt3";
            this.bt3.Size = new System.Drawing.Size(29, 23);
            this.bt3.TabIndex = 5;
            this.bt3.Text = "3";
            this.bt3.UseVisualStyleBackColor = true;
            this.bt3.Click += new System.EventHandler(this.bt3_Click);
            // 
            // bt4
            // 
            this.bt4.Location = new System.Drawing.Point(116, 12);
            this.bt4.Name = "bt4";
            this.bt4.Size = new System.Drawing.Size(30, 23);
            this.bt4.TabIndex = 6;
            this.bt4.Text = "4";
            this.bt4.UseVisualStyleBackColor = true;
            this.bt4.Click += new System.EventHandler(this.bt4_Click);
            // 
            // btPhilosophers
            // 
            this.btPhilosophers.Location = new System.Drawing.Point(180, 12);
            this.btPhilosophers.Name = "btPhilosophers";
            this.btPhilosophers.Size = new System.Drawing.Size(31, 23);
            this.btPhilosophers.TabIndex = 7;
            this.btPhilosophers.Text = "P";
            this.btPhilosophers.UseVisualStyleBackColor = true;
            this.btPhilosophers.Click += new System.EventHandler(this.btPhilosophers_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btPhilosophers);
            this.Controls.Add(this.bt4);
            this.Controls.Add(this.bt3);
            this.Controls.Add(this.bt2);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.bt10);
            this.Controls.Add(this.bt1);
            this.Controls.Add(this.tbOut);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbOut;
        private System.Windows.Forms.Button bt1;
        private System.ComponentModel.BackgroundWorker bw1;
        private System.Windows.Forms.Button bt10;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button bt2;
        private System.Windows.Forms.Button bt3;
        private System.Windows.Forms.Button bt4;
        private System.Windows.Forms.Button btPhilosophers;
    }
}

