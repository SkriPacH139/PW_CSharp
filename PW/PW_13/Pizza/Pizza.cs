using System.Collections.Generic;

namespace PW_13
{
    internal class Pizza
    {
        public string Size { get; set; }
        public string Dough { get; set; }
        public string Sauce { get; set; }
        public List<string> Toppings { get; set; } = new List<string>();

        public override string ToString() => $"Пицца: Размер - {Size}, Тесто - {Dough}, Соус - {Sauce}, Начинка - {string.Join(", ", Toppings)}";
    }
}
