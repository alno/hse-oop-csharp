using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Editor1
{
    abstract class Element
    {
        public Panel UI = new Panel(); // Интерфейс для элемента

        // Координаты элемента
        public Int32 X; 
        public Int32 Y;

        // Цвет элемент - открытое свойство
        public Color Color
        {
            get { return color; }
            set { color = value; colorBox.BackColor = value; }
        }

        // Контейнер на котором происходит отрисовка
        protected Control Container;

        // Цвет элемента
        private Color color = Color.Green;

        // Поле для выбора цвета
        private TextBox colorBox;

        // Конструктор элемента
        public Element(Control container)
        {
            this.Container = container;

            Label label = new Label();
            label.Text = GetType().Name;
            label.Left = 10;
            label.Top = 10;

            colorBox = new TextBox();
            colorBox.Left = 10;
            colorBox.Top = 40;
            colorBox.ReadOnly = false;
            colorBox.BackColor = color;
            colorBox.MouseClick += new MouseEventHandler(colorBox_MouseClick);
            
            UI.Controls.Add(label);
            UI.Controls.Add(colorBox);
        }

        void colorBox_MouseClick(object sender, MouseEventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = color;
            dialog.ShowDialog();

            Color = dialog.Color;
            Container.Refresh();
        }

        // Метод перерисовки элемента
        public abstract void Draw( Graphics graphics );

        // Метод проверки принадлежности точки фигуре
        public abstract bool Contains(int x, int y);

        // Чтение элемента из файла
        public virtual void Read(BinaryReader reader)
        {
            X = reader.ReadInt32();
            Y = reader.ReadInt32();

            byte r = reader.ReadByte();
            byte g = reader.ReadByte();
            byte b = reader.ReadByte();

            Color = Color.FromArgb(r, g, b);
        }

        // Запись элемента в файл
        public virtual void Write(BinaryWriter writer)
        {
            writer.Write(X);
            writer.Write(Y);

            writer.Write(color.R);
            writer.Write(color.G);
            writer.Write(color.B);
        }
    }
}
