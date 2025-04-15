using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public abstract class Device
    {
        public abstract void TurnOn();
    }

    public class Laptop : Device
    {
        public override void TurnOn()
        {
            Console.WriteLine("Laptop TurnOn");
        }
    }

    public class Smartphone : Device
    {
        public override void TurnOn()
        {
            Console.WriteLine("Smartphone TurnOn");
        }
    }

    public class Tablet : Device
    {
        public override void TurnOn()
        {
            Console.WriteLine("Tablet TurnOn");
        }
    }
}
        