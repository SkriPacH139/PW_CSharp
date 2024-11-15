namespace PW_15.Command
{
    internal class LightOffCommand : Command
    {
        private Light _light;

        public LightOffCommand(Light light) => _light = light;

        public override void Execute() => _light.Off();
    }
}
