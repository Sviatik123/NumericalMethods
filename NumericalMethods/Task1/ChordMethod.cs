using System;
using org.mariuszgromada.math.mxparser;

namespace NumericalMethods
{
    class ChordMethod
    {
        public double Left { get; set; }

        public double Right { get; set; }

        public double Epsilon { get; set; }

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
            var x = Right - CalculateFunction(Right) *
                (Left - Right) / (CalculateFunction(Left) - CalculateFunction(Right));

            while (Math.Abs(CalculateFunction(x)) > Epsilon)
            {
                x = Right - CalculateFunction(Right) *
                    (Left - Right) / (CalculateFunction(Left) - CalculateFunction(Right));
                if (CalculateFunction(Left) * CalculateFunction(x) < 0)
                {
                    Right = x;
                }
                else
                {
                    Left = x;
                }
            }

            return x;
        }
    }
}




