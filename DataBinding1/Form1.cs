using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataBinding1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            BindingContext[dataSet, "Customers"].PositionChanged += new EventHandler(Form1_PositionChanged);

            DataTable table = dataSet.Tables["Customers"];
            DataRow row = table.NewRow();
            row["FirstName"] = "Tester";
            row["LastName"] = "LastName";
            row["Address"] = "Address";
            table.Rows.Add( row );
        }

        void Form1_PositionChanged(object sender, EventArgs e)
        {
            tbPos.Text = Convert.ToString(BindingContext[dataSet, "Customers"].Position);
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            BindingManagerBase bm = BindingContext[dataSet, "Customers"];

            if (bm.Position < bm.Count - 1)
                bm.Position++;
        }
    }
}
