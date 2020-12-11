using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NumericalMethods
{
    public partial class Task3 : Form
    {
        public Task3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var method = new RectanglesMethod()
            {
                Epsilon = double.Parse(epsilon.Text),
                Left = double.Parse(leftBound.Text),
                Right = double.Parse(rightBound.Text),
                FunctionString = function.Text
            };
            result.Text = method.Calculate().ToString();
            textBox1.Text = method.N.ToString();
            var data = new DataTable();
            data.Columns.Add("N", typeof(int));
            data.Columns.Add("E", typeof(double));
            for (var i = 0; i < method.EpsilonArray.Count; i++)
            {
                data.Rows.Add(method.NArray[i], method.EpsilonArray[i]);
            }
            chart1.DataSource = data;
            chart1.Series["IntegrationError"].XValueMember = "N";
            chart1.Series["IntegrationError"].YValueMembers = "E";
            chart1.Series["IntegrationError"].ChartType = SeriesChartType.Line;
            chart1.ChartAreas[0].AxisX.Title = "N";
            chart1.ChartAreas[0].AxisY.Title = "E";
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var method = new SimpsonMethod()
            {
                Epsilon = double.Parse(epsilon.Text),
                Left = double.Parse(leftBound.Text),
                Right = double.Parse(rightBound.Text),
                FunctionString = function.Text
            };
            result.Text = method.Calculate().ToString();
            textBox1.Text = method.N.ToString();
            var data = new DataTable();
            data.Columns.Add("N", typeof(int));
            data.Columns.Add("E", typeof(double));
            for (var i = 0; i < method.EpsilonArray.Count; i++)
            {
                data.Rows.Add(method.NArray[i], method.EpsilonArray[i]);
            }
            chart1.DataSource = data;
            chart1.Series["IntegrationError"].XValueMember = "N";
            chart1.Series["IntegrationError"].YValueMembers = "E";
            chart1.Series["IntegrationError"].ChartType = SeriesChartType.Line;
            chart1.ChartAreas[0].AxisX.Title = "N";
            chart1.ChartAreas[0].AxisY.Title = "E";
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var method = new TrapezoidalMethod
            {
                Epsilon = double.Parse(epsilon.Text),
                Left = double.Parse(leftBound.Text),
                Right = double.Parse(rightBound.Text),
                FunctionString = function.Text
            };
            result.Text = method.Calcualte().ToString();
            textBox1.Text = method.N.ToString();
            var data = new DataTable();
            data.Columns.Add("N", typeof(int));
            data.Columns.Add("E", typeof(double));
            for (var i = 0; i < method.EpsilonArray.Count; i++)
            {
                data.Rows.Add(method.NArray[i], method.EpsilonArray[i]);
            }
            chart1.DataSource = data;
            chart1.Series["IntegrationError"].XValueMember = "N";
            chart1.Series["IntegrationError"].YValueMembers = "E";
            chart1.Series["IntegrationError"].ChartType = SeriesChartType.Line;
            chart1.ChartAreas[0].AxisX.Title = "N";
            chart1.ChartAreas[0].AxisY.Title = "E";
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "";
        }
    }
}
