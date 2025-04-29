using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    /// <summary>
    /// Класс, представляющий планшет. Реализует базовый функционал устройства.
    /// </summary>
    internal class Tablet : Device
    {
        /// <summary>
        /// Включает планшет, выводя сообщение о загрузке.
        /// </summary>
        public override void TurnOn()
        {
            Console.WriteLine("The tablet is booting up...");
        }
    }
}
