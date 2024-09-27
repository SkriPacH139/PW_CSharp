using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Herbivore : Animal
    {
        public string Food { get; set; }

        public Herbivore(string name, int age, double weight, string food) : base(name, age, weight) => Food = food;

        public override void MakeSound() => Console.WriteLine($"{Name} ест {Food}!");
        
    }
}
