using UnityEngine;

namespace Core.Gamepad.EscapeFromKing
{
    public abstract class Weapon : MonoBehaviour
    {
        [Header("Weapon Settings")]
        public float attackRange = 1.5f;
        public Damage damage;
        public LayerMask enemyLayers;

        public abstract void Attack();
        protected void DealDamage()
        {
            Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                if (enemy.TryGetComponent<IDamageable>(out IDamageable damagable))
                {
                    damagable.ApplyDamage(damage);
                }
            }
        }
    }

}
