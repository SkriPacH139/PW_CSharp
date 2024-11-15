using PW_15.Command;
using PW_15.Observer;
using PW_15.State;
using PW_15.Strategy;
using System;

namespace PW_15
{
    internal class Program
    {
        static void Command()
        {
            // Создаем устройства
            Light light = new Light();
            AirConditioner ac = new AirConditioner();
            TV tv = new TV();

            // Создаем команды
            PW_15.Command.Command lightOn = new LightOnCommand(light);
            PW_15.Command.Command lightOff = new LightOffCommand(light);
            PW_15.Command.Command acOn = new AirConditionerOnCommand(ac);
            PW_15.Command.Command acOff = new AirConditionerOffCommand(ac);
            PW_15.Command.Command tvOn = new TVOnCommand(tv);
            PW_15.Command.Command tvOff = new TVOffCommand(tv);

            // Создаем пульт
            RemoteControl remote = new RemoteControl();

            // Включаем свет
            remote.SetCommand(lightOn);
            remote.PressButton();

            // Выключаем свет
            remote.SetCommand(lightOff);
            remote.PressButton();

            // Включаем кондиционер
            remote.SetCommand(acOn);
            remote.PressButton();

            // Выключаем кондиционер
            remote.SetCommand(acOff);
            remote.PressButton();

            // Включаем телевизор
            remote.SetCommand(tvOn);
            remote.PressButton();

            // Выключаем телевизор
            remote.SetCommand(tvOff);
            remote.PressButton();
        }

        static void Strategy()
        {
            TaxCalculator taxCalculator = new TaxCalculator();

            // Используем прогрессивную систему налогообложения
            taxCalculator.SetTaxCalculationStrategy(new ProgressiveTaxCalculationStrategy());
            decimal progressiveTax = taxCalculator.CalculateTax(40000);
            Console.WriteLine($"Налог по прогрессивной системе для дохода 40.000: {progressiveTax}");

            // Используем фиксированную ставку налога 20%
            taxCalculator.SetTaxCalculationStrategy(new FixedRateTaxCalculationStrategy(0.20m));
            decimal fixedRateTax = taxCalculator.CalculateTax(40000);
            Console.WriteLine($"Налог по фиксированной ставке (20%) для дохода 40.000: {fixedRateTax}");
        }

        static void Observer()
        {
            // Создаем сервер
            Server server = new Server();

            // Создаем подписчиков
            Logger logger = new Logger();
            EmailNotifier emailNotifierFirst = new EmailNotifier("userFirst@example.com");
            EmailNotifier emailNotifierSecond = new EmailNotifier("userSecond@example.com");
            EmailNotifier emailNotifierThird = new EmailNotifier("userThird@example.com");

            // Подписываемся на изменения состояния сервера
            server.Attach(logger);
            server.Attach(emailNotifierFirst);
            server.Attach(emailNotifierSecond);
            server.Attach(emailNotifierThird);

            // Изменяем состояние сервера
            server.State = "Запущен";
            server.State = "Ожидание нагрузки";
            server.State = "Ошибка";

            // Убираем логгер и изменяем состояние
            server.Detach(logger);
            server.State = "Восстановлен";
        }

        static void Stat() 
        {
            Document document = new Document();

            document.Open();    
            document.Save();    
            document.Print();   
            document.Close();   
            document.Open();    
            document.Save();    
        }

        static void Main(string[] args)
        {
            Command();
            Console.WriteLine("\n----------------------------------------------------");

            Strategy();
            Console.WriteLine("\n----------------------------------------------------");

            Observer();
            Console.WriteLine("\n----------------------------------------------------");

            Stat();
        }
    }
}
