namespace Runner.UI
{
    using GameFlow;
    using Zenject;

    public class GameWindow : Window
    {
        [Inject]
        public SignalBus SignalBus { get; set; }
        private void Start()
        {
            SignalBus.Subscribe<LevelFailed>(Close);
        }

        private void OnDestroy()
        {
            SignalBus.TryUnsubscribe<LevelFailed>(Close);
        }
    }
}