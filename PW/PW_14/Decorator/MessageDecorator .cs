namespace PW_14.Decorator
{
    internal abstract class MessageDecorator : Message
    {
        protected Message _message;

        public MessageDecorator(Message message) => _message = message;
    }
}
