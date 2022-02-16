using HW1;
using HW2;
using HW3;
using HW4_1;
using HW4_2;
using System;
using System.Diagnostics;

namespace GM
{
    internal class GMenu
    {
        internal delegate void method();
        internal static void Menu()
        {
            Console.WriteLine("Для выбора задания воспользуйтесь стрелочками [ВЕРХ] и [НИЗ]");
            string[] items = {
                "Задание 1   - [Диаграммы]",
                "Задание 2.1 - [Создать класс счет в банке]",
                "Задание 2.2 - [Создать класс счет в банке (Конструктор)]",
                "Задание 3.1 - [Добавить метод, который переводит деньги с одного счета на другой]",
                "Задание 3.2 - [Метод возвращающей строку типа string, буквы в которой идут в обратном порядке]",
                "Задание 4.1 - [Реализовать класс для описания здания]",
                "Задание 4.2 - [Фабрика объектов класса здания]",
                "Выход" };            
            method[] methods = new method[] { Lesson1, Lesson2, Lesson3, Lesson4, Lesson5, Lesson6, Lesson7, Exit };
            ConsoleMenu menu = new ConsoleMenu(items);
            int menuResult;
            do
            {               
                menuResult = menu.PrintMenu();
                methods[menuResult]();
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();
            }
            while (menuResult != items.Length - 1);
        }
        internal static void Lesson1()//"Задание 1"
        {            
            Diagrams.Diagram();
        }
        internal static void Lesson2()//"Задание 2.1"
        {
            BankAccount.MainBankAccount();            
        }
        internal static void Lesson3()//"Задание 2.2"
        {
            BankAccountConstructor.MainBankAccountConstructor();
        }
        internal static void Lesson4()//"Задание 3.1"
        {
            BankAccountConstructor2.MainBankAccountConstructor2();
        }
        internal static void Lesson5()//"Задание 3.2"
        {
            ReversString.Revers();
        }
        internal static void Lesson6()//"Задание 4.1"
        {
            PrintBuilding.PrintBuild();
        }
        internal static void Lesson7()//"Задание 4.1"
        {
            Creator.CreateBuild();
        }
        internal static void Exit()//"Выход"
        {
            Process.GetCurrentProcess().Kill();
        }
    }
    internal class ConsoleMenu
    {
        string[] menuItems;
        int counter = 0;
        internal ConsoleMenu(string[] menuItems)
        {
            this.menuItems = menuItems;
        }
        internal int PrintMenu()
        {
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (counter == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(menuItems[i]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else 
                        Console.WriteLine(menuItems[i]);
                }
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    counter--;
                    if (counter == -1) counter = menuItems.Length - 1;
                }               
                if (key.Key == ConsoleKey.DownArrow)
                {
                    counter++;
                    if (counter == menuItems.Length) counter = 0;
                }
            }
            while (key.Key != ConsoleKey.Enter);
            return counter;
        }
    }
}
