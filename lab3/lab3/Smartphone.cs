using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    /// <summary>
    /// Класс, представляющий смартфон. Наследует базовый функционал устройства.
    /// </summary>
    internal class Smartphone : Device
    {
        /// <summary>
        /// Включает смартфон, выводя сообщение о загрузке.
        /// </summary>
        public override void TurnOn()
        {
            Console.WriteLine("The smartphone is booting up...");
        }
    }
}
