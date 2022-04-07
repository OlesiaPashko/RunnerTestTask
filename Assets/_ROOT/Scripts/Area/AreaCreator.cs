namespace Runner.Area
{
    using Settings;
    using UnityEngine;
    using Zenject;

    public class AreaCreator : MonoBehaviour
    {
        [Inject]
        public AreaPrefabSettings AreaPrefabSettings { get; set; }

        [Inject]
        public DiContainer DiContainer { get; set; }

        private void Start()
        {
            DiContainer.InstantiatePrefabForComponent<Area>(AreaPrefabSettings.Area, transform);
        }
    }
}