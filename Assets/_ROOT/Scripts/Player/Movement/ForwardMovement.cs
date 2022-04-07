namespace Runner.Player.Movement
{
    using GameFlow;
    using Settings;
    using UnityEngine;
    using Zenject;

    public class ForwardMovement : MonoBehaviour
    {
        [Inject]
        public MovementSettings MovementSettings { get; set; }

        [Inject]
        public SignalBus SignalBus { get; set; }

        [SerializeField] 
        private Rigidbody rb;

        private float speed;

        private void Start()
        {
            SignalBus.Subscribe<LevelStarted>(StartMovement);
            SignalBus.Subscribe<LevelFailed>(StopMovement);
        }

        private void StartMovement()
        {
            speed = MovementSettings.startSpeed;
        }

        private void FixedUpdate()
        {
            TryMove();
        }

        private void TryMove()
        {
            if (IsStopped())
            {
                return;
            }

            Move();
        }

        private void Move()
        {
            var newPosition = transform.position + new Vector3(speed, 0);
            rb.MovePosition(newPosition);
            var acceleration = MovementSettings.acceleration;
            speed += acceleration;
        }

        private bool IsStopped()
        {
            const float precise = 0.01f;
            return speed < precise;
        }

        private void StopMovement()
        {
            speed = 0f;
        }

        private void OnDestroy()
        {
            SignalBus.TryUnsubscribe<LevelStarted>(StartMovement);
            SignalBus.TryUnsubscribe<LevelFailed>(StopMovement);
        }
    }
}