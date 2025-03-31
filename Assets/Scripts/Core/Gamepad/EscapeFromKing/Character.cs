using UnityEngine;

namespace Core.Gamepad.EscapeFromKing
{
    public class Character : MonoBehaviour, IDamageable
    {
        public Health health;
        public float armor;
        public float speed;
        public void Initialize(float health, float armor, float speed)
        {
            this.armor = armor;
            this.speed = speed;
            this.health = new Health(health);
        }
        public virtual float ApplyDamage(Damage damage)
        {
            damage.amount -= armor;

            if (damage.amount < 0)
            {
                damage.amount = 0;
            }

            health.TakeDamage(damage);
        
            if (health.isDead)
            {
                Die();
            }

            //Debug.Log($"{nameof(gameObject)} took {damage.amount} damage");
            return damage.amount;
        }
        protected virtual void Die()
        {
            Destroy(gameObject);
        }
    }

}

