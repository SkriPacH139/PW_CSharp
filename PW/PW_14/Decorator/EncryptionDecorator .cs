using System.Text;

namespace PW_14.Decorator
{
    internal class EncryptionDecorator : MessageDecorator
    {
        public EncryptionDecorator(Message message) : base(message) { }

        public override string Content => Encrypt(_message.Content);

        private string Encrypt(string text)
        {
            // Простая замена: a -> b, b -> c и т.д.
            StringBuilder sb = new StringBuilder();
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char shiftedChar = (char)(((c - 'a' + 1) % 26) + 'a'); //Циклический сдвиг на 1 позицию
                    sb.Append(shiftedChar);
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
