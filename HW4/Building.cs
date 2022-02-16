using System;

namespace HW4_1
{
    /// <summary>
    /// 1. Реализовать класс для описания здания (уникальный номер здания, высота, этажность, количество квартир, подъездов).
    /// Поля сделать закрытыми, предусмотреть методы для заполнения полей и получения значений полей для печати.
    /// Добавить методы вычисления высоты этажа, количества квартир в подъезде, количества квартир на этаже и т.д.
    /// Предусмотреть возможность, чтобы уникальный номер здания генерировался программно.
    /// Для этого в классе предусмотреть статическое поле, которое бы хранило последний использованный номер здания,
    /// и предусмотреть метод, который увеличивал бы значение этого поля.
    /// 
    /// 2. * Для реализованного класса создать новый класс Creator, который будет являться фабрикой объектов класса здания.
    /// Для этого изменить модификатор доступа к конструкторам класса, в новый созданный класс добавить перегруженные фабричные методы CreateBuild для создания объектов класса здания.
    /// В классе Creator все методы сделать статическими, конструктор класса сделать закрытым. Для хранения объектов класса здания в классе Creator использовать хеш-таблицу.
    /// Предусмотреть возможность удаления объекта здания по его уникальному номеру из хеш-таблицы.Создать тестовый пример, работающий с созданными классами.
    /// 
    /// 3. * Разбить созданные классы (здания, фабричный класс) и тестовый пример в разные исходные файлы.
    /// Разместить классы в одном пространстве имен. Создать сборку (DLL), включающие эти классы.Подключить сборку к проекту и откомпилировать тестовый пример со сборкой.
    /// Получить исполняемый файл, проверить с помощью утилиты ILDASM, что тестовый пример ссылается на сборку и не содержит в себе классов здания и Creator.
    /// </summary>
    internal class PrintBuilding
    {
        internal static void PrintBuild()
        {
            var building = new Building(0, 0, 0, 0, 0);
            building.RandomBuildingNumber();  //"Метод" генерации номера здания:            
            building.RandomHeight();//"Метод" генерации параметров здания:
            Console.WriteLine($"Номер здания - {building.BuildingNumber}, Высота - {building.Height} м, Этажность - {building.NumberOfStoreys}, Количество квартир - {building.NumberOfApartments}, Количество подъездов - {building.NumberEntrance}");//Вывод на консоль параметров здания
        }
    }
    internal class Building // Здание
    {
        //"Поля" здания:
        private int _BuildingNumber; //Номер здания
        private int _Height; //Высота м
        private int _NumberOfStoreys; //Этажность
        private int _NumberOfApartments; //Количество квартир
        private int _NumberEntrance; //Количество Подъездов

        //"Cвойства" здания (модель данных, доменная модель)
        public int BuildingNumber { get => _BuildingNumber; set => _BuildingNumber = value; }
        public int Height { get => _Height; set => _Height = value; }
        public int NumberOfStoreys { get => _NumberOfStoreys; set => _NumberOfStoreys = value; }
        public int NumberOfApartments { get => _NumberOfApartments; set => _NumberOfApartments = value; }
        public int NumberEntrance { get => _NumberEntrance; set => _NumberEntrance = value; }

        //"Конструктор" здания:
        internal Building(int BuildingNumber, int Height, int NumberOfStoreys, int NumberOfApartments, int NumberEntrance)
        {
            _BuildingNumber = BuildingNumber;
            _Height = Height;
            _NumberOfStoreys = NumberOfStoreys;
            _NumberOfApartments = NumberOfApartments;
            _NumberEntrance = NumberEntrance;
        }

        // "Метод" генерации номера здания:
        internal int RandomBuildingNumber()
        {
            Random random1 = new();
            int value1 = random1.Next(1, 100);
            _BuildingNumber = value1;
            return _BuildingNumber;
        }

        // "Метод" генерации здания:
        internal int RandomHeight()
        {
            Random random1 = new();
            int value1 = random1.Next(10, 50);
            _NumberOfApartments = value1;
            if (value1 < 10)
            {
                _NumberOfStoreys = 1;
                _NumberEntrance = 1;
                _Height = 3;                
                return _Height;
            }
            if (value1 < 20)
            {
                _NumberOfStoreys = 2;
                _NumberEntrance = 1;
                _Height = 6;                
                return _Height;
            }
            if (value1 < 30)
            {
                _NumberOfStoreys = 2;
                _NumberEntrance = 2;
                _Height = 6;               
                return _Height;
            }
            if (value1 < 40)
            {
                _NumberOfStoreys = 3;
                _NumberEntrance = 2;
                _Height = 9;                
                return _Height;
            }
            if (value1 < 50)
            {
                _NumberOfStoreys = 3;
                _NumberEntrance = 3;
                _Height = 9;                
                return _Height;
            }
            return _NumberOfApartments;
        }
    }
}
