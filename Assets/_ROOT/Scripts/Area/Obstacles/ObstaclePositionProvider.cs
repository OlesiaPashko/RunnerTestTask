namespace Runner.Area.Obstacles
{
    using UnityEngine;
    
    public class ObstaclePositionProvider : MonoBehaviour
    {
        [SerializeField] 
        private BoundsPair boundsPair;
        public Vector3 Get()
        {
            var bounds = boundsPair.SegmentBounds;
            var y = Random.Range(bounds.BottomRightSegmentPoint.y, bounds.TopLeftSegmentPoint.y);
            var x = Random.Range(bounds.BottomRightSegmentPoint.x, bounds.TopLeftSegmentPoint.x);
            return new Vector3(x, y);
        }
        
        
    }
}