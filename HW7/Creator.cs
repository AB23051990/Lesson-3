using HW4_1;
using System;

namespace HW4_2
{
    class Creator // Фабрика зданий
    {        
        internal static void CreateBuild()
        {
            int[,] A = null;
            var сreator = new Creator(A);
            
            Random random = new();
            int value = random.Next(1, 25);

            for (int i = 1; i < value; i++)
            {
                сreator.MethodCreateBuild();
            }
        }
        //"Поля" Фабрики:
        private int[,] _BuildMaker;

        //"Cвойства" Фабрики
        public int[,] BuildMaker { get => _BuildMaker; set => _BuildMaker = value; }

        //"Конструктор" Фабрики:
        public Creator(int[,] BuildMaker)
        {
            _BuildMaker = BuildMaker;           
        }   

        // "Метод" генерации зданий:
        internal int[,] MethodCreateBuild()
        {
            var building = new Building(0, 0, 0, 0, 0);
            building.RandomBuildingNumber();
            building.RandomHeight();

            int[,] BuildMaker = new int[1, 5];
            BuildMaker[0, 0] = building.BuildingNumber; //Номер здания
            BuildMaker[0, 1] = building.Height; //Высота м
            BuildMaker[0, 2] = building.NumberOfStoreys; //Этажность
            BuildMaker[0, 3] = building.NumberOfApartments; //Количество квартир
            BuildMaker[0, 4] = building.NumberEntrance; //Количество Подъездов
            _BuildMaker = BuildMaker;
            for (int i = 0; i < _BuildMaker.GetLength(0); i++)
            {
                for (int j = 0; j < _BuildMaker.GetLength(1); j++)
                {
                    Console.Write($"{_BuildMaker[i, j]} ");
                }
                Console.WriteLine();
            }       
            return _BuildMaker;
        }        
    }
}

