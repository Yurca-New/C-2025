using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    /// <summary>
    /// Абстрактный базовый класс для всех устройств.
    /// Определяет общий интерфейс для включения устройства.
    /// </summary>
    public abstract class Device
    {
        /// <summary>
        /// Абстрактный метод для включения устройства.
        /// </summary>
        public abstract void TurnOn();
    }
}
        