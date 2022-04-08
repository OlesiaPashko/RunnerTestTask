namespace Runner.Player.Movement
{
    using System;
    using System.Collections;
    using Input;
    using Settings;
    using UnityEngine;
    using Zenject;

    public enum MovementState
    {
        Bottom,
        Up
    }

    public interface IMovementStateProvider
    {
        MovementState MovementState { get; }
        event Action Jump;
    }
    
    public class MovementStateProvider : IMovementStateProvider, IInitializable
    {
        [Inject]
        public IInputProvider InputProvider { get; set; }

        [Inject]
        public MovementSettings MovementSettings { get; set; }

        [Inject]
        public CoroutineProvider CoroutineProvider { get; set; }
        
        public MovementState MovementState { get; private set; }
        public event Action Jump;

        private float lastClickTime;

        public void Initialize()
        {
            InputProvider.OnButtonClicked += OnButtonClicked;
        }

        private void OnButtonClicked()
        {
            if (lastClickTime <= 0)
            {
                lastClickTime = Time.time;
                return;
            }

            if (MovementState == MovementState.Bottom)
            {
                CheckDoubleClick();
            }
            else
            {
                TryChangeState(MovementState.Bottom);
            }
            lastClickTime = Time.time;
        }

        private void CheckDoubleClick()
        {
            var maxGap = MovementSettings.clicksMaxGap;

            if (Time.time - lastClickTime < maxGap)
            {
                TryChangeState(MovementState.Up);
            }
            else
            {
                Jump?.Invoke();
            }
        }

        private void TryChangeState(MovementState state)
        {
            if (MovementState == state)
            {
                return;
            }

            MovementState = state;
            SwitchGravity();
        }

        private void SwitchGravity()
        {
            var gravity = Physics.gravity;
            Physics.gravity = new Vector3(gravity.x, -gravity.y, gravity.z);
        }
    }
}