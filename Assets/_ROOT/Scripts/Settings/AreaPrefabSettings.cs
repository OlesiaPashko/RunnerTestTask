namespace Runner.Settings
{
    using Area;
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(AreaPrefabSettings), menuName = "Runner/AreaPrefabSettings")]
    public class AreaPrefabSettings : ScriptableObject
    {
        public Area Area;
    }
    
}