using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal class Laptop : Device
    {
        public override void TurnOn()
        {
            Console.WriteLine("The laptop is booting up...");
        }
    }
}
