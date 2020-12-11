using System;
using System.Collections.Generic;
using org.mariuszgromada.math.mxparser;

namespace NumericalMethods
{
    class TrapezoidalMethod
    {
        public double Left { get; set; }

        public double Right { get; set; }
        public double Epsilon { get; set; }


        public List<int> NArray = new List<int>();
        public List<double> EpsilonArray = new List<double>();
        private Function _function;
        public int N;

        private string _functionString;

        public string FunctionString
        {
            get => _functionString;
            set
            {
                _functionString = value;
                _function = new Function("f(x) = " + value);
            }
        }

        private double CalcualteFunction(double x)
        {

            return _function.calculate(x);
        }

        private double CalculateTrapezoidalFormula(int n)
        {

            var step = (Right - Left) / n;
            var res = 0.5 * (CalcualteFunction(Left) + CalcualteFunction(Right));
            for (var i = 0; i < n; ++i)
            {
                res += CalcualteFunction(Left + step * i);
            }
            res *= step;
            return res;
        }

        public double Calcualte()
        {

            var n = 1;
            double integral1N = 0;
            double integral2N = 0;
            double tempEpsilon = 1;

            while (tempEpsilon >= Epsilon)
            {
                
                integral1N = CalculateTrapezoidalFormula(n);
                integral2N = CalculateTrapezoidalFormula(2 * n);
                tempEpsilon = Math.Abs((integral1N - integral2N) / integral2N);
                NArray.Add(n);
                EpsilonArray.Add(tempEpsilon);

                n *= 2;
            }

            N = n / 2;

            return integral1N;
        }
    }
}
