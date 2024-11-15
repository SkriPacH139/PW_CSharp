namespace PW_13
{
    internal class SpreadsheetDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument() => new SpreadsheetDocument();
    }
}
