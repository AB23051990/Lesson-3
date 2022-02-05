using System;

namespace HW6
{
    /// <summary>
    /// 1. Для класса банковский счет переопределить операторы == и != для сравнения информации в двух счетах.
    /// Переопределить метод Equals аналогично оператору ==, не забыть переопределить метод GetHashCode().
    /// Переопределить методToString() для печати информации о счете. Протестировать функционирование переопределенных методов и операторов на простом примере.
    /// 
    /// 2. * Создать класс Figure для работы с геометрическими фигурами. В качестве полей класса задаются цвет фигуры, состояние «видимое/невидимое».
    /// Реализовать операции: передвижение геометрической фигуры по горизонтали, по вертикали, изменение цвета, опрос состояния (видимый/невидимый).
    /// Метод вывода на экран должен выводить состояние всех полей объекта. Создать класс Point (точка) как потомок геометрической фигуры.
    /// Создать класс Circle (окружность) как потомок точки. В класс Circle добавить метод, который вычисляет площадь окружности.
    /// Создать класс Rectangle (прямоугольник) как потомок точки, реализовать метод вычисления площади прямоугольника.
    /// Точка, окружность, прямоугольник должны поддерживать методы передвижения по горизонтали и вертикали, изменения цвета.
    /// </summary>
    class BankAccountConstructor3
    {
        internal static void PrintRationalNumbers()
        {
            var a = new BankAccountConstructor3(0, 0);            
            Random random1 = new Random();
            int value1 = random1.Next(1, 10);
            a.AccountNumber = value1;            

            var b = new BankAccountConstructor3(0, 0);
            Random random3 = new Random();
            int value2 = random3.Next(1, 10);
            b.NewAccountNumber = value2;

            Console.WriteLine($"Номер счета - {a.AccountNumber},Новый номер счета - {b.NewAccountNumber}, Операторы сравнения - { a == b}");
            Console.WriteLine($"Номер счета - {a.AccountNumber},Новый номер счета - {b.NewAccountNumber}, Операторы сравнения - {a != b}");
        }
        
        //"Поля"
        private int _AccountNumber;
        private int _NewAccountNumber;
        
        //"Cвойства"
        internal int AccountNumber { get => _AccountNumber; set => _AccountNumber = value; }
        internal int NewAccountNumber { get => _NewAccountNumber; set => _NewAccountNumber = value; }
        
        //"Конструктор"
        internal BankAccountConstructor3(int account_number, int newaccountnumber)
        {
            _AccountNumber = account_number;
            _NewAccountNumber = newaccountnumber;
        }
        
        //Операторы сравнения
        public static bool operator ==(BankAccountConstructor3 a, BankAccountConstructor3 b)
        {
            if ((a._AccountNumber == b._NewAccountNumber) && (a._AccountNumber == b._NewAccountNumber))
                return true;
            else
                return false;
        }
        public static bool operator !=(BankAccountConstructor3 a, BankAccountConstructor3 b)
        {
            if ((a._AccountNumber != b._NewAccountNumber) || (a._AccountNumber != b._NewAccountNumber))
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
            return _AccountNumber;

        }
        //Метод ToString()
        public override string ToString() => $"{AccountNumber}; {NewAccountNumber}";
    }
}