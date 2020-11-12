using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numerical_Methods_2
{
    public partial class Form1 : Form
    {
        const double Pi = 3.14;
        const double h = Pi / 7;

        public Form1()
        {
            InitializeComponent();
        }

        double f(double x)
        {
            return Math.Sin(x) * Math.Sqrt(x) + 1;
        }

        double f_const(int k)
        {
            double[] x_array = new double[5] {h / 2, h * 5 / 2, h * 13 / 2, h * 9 / 2, h * 3 / 2};
            double FuncSum = 0;
            double FuncMult = 1;
            int i = 1, j = 1;
            while (i <= k)
            {
                j = 1;
                while (j <= k)
                {
                    if (j != i) FuncMult *= x_array[i - 1] - x_array[j - 1];
                    j++;
                }
                FuncSum += f(x_array[i - 1]) / FuncMult;
                FuncMult = 1;
                i++;
            }
            return FuncSum;
        }

        double Ln(double x, int n)
        { 
            double[] x_array = new double[5] { h / 2, h * 5 / 2, h * 13 / 2, h * 9 / 2, h * 3 / 2 };

            int i = 1;
            double FuncSum = 0;

            while (i <= n)
            {
                switch (i)
                {
                    case 1:
                        FuncSum += f(x_array[0]);
                        break;
                    case 2:
                        FuncSum += f_const(2) * (x - x_array[0]);
                        break;
                    case 3:
                        FuncSum += f_const(3) * (x - x_array[0]) * (x - x_array[1]);
                        break;
                    case 4:
                        FuncSum += f_const(4) * (x - x_array[0]) * (x - x_array[1]) * (x - x_array[2]);
                        break;
                    case 5:
                        FuncSum += f_const(5) * (x - x_array[0]) * (x - x_array[1]) * (x - x_array[2]) * (x - x_array[3]);
                        break;
                }
                i++;
            }
            return FuncSum;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] x_array = new double[5] { h / 2, h * 3 / 2, h * 5 / 2, h * 9 / 2, h * 13 / 2 };
            double a = 0, b = 5 * Pi, step = 0.01;
            double x = a + step, y;
            this.chart1.Series[0].Points.Clear();

            while (x < b)
            {
                y = f(x);
                this.chart1.Series[0].Points.AddXY(x, y);

                for (int i = 1; i != 6; ++i)
                {
                    y = Ln(x, i);
                    this.chart1.Series[i].Points.AddXY(x, y);
                }

                x += step;
            }
        }
    }
}
