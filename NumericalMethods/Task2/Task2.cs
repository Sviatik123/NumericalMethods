using System;
using System.Linq;
using System.Windows.Forms;

namespace NumericalMethods
{
    public partial class Task2 : Form
    {
        public Task2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var method = new LagrangeMethod()
            {
                ArrayX = arrayX.Text.Split().Select(p => double.Parse(p)).ToList(),
                ArrayY = arrayY.Text.Split().Select(p => double.Parse(p)).ToList(),
                X = double.Parse(x.Text)
            };
            result.Text = method.Calculate().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var method = new NewtonMethodInterpolation()
            {
                ArrayX = arrayX.Text.Split().Select(p => double.Parse(p)).ToList(),
                ArrayY = arrayY.Text.Split().Select(p => double.Parse(p)).ToList(),
                X = double.Parse(x.Text)
            };
            result.Text = method.Calculate().ToString();
        }
    }
}
