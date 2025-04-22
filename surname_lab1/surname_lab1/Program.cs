using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Components_Classes;

namespace surname_lab1
{
    class Program
    {
        static void Main()
        {
            List<Component> components = new List<Component>();

            while (true)
            {
                Console.WriteLine("\nВыберите комплектующее для добавления:");
                Console.WriteLine("1 - Процессор");
                Console.WriteLine("2 - Видеокарта");
                Console.WriteLine("3 - Оперативная память");
                Console.WriteLine("4 - Показать все комплектующие");
                Console.WriteLine("5 - Выход");
                Console.Write("Ваш выбор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        components.Add(CreateProcessor());
                        break;
                    case "2":
                        components.Add(CreateGraphicsCard());
                        break;
                    case "3":
                        components.Add(CreateRAM());
                        break;
                    case "4":
                        ShowAllComponents(components);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Некорректный ввод, попробуйте снова.");
                        break;
                }
            }
        }

        static Processor CreateProcessor()
        {
            Console.Write("Введите название процессора: ");
            string name = Console.ReadLine();
            Console.Write("Введите производителя: ");
            string manufacturer = Console.ReadLine();
            Console.Write("Введите цену: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Введите количество ядер: ");
            int cores = int.Parse(Console.ReadLine());
            Console.Write("Введите частоту (ГГц): ");
            double frequency = double.Parse(Console.ReadLine());

            return new Processor(name, manufacturer, price, cores, frequency);
        }

        static GraphicsCard CreateGraphicsCard()
        {
            Console.Write("Введите название видеокарты: ");
            string name = Console.ReadLine();
            Console.Write("Введите производителя: ");
            string manufacturer = Console.ReadLine();
            Console.Write("Введите цену: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Введите объем памяти (ГБ): ");
            int memorySize = int.Parse(Console.ReadLine());
            Console.Write("Введите чипсет: ");
            string chipset = Console.ReadLine();

            return new GraphicsCard(name, manufacturer, price, memorySize, chipset);
        }

        static RAM CreateRAM()
        {
            Console.Write("Введите название оперативной памяти: ");
            string name = Console.ReadLine();
            Console.Write("Введите производителя: ");
            string manufacturer = Console.ReadLine();
            Console.Write("Введите цену: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Введите объем (ГБ): ");
            int capacity = int.Parse(Console.ReadLine());
            Console.Write("Введите скорость (МГц): ");
            int speed = int.Parse(Console.ReadLine());

            Console.Write("Введите скорость (МГц): ");
            int memorysize = int.Parse(Console.ReadLine());

            Console.Write("Введите скорость (МГц): ");
            string chipset = Console.ReadLine();

            return new RAM(name, manufacturer, price, memorysize, chipset, capacity, speed) ;
        }

        static void ShowAllComponents(List<Component> components)
        {
            Console.WriteLine("\nСписок добавленных комплектующих:");
            foreach (var component in components)
            {
                component.DisplayInfo();
                Console.WriteLine("----------------------");
            }
        } 
        

    }

}
