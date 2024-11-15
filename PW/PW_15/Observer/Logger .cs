using System;

namespace PW_15.Observer
{
    internal class Logger : Observer
    {
        public override void Update(string message) => Console.WriteLine($"Лог: {message}");
    }
}
