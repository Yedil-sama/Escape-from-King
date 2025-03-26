using System;

[Serializable]
public class Health
{
    public float maxHealth; // { get; private set; }

    public float currentHealth; // { get; private set; }

    public bool isDead => currentHealth <= 0;
    public Health(float maxHealth)
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
    }
    public float TakeDamage(Damage damage)
    {
        if (isDead) return 0;
        if (damage.amount <= 0) return 0;
        
        currentHealth -= damage.amount;

        if (currentHealth <= 0)
        {
            (currentHealth, damage.amount) = (0, damage.amount + currentHealth);
        }

        return damage.amount;
    }
    public float HealUp(float amount)
    {
        if (isDead) return 0;
        if (amount <= 0) return 0;

        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            (currentHealth, amount) = (maxHealth, amount + maxHealth - currentHealth);

        }

        return amount;
    }

}
