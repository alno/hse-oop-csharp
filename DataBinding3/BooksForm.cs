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
    public partial class BooksForm : Form
    {
        public BooksForm( IList<Book> books )
        {
            InitializeComponent();

            booksBindingSource.DataSource = books;
            booksBindingSource.ResumeBinding();

            bookGridView.DataSource = booksBindingSource;
        }
    }
}
