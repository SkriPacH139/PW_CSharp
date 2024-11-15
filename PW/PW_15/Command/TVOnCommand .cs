namespace PW_15.Command
{
    internal class TVOnCommand : Command
    {
        private TV _tv;

        public TVOnCommand(TV tv) => _tv = tv;

        public override void Execute() => _tv.On();
    }
}
