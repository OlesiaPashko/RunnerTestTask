namespace Runner.Area
{
    using System;
    using UnityEngine;

    [RequireComponent(typeof(Collider))]
    public class CollisionSource : MonoBehaviour
    {
        public event Action<Collision> onCollisionEnter; 
        private void OnCollisionEnter(Collision other)
        {
            onCollisionEnter?.Invoke(other);
        }
    }
}