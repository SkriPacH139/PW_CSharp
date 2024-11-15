namespace PW_13
{
    internal class ConcretePizzaBuilder : PizzaBuilder
    {
        private Pizza _pizza = new Pizza();

        public override void SetSize(string size) => _pizza.Size = size;

        public override void SetDough(string dough) => _pizza.Dough = dough;

        public override void SetSauce(string sauce) => _pizza.Sauce = sauce;

        public override void AddTopping(string topping) => _pizza.Toppings.Add(topping);

        public override Pizza GetPizza()
        {
            Pizza pizza = _pizza;
            _pizza = new Pizza(); // Сбрасываем для следующей пиццы
            return pizza;
        }
    }
}
