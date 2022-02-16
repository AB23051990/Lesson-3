using System;
using System.IO;

internal class ClassFolder : IFileManager2 //Класс "Папка" с наследованием интерфейса
{
    //"Поле" Папки:
    private string _Preview;
    private string _GetFolder;
    private string _Info;
    private string _Edit;
    private string _Delete;
    private string _Create;
    private string _Copy;
    private string _Transfer;
    private string _Search;

    //"Cвойства" Папки:
    internal string Preview { get => _Preview; set => _Preview = value; }
    internal string GetFolder { get => _GetFolder; set => _GetFolder = value; }
    internal string Info { get => _Info; set => _Info = value; }
    internal string Edit { get => _Edit; set => _Edit = value; }
    internal string Delete { get => _Delete; set => _Delete = value; }
    internal string Create { get => _Create; set => _Create = value; }
    internal string Copy { get => _Copy; set => _Copy = value; }
    internal string Transfer { get => _Transfer; set => _Transfer = value; }
    internal string Search { get => _Search; set => _Search = value; }

    //"Конструктор" Папки:
    internal ClassFolder(string Preview, string GetFolder, string Info, string Edit, string Delete, string Create, string Transfer, string Copy, string Search)
    {
        _Preview = Preview;
        _GetFolder = GetFolder;
        _Info = Info;
        _Edit = Edit;
        _Delete = Delete;
        _Create = Create;
        _Copy = Copy;
        _Transfer = Transfer;
        _Search = Search;
    }

    //"Методы" Папки:
    string IFileManager2.Preview() // Метод отображения "Папок"
    {
        Console.WriteLine("Папки:");
        var directory = new DirectoryInfo(@"\");
        DirectoryInfo[] dirs = directory.GetDirectories();
        foreach (DirectoryInfo dir in dirs)
        {
            Console.WriteLine(dir.FullName);
        }
        return _Preview;
    }
    string IFileManager2.DisplayInfo() // Метод отображения "Папок"
    {
        try
        {
            var directory = new DirectoryInfo(_GetFolder);
            Console.WriteLine("Папки:");
            DirectoryInfo[] dirs = directory.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                Console.WriteLine(dir.FullName);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
        return _GetFolder;
    }
    string IFileManager2.Info() // метод информация о папке:
    {
        try
        {
            string path = _GetFolder + _Info;
            DirectoryInfo dirInf = new DirectoryInfo(path);
            if (dirInf.Exists)
            {
                Console.WriteLine("Имя папки: {0}", dirInf.Name);
                Console.WriteLine("Время создания: {0}", dirInf.CreationTime);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
        return _Info;
    }
    string IFileManager2.Edit() // метод переименования папки:
    {
        try
        {
            string path = _GetFolder + _Edit;
            Console.WriteLine(@"Введите путь папки: [пример - \Windows]");
            string subpath = _GetFolder + Console.ReadLine();
            Directory.Move(path, subpath);
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
        return _Edit;
    }
    string IFileManager2.Delete() // метод удаления папки:
    {
        try
        {
            string path = _GetFolder + _Delete;
            Directory.Delete(path, true);
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
        return _Delete;
    }
    string IFileManager2.Create() // метод создания папки:
    {
        try
        {
            string path = _GetFolder + _Create;
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
        return _Create;
    }
    string IFileManager2.Copy() // метод копирования папки:
    {
        try
        {
            //папка для копирования
            string sourcePath = Console.ReadLine();
            //Куда копировать папку
            string targetPath = Console.ReadLine();
            //Создать идентичное дерево каталогов
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }
            //Копировать все файлы и перезаписать файлы с идентичным именем
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
        return _Copy;
    }
    string IFileManager2.Transfer() // метод переноса папки:
    {
        string sourceDirectory = _Transfer;
        string destinationDirectory = Console.ReadLine();
        try
        {
            Directory.Move(sourceDirectory, destinationDirectory);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return _Transfer;
    }
    string IFileManager2.Search() // метод поиска папки:
    {
        try
        {           
            string[] dirs = Directory.GetDirectories(@"c:\", $"{Console.ReadLine()}*");
            Console.WriteLine("The number of files starting with c is {0}.", dirs.Length);
            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
        return _Search;
    }
}

