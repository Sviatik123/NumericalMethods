using System;
using System.Collections.Generic;
using org.mariuszgromada.math.mxparser;

namespace NumericalMethods
{
    class RectanglesMethod
    {
        public double Left { get; set; }

        public double Right { get; set; }
        public double Epsilon { get; set; }

        private Function _function;

        private string _functionString;
        public List<int> NArray = new List<int>();
        public List<double> EpsilonArray = new List<double>();

        public int N;
        public string FunctionString
        {
            get => _functionString;
            set
            {
                _functionString = value;
                _function = new Function("f(x) = " + value);
            }
        }

        private double CalculateFunction(double x)
        {

            return _function.calculate(x);
        }

        private double CalculateRectangularFormula(int n)
        {
            var step = (Right - Left) / n;
            double res = 0;
            for (var i = 1; i < n; i++)
            {
                res += step * CalculateFunction(Left + (2*i-1) * step / 2);
            }

            return res;
        }

        public double Calculate()
        {
            var n = 1;
            double integral1N = 0;
            double integral2N = 0;
            double tempEpsilon = 1;

            while (tempEpsilon >= Epsilon)
            {
               
                integral1N = CalculateRectangularFormula(n);
                integral2N = CalculateRectangularFormula(2*n);
                tempEpsilon = Math.Abs((integral1N - integral2N) / integral2N);
                NArray.Add(n);
                EpsilonArray.Add(tempEpsilon);

                n *= 2;
            }

            N = n/2;
            return integral1N;
        }
    }
}
