using System;

namespace PW_15.Observer
{
    internal class EmailNotifier : Observer
    {
        private string _email;

        public EmailNotifier(string email) => _email = email;

        public override void Update(string message) => Console.WriteLine($"Отправка уведомления на {_email}: {message}");
    }
}
