namespace PW_15.Command
{
    internal class AirConditionerOffCommand : Command
    {
        private AirConditioner _ac;

        public AirConditionerOffCommand(AirConditioner ac) => _ac = ac;

        public override void Execute() => _ac.Off();
    }
}
