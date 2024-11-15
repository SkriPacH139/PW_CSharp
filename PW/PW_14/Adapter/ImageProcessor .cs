using System;

namespace PW_14.Adapter
{
    internal class ImageProcessor : IImageProcessor
    {
        public void ProcessImage(string filePath)
        {
            Console.WriteLine($"Обработка изображения {filePath} с помощью ImageProcessor");
            // логика обработки 
        }
    }
}
