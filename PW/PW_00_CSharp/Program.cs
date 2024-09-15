using System;

class PW_01
{
    public static void Task_01_Es()
    {
        while (true)
        {
            string input = Console.ReadLine();

            // Проверка, содержит ли строка только цифры
            if (input.All(char.IsDigit) && int.TryParse(input, out int number) && number >= 1000 && number <= 9999)
            {
                // Извлечение цифр
                int digit1 = number / 1000;
                int digit2 = (number % 1000) / 100;
                int digit3 = (number % 100) / 10;
                int digit4 = number % 10;

                // Проверка условия
                if (digit1 + digit4 == digit2 * digit3)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
                break;
            }

            Console.WriteLine("Введите корректное четырехзначное положительное целое число:");
        }
    }

    public static void Task_01_Hard()
    {
        while (true)
        {
            string decimalNumber = Console.ReadLine();

            // Проверка, содержит ли строка только цифры
            if (decimalNumber.All(char.IsDigit) && int.TryParse(decimalNumber, out int number) && number >= 10 && number <= 99)
            {
                // Преобразование десятичного числа в троичное
                string ternaryNumber = ConvertToDecimal(number);

                
                List<int> decimDigits = new List<int>();
                List<int> ternDigits = new List<int>();

                decimDigits.Add((number % 100) / 10);
                decimDigits.Add(number % 10);

               foreach (char item in ternaryNumber)
               {
                   ternDigits.Add((int)char.GetNumericValue(item));
               }                       
                
               if (decimDigits[0] > decimDigits[1])
               {
                   foreach (int digit in ternDigits)
                   {
                       Console.Write(GetDigitName(digit, "ru") + " ");                        
                   }
                   
               }
               else
               {
                   foreach (int digit in ternDigits)
                   {
                       Console.Write(GetDigitName(digit, "en") + " ");
                   }                    
               }
               break;
            }

            Console.WriteLine("Введите корректное двухзначное положительное целое число:");
        }       

    }

    // Преобразование десятичного числа в троичное
    private static string ConvertToDecimal(int decimalNumber)
    {
        string ternary = "";
        while (decimalNumber > 0)
        {
            ternary += (decimalNumber % 3) ;
            decimalNumber /= 3;
        }

        // Дополнение до двух цифр
        if (ternary.Length == 1)
        {
            ternary = "0" + ternary;
        }

        return ternary;
    }

    // Возвращает название цифры на русском или английском языке
    private static string GetDigitName(int digit, string language)
    {
        switch (digit)
        {
            case 0:
                return language == "ru" ? "Ноль" : "Zero";
            case 1:
                return language == "ru" ? "Один" : "One";
            case 2:
                return language == "ru" ? "Два" : "Two";
            default:
                return "Неизвестная цифра";
        }
    }




    public static void Main()
    {
        Console.WriteLine("Введите четырехзначное положительное целое число:");
        Task_01_Es();

        Console.WriteLine("\nВведите двухзначное положительное целое число:");
        Task_01_Hard();

        Console.WriteLine("\n");
    }
    
}