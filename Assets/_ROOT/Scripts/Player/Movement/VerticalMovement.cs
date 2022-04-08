namespace Runner.Player.Movement
{
    using Settings;
    using UnityEngine;
    using Zenject;

    public class VerticalMovement : MonoBehaviour
    {
        [Inject]
        public MovementSettings MovementSettings { get; set; }
        
        [SerializeField] 
        private Rigidbody rb;

        public void Jump()
        {
            var force = MovementSettings.jumpForce;

            rb.AddForce(new Vector3(0, force), ForceMode.Impulse);
        }
    }
}