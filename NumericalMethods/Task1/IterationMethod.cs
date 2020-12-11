using System;
using org.mariuszgromada.math.mxparser;

namespace NumericalMethods
{
    class IterationMethod
    {
        public double Epsilon { get; set; }

        public double X0 { get; set; }

        private Function _function;

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

        public double Calculate()
        {
            var maxIteration = 1000;
            double x;

            for (var i = 1; i <= maxIteration; i++) 
            {
                x = CalculateFunction(X0);
                if (Math.Abs(X0 - x) < Epsilon)
                {
                    return x;
                }

                X0 = x;
            }

            return double.NaN;
        }
    }
}
