namespace PW_15.State
{
    internal class Document
    {
        private DocumentState state;

        public Document() => state = new NewState();

        public void SetState(DocumentState state) => this.state = state;

        public void Open() => state.Open(this);

        public void Save() => state.Save(this);

        public void Close() => state.Close(this);

        public void Print() => state.Print(this);
    }
}
