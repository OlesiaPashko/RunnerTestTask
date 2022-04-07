namespace Runner.Settings
{
    using UI;
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(WindowPrefabSettings), menuName = "Runner/WindowPrefabSettings")]
    public class WindowPrefabSettings : ScriptableObject
    {
        public HomeWindow HomeWindow;
    }
}