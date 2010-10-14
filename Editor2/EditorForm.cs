using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Editor1
{
    public partial class EditorForm : Form
    {
        private List<Element> elements = new List<Element>(); // Список фигур

        private Element selectedElement = null; // Выбранная фигура

        private int lastMouseX; // X-координата последнего положения мышки
        private int lastMouseY; // Y-координата последнего положения мышки
        private bool moving = false; // Проичходит ли перемещение в текущий момент

        private Random rand = new Random(); // Генератор случайных чисел

        public EditorForm()
        {
            InitializeComponent();
        }

        // Найти фигуру, включающую точку с заданными координатами
        private Element GetElement(Int32 x, Int32 y) 
        {
            foreach (Element el in elements)
                if (el.Contains(x, y))
                    return el;

            return null;
        }

        // Добавить новую фигуру
        private void AddElement(Element el)
        {
            elements.Add(el); // Добавляем новый элемент в список

            SelectElement(el); // Отмечаем новый элемент как выбранный

            splitContainer.Panel1.Refresh(); // Перерисовываем панель
        }

        // Выбрать фигуру - установить ссылку на нее и показать интерфейс редактирования
        private void SelectElement(Element el)
        {
            splitContainer.Panel2.Controls.Clear(); // Убираем старый интерфейс, если он был
            if (el != null) // Если элемент существует
                splitContainer.Panel2.Controls.Add(el.UI); // То добавляем его интерфейс на панель

            selectedElement = el; // Устанавливаем ссылку на выбранный элемент
        }

        // Событие перерисовки белой панели
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Element el in elements) // Для каждого элемента из списка
                el.Draw(e.Graphics); // Вызываем функцию прорисовки
        }

        // Пункт меню - создать прямоугольник
        private void newRectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rectangle rc = new Rectangle( splitContainer.Panel1 ); // Создаеи новую фигуру-прямоугольник

            // Генерируем случайные координаты и размеры
            rc.Width = rand.Next( 10, 100 );
            rc.Height = rand.Next(10, 100);
            rc.X = rand.Next(0, splitContainer.Panel1.ClientRectangle.Width - rc.Width);
            rc.Y = rand.Next(0, splitContainer.Panel1.ClientRectangle.Height - rc.Height);

            AddElement(rc); // Добавляем в список
        }

        // Пункт меню - создать круг
        private void newEllipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Circle rc = new Circle(splitContainer.Panel1); // Создаем новую фигуру-круг

            // Генерируем случайные координаты и радиус
            rc.Radius = rand.Next(10, 100);
            rc.X = rand.Next(rc.Radius, splitContainer.Panel1.ClientRectangle.Width - rc.Radius);
            rc.Y = rand.Next(rc.Radius, splitContainer.Panel1.ClientRectangle.Height - rc.Radius);

            AddElement(rc); // Добавляем в список
        }

        // Кнопка мыши нажата над белой панелью - выделяем компонент
        private void splitContainer_Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            SelectElement(GetElement(e.X, e.Y)); // Находим и выделяем компонент

            moving = true; // Начинаем перемещение

            // Запоминаем положение мышки
            lastMouseX = e.X;
            lastMouseY = e.Y;
        }

        // Меню - очистить
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            elements.Clear();

            splitContainer.Panel1.Refresh();
            splitContainer.Panel2.Controls.Clear();
        }

        // Сохранить фигуры
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog(); // Создаем диалог сохранения

            dialog.DefaultExt = "drw";
            dialog.Filter = "Vector Drawing (*.drw)|*.drw";
            dialog.FileName = "MyDrawing.drw";

            if (dialog.ShowDialog() == DialogResult.OK) // Если пользователь нажал ОК
            {
                BinaryWriter writer = new BinaryWriter( File.Create( dialog.FileName ) ); // Открываем файл на запись

                writer.Write( elements.Count ); // Пишем число элементов

                foreach ( Element el in elements ) // Для каждого элемента
                {
                    writer.Write(el.GetType().FullName); // Пишем полное имя класса

                    el.Write(writer); // Вызываем запись содержимого
                }

                writer.Close(); // Закрываем запись в файл
            }
        }

        // Загрузить фигуры из файла
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog(); // Создаем диалог выбора файла

            dialog.DefaultExt = "drw";
            dialog.Filter = "Vector Drawing (*.drw)|*.drw";

            if (dialog.ShowDialog() == DialogResult.OK) // Если пользователь нажал ОК
            {
                BinaryReader reader = new BinaryReader(File.OpenRead(dialog.FileName)); // Открываем файл для чтения

                int count = reader.ReadInt32(); // Читаем кол-во фигур

                elements.Clear(); // Удаляем все старые фигуры

                for (int i = 0; i < count; ++i) // Необходимое число раз читаем фигуру
                {
                    String typeName = reader.ReadString(); // Читаем полное имя класса
                    Type type = Type.GetType(typeName); // Получаем сам класс по имени
                    ConstructorInfo constructor = type.GetConstructor( new Type[]{ typeof( Control ) } ); // ПОлучаем конструктор
                    Element el = (Element) constructor.Invoke(new Object[] { splitContainer.Panel1 }); // Вызываем конструктор - создаем новую фигуру

                    el.Read(reader); // Читаем поля фигуры из файла

                    elements.Add(el); // Добавляем ее в список
                }

                reader.Close(); // Закрываем файл

                splitContainer.Panel1.Refresh(); // Перерисовываем панель
            }
        }

        // Перемещение курсора над панелью
        private void splitContainer_Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            moving = moving && e.Button == MouseButtons.Left; // Если левая кнопка не нажата - завершаем перемещение

            if (moving && selectedElement != null) // Если перемещение и выбран элемент
            {
                // Перемещаем элемент
                selectedElement.X += e.X - lastMouseX;
                selectedElement.Y += e.Y - lastMouseY;

                // Запоминаем новые координаты мышки
                lastMouseX = e.X;
                lastMouseY = e.Y;

                // Перерисовываем панель
                splitContainer.Panel1.Refresh();
            }
        }
    }
}
