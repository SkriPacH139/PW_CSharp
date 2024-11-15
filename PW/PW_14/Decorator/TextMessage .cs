namespace PW_14.Decorator
{
    internal class TextMessage : Message
    {
        private string _content;

        public TextMessage(string content) => _content = content;

        public override string Content => _content;
    }
}
