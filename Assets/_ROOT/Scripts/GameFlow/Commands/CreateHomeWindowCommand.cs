namespace Runner.GameFlow.Commands
{
    using Settings;
    using UI;
    using Zenject;

    public class CreateHomeWindowCommand : Command
    {
        [Inject]
        public IWindowCreator WindowCreator { get; set; }

        [Inject]
        public WindowPrefabSettings WindowPrefabSettings { get; set; }
        
        public override void Execute()
        {
            WindowCreator.CreateWindow(WindowPrefabSettings.HomeWindow);
        }
    }
}