using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Zoo
{
    public class Predator : Animal
    {
        public string Prey { get; set; }

        public Predator(string name, int age, double weight, string prey) : base(name, age, weight) => Prey = prey;        
                
        public override void MakeSound() => Console.WriteLine($"{Name} рычит!");
        
    }
}
