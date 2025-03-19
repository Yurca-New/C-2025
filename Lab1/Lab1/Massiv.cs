using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Massiv
    {
        private int[] data;

        public int[] Data
        {
            get { return data; }
        }

        public Massiv(string name) 
        {
            int size = 0;
            for (int i = 0; i < 1;)
            {
                Console.WriteLine($"Введите длину масива {name}");
                if (int.TryParse(Console.ReadLine(), out size))
                {
                    Console.WriteLine($"Масив {name} имеет длину {size}");
                    i++;
                }
                else
                {
                    Console.WriteLine("ДЛИНА МОЖЕТ БЫТЬ ТОЛЬКО ЦЕЛЫМ ЧИСЛОМ");
                }
            }
            data = new int[size];
        }

        public void Input()
        {
            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine($"Введите {i + 1} елемент");
                if (int.TryParse(Console.ReadLine(), out data[i]))
                {
                    Console.WriteLine($"Вы ввели {data[i]}");
                }
                else
                {
                    Console.WriteLine("МАСИВ ПРИНИМАЕТ ТОЛЬКО ЦЕЛЫЕ ЧИСЛА");
                    i--;
                }
            }
        }
        public void Output()
        {
            Console.WriteLine(string.Join(", ", data));
        }
        public int LeftMin()
        {
            return Array.IndexOf(data, data.Min());
        }
        public int RightMin()
        {
            return Array.LastIndexOf(data, data.Min());
        }
    }
}
