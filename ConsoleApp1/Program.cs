using System;

namespace complex
{
    public struct Complex : IEquatable<Complex>
    {
        private double _real;
        private double _imaginary;

        public double Real => this._real;
        public double Imaginary => this._imaginary;

        static Complex()
        {
        }

        public Complex(double real, double imaginary)
        {
            this._real = real;
            this._imaginary = imaginary;
        }
     
        public static implicit operator Complex(double value)
        {
            return new Complex(value, 0.0);
        }

        public static explicit operator double(Complex complex)
        {
            return complex._real;
        }

        public static Complex operator -(Complex value)
        {
            return new Complex(-value._real, -value._imaginary);
        }
        
        public static Complex operator +(Complex left, Complex right)
        {
            return new Complex(left._real + right._real, left._imaginary + right._imaginary);
        }
        
        public static Complex operator -(Complex left, Complex right)
        {
            return new Complex(left._real - right._real, left._imaginary - right._imaginary);
        }

        public static Complex operator *(Complex left, Complex right)
        {
            return new Complex(left._real * right._real - left._imaginary * right._imaginary, left._imaginary * right._real + left._real * right._imaginary);
        }

        public static Complex operator /(Complex left, Complex right)
        {
            double num1 = left._real;
            double num2 = left._imaginary;
            double num3 = right._real;
            double num4 = right._imaginary;
            if (Math.Abs(num4) < Math.Abs(num3))
                return new Complex((num1 + num2 * (num4 / num3)) / (num3 + num4 * (num4 / num3)), (num2 - num1 * (num4 / num3)) / (num3 + num4 * (num4 / num3)));
            else
                return new Complex((num2 + num1 * (num3 / num4)) / (num4 + num3 * (num3 / num4)), (-num1 + num2 * (num3 / num4)) / (num4 + num3 * (num3 / num4)));
        }

        public static bool operator ==(Complex left, Complex right)
        {
            if (left._real == right._real)
                return left._imaginary == right._imaginary;
            else
                return false;
        }

        public static bool operator !=(Complex left, Complex right)
        {
            if (left._real == right._real)
                return left._imaginary != right._imaginary;
            else
                return true;
        }

        public static bool operator >(Complex left, Complex right)
        {
            return Abs(left) > Abs(right);
        }

        public static bool operator <(Complex left, Complex right)
        {
            return Abs(left) < Abs(right);
        }

        public static double Abs(Complex value)
        {
            return Math.Sqrt(Math.Pow(value._real, 2) + Math.Pow(value._imaginary, 2));
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Complex))
                return false;
            else
                return this == (Complex)obj;
        }

        public bool Equals(Complex value)
        {
            if (this._real.Equals(value._real))
                return this._imaginary.Equals(value._imaginary);
            else
                return false;
        }

        public override string ToString()
        {
            return string.Format($"({this._real}, {this._imaginary})");
        }

        static void Main(string[] args)
        {
            Complex complex1 = new Complex(4, 1);
            Complex complex2 = new Complex(1, 2);

            Console.WriteLine($"Complex numbers.\nFirst: {complex1}, second: {complex2}");
            Console.WriteLine($"Negatives: {-complex1}, {-complex2}");
            Console.WriteLine($"{complex1} - {complex2} = {complex1-complex2}");
            Console.WriteLine($"{complex1} + {complex2} = {complex1+complex2}");
            Console.WriteLine($"{complex1} * {complex2} = {complex1*complex2}");
            Console.WriteLine($"{complex1} / {complex2} = {complex1/complex2}");
            Console.WriteLine($"{complex1} == {complex2} ? {complex1==complex2}");
            Console.WriteLine($"{complex1} != {complex2} ? {complex1!=complex2}");
            Console.WriteLine($"{complex1} > {complex2} ? {complex1>complex2}");
            Console.WriteLine($"{complex1} < {complex2} ? {complex1<complex2}");
            Console.WriteLine($"Equals? {complex1.Equals(complex2)}");
            Console.WriteLine($"Abs: {Abs(complex1)}, {Abs(complex2)}");
            Console.ReadLine();
        }
    }
}