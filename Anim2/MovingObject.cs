using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Anim2
{
    class MovingObject
    {
        private Form1 form;
        private Button button;

        public Int32 VX;
        public Int32 VY;

        public Int32 X
        {
            get { return button.Left + button.Width / 2; }
            set { button.Left = value - button.Width / 2; }
        }

        public Int32 Y
        {
            get { return button.Top + button.Height / 2; }
            set { button.Top = value - button.Height / 2; }
        }

        public MovingObject(Form1 form)
        {
            this.button = new Button();
            this.button.Width = 30;
            this.button.Height = 30;

            this.form = form;
            this.form.Controls.Add(button);
        }

        public void Move()
        {
            if (X + VX < 0 || X + VX > form.ClientRectangle.Width)
                VX = -VX;
            if (Y + VY < 0 || Y + VY > form.ClientRectangle.Height)
                VY = -VY;

            X = X + VX;
            Y = Y + VY;
        }

        public void Dispose()
        {
            this.button.Dispose();
        }
    }
}
