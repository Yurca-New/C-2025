using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{

    internal class MyArray
    {
        private readonly string _name;
        private readonly IUserInterface _userInterface;
        private int[] _data = Array.Empty<int>();

        public int[] Data => _data;

        public MyArray(string name, IUserInterface userInterface)
        {
            _name = name;
            _userInterface = userInterface;
            InitializeArray();
        }

        private void InitializeArray()
        {
            var size = _userInterface.GetPositiveIntInput($"Введите длину массива {_name}", "Некорректный размер массива!");

            _data = new int[size];
            _userInterface.ShowMessage($"Массив {_name} создан. Длина: {size}");
        }


        public void InputElements()
        {
            for (var i = 0; i < _data.Length; i++)
            {
                _data[i] = _userInterface.GetIntInput(
                    $"Введите элемент {i + 1} массива {_name}",
                    "Некорректное значение элемента!"
                );
            }
        }

        public void OutputElements() => _userInterface.ShowArray(_name, _data);

        public int GetFirstMinIndex() => Array.IndexOf(_data, _data.Min());
        public int GetLastMinIndex() => Array.LastIndexOf(_data, _data.Min());
    }
}
