using System;

namespace HW5
{
    /// <summary>
    /// 1. Создать класс рациональных чисел. В классе два поля – числитель и знаменатель. Предусмотреть конструктор.
    /// Определить операторы ==, != (метод Equals()), <, >, <=, >=, +, –, ++, --. Переопределить метод ToString() для вывода дроби.
    /// Определить операторы преобразования типов между типом дробь,float, int. Определить операторы *, /, %.
    /// 2. * На перегрузку операторов.Описать класс комплексных чисел.
    /// Реализовать операцию сложения, умножения, вычитания, проверку на равенство двух комплексных чисел.
    /// Переопределить метод ToString() для комплексного числа. Протестировать на простом примере.
    /// </summary>
    class RationalNumbers
    {
        internal static void PrintRationalNumbers()
        {
            var a = new RationalNumbers(5, 5);
            var b = new RationalNumbers(5, 5);

            Console.WriteLine(a + b);
            Console.WriteLine(a - b);
            Console.WriteLine(a * b);
            Console.WriteLine(a / b);
            Console.WriteLine(a++);
            Console.WriteLine(a--);
            Console.WriteLine(a == b);
            Console.WriteLine(a != b);
            Console.WriteLine(a < b);
            Console.WriteLine(a > b);
            Console.WriteLine(a <= b);
            Console.WriteLine(a >= b);
        }

        //"Поля" числитель и знаменатель:
        private int _Numerator; // числитель
        private int _Denominator; // знаменатель

        //"Cвойства" числитель и знаменатель:
        public int Numerator { get => _Numerator; set => _Numerator = value; }
        public int Denominator { get => _Denominator; set => _Denominator = value; }

        //"Конструктор" числитель и знаменатель:
        public RationalNumbers(int Numerator, int Denominator)
        {
            _Numerator = Numerator;
            _Denominator = Denominator;
        }

        //Арифметические операторы
        public static RationalNumbers operator +(RationalNumbers a, RationalNumbers b)
        {
            return new RationalNumbers(a._Numerator + b._Numerator, a._Denominator + b._Denominator);
        }

        public static RationalNumbers operator -(RationalNumbers a, RationalNumbers b)
        {
            return new RationalNumbers(a._Numerator - b._Numerator, a._Denominator - b._Denominator);
        }

        public static RationalNumbers operator *(RationalNumbers a, RationalNumbers b)
        {
            return new RationalNumbers(a._Numerator * b._Numerator, a._Denominator * b._Denominator);
        }

        public static RationalNumbers operator /(RationalNumbers a, RationalNumbers b)
        {
            return new RationalNumbers(a._Numerator / b._Denominator, a._Denominator / b._Numerator);
        }

        public static RationalNumbers operator ++(RationalNumbers a)
        {
            a._Numerator += 10;
            return a;
        }
        public static RationalNumbers operator --(RationalNumbers a)
        {
            a._Numerator -= 10;
            return a;
        }
        //Операторы сравнения
        public static bool operator ==(RationalNumbers a, RationalNumbers b)
        {
            if ((a._Numerator == b._Numerator) && (a._Denominator == b._Denominator))
                return true;
            else
                return false;
        }
        public static bool operator !=(RationalNumbers a, RationalNumbers b)
        {
            if ((a._Numerator != b._Numerator) || (a._Denominator != b._Denominator))
                return true;
            else
                return false;
        }
        public override bool Equals(object a)
        {
            if (ReferenceEquals(this, a))
            {
                return true;
            }

            if (ReferenceEquals(a, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }
        public override int GetHashCode()
        {
            return _Numerator;

        }

        public static bool operator >(RationalNumbers a, RationalNumbers b)
        {
            if (a._Numerator > b._Denominator)
                return true;
            else
                return false;
        }
        public static bool operator <(RationalNumbers a, RationalNumbers b)
        {
            if (a._Numerator < b._Denominator)
                return true;
            else
                return false;
        }
        public static bool operator >=(RationalNumbers a, RationalNumbers b)
        {
            if (a._Numerator >= b._Denominator)
                return true;
            else
                return false;

        }
        public static bool operator <=(RationalNumbers a, RationalNumbers b)
        {
            if (a._Numerator <= b._Denominator)
                return true;
            else
                return false;
        }
        //Метод ToString()
        public override string ToString() => $"{Numerator}; {Denominator}";

        
    }
}

