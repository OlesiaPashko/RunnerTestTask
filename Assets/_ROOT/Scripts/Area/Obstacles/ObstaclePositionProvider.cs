namespace Runner.Area.Obstacles
{
    using UnityEngine;

    public interface IObstaclePositionProvider
    {
        Vector3 Get();
    }
    
    public class ObstaclePositionProvider : IObstaclePositionProvider
    {
        public Vector3 Get()
        {
            return new Vector3(10, 10, 10);
        }
    }
}