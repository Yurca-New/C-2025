using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal class Tablet : Device
    {
        public override void TurnOn()
        {
            Console.WriteLine("The tablet is booting up...");
        }
    }
}
