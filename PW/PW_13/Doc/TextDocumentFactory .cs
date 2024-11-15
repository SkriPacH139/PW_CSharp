namespace PW_13
{
    internal class TextDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument() => new TextDocument();
    }
}
