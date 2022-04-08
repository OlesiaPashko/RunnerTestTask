namespace Runner.Player.Movement
{
    using GameFlow;
    using UnityEngine;
    using Zenject;

    public interface IGravitySwitcher
    {
        void Switch();
    }
    
    public class GravitySwitcher : IGravitySwitcher, IInitializable
    {
        [Inject]
        public SignalBus SignalBus { get; set; }
        public void Switch()
        {
            var gravity = Physics.gravity;
            Physics.gravity = new Vector3(gravity.x, -gravity.y, gravity.z);
        }

        public void Initialize()
        {
            SignalBus.Subscribe<LevelRestarted>(OnLevelRestarted);
        }

        private void OnLevelRestarted()
        {
            if (Physics.gravity.y > 0)
            {
                Switch();
            }
        }
    }
}