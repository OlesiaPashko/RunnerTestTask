namespace Runner.Area
{
    using Player;
    using Settings;
    using UnityEngine;
    using Zenject;

    public class AreaCreator : MonoBehaviour
    {
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
            CreateArea();
            CreatePlayer();
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
    }
}