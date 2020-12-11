using System;
using System.Collections.Generic;
using org.mariuszgromada.math.mxparser;


namespace NumericalMethods
{
    class SimpsonMethod
    {
        public double Left { get; set; }

        public double Right { get; set; }
        public double Epsilon { get; set; }

        private Function _function;

        public List<int> NArray = new List<int>();
        public List<double> EpsilonArray = new List<double>();
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

        private double CalculateFunction(double x)
        {

            return _function.calculate(x);
        }

        private double CalculateSimpsonFormula(int n)
        {
            var step = (Right - Left) / n;

            var x = new double[n + 1];
            var fx = new double[n + 1];    

            for (var i = 0; i <= n; i++)
            {
                x[i] = Left + i * step;
                fx[i] = CalculateFunction(x[i]);
            }

            double res = 0;
            for (var i = 0; i <= n; i++)
            {
                if (i == 0 || i == n)
                    res += fx[i];
                else if (i % 2 != 0)
                    res += 4 * fx[i];
                else
                    res += 2 * fx[i];
            }

            res *= (step / 3);
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
                
                integral1N = CalculateSimpsonFormula(n);
                integral2N = CalculateSimpsonFormula(2 * n);
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
