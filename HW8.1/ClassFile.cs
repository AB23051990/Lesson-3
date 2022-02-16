using System;
using System.IO;
using System.Text;

internal class ClassFile : IFileManager2 //Класс "Фаил" с наследованием интерфейса
{
    //"Поле" Файла:
    private string _Preview;
    private string _GetFile;
    private string _Info;
    private string _Edit;
    private string _Delete;
    private string _Create;
    private string _Copy;
    private string _Transfer;
    private string _Search;

    //"Cвойства" Файла:
    internal string Preview { get => _Preview; set => _Preview = value; }
    internal string GetFile { get => _GetFile; set => _GetFile = value; }
    internal string Info { get => _Info; set => _Info = value; }
    internal string Edit { get => _Edit; set => _Edit = value; }
    internal string Delete { get => _Delete; set => _Delete = value; }
    internal string Create { get => _Create; set => _Create = value; }
    internal string Copy { get => _Copy; set => _Copy = value; }
    internal string Transfer { get => _Transfer; set => _Transfer = value; }
    internal string Search { get => _Search; set => _Search = value; }

    //"Конструктор" Файла:
    internal ClassFile(string Preview, string GetFile, string Info, string Edit, string Delete, string Create, string Transfer, string Copy, string Search)
    {
        _Preview = Preview;
        _GetFile = GetFile;
        _Info = Info;
        _Edit = Edit;
        _Delete = Delete;
        _Create = Create;
        _Transfer = Transfer;
        _Copy = Copy;
        _Search = Search;
    }

    //"Методы" Файла:
    string IFileManager2.Preview() // Метод отображения "Файлов"
    {
        Console.WriteLine("Файлы:");
        var directory = new DirectoryInfo(@"\");

        FileInfo[] files = directory.GetFiles();
        foreach (FileInfo file in files)
        {
            Console.WriteLine(file.FullName);
        }
        return _Preview;
    }
    string IFileManager2.DisplayInfo() // Метод отображения "Файлов"
    {
        try
        {
            var directory = new DirectoryInfo(_GetFile);
            Console.WriteLine("Файлы:");
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                Console.WriteLine(file.FullName);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
        return _GetFile;
    }
    string IFileManager2.Info() // метод информация о файле:
    {
        try
        {
            string path = _GetFile + _Info;
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                Console.WriteLine("Имя файла: {0}", fileInf.Name);
                Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                Console.WriteLine("Размер: {0}", fileInf.Length);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
        return _Info;
    }
    string IFileManager2.Edit() // метод редактирования фаила:
    {
        try
        {
            string writePath = _GetFile + _Edit;
            Console.WriteLine(@"Введите текст");
            string text = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(text);
            }
            Console.WriteLine("Запись выполнена");
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
        return _Edit;
    }
    string IFileManager2.Delete() // метод удаления файла:
    {
        try
        {
            string path = _GetFile + _Delete;
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
        return _Delete;
    }
    string IFileManager2.Create() // метод создания файла:
    {
        try
        {
            string path = _GetFile + _Create;
            using (FileStream fs = File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                fs.Write(info, 0, info.Length);
            }
            Console.WriteLine("Текст записан в файл");
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
        return _Create;
    }
    string IFileManager2.Copy() // метод копирования файла:
    {
        try
        {
            string path = _GetFile + _Copy;
            Console.WriteLine(@"Введите путь файла: [пример - \1.txt]");
            string newPath = _GetFile + Console.ReadLine();
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(newPath, true);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
        return _Copy;
    }
    string IFileManager2.Transfer() // метод переноса файла:
    {
        try
        {
            string path = _GetFile + _Transfer;
            string newPath = _GetFile + Console.ReadLine();
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.MoveTo(newPath);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
        return _Transfer;
    }
    string IFileManager2.Search() // метод поиска файла:
    {
        try
        {
            // Only get files that begin with the letter "c".
            string[] dirs = Directory.GetFiles(@"c:\", $"{Console.ReadLine()}*");
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

