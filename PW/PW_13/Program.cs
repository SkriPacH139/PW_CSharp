using System;

namespace PW_13
{
    internal class Program
    {
        static void settingsApp()
        {         
            Settings settings = Settings.GetInstance();
                        
            settings.SetSetting("DatabaseServer", "localhost");
            settings.SetSetting("DatabasePort", "5432");
            settings.SetSetting("Username", "myuser");

            settings.PrintSettings();
            Console.WriteLine("\n");

            Settings settings2 = Settings.GetInstance();
            settings2.SetSetting("NewSetting", "NewValue");
            settings.PrintSettings();
        }

        static void doc()
        {
            DocumentFactory textFactory = new TextDocumentFactory();
            IDocument textDoc = textFactory.CreateDocument();
            Console.WriteLine(textDoc.Create());

            DocumentFactory graphicFactory = new GraphicDocumentFactory();
            IDocument graphicDoc = graphicFactory.CreateDocument();
            Console.WriteLine(graphicDoc.Create());

            DocumentFactory spreadsheetFactory = new SpreadsheetDocumentFactory();
            IDocument spreadsheetDoc = spreadsheetFactory.CreateDocument();
            Console.WriteLine(spreadsheetDoc.Create());
        }

        static void vehical()
        {            
            VehicleFactory carFactory = new CarFactory();
            IVehicle car = carFactory.CreateVehicle();
            Console.WriteLine(car.Drive());

            VehicleFactory bicycleFactory = new BicycleFactory();
            IVehicle bicycle = bicycleFactory.CreateVehicle();
            Console.WriteLine(bicycle.Drive());
        }

        static void pizza()
        {
            PizzaDirector director = new PizzaDirector();
            ConcretePizzaBuilder builder = new ConcretePizzaBuilder();

            Pizza pizza1 = director.Construct(builder);
            Console.WriteLine(pizza1);

            Pizza pizza2 = director.ConstructVegetarian(builder);
            Console.WriteLine(pizza2);
        }

        static void Main(string[] args)
        {
            settingsApp();
            Console.WriteLine("\n");

            doc();
            Console.WriteLine("\n");

            vehical();
            Console.WriteLine("\n");

            pizza();

        }
    }
}
