namespace DataBinding2
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
            this.customerDataGridView = new System.Windows.Forms.DataGridView();
            this.btAdd = new System.Windows.Forms.Button();
            this.updFirst = new System.Windows.Forms.Button();
            this.btRemoveLast = new System.Windows.Forms.Button();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // customerDataGridView
            // 
            this.customerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerDataGridView.Location = new System.Drawing.Point(12, 41);
            this.customerDataGridView.Name = "customerDataGridView";
            this.customerDataGridView.RowTemplate.Height = 24;
            this.customerDataGridView.Size = new System.Drawing.Size(601, 237);
            this.customerDataGridView.TabIndex = 0;
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(12, 12);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 23);
            this.btAdd.TabIndex = 1;
            this.btAdd.Text = "Add new";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // updFirst
            // 
            this.updFirst.Location = new System.Drawing.Point(93, 12);
            this.updFirst.Name = "updFirst";
            this.updFirst.Size = new System.Drawing.Size(91, 23);
            this.updFirst.TabIndex = 2;
            this.updFirst.Text = "Update first";
            this.updFirst.UseVisualStyleBackColor = true;
            this.updFirst.Click += new System.EventHandler(this.updFirst_Click);
            // 
            // btRemoveLast
            // 
            this.btRemoveLast.Location = new System.Drawing.Point(190, 12);
            this.btRemoveLast.Name = "btRemoveLast";
            this.btRemoveLast.Size = new System.Drawing.Size(94, 23);
            this.btRemoveLast.TabIndex = 3;
            this.btRemoveLast.Text = "Remove last";
            this.btRemoveLast.UseVisualStyleBackColor = true;
            this.btRemoveLast.Click += new System.EventHandler(this.btRemoveLast_Click);
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(419, 12);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(194, 22);
            this.tbFirstName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(335, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "First name:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 290);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFirstName);
            this.Controls.Add(this.btRemoveLast);
            this.Controls.Add(this.updFirst);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.customerDataGridView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView customerDataGridView;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button updFirst;
        private System.Windows.Forms.Button btRemoveLast;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.Label label1;
    }
}

