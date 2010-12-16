using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StarSystem.Objects;

namespace StarSystem.UI
{
    public partial class PlanetViewer : UserControl
    {
        private Planet planet;

        public PlanetViewer( Planet planet )
        {
            this.planet = planet;
            this.planet.Moved += new MovedEventHandler(planet_Moved);

            InitializeComponent();

            colorButton.BackColor = planet.Color;

            planet_Moved(planet);
        }

        void planet_Moved(CelestialObject sender)
        {
            xTextBox.Text = Convert.ToString(planet.GlobalPos.X);
            yTextBox.Text = Convert.ToString(planet.GlobalPos.Y);
        }

        private void createSatelliteButton_Click(object sender, EventArgs e)
        {
            ((PlanetSystem)planet.Parent).CreateSatellite();
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = planet.Color;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                planet.Color = dialog.Color;
                colorButton.BackColor = dialog.Color;
            }
        }
    }
}
