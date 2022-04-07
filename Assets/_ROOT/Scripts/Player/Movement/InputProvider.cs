namespace Runner.Player.Movement
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
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                OnButtonClicked?.Invoke();
            }
        }
    }
}