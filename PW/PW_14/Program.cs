using PW_14.Adapter;
using PW_14.Bridge;
using PW_14.Composite;
using PW_14.Decorator;
using System;
using System.Collections.Generic;

using Directory = System.IO.Directory;
using DirectoryItem = PW_14.Composite.Directory;

namespace PW_14
{
    internal class Program
    {
        static void Adapter()
        {
            // Использование существующего кода
            IImageProcessor imageProcessor = new ImageProcessor();
            imageProcessor.ProcessImage("image1.jpg");
            Console.WriteLine("\n");

            // Использование сторонней библиотеки через адаптер
            GraphicFileProcessor graphicProcessor = new GraphicFileProcessor();
            IImageProcessor adapter = new GraphicFileAdapter(graphicProcessor);
            adapter.ProcessImage("image2.png");
            Console.WriteLine("\n");

            //Пример использования с общим интерфейсом
            List<IImageProcessor> processors = new List<IImageProcessor>()
            {
            new ImageProcessor(),
            new GraphicFileAdapter(new GraphicFileProcessor())
            };

            foreach (var processor in processors)
            {
                processor.ProcessImage("image3.bmp");
            }
        }

        static void Bridge()
        {
            // Использование векторного рендерера
            IRenderer vectorRenderer = new VectorRenderer();
            Shape circle = new Circle(vectorRenderer, 5);
            Shape rectangle = new Rectangle(vectorRenderer, 10, 20);
            circle.Draw();
            rectangle.Draw();

            Console.WriteLine();

            // Использование растрового рендерера
            IRenderer rasterRenderer = new RasterRenderer();
            circle = new Circle(rasterRenderer, 5);
            rectangle = new Rectangle(rasterRenderer, 10, 20);
            circle.Draw();
            rectangle.Draw();
        }


        static void Composite()
        {
            string rootPath = Directory.GetCurrentDirectory();
            FileSystemBuilder builder = new FileSystemBuilder(); 
            DirectoryItem root = builder.BuildFileSystemTree(rootPath); 

            if (root != null)
            {
                root.Display(0);
            }
            else
            {
                Console.WriteLine("Ошибка при построении дерева файловой системы.");
            }
        }
               

        static void Decorator()
        {
            Message message = new TextMessage("Hello, world!");
            Console.WriteLine($"Оригинальное сообщение: {message.Content}");

            //шифрование
            Message encryptedMessage = new EncryptionDecorator(message);
            Console.WriteLine($"Зашифрованное сообщение: {encryptedMessage.Content}");

            //подпись после шифрования
            Message signedMessage = new SigningDecorator(encryptedMessage);
            Console.WriteLine($"Зашифрованное и подписанное сообщение: {signedMessage.Content}");

            //подпись до шифрования       
            Message signedThenEncrypted = new EncryptionDecorator(new SigningDecorator(new TextMessage("Test")));
            Console.WriteLine($"Подписанное, затем зашифрованное сообщение: {signedThenEncrypted.Content}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Adapter:");
            Adapter();
            Console.WriteLine("\n");

            Console.WriteLine("Bridge:");
            Bridge();
            Console.WriteLine("\n");

            Console.WriteLine("Composite:");
            Composite();
            Console.WriteLine("\n");

            Console.WriteLine("Decorator:");
            Decorator();
        }
    }
}
