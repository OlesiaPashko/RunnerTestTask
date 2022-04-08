namespace Runner.Player.Movement
{
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
    }
    
    public class MovementStateSwitcher : MonoBehaviour, IMovementStateProvider
    {
        [Inject]
        public IInputProvider InputProvider { get; set; }

        [Inject]
        public IGravitySwitcher GravitySwitcher { get; set; }

        [Inject]
        public MovementSettings MovementSettings { get; set; }
        
        public MovementState MovementState { get; private set; }

        [SerializeField] 
        private VerticalMovement verticalMovement;

        private float lastClickTime;

        private void Start()
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
                verticalMovement.Jump();
            }
        }

        private void TryChangeState(MovementState state)
        {
            if (MovementState == state)
            {
                return;
            }

            MovementState = state;
            GravitySwitcher.Switch();
        }
    }
}