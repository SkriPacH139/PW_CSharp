namespace PW_13
{
    internal abstract class PizzaBuilder
    {
        public abstract void SetSize(string size);
        public abstract void SetDough(string dough);
        public abstract void SetSauce(string sauce);
        public abstract void AddTopping(string topping);
        public abstract Pizza GetPizza();
    }
}
