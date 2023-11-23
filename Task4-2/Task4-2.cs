using System;
using System.Security.Cryptography.X509Certificates;
using Task4_2;

namespace Task4_2
{
    public class Rational : IComparable<Rational>
    {
        private int x;
        private int y;

        public int Numerator
        {
            get { return x; }
            set { x = value; }
        }

        public int Denominator
        {
            get { return y; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Denominator can't be zero");
                }
                y = value;
            }
        }

        public Rational(int x, int y)
        {
            Numerator = x;
            Denominator = y;
            Simplify();
        }

        private int FindCGD(int a, int b)
        {
            while (b!= 0)
            {
                int temp = b;
                b = a% b;
                a = temp;
            }
            return a;
        }

        //1st Point - stored a rational number as an irreducible fraction
        private void Simplify()
        {
            int GCD = FindCGD(Numerator, Denominator);
            Numerator /= GCD;
            Denominator /= GCD;

        }

        public Rational Add(Rational other)
        {
           int ComDenominator = Denominator * other.Denominator;
           int sumNumerator = Numerator * other.Denominator + other.Numerator * Denominator;

           return new Rational(sumNumerator, ComDenominator);
        }

        public static Rational PerformOperation(Rational a, Rational b, char operation)
        {
            int resultNum = 0;
            int resultDen = 0;

            switch (operation)
            {
                //sum
                case '+':
                    resultDen = a.Denominator * b.Denominator;
                    resultNum = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
                break;
                
                //dif
                case '-':
                    resultDen = a.Denominator * b.Denominator;
                    resultNum = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
                break;

                //prod
                case '*':
                    resultNum = a.Numerator * b.Numerator;
                    resultDen = a.Denominator * b.Denominator;
                break;

                //div
                case '/':
                    resultNum = a.Numerator * b.Denominator;
                    resultDen = a.Denominator * b.Numerator;
                break;
            default:
                throw new ArgumentException("Invalid Operator, please use +, -, * or / ");
            } 
        return new Rational(resultNum, resultDen);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Rational other = (Rational)obj;
            return Numerator == other.Numerator && Denominator == other.Denominator;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public int CompareTo(Rational other)
        {
            double thisValue = (double)Numerator / Denominator;
            double otherValue = (double)other.Numerator / other.Denominator;

            return thisValue.CompareTo(otherValue);
        }

        public static implicit operator Rational(int value)
        {
            return new Rational(value, 1);
        }

        public static explicit operator double(Rational rational)
        {
            return (double)rational.Numerator / rational.Denominator;
        }
    }
    class Programa
        {
            static void Mains(string[] args)
            {
                Rational rat1 = new Rational(1, 2);
                Rational rat2 = new Rational(1, 3);

                Rational sum = Rational.PerformOperation(rat1, rat2, '+');
                Rational difference = Rational.PerformOperation(rat1, rat2, '-');
                Rational product = Rational.PerformOperation(rat1, rat2, '*');
                Rational division = Rational.PerformOperation(rat1, rat2, '/');

                bool comparisonResult = rat1.CompareTo(rat2) < 0;

                Rational ratFromInt = 5;
                double doubleFromRat = (double)rat1;

                Console.WriteLine($"Sum: {sum}");
                Console.WriteLine($"Difference: {difference}");
                Console.WriteLine($"Product: {product}");
                Console.WriteLine($"Division: {division}");
                Console.WriteLine($"Comparison Result: {comparisonResult}");

                Console.WriteLine($"Rational from int: {ratFromInt}");
                Console.WriteLine($"Double from Rational: {doubleFromRat}");
            }
        }
}