using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    /// <summary>
    /// Класс, представляющий ноутбук. Реализует базовый функционал устройства.
    /// </summary>
    internal class Laptop : Device
    {
        /// <summary>
        /// Включает ноутбук, выводя сообщение о загрузке.
        /// </summary>
        public override void TurnOn()
        {
            Console.WriteLine("The laptop is booting up...");
        }
    }
}
