namespace Runner.Area.Obstacles
{
    using System.Collections.Generic;
    using Settings;
    using UnityEngine;
    using Zenject;

    public class ObstaclesContainer : MonoBehaviour
    {
        [Inject]
        public ObstacleFactory ObstacleFactory { get; set; }

        [Inject]
        public ObstacleSettings ObstacleSettings { get; set; }

        [SerializeField] 
        private ObstaclePositionProvider obstaclePositionProvider;

        private List<Obstacle> obstacles = new List<Obstacle>();

        public void CreateObstacles()
        {
            var obstaclesCount = ObstacleSettings.obstaclesPerSegment;
            for (int i = 0; i <= obstaclesCount; i++)
            {
                CreateObstacle();
            }
        }
        
        public void ShuffleObstacles()
        {
            foreach (var obstacle in obstacles)
            {
                SetObstaclePosition(obstacle);
            }
        }

        private void SetObstaclePosition(Obstacle obstacle)
        {
            var position = obstaclePositionProvider.Get();
            obstacle.transform.position = position;
        }

        private void CreateObstacle()
        {
            var obstacle = ObstacleFactory.Create(transform);
            SetObstaclePosition(obstacle);
            obstacles.Add(obstacle);
        }
    }
}