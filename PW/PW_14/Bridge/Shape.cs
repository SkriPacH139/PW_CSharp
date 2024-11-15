namespace PW_14.Bridge
{
    internal abstract class Shape
    {
        protected IRenderer Renderer;

        public Shape(IRenderer renderer) => Renderer = renderer;

        public abstract void Draw();
    }
}
