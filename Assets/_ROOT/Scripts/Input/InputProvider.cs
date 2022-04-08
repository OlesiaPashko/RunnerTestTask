namespace Runner.Player.Input
{
    using System;
    using GameFlow;
    using UnityEngine;
    using Zenject;

    public interface IInputProvider
    {
        event Action OnButtonClicked;
    }
    
    public class InputProvider : MonoBehaviour, IInputProvider, IInitializable
    {
        [Inject]
        public SignalBus SignalBus { get; set; }
        public event Action OnButtonClicked;

        private bool isActive;
        
        public void Initialize()
        {
            SignalBus.Subscribe<LevelFailed>(DisableInput);
            SignalBus.Subscribe<LevelStarted>(EnableInput);
        }

        private void EnableInput()
        {
            isActive = true;
        }
        
        private void DisableInput()
        {
            isActive = false;
        }

        private void Update()
        {
            if (!isActive)
            {
                return;
            }
            
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                OnButtonClicked?.Invoke();
            }
        }
    }
}