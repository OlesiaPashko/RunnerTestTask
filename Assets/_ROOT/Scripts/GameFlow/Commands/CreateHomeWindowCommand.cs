namespace Runner.GameFlow.Commands
{
    using Settings;
    using UI;
    using Zenject;

    public abstract class CreateWindowCommand : Command
    {
        [Inject]
        public IWindowCreator WindowCreator { get; set; }

        [Inject]
        public WindowPrefabSettings WindowPrefabSettings { get; set; }

        protected abstract Window window { get; }
        
        public override void Execute()
        {
            WindowCreator.CreateWindow(window);
        }
    }
    
    public class CreateHomeWindowCommand : CreateWindowCommand
    {
        protected override Window window => WindowPrefabSettings.HomeWindow;
    }
    
    public class CreateGameWindowCommand : CreateWindowCommand
    {
        protected override Window window => WindowPrefabSettings.GameWindow;
    }
    
    public class CreateLevelFailedWindowCommand : CreateWindowCommand
    {
        protected override Window window => WindowPrefabSettings.LevelFailedWindow;
    }
}