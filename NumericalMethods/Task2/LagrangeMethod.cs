using System.Collections.Generic;

namespace NumericalMethods
{
    class LagrangeMethod
    {
        public List<double> ArrayX { get; set; }
        public List<double> ArrayY { get; set; }
        public double X { get; set; }

        public double Calculate()
        {
            var n = ArrayX.Count;
            double res = 0;
            double polinom;

            for (var i = 0; i < n; i++)
            {
                polinom = 1;
                for (var j = 0; j < n; j++)
                {
                    if (j != i)
                    {
                        polinom *= (X - ArrayX[j]) / (ArrayX[i] - ArrayX[j]);
                    }
                }
                res += polinom * ArrayY[i];
            }

            return res;
        }
    }
}
