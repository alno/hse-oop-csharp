using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Anim1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void movingTimer_Tick(object sender, EventArgs e)
        {
            int cX = center.Left + center.Width / 2;
            int cY = center.Top + center.Height / 2;

            movingObj.Left = (int)Math.Round(Math.Cos(angle) * distance + cX - movingObj.Width / 2);
            movingObj.Top = (int)Math.Round(Math.Sin(angle) * distance + cY - movingObj.Height / 2);

            angle += 0.1;
        }

        private double angle = 0;
        private double distance = 100;

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            center.Left = e.X - center.Width / 2;
            center.Top = e.Y - center.Height / 2;
        }
    }
}
