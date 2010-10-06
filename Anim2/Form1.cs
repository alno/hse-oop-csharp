using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Anim2
{
    public partial class Form1 : Form
    {
        private List<MovingObject> objects = new List<MovingObject>();

        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            MovingObject obj = new MovingObject(this);

            obj.X = random.Next(ClientRectangle.Width);
            obj.Y = random.Next(ClientRectangle.Height);
            obj.VX = random.Next(10) - 5;
            obj.VY = random.Next(10) - 5;

            objects.Add(obj);
        }

        private void movingTimer_Tick(object sender, EventArgs e)
        {
            foreach (MovingObject obj in objects)
                obj.Move();
        }

    }
}
