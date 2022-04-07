namespace Runner.Player.Movement
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Settings;
    using UnityEngine;
    using Zenject;

    public class VerticalMovement : MonoBehaviour
    {
        [Inject]
        public IInputProvider InputProvider { get; set; }

        [Inject]
        public MovementSettings MovementSettings { get; set; }
        
        [SerializeField] 
        private Rigidbody rb;

        private void Start()
        {
            InputProvider.OnButtonClicked += MoveVertical;
        }

        private void MoveVertical()
        {
            var force = MovementSettings.jumpForce;

            rb.AddForce(new Vector3(0, force), ForceMode.Impulse);
        }

        private void OnDestroy()
        {
            InputProvider.OnButtonClicked -= MoveVertical;
        }
    }

    public enum VerticalState
    {
        Bottom,
        Up
    }
}