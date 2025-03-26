using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [Header("Weapon Settings")]
    public float attackRange = 1.5f;
    public Damage attackDamage;
    public LayerMask enemyLayers;

    public abstract void Attack();
    protected void DealDamage()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayers);
        foreach (Collider enemy in hitEnemies)
        {
            if (enemy.TryGetComponent<IDamagable>(out IDamagable damagable))
            {
                damagable.ApplyDamage(attackDamage);
            }
        }
    }
    protected virtual void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
