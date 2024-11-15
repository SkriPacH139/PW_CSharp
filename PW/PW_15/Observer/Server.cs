using System.Collections.Generic;

namespace PW_15.Observer
{
    internal class Server
    {
        private List<Observer> observers = new List<Observer>();
        private string _state;

        public string State
        {
            get => _state;
            set
            {
                _state = value;
                Notify($"Состояние сервера изменилось на: {_state}");
            }
        }

        // добавление подписчика
        public void Attach(Observer observer) => observers.Add(observer);

        // удаление подписчика
        public void Detach(Observer observer) => observers.Remove(observer);

        // уведомления подписчиков
        public void Notify(string message)
        {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        }
    }
}
