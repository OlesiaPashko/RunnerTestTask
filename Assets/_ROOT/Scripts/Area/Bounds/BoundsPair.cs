namespace Runner.Area
{
    using System;
    using Shared;
    using UnityEngine;

    public class BoundsPair : MonoBehaviour
    {
        public event Action<BoundsPair> endAchieved; 
        
        [SerializeField] 
        private GroundBound groundBound;
        
        [SerializeField] 
        private CellBound cellBound;
        
        [SerializeField] 
        private CollisionSource collisionSource;

        private void Start()
        {
            collisionSource.onCollisionEnter += OnCollision;
        }

        private void OnCollision(Collision other)
        {
            endAchieved?.Invoke(this);
        }

        private void OnDestroy()
        {
            collisionSource.onCollisionEnter -= OnCollision;
        }
    }
}