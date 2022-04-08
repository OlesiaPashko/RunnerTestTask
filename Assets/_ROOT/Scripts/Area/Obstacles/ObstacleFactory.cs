namespace Runner.Area.Obstacles
{
    using Settings;
    using UnityEngine;
    using Zenject;

    public class ObstacleFactory : IFactory<Transform, Obstacle>
    {
        private readonly ObstacleSettings obstacleSettings;
        private readonly DiContainer container;

        public ObstacleFactory(ObstacleSettings obstacleSettings, DiContainer container)
        {
            this.obstacleSettings = obstacleSettings;
            this.container = container;
        }

        public Obstacle Create(Transform transform)
        {
            var prefab = GetRandomObstacle();
            return container.InstantiatePrefabForComponent<Obstacle>(prefab, transform);
        }

        private Obstacle GetRandomObstacle()
        {
            var obstacles = obstacleSettings.Obstacles;
            var maxIndex = obstacles.Count;
            var randomIndex = Random.Range(0, maxIndex);
            return obstacles[randomIndex];
        }
    }
}