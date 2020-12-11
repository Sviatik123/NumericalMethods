using System;
using org.mariuszgromada.math.mxparser;

namespace NumericalMethods
{
    class NewtonMethod
    {
        public double Left { get; set; }

        public double Right { get; set; }

        public double X0 { get; set; }

        public double Epsilon { get; set; }

        private Function _function;

        private Function _derivate;

        private string _functionString;

        public string FunctionString
        {
            get => _functionString;
            set
            {
                _functionString = value;
                _function = new Function("f(x) = " + value);
                _derivate = new Function("f(x) = der(" + value + ", x)");
            }
        }

        private double CalculateFunction(double x)
        {

            return _function.calculate(x);
        }
        
        private double CalculateDerivate(double x)
        {

            return _derivate.calculate(x);      
        }

        public double Calculate()
        {
            var x = X0;
            while (Math.Abs(CalculateFunction(x)) > Epsilon)
            {
                x = x - (CalculateFunction(x) / CalculateDerivate(x));
            }

            return x;
        }
    }
}
