namespace Runner.Player
{
    using Settings;
    using UnityEngine;
    using Zenject;

    public class PlayerFactory : IFactory<Transform, Player>
    {
        private readonly PlayerSettings playerSettings;
        private readonly DiContainer container;

        public PlayerFactory(PlayerSettings playerSettings, DiContainer container)
        {
            this.playerSettings = playerSettings;
            this.container = container;
        }

        public Player Create(Transform transform)
        {
            var prefab = playerSettings.Player;
            return container.InstantiatePrefabForComponent<Player>(prefab, transform);
        }
    }
}