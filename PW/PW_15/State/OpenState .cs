using System;

namespace PW_15.State
{
    internal class OpenState : DocumentState
    {
        public override void Save(Document document)
        {
            Console.WriteLine("Документ сохранен.");
            document.SetState(new SavedState());
        }

        public override void Close(Document document)
        {
            Console.WriteLine("Документ закрыт.");
            document.SetState(new NewState());
        }

        public override void Open(Document document) => Console.WriteLine("Документ уже открыт.");        

        public override void Print(Document document) => Console.WriteLine("Документ напечатан.");
    }
}
