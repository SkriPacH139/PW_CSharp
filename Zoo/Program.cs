using System;

namespace Zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predator lion = new Predator("Лев", 5, 200, "Антилопа");
            Herbivore giraffe = new Herbivore("Зебра", 8, 1500, "листья");
            Bird eagle = new Bird("Попугай", 3, 5, 2.5);

            _Zoo myZoo = new _Zoo();

            myZoo.AddAnimal(lion);
            myZoo.AddAnimal(giraffe);
            myZoo.AddAnimal(eagle);

            myZoo.MakeAllSounds();

            Console.ReadLine();
        }
    }
}
