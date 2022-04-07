namespace Runner.Settings
{
    using Player;
    using UnityEngine;
    
    [CreateAssetMenu(fileName = nameof(PlayerSettings), menuName = "Runner/PlayerSettings")]
    public class PlayerSettings : ScriptableObject
    {
        public Player Player;
    }
}