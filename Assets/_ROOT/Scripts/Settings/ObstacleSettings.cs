namespace Runner.Settings
{
    using System.Collections.Generic;
    using Area.Obstacles;
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(ObstacleSettings), menuName = "Runner/ObstacleSettings")]
    public class ObstacleSettings : ScriptableObject
    {
        public List<Obstacle> Obstacles;
        
        [Range(0, 10)]
        public int obstaclesPerSegment = 5;
    }
}