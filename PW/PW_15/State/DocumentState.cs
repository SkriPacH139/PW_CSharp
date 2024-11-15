namespace PW_15.State
{
    internal abstract class DocumentState
    {
        public abstract void Open(Document document);
        public abstract void Save(Document document);
        public abstract void Close(Document document);
        public abstract void Print(Document document);
    }
}
