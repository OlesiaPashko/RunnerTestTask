namespace Runner.Player.Input
{
    using System;
    using UnityEngine;

    public interface IInputProvider
    {
        event Action OnButtonClicked;
    }
    
    public class InputProvider : MonoBehaviour, IInputProvider
    {
        public event Action OnButtonClicked;

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                OnButtonClicked?.Invoke();
            }
        }
    }
}