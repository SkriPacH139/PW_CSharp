namespace PW_15.Command
{
    internal class TVOffCommand : Command
    {
        private TV _tv;

        public TVOffCommand(TV tv) => _tv = tv;

        public override void Execute() => _tv.Off();
    }
}
