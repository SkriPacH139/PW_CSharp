using System;

namespace PW_15.Command
{
    internal class Light
    {
        public void On() => Console.WriteLine("Свет включен");

        public void Off() => Console.WriteLine("Свет выключен");
    }
}
