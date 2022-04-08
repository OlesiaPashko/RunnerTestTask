namespace Runner.Area
{
    using Obstacles;
    using UnityEngine;

    public class Area : MonoBehaviour
    {
        [SerializeField] 
        private PlayerPlaceholder playerPlaceholder;

        public PlayerPlaceholder PlayerPlaceholder => playerPlaceholder;
        
        [SerializeField] 
        private ObstaclesContainer obstaclesContainer;

        public ObstaclesContainer ObstaclesContainer => obstaclesContainer;
    }
}