namespace Runner.Area.Obstacles
{
    using UnityEngine;
    using UnityEngine.Serialization;

    public class ObstaclePositionProvider : MonoBehaviour
    {
        [FormerlySerializedAs("boundsPair")] [SerializeField] 
        private Segment segment;
        public Vector3 Get()
        {
            var bounds = segment.SegmentBounds;
            var y = Random.Range(bounds.BottomRightSegmentPoint.y, bounds.TopLeftSegmentPoint.y);
            var x = Random.Range(bounds.BottomRightSegmentPoint.x, bounds.TopLeftSegmentPoint.x);
            return new Vector3(x, y);
        }
        
        
    }
}