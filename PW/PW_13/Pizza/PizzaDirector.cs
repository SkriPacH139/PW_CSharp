namespace PW_13
{
    internal class PizzaDirector
    {
        public Pizza Construct(PizzaBuilder builder)
        {
            builder.SetSize("Большая");
            builder.SetDough("Тонкое");
            builder.SetSauce("Томатный");
            builder.AddTopping("Сыр");
            builder.AddTopping("Пепперони");
            return builder.GetPizza();
        }

        public Pizza ConstructVegetarian(PizzaBuilder builder)
        {
            builder.SetSize("Средняя");
            builder.SetDough("Толстое");
            builder.SetSauce("Сливочный");
            builder.AddTopping("Грибы");
            builder.AddTopping("Оливки");
            builder.AddTopping("Перец");
            return builder.GetPizza();
        }
    }
}
