namespace Runner.Player
{
    using GameFlow;
    using UnityEngine;
    using Zenject;

    public class DamageReceiver : MonoBehaviour
    {
        [Inject]
        public SignalBus SignalBus { get; set; }
        
        [SerializeField] 
        private int health = 100;

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                SignalBus.Fire<LevelFailed>();
            }
        }
    }
}