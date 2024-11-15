using System;

namespace PW_14.Bridge
{
    internal class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius) => Console.WriteLine($"Рисуем круг радиусом {radius} с помощью растрового рендерера");

        public void RenderRectangle(float width, float height) => Console.WriteLine($"Рисуем прямоугольник {width}x{height} с помощью растрового рендерера");
    }
}
