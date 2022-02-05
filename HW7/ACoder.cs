using System;

namespace HW7
{
    /// <summary>
    /// 1. Определить интерфейс IСoder, который полагает методы поддержки шифрования строк.
    /// В интерфейсе объявляются два метода Encode() и Decode(), используемые для шифрования и дешифрования строк.
    /// Создать класс ACoder, реализующий интерфейс ICoder. Класс шифрует строку посредством сдвига каждого символа на одну «алфавитную» позицию выше.
    /// (В результате такого сдвига буква А становится буквой Б). Создать класс BCoder, реализующий интерфейс ICoder.
    /// Класс шифрует строку, выполняя замену каждой буквы, стоящей в алфавите на i-й позиции, на букву того же регистра,
    /// расположенную в алфавите на i-й позиции с конца алфавита. (Например, буква В заменяется на букву Э. Написать программу, демонстрирующую функционирование классов).
    /// 
    /// 2. * Создать класс Figure для работы с геометрическими фигурами.В качестве полей класса задаются цвет фигуры, состояние «видимое/невидимое».
    /// Реализовать операции: передвижение геометрической фигуры по горизонтали, по вертикали, изменение цвета, опрос состояния(видимый/невидимый).
    /// Метод вывода на экран должен выводить состояние всех полей объекта.Создать класс Point (точка) как потомок геометрической фигуры.
    /// Создать класс Circle (окружность) как потомок точки. В класс Circle добавить метод, который вычисляет площадь окружности. Создать класс Rectangle (прямоугольник) как потомок точки,
    /// реализовать метод вычисления площади прямоугольника.Точка, окружность, прямоугольник должны поддерживать методы передвижения по горизонтали и вертикали, изменения цвета.
    /// Подумать, какие методы можно объявить в интерфейсе, нужно ли объявлять абстрактный класс, какие методы и поля будут в абстрактном классе, какие методы будут виртуальными, какие перегруженными.
    /// </summary>

    internal interface IСoder // Интерфейс
    {
        string Encode();
        string Decode();
    }
    class ACoder : IСoder // Класс с наследованием интерфейса
    {
        internal static void Print()
        {
            IСoder i_coder; // ссылка на интерфейс

            ACoder a_coder = new ACoder("", ""); // создание объекта класса ACoder            
            i_coder = a_coder;
            Console.WriteLine("[ACoder]\nШифрование строк - введите [СЛОВО] (В результате такого сдвига буква А становится буквой Б)");
            var а_str = Console.ReadLine();            
            a_coder.A = а_str;
            i_coder.Encode();
            
            Console.WriteLine($"Дешифрование строк - введённого слово - [{a_coder.A}]");                       
            a_coder.B = a_coder.A;
            i_coder.Decode();

            BCoder b_coder = new BCoder("", ""); // создание объекта класса BCoder
            i_coder = b_coder;

            Console.WriteLine("\n[BCoder]\nШифрование строк - введите [СЛОВО] (В результате такого сдвига буква В становится буквой Э)");
            var b_str = Console.ReadLine();
            b_coder.C = b_str;
            i_coder.Encode();

            Console.WriteLine($"Дешифрование строк - введённого слово - [{b_coder.C}]");
            b_coder.D = b_coder.C;
            i_coder.Decode();
        }

        //"Поля" числитель и знаменатель:
        private string _A; // Шифратор
        private string _B; // Дешифратор

        //"Cвойства" Шифратор и Дешифратор:
        public string A { get => _A; set => _A = value; }
        public string B { get => _B; set => _B = value; }

        //"Конструктор" Шифратор и Дешифратор:
        public ACoder(string A, string B)
        {
            _A = A;
            _B = B;
        }
                
        string IСoder.Encode() // метод шифрования строк
        {                     
            char[] code = new char[_A.Length];

            for (int i = 0; i < code.Length; i++)
            {
                char c = _A[i];

                if (!Char.IsLetter(c))
                {
                    code[i] = c;
                }                    
                else
                {
                    if (Char.IsLower(c))
                    { 
                        code[i] = (char)((c + 18) % 33 + 'а');
                    }
                    else
                    {
                        code[i] = (char)((c + 17) % 33 + 'А');
                    }                   
                }                
            }
            string result = new string(code);
            _A = result;
            Console.WriteLine($"Зашифровано как - [{_A}]");
            return _A;
        }
        string IСoder.Decode() // метод дешифрования строк
        {
            char[] code = new char[_B.Length];

            for (int i = 0; i < code.Length; i++)
            {
                char c = _B[i];

                if (!Char.IsLetter(c))
                {
                    code[i] = c;
                }
                else
                {
                    if (Char.IsLower(c))
                    {
                        code[i] = (char)((c + 16) % 33 + 'а');
                    }
                    else
                    {
                        code[i] = (char)((c + 48) % 33 + 'А');
                    }                   
                }
            }
            string result = new string(code);
            _B = result;
            Console.WriteLine($"Разшифровано как - [{_B}]");
            return _B;
        }

    }
    class BCoder: IСoder
    {
        //"Поля" числитель и знаменатель:
        private string _C; // Шифратор
        private string _D; // Дешифратор

        //"Cвойства" Шифратор и Дешифратор:
        public string C { get => _C; set => _C = value; }
        public string D { get => _D; set => _D = value; }

        //"Конструктор" Шифратор и Дешифратор:
        public BCoder(string C, string D)
        {
            _C = C;
            _D = D;
        }
        string IСoder.Encode()
        {
            char[] code = new char[_C.Length];

            for (int i = 0; i < code.Length; i++)
            {
                char c = _C[i];

                if (!Char.IsLetter(c))
                {
                    code[i] = c;
                }
                else
                {
                    if (Char.IsLower(c))
                    {
                        code[i] = (char)((c + 11) % 33 + 'а');
                    }
                    else
                    {
                        code[i] = (char)((c + 10) % 33 + 'А');
                    }
                }
            }
            string result = new string(code);
            _C = result;
            Console.WriteLine($"Зашифровано как - [{_C}]");
            return _C;
        }
        string IСoder.Decode()
        {
            char[] code = new char[_D.Length];

            for (int i = 0; i < code.Length; i++)
            {
                char c = _D[i];

                if (!Char.IsLetter(c))
                {
                    code[i] = c;
                }
                else
                {
                    if (Char.IsLower(c))
                    {
                        code[i] = (char)((c + 23) % 33 + 'а');
                    }
                    else
                    {
                        code[i] = (char)((c + 22) % 33 + 'А');
                    }
                }
            }
            string result = new string(code);
            _D = result;
            Console.WriteLine($"Разшифровано как - [{_D}]");
            return _D;
        }
    }   
}
