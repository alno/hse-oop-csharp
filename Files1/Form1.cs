using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Files1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                String path = fbd.SelectedPath;
                DirectoryInfo rootDir = new DirectoryInfo(path);

                FileInfo[] files = rootDir.GetFiles();

                lbFiles.Items.Clear();
                foreach ( FileInfo fi in files ) {
                    lbFiles.Items.Add(fi.FullName);
                }

                DirectoryInfo[] dirs = rootDir.GetDirectories();

                lbDirs.Items.Clear();
                foreach (DirectoryInfo di in dirs)
                {
                    lbDirs.Items.Add(di.Name);
                }
            }
        }
    }
}
