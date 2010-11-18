using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StarSystem
{
    public partial class SpaceViewForm : Form
    {
        private Random rand = new Random();
        private StarSystem starSystem;

        private PointF center = new PointF(0,0);
        private float scale = 1.0f;

        public SpaceViewForm()
        {
            InitializeComponent();

            StartStopAnimation(true);

            starSystem = new StarSystem();
            starSystem.CreatePlanet(rand.NextDouble() * 100 + 20, rand.NextDouble() * 5);
            starSystem.CreatePlanet(rand.NextDouble() * 100 + 20, rand.NextDouble() * 5);
        }

        private void StartStopAnimation(bool value)
        {
            animationTimer.Enabled = value;

            stopToolStripMenuItem.Enabled = value;
            startToolStripMenuItem.Enabled = !value;
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            starSystem.Animate(0.01);
            splitContainer.Panel1.Refresh();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            starSystem = new StarSystem();
        }

        private void newPlanetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            starSystem.CreatePlanet( rand.NextDouble() * 100 + 20, rand.NextDouble() * 5 );

            splitContainer.Panel1.Refresh();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = splitContainer.Panel1.ClientRectangle;

            e.Graphics.TranslateTransform(r.Width / 2, r.Height/2);
            e.Graphics.ScaleTransform(scale, scale);
            e.Graphics.TranslateTransform(-center.X,-center.Y);
            starSystem.Draw(e.Graphics);
        }

        private void mainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartStopAnimation(true);
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartStopAnimation(false);
        }

        private Point lastMousePoint;

        private bool moving = false;
        private bool scaling = false;

        private void splitContainer_Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = e.Button == MouseButtons.Left;
            scaling = e.Button == MouseButtons.Right;

            lastMousePoint = e.Location;
        }

        private void splitContainer_Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            moving = moving && e.Button == MouseButtons.Left;
            scaling = scaling && e.Button == MouseButtons.Right;

            if (moving)
            {
                center.X -= (float)((e.X - lastMousePoint.X) / scale);
                center.Y -= (float)((e.Y - lastMousePoint.Y) / scale);

                splitContainer.Panel1.Refresh();
            }

            if (scaling)
            {
                scale *= (float)( Math.Exp((e.X - lastMousePoint.X)/200.0) );

                splitContainer.Panel1.Refresh();
            }

            lastMousePoint = e.Location;
        }

        private void countBodiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach ( CelestialBody b in starSystem.AllBodies ) {
                ++ count;
            }

            MessageBox.Show(Convert.ToString(count));
        }
    }
}
