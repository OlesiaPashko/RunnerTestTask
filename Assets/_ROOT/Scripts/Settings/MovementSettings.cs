namespace Runner.Settings
{
    using UnityEngine;
    using UnityEngine.Serialization;

    [CreateAssetMenu(fileName = nameof(MovementSettings), menuName = "Runner/MovementSettings")]
    public class MovementSettings : ScriptableObject
    {
        [Range(0, 10f)] 
        public float startSpeed = 1f;
        
        [FormerlySerializedAs("jumpHeight")] [Range(0, 1)] 
        public float jumpForce = 1f;
        
        [Range(0, 1)] 
        public float clicksMaxGap = 1f;
    }
}