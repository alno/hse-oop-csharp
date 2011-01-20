using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataBinding2
{
    public partial class Form1 : Form
    {
        private BindingList<Customer> customerList = new BindingList<Customer>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Customer cust = new Customer();
            cust.FirstName = "First";
            cust.LastName  = "Last";
            cust.Address = "Addr";

            customerList.Add(cust);
            customerList.AllowNew = true;
            customerList.AllowRemove = true;
            customerList.AllowEdit = true;

            customerDataGridView.DataSource = customerList;

            tbFirstName.DataBindings.Add(new Binding("Text",customerList,"FirstName"));
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Customer cust = new Customer();
            cust.FirstName = "First";
            cust.LastName = "Last";
            cust.Address = "Addr";

            customerList.Add(cust);
        }

        private void updFirst_Click(object sender, EventArgs e)
        {
            customerList[0].FirstName += "!!!";
        }

        private void btRemoveLast_Click(object sender, EventArgs e)
        {
            customerList.Remove(customerList.Last());
        }

    }
}
