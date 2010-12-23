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
    public partial class PlanetSystemViewer : UserControl
    {
        private PlanetSystem planetSystem;

        private OpenView openViewDelegate;

        public PlanetSystemViewer(PlanetSystem planetSystem, OpenView openViewDelegate)
        {
            this.openViewDelegate = openViewDelegate;

            this.planetSystem = planetSystem;
            this.planetSystem.Moved += new MovedEventHandler(planetSystem_Moved);

            InitializeComponent();

            planetSystem_Moved(planetSystem);
        }

        // Обработка уничтожения элемент управления
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose(); // Уничтожаем все внутренние элементы

                // Убираем обработчики событий
                this.planetSystem.Moved -= new MovedEventHandler(planetSystem_Moved);
            }

            base.Dispose(disposing);
        }


        void planetSystem_Moved(CelestialObject sender)
        {
            xTextBox.Text = Convert.ToString(planetSystem.GlobalPos.X);
            yTextBox.Text = Convert.ToString(planetSystem.GlobalPos.Y);
        }

    }
}
