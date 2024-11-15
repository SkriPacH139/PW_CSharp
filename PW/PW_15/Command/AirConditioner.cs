using System;

namespace PW_15.Command
{
    internal class AirConditioner
    {
        public void On() => Console.WriteLine("Кондиционер включен");

        public void Off() => Console.WriteLine("Кондиционер выключен");
    }
}
