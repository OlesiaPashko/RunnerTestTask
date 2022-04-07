namespace Runner.GameFlow
{
    using UnityEngine;
    using Zenject;

    public class GameStarter : MonoBehaviour
    {
        [Inject]
        public SignalBus SignalBus { get; set; }
        
        private void Start()
        {
            SignalBus.Fire<GameLoaded>();
        }
    }
}