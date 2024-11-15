namespace PW_14.Bridge
{
    internal class Circle : Shape
    {
        private float _radius;

        public Circle(IRenderer renderer, float radius) : base(renderer) => _radius = radius;

        public override void Draw() => Renderer.RenderCircle(_radius);
    }
}
