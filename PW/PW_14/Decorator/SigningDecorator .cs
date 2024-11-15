using System;
using System.Security.Cryptography;
using System.Text;

namespace PW_14.Decorator
{
    internal class SigningDecorator : MessageDecorator
    {
        public SigningDecorator(Message message) : base(message) { }

        public override string Content => Sign(_message.Content);


        private string Sign(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                return $"{text} [Hash: {hash}]";
            }
        }
    }
}
