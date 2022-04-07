namespace Runner.Area
{
    using Settings;
    using UnityEngine;
    using Zenject;

    public class AreaCreator : MonoBehaviour
    {
        [Inject]
        public AreaPrefabSettings AreaPrefabSettings { get; set; }

        private void Start()
        {
            Instantiate(AreaPrefabSettings.Area, transform);
        }
    }
}