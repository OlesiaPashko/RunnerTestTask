namespace Runner.Area
{
    using System;
    using Shared;
    using UnityEngine;

    public class BoundsPair : MonoBehaviour
    {
        public event Action<BoundsPair> endAchieved; 
        public SegmentBounds SegmentBounds { get; private set; }
        
        [SerializeField] 
        private GroundBound groundBound;
        
        [SerializeField] 
        private CellBound cellBound;
        
        [SerializeField] 
        private CollisionSource collisionSource;

        private void Awake()
        {
            SegmentBounds = new SegmentBounds(cellBound.TopLeftPoint, groundBound.BottomRightPoint);
        }

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
            SegmentBounds = new SegmentBounds(cellBound.TopLeftPoint, groundBound.BottomRightPoint);
        }
    }

    public struct SegmentBounds
    {
        public Vector3 TopLeftSegmentPoint { get;}
        public Vector3 BottomRightSegmentPoint { get; }

        public SegmentBounds(Vector3 topLeftSegmentPoint, Vector3 bottomRightSegmentPoint)
        {
            TopLeftSegmentPoint = topLeftSegmentPoint;
            BottomRightSegmentPoint = bottomRightSegmentPoint;
        }
    }
}