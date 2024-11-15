using System;

namespace PW_14.Bridge
{
    internal class VectorRenderer : IRenderer
    {
        public void RenderCircle(float radius) => Console.WriteLine($"Рисуем круг радиусом {radius} с помощью векторного рендерера");

        public void RenderRectangle(float width, float height) => Console.WriteLine($"Рисуем прямоугольник {width}x{height} с помощью векторного рендерера");
    }
}
