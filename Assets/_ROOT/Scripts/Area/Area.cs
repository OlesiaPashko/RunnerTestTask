namespace Runner.Area
{
    using UnityEngine;

    public class Area : MonoBehaviour
    {
        [SerializeField] 
        private PlayerPlaceholder playerPlaceholder;

        public PlayerPlaceholder PlayerPlaceholder => playerPlaceholder;
    }
}