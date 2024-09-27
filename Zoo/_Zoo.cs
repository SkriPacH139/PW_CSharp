using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class _Zoo
    {
        private List<Animal> animals = new List<Animal>();

        public void AddAnimal(Animal animal) => animals.Add(animal);
        
        public void MakeAllSounds()
        {
            foreach (Animal animal in animals)
                animal.MakeSound();            
        }
    }
}
