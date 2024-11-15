namespace PW_14.Adapter
{
    internal class GraphicFileAdapter : IImageProcessor
    {
        private readonly GraphicFileProcessor _graphicFileProcessor;

        public GraphicFileAdapter(GraphicFileProcessor graphicFileProcessor) => _graphicFileProcessor = graphicFileProcessor;

        public void ProcessImage(string filePath) => _graphicFileProcessor.ProcessFile(filePath);
    }
}
