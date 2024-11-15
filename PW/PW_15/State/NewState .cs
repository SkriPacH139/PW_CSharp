using System;

namespace PW_15.State
{
    internal class NewState : DocumentState
    {
        public override void Open(Document document)
        {
            Console.WriteLine("Документ открыт.");
            document.SetState(new OpenState());
        }

        public override void Save(Document document) => Console.WriteLine("Документ не может быть сохранен, так как он новый.");

        public override void Close(Document document) => Console.WriteLine("Документ закрыт.");

        public override void Print(Document document) => Console.WriteLine("Документ не может быть напечатан, так как он новый.");
    }
}
