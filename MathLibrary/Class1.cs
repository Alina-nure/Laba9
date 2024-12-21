using System;

namespace MathLibrary
{
    
    public interface IBasicMath
    {
        double Add(double a, double b);
        double Subtract(double a, double b);
        double Multiply(double a, double b);
        double Divide(double a, double b);
    }

    
    public interface IAdvancedMath
    {
        void TabulateExp();
    }

    
    public class Math : IBasicMath, IAdvancedMath
    {
        public double Add(double a, double b) => a + b;

        public double Subtract(double a, double b) => a - b;

        public double Multiply(double a, double b) => a * b;

        public double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Деление на ноль невозможно.");
            return a / b;
        }

        public void TabulateExp()
        {
            Console.WriteLine("Табуляция функции exp(a) на интервале [-5, 5]:");
            for (double a = -5; a <= 5; a += 0.5)
            {
                Console.WriteLine($"exp({a}) = {System.Math.Exp(a):F4}");
            }
        }

    }

    
    public class MathProxy : IBasicMath, IAdvancedMath
    {
        private static MathProxy _instance;
        private readonly Math _math;

        private MathProxy()
        {
            _math = new Math();
        }

       
        public static MathProxy Instance => _instance ??= new MathProxy();

        public double Add(double a, double b) => _math.Add(a, b);

        public double Subtract(double a, double b) => _math.Subtract(a, b);

        public double Multiply(double a, double b) => _math.Multiply(a, b);

        public double Divide(double a, double b) => _math.Divide(a, b);

        public void TabulateExp() => _math.TabulateExp();
    }

   
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }
}
