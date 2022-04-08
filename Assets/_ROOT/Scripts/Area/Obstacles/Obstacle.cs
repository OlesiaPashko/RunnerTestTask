namespace Runner.Area.Obstacles
{
    using Player;
    using Shared;
    using UnityEngine;

    public class Obstacle : MonoBehaviour
    {
        [Header("Structure")] 
        [SerializeField] 
        private CollisionSource collisionSource;

        [Header("Settings")] 
        [SerializeField] 
        private int hitDamage = 100;

        private void Start()
        {
            collisionSource.onCollisionEnter += Hit;
        }

        private void Hit(Collision other)
        {
            var damageReceiver = other.gameObject.GetComponent<DamageReceiver>();
            if (damageReceiver == null)
            {
                return;
            }
            damageReceiver.TakeDamage(hitDamage);
        }

        private void OnDestroy()
        {
            collisionSource.onCollisionEnter -= Hit;
        }
    }
}