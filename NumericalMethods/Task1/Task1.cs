using System;
using System.Windows.Forms;

namespace NumericalMethods
{
    public partial class Task1 : Form
    {
        public Task1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var method = new ChordMethod()
            {
                Epsilon = double.Parse(epsilon.Text),
                FunctionString = function.Text,
                Left = double.Parse(leftBound.Text),
                Right = double.Parse(rightBound.Text)
            };
            result.Text = method.Calculate().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var method = new IterationMethod()
            {
                Epsilon = double.Parse(epsilon.Text),
                FunctionString = function.Text,
                X0 = double.Parse(x0.Text)
            };
            result.Text = method.Calculate().ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var method = new NewtonMethod()
            {
                Epsilon = double.Parse(epsilon.Text),
                FunctionString = function.Text,
                X0 = double.Parse(x0.Text),
                Left = double.Parse(leftBound.Text),
                Right = double.Parse(rightBound.Text)
            };
            result.Text = method.Calculate().ToString();
        }
    }
}
