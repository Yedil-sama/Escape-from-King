using System;

namespace Core.Gamepad.EscapeFromKing
{
    public enum DamageType
    {
        Physical,
        True
    }
    [Serializable]
    public struct Damage
    {
        public float amount;
        public DamageType type;

        public Damage(float amount) : this(amount, DamageType.Physical) { }
    
        public Damage(float  amount, DamageType type)
        {
            this.amount = amount;
            this.type = type;
        }
    }

}
