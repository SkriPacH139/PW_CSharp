namespace PW_15.Command
{
    internal class LightOnCommand : Command
    {
        private Light _light;

        public LightOnCommand(Light light) => _light = light;

        public override void Execute() => _light.On();
    }
}
