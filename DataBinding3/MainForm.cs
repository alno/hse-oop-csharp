using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataBinding3
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Person p1 = new Person();
            p1.FirstName = "Tester";
            p1.LastName = "TestLast";
            p1.BirthDate = DateTime.Parse("21.09.1980");
            p1.Books.Add(new Book { Title = "TestBook" });

            Person p2 = new Person();
            p2.FirstName = "Tester";
            p2.LastName = "Ivanov";
            p2.BirthDate = DateTime.Parse("10.02.1983");

            Person p3 = new Person();
            p3.FirstName = "Oleg";
            p3.LastName = "Ivanov";
            p3.BirthDate = DateTime.Parse("10.02.1983");

            personList.Add(p1);
            personList.Add(p2);
            personList.Add(p3);
        }

        private void personGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Error in column " + e.ColumnIndex);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            personBindingSource.DataSource = personList.Where(person => person.FirstName.StartsWith(tbSearchFirstName.Text) && person.LastName.StartsWith(tbSearchLastName.Text));
            personBindingSource.DataSource = from person in personList where person.FirstName.StartsWith(tbSearchFirstName.Text) && person.LastName.StartsWith(tbSearchLastName.Text) select person;
            lbRecords.Text = "Records matching " + tbSearchFirstName.Text + " " + tbSearchLastName.Text;
        }

        private void btResetSearch_Click(object sender, EventArgs e)
        {
            lbRecords.Text = "All records";
        }

        private void btBooks_Click(object sender, EventArgs e)
        {
            BooksForm f = new BooksForm( ((Person)personBindingSource.Current).Books );
            f.Show();
        }

    }
}
