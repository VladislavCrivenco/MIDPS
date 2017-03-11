using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double value = 0;
        String operation = "";
        Boolean err = false;
        bool operation_pressed = false;

        public Form1()
        {
            InitializeComponent();
        }


        private void number_Click(object sender, EventArgs e)
        {
            if (result.Text == "0"|| err)
                result.Clear();
            //operation_pressed = false;
            err = false;
            Button button = (Button) sender;
            if (button.Text == ".")
            {
                if (result.Text == "")
                    result.Text = "0,";
                else if (!result.Text.Contains(","))
                    result.Text = result.Text + ",";
            }
            else if (result.Text.Length <= 15) 
                result.Text = result.Text + button.Text;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            equation.Text = "";
            result.Text = "0";
        }

        private void operator_click(object sender, EventArgs e)
        {
            operation_pressed = true;
            err = true;
            Button button = (Button)sender;
            if (button.Text == "pow")
            {
                result.Text = Math.Pow(Double.Parse(result.Text), 2).ToString();
                value = Math.Pow(Double.Parse(result.Text), 2);
            }
            else if (button.Text == "sqrt")
            {
                if (Double.Parse(result.Text) < 0)
                    result.Text = "ERROR";
                else
                {
                    value = Math.Sqrt(Double.Parse(result.Text));
                    result.Text = value.ToString();
                }
            }
            else
            {
                operation = button.Text;
                value = Double.Parse(result.Text);
                operation_pressed = true;
                equation.Text = value + " " + operation;
            }
        }

        private void egal_Click(object sender, EventArgs e)
        {
            err = true;
            equation.Text = "";
            if (operation_pressed)
            {
                switch (operation)
                {
                    case "+":
                        result.Text = (value + Double.Parse(result.Text)).ToString();
                        break;
                    case "-":
                        result.Text = (value - Double.Parse(result.Text)).ToString();
                        break;
                    case "*":
                        result.Text = (value * Double.Parse(result.Text)).ToString();
                        break;
                    case "/":
                        if (Double.Parse(result.Text) == 0)
                        {
                            result.Text = Double.PositiveInfinity.ToString();
                            err = true;
                        }
                        else
                            result.Text = (value / Double.Parse(result.Text)).ToString();
                        break;
                }
                operation_pressed = false;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (result.Text.StartsWith("-"))
                result.Text = result.Text.Substring(1);
            else
                result.Text = "-" + result.Text;
            value = -value;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Button bt = new Button();
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                bt.Text = e.KeyChar.ToString();
                number_Click((object)bt, e);
            }
            else if (e.KeyChar == (char)Keys.Return)
            {
                MessageBox.Show("Enter!");
                e.Handled = true;
                egal_Click(bt, e);
            }
            else
            {
                switch (e.KeyChar)
                {
                    case '/':
                    case '*':
                    case '-':
                    case '+':
                        bt.Text = e.KeyChar.ToString();
                        operator_click(bt, e);
                        break;
                    default :
                        break;
                }
            }
        }



    }
}
