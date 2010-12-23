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

        private OpenView openViewDelegate;

        public PlanetViewer(Planet planet, OpenView openViewDelegate)
        {
            this.openViewDelegate = openViewDelegate;

            this.planet = planet;
            this.planet.Moved += new MovedEventHandler(planet_Moved);
            this.planet.Changed += new ChangedEventHandler(planet_Changed);

            InitializeComponent();

            planet_Changed(planet);
            planet_Moved(planet);
        }

        // Обработка уничтожения элемент управления
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose(); // Уничтожаем все внутренние элементы

                // Убираем обработчики событий
                this.planet.Moved -= new MovedEventHandler(planet_Moved);
                this.planet.Changed -= new ChangedEventHandler(planet_Changed);
            }

            base.Dispose(disposing);
        }

        void planet_Changed(CelestialObject sender)
        {
            colorButton.BackColor = planet.Color;
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

        private void moveButton_Click(object sender, EventArgs e)
        {
            try
            {
                float x = planet.Parent.LocalPos.X + (float)Convert.ToDouble(xTextBox.Text) - planet.GlobalPos.X;
                float y = planet.Parent.LocalPos.Y + (float)Convert.ToDouble(yTextBox.Text) - planet.GlobalPos.Y;

                planet.Parent.LocalPos = new PointF(x, y);
            }
            catch (FormatException)
            {
            }
        }

        private void showPlanetSystemButton_Click(object sender, EventArgs e)
        {
            openViewDelegate(new PlanetSystemViewer((PlanetSystem)planet.Parent, openViewDelegate));
        }
    }
}
