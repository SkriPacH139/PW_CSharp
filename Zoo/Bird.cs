using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Bird : Animal
    {
        public double Wingspan { get; set; }

        public Bird(string name, int age, double weight, double wingspan) : base(name, age, weight) => Wingspan = wingspan;
        
        public override void MakeSound() => Console.WriteLine($"{Name} щебечет!");
        
    }
}
