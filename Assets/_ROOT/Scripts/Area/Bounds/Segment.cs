namespace Runner.Area
{
    using System;
    using Obstacles;
    using Shared;
    using UnityEngine;

    public class Segment : MonoBehaviour
    {
        public event Action<Segment> endAchieved; 
        public SegmentBounds SegmentBounds { get; private set; }
        
        [SerializeField] 
        private GroundBound groundBound;
        
        [SerializeField] 
        private CellBound cellBound;
        
        [SerializeField] 
        private CollisionSource collisionSource;

        [SerializeField] 
        private ObstaclesContainer obstaclesContainer;
        private void Awake()
        {
            SegmentBounds = new SegmentBounds(cellBound.TopLeftPoint, groundBound.BottomRightPoint);
        }

        private void Start()
        {
            collisionSource.onCollisionEnter += OnCollision;
        }

        public void CreateObstacles()
        {
            obstaclesContainer.CreateObstacles();
        }

        private void OnCollision(Collision other)
        {
            endAchieved?.Invoke(this);
            SegmentBounds = new SegmentBounds(cellBound.TopLeftPoint, groundBound.BottomRightPoint);
            obstaclesContainer.ShuffleObstacles();
        }

        private void OnDestroy()
        {
            collisionSource.onCollisionEnter -= OnCollision;
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