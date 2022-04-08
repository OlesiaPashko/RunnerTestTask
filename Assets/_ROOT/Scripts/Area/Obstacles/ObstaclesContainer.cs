namespace Runner.Area.Obstacles
{
    using System.Collections.Generic;
    using UnityEngine;
    using Zenject;

    public class ObstaclesContainer : MonoBehaviour
    {
        [Inject]
        public ObstacleFactory ObstacleFactory { get; set; }

        [SerializeField] 
        private List<Obstacle> obstacles = new List<Obstacle>();
        
        
        public void CreateOneObstacle()
        {
            var obstacle = ObstacleFactory.Create(transform);
            obstacles.Add(obstacle);
        }
    }
}