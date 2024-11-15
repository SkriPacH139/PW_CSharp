using System;

namespace PW_15.State
{
    internal class SavedState : DocumentState
    {
        public override void Open(Document document)
        {
            Console.WriteLine("Документ открыт.");
            document.SetState(new OpenState());
        }

        public override void Close(Document document)
        {
            Console.WriteLine("Документ закрыт.");
            document.SetState(new NewState());
        }

        public override void Save(Document document) => Console.WriteLine("Документ уже сохранен.");

        public override void Print(Document document) => Console.WriteLine("Документ напечатан.");
    }
}
