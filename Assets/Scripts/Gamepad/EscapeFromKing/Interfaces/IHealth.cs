namespace Core.Gamepad.EscapeFromKing
{
    public interface IHealth
    {
        float maxHealth { get; }
        float currentHealth { get; }
        bool isDead { get; }
        float TakeDamage(Damage amount);
        float HealUp(float amount);
    }

}
