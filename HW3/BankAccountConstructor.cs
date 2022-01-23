﻿using System;
using System.Diagnostics;

namespace HW2
{
    /// <summary>
    /// 1. Создать класс счет в банке с закрытыми полями: номер счета, баланс, тип банковского счета (использовать перечислимый тип).
    /// Предусмотреть методы для доступа к данным – заполнения и чтения.
    /// Создать объект класса, заполнить его поля и вывести информацию об объекте класса на печать.
    /// 2. Изменить класс счет в банке из упражнения таким образом, чтобы номер счета генерировался сам и был уникальным.
    /// Для этого надо создать в классе статическую переменную и метод, который увеличивает значение этого переменной.
    /// 3. В классе банковский счет удалить методы заполнения полей. Вместо этих методов создать конструкторы.Переопределить конструктор по умолчанию,
    /// создать конструктор для заполнения поля баланс,
    /// конструктор для заполнения поля тип банковского счета,
    /// конструктор для заполнения баланса и типа банковского счета.
    /// Каждый конструктор должен вызывать метод, генерирующий номер счета.
    /// 4. В классе все методы для заполнения и получения значений полей заменить на свойства.Написать тестовый пример.
    /// 5. * Добавить в класс счет в банке два метода: снять со счета и положить на счет.Метод снять со счета проверяет, возможно ли снять запрашиваемую сумму, и в случае положительного результата изменяет баланс.
    /// </summary> 
    internal class BankAccount // Создать класс счет в банке с закрытыми полями
    {
        private static object AccountNumber { get; set; }//номер счета        
        private static object Balance { get; set; } //баланс
        private static object BankAccountType { get; set; } //тип банковского счета
        private enum bank_account_type //использовать перечислимый тип
        {
            White,
            Black,
            Red,
        }
        internal static void MainBankAccount() //Предусмотреть методы для доступа к данным – заполнения и чтения.
        {
            Console.WriteLine("___________________________________________________________________");
            Console.WriteLine($"Объекты класса");
            Console.WriteLine($"Введите цифрами номер счёта");
            BankAccount.AccountNumber = Console.ReadLine();//номер счета
            Console.WriteLine($"Номер счета - {BankAccount.AccountNumber}");
            Console.WriteLine($"Введите цифрами баланс счёта");
            BankAccount.Balance = Console.ReadLine();//баланс
            Console.WriteLine($"Баланс - {BankAccount.Balance} ед.");
            
            Console.WriteLine($"Введите цифрами тип счёта");
            var type = Console.ReadLine();//тип банковского счета
            var bank_Account_type = Convert.ToInt32(type);
            if (bank_Account_type <= 1)
            { BankAccount.BankAccountType = bank_account_type.White; }
            if (bank_Account_type == 2)
            { BankAccount.BankAccountType = bank_account_type.Black; }
            if (bank_Account_type >= 3)
            { BankAccount.BankAccountType = bank_account_type.Red; }
            Console.WriteLine($"Тип банковского счета - {BankAccount.BankAccountType}");

            Random random = new Random();//номер счета генерировался сам и был уникальным
            double value = random.Next(10000, 100000);
            BankAccount.AccountNumber = value;
            Console.WriteLine($"Генерируемый номер счета - {BankAccount.AccountNumber}");
        }
    }
    internal class BankAccountConstructor
    {
        private double _AccountNumber;
        private double _Balance;
        private double _BankAccountType;

        internal double AccountNumber { get; set; }
        internal double Balance { get; set; }
        internal double BankAccountType { get; set; }

        internal BankAccountConstructor(double accountnumber, double balance, double bankaccounttype)
        {
            _AccountNumber = accountnumber;
            _Balance = balance;
            _BankAccountType = bankaccounttype;
        }
        internal static void MainBankAccountConstructor()
        {
            Console.WriteLine("___________________________________________________________________");
            Console.WriteLine($"\nКонструктор");
            var check = new BankAccountConstructor(0, 0, 0);

            Random random1 = new Random();
            double value1 = random1.Next(10000, 100000000);
            check.AccountNumber = value1;
            Console.WriteLine($"Номер счета - {check.AccountNumber}");

            Random random2 = new Random();
            double value2 = random2.Next(1, 10000);
            check.Balance = value2;
            Console.WriteLine($"Баланс - {check.Balance} ед.");

            Random random3 = new Random();
            double value3 = random3.Next(1, 100000);
            check.BankAccountType = value3;
            Console.WriteLine($"Тип банковского счета - {check.BankAccountType}");
            while (true)
            {
                Console.WriteLine("Снять со чёта ед");
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
                    Console.WriteLine($"со cчёта снято - {take_off} ед. Остаток {check.Balance} ед.");
                }
                else { Console.WriteLine($"Недостаточно ед.! Введите другую сумму"); }
                Console.WriteLine("введите 0 для выхода");
            }
        }
    }
}
