namespace PW_14.Bridge
{
    internal class Rectangle : Shape
    {
        private float _width;
        private float _height;

        public Rectangle(IRenderer renderer, float width, float height) : base(renderer)
        {
            _width = width;
            _height = height;
        }

        public override void Draw() => Renderer.RenderRectangle(_width, _height);
    }
}
