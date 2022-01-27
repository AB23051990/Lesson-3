using System;

namespace HW3
{
    /// <summary>
    /// 1. В класс банковский счет, созданный в упражнениях, добавить метод, который переводит деньги с одного счета на другой. У метода два параметра:
    /// ссылка на объект класса банковский счет откуда снимаются деньги, второй параметр – сумма.
    /// 
    /// 2. Реализовать метод, который в качестве входного параметра принимает строку string,
    /// возвращает строку типа string, буквы в которой идут в обратном порядке.Протестировать метод.
    /// 
    /// 3. * Работа со строками.Дан текстовый файл, содержащий ФИО и e-mail адрес.
    /// Разделителем между ФИО и адресом электронной почты является символ &: Кучма Андрей Витальевич & Kuchma @mail.ru Мизинцев Павел Николаевич & Pasha @mail.ru Сформировать новый файл,
    /// содержащий список адресов электронной почты.Предусмотреть метод, выделяющий из строки адрес почты.
    /// Методу в качестве параметра передается символьная строка s, e-mail возвращается в той же строке s: public void SearchMail(ref string s).
    /// </summary>
    internal class BankAccountConstructor2
    {
        private double _AccountNumber;
        private double _Balance;
        private double _NewAccountNumber;
        private double _NewBalance;
        internal double AccountNumber { get; set; }
        internal double Balance { get; set; }
        internal double NewAccountNumber { get; set; }
        internal double NewBalance { get; set; }
        internal BankAccountConstructor2(double account_number, double balance, double newaccountnumber, double new_balance)
        {
            _AccountNumber = account_number;
            _Balance = balance;
            _NewAccountNumber = newaccountnumber;
            _NewBalance = new_balance;
        }
        internal static void MainBankAccountConstructor2()
        {
            var check = new BankAccountConstructor2(0, 0, 0, 0);

            Random random1 = new Random();
            double value1 = random1.Next(10000000, 100000000);
            check.AccountNumber = value1;

            Random random2 = new Random();
            double value2 = random2.Next(100, 10000);
            check.Balance = value2;

            Random random3 = new Random();
            double value3 = random3.Next(10000000, 100000000);
            check.NewAccountNumber = value3;

            Random random4 = new Random();
            double value4 = random4.Next(100, 100000);
            check.NewBalance = value4;

            while (true)
            {
                Console.WriteLine("___________________________________________________________________");
                Console.WriteLine($"Операция: 'Снять ед. со чёта {check.AccountNumber} и перевести на счёт {check.NewAccountNumber}'");

                Console.WriteLine($"\nНомер счета - №{check.AccountNumber}");
                Console.WriteLine($"Баланс - {check.Balance} ед.");

                Console.WriteLine($"\nНомер счета - №{check.NewAccountNumber}");
                Console.WriteLine($"Баланс - {check.NewBalance}");

                Console.WriteLine("\nДля выхода ведите 'q' для выхода");
                var type = Console.ReadLine();
                if (type == "q")
                {
                    Console.WriteLine($"выход");
                    return;
                }
                double take_off = Convert.ToInt32(type);                
                if (check.Balance <= 0)
                {
                    Console.WriteLine($"Недостаточно ед.! Введите другую операцию");
                    return;
                }
                if (take_off <= value2)
                {
                    check.Balance -= take_off;
                    check.NewBalance += take_off;
                    Console.WriteLine($"снято - {take_off} ед. со cчёта № {check.AccountNumber} текущий баланс счёта {check.Balance} ед.");
                    Console.WriteLine($"и переведено на cчёт № {check.NewAccountNumber} текущий баланс счета {check.NewBalance} ед.");                    
                }
                else { Console.WriteLine($"Недостаточно ед.! Введите другую сумму"); }      
            }
        }
    }
    internal class ReversString
    {
        internal static void Revers()
        {
            Console.WriteLine("___________________________________________________________________");
            Console.WriteLine($"Введите любое слово");
            string Rev = Console.ReadLine();
            char[] sReverse = Rev.ToCharArray();
            Array.Reverse(sReverse);
            Rev = new string(sReverse);
            Console.WriteLine(Rev);          
        }
    }
}


