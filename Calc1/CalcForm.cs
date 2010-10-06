using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calc1
{
    public partial class CalcForm : Form
    {
        public CalcForm()
        {
            InitializeComponent();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            Int32 firstNumber = Convert.ToInt32(textBoxFirstNumber.Text);
            Int32 secondNumber = Convert.ToInt32(textBoxSecondNumber.Text);

            switch (comboBoxOperation.SelectedIndex)
            {
                case 0:
                    textBoxResult.Text = Convert.ToString(firstNumber + secondNumber);
                    break;
                case 1:
                    textBoxResult.Text = Convert.ToString(firstNumber - secondNumber);
                    break;
                default:
                    MessageBox.Show("Неизвестная операция!");
                    break;
            }
        }
    }
}
