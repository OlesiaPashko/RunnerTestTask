namespace Runner.Settings
{
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(MovementSettings), menuName = "Runner/MovementSettings")]
    public class MovementSettings : ScriptableObject
    {
        [Range(0, 10f)] 
        public float startSpeed = 1f;

        [Range(0, 1)] 
        public float acceleration = 0.01f;
    }
}