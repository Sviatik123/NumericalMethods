using System;
using System.Windows.Forms;

namespace NumericalMethods
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var task = new Task1();
            task.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var task = new Task2();
            task.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var task = new Task3();
            task.Show();
        }
    }
}
