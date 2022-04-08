namespace Runner.Player.Movement
{
    using Settings;
    using UnityEngine;
    using Zenject;

    public class VerticalMovement : MonoBehaviour
    {
        [Inject]
        public IMovementStateProvider MovementStateProvider { get; set; }

        [Inject]
        public MovementSettings MovementSettings { get; set; }
        
        [SerializeField] 
        private Rigidbody rb;

        private void Start()
        {
            MovementStateProvider.Jump += Jump;
        }

        private void Jump()
        {
            var force = MovementSettings.jumpForce;

            rb.AddForce(new Vector3(0, force), ForceMode.Impulse);
        }

        private void OnDestroy()
        {
            MovementStateProvider.Jump -= Jump;
        }
    }

    
}