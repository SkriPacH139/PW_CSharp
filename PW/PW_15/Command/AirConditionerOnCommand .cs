namespace PW_15.Command
{
    internal class AirConditionerOnCommand : Command
    {
        private AirConditioner _ac;

        public AirConditionerOnCommand(AirConditioner ac) => _ac = ac;

        public override void Execute() => _ac.On();
    }
}
