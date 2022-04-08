namespace Runner.Area
{
    using System;
    using GameFlow;
    using Obstacles;
    using Player;
    using Settings;
    using UnityEngine;
    using Zenject;

    public class AreaCreator : MonoBehaviour
    {
        [Inject]
        public SignalBus SignalBus { get; set; }
        
        [Inject]
        public AreaPrefabSettings AreaPrefabSettings { get; set; }

        [Inject]
        public DiContainer DiContainer { get; set; }

        [Inject]
        public PlayerFactory PlayerFactory { get; set; }
        
        [Inject]
        public IPlayerInstanceProvider PlayerInstanceProvider { get; set; }

        private Area currentArea;

        private void Start()
        {
            Create();
            SignalBus.Subscribe<LevelRestarted>(RecreateArea);
        }

        private void RecreateArea()
        {
            Destroy(currentArea.gameObject);
            Create();
        }

        private void Create()
        {
            CreateArea();
            CreatePlayer();
            currentArea.ObstaclesContainer.CreateObstacles();
        }

        private void CreateArea()
        {
            var areaPrefab = AreaPrefabSettings.Area;
            currentArea = DiContainer.InstantiatePrefabForComponent<Area>(areaPrefab, transform);
        }

        private void CreatePlayer()
        {
            var playerParent = currentArea.PlayerPlaceholder.transform;
            var player = PlayerFactory.Create(playerParent);
            PlayerInstanceProvider.Player = player;
        }

        private void OnDestroy()
        {
            SignalBus.TryUnsubscribe<LevelRestarted>(RecreateArea);
        }
    }
}