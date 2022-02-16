using System;

namespace HW8
{
    /// <summary>
    /// 1. Реализовать простейший файловый менеджер с использованием ООП (классы, наследование и прочее).
    /// ### Файловый менеджер должен иметь возможность:
    /// * показывать содержимое дисков;
    /// * создавать папки/файлы;
    /// * удалять папки/файлы;
    /// * переименовывать папки/файлы;
    /// * копировать/переносить папки/файлы;
    /// * вычислять размер папки/файла;
    /// * производить поиск по маске(с поиском по подпапкам);
    /// * для текстовых файлов готовить статические данные(кол-во слов, кол-во строк, кол-во абзацев, кол-во символов с пробелами, кол-во слов без пробелов).
    /// Предусмотреть возможность изменения атрибутов файлов.
    /// </summary>
    internal class FileManager2
    {
        internal static void Main(string[] args)
        {  
            IFileManager2 i_file_manager2; // создание интерфейса

            ClassFolder class_folder = new ClassFolder("", "", "", "", "", "", "", "", ""); // создание объекта класса "Папки"
            i_file_manager2 = class_folder;
            i_file_manager2.Preview();

            ClassFile class_file = new ClassFile("", "", "", "", "", "", "", "", ""); // создание объекта класса "Файла"                                             
            i_file_manager2 = class_file;
            i_file_manager2.Preview();

            Console.WriteLine(class_folder.Preview);
            while (true)
            {
                Console.WriteLine("Введите команду" +
                "\n[cd] - зайти в дерикторию   [ls] - отабразить текущию дерикторию [/] - в начальную" +
                "\n[ q] - выйnи из менеджера   [ s] - Поиск по маске" +
                "\n[ 1] - информация о файл    [ 2] - Информация о папке" +
                "\n[ 3] - переименовывать файл [ 4] - переименовывать папку" +
                "\n[ 5] - удалить файл         [ 6] - Удалить папку" +
                "\n[ 7] - Создать файл         [ 8] - Создать папку" +
                "\n[ 9] - копировать файл      [10] - копировать папку" +
                "\n[11] - перенести файл       [12] - перенести папку" +
                "\n[13] - Поиск файла          [14] - Поиск папки");

                string comand = Console.ReadLine();
                if (comand == "q")
                {
                    Quit();
                    return;
                }
                if (comand == "cd")
                {
                    Console.WriteLine(@"Введите путь: [пример - \Windows]");
                    string path = Console.ReadLine();

                    class_folder.GetFolder = class_folder.GetFolder + path;
                    i_file_manager2 = class_folder;
                    i_file_manager2.DisplayInfo();

                    class_file.GetFile = class_file.GetFile + path;
                    i_file_manager2 = class_file;
                    i_file_manager2.DisplayInfo();
                }
                if (comand == "/")
                { 
                    class_folder.GetFolder = @"\";
                    i_file_manager2 = class_folder;
                    i_file_manager2.DisplayInfo();

                    class_file.GetFile = @"\";
                    i_file_manager2 = class_file;
                    i_file_manager2.DisplayInfo();
                }
                if (comand == "ls")
                {
                    Console.WriteLine(@"текущая дериктория");
                    i_file_manager2 = class_folder;
                    i_file_manager2.DisplayInfo();
                    i_file_manager2 = class_file;
                    i_file_manager2.DisplayInfo();
                }                
                if (comand == "1")
                {
                    Console.WriteLine(@"Введите путь файла: [пример - \1.txt]");
                    class_file.Info = Console.ReadLine();
                    i_file_manager2 = class_file;
                    i_file_manager2.Info();
                }
                if (comand == "2")
                {
                    Console.WriteLine(@"Введите путь папки: [пример - \Windows]");
                    class_folder.Info = Console.ReadLine();
                    i_file_manager2 = class_folder;
                    i_file_manager2.Info();
                }
                if (comand == "3")
                {
                    Console.WriteLine(@"Введите путь файла: [пример - \1.txt]");
                    class_file.Edit = Console.ReadLine();
                    i_file_manager2 = class_file;
                    i_file_manager2.Edit();
                }
                if (comand == "4")
                {
                    Console.WriteLine(@"Введите путь папки: [пример - \Windows]");
                    class_folder.Edit = Console.ReadLine();
                    i_file_manager2 = class_folder;
                    i_file_manager2.Edit();
                }
                if (comand == "5")
                {
                    Console.WriteLine(@"Введите путь файла: [пример - \1.txt]");
                    class_file.Delete = Console.ReadLine();
                    i_file_manager2 = class_file;
                    i_file_manager2.Delete();
                }
                if (comand == "6")
                {
                    Console.WriteLine(@"Введите путь папки: [пример - \Windows]");
                    class_folder.Delete = Console.ReadLine();
                    i_file_manager2 = class_folder;
                    i_file_manager2.Delete();
                }
                if (comand == "7")
                {
                    Console.WriteLine(@"Введите путь файла: [пример - \1.txt]");
                    class_file.Create = Console.ReadLine();
                    i_file_manager2 = class_file;
                    i_file_manager2.Create();
                }
                if (comand == "8")
                {
                    Console.WriteLine(@"Введите путь папки: [пример - \Windows]");
                    class_folder.Create = Console.ReadLine();
                    i_file_manager2 = class_folder;
                    i_file_manager2.Create();
                }
                if (comand == "9")
                {
                    Console.WriteLine(@"Введите путь файла: [пример - \1.txt]");
                    class_file.Copy = Console.ReadLine();
                    i_file_manager2 = class_file;
                    i_file_manager2.Copy();
                }
                if (comand == "10")
                {
                    Console.WriteLine(@"Введите путь папки: [пример - \Windows]");
                    class_folder.Copy = Console.ReadLine();
                    i_file_manager2 = class_folder;
                    i_file_manager2.Copy();
                }
                if (comand == "11")
                {
                    Console.WriteLine(@"Введите путь файла: [пример - \1.txt]");
                    class_file.Transfer = Console.ReadLine();
                    i_file_manager2 = class_file;
                    i_file_manager2.Transfer();
                }
                if (comand == "12")
                {
                    Console.WriteLine(@"Введите путь папки: [пример - \Windows]");
                    class_folder.Transfer = Console.ReadLine();
                    i_file_manager2 = class_folder;
                    i_file_manager2.Transfer();
                }
                if (comand == "13")
                {
                    Console.WriteLine(@"Поиск файла");
                    i_file_manager2 = class_file;
                    i_file_manager2.Search();
                }
                if (comand == "14")
                {
                    Console.WriteLine(@"Поиск папки");
                    i_file_manager2 = class_folder;
                    i_file_manager2.Search();
                }
            }
        }
        static string Quit()
        {
            Console.WriteLine(@"Завершение программы");
            return "";
        }
    }
}
