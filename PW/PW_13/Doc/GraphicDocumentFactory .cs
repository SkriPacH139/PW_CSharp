namespace PW_13
{
    internal class GraphicDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new GraphicDocument();
        }
    }
}
