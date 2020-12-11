using System.Collections.Generic;

namespace NumericalMethods
{
    class NewtonMethodInterpolation
    {
        public List<double> ArrayX { get; set; }
        public List<double> ArrayY { get; set; }
        public double X { get; set; }

        public double Calculate()
        {
            var n = ArrayX.Count;
            double polinom;
            double res = 0;
            for (var j = 0; j < n - 1; j++)
            {
                for (var i = n - 1; i > j; i--)
                {
                    ArrayY[i] = (ArrayY[i] - ArrayY[i - 1]) / (ArrayX[i] - ArrayX[i - j - 1]);
                }
            }
            for (var i = n - 1; i >= 0; i--)
            {
                polinom = 1;
                for (var j = 0; j < i; j++)
                {
                    polinom *= (X - ArrayX[j]);
                }
                
                polinom *= ArrayY[i];
                res += polinom;
            }

            return res;
        }
    }
}
