using UnityEngine;

public class Sword : Weapon
{
    public override void Attack()
    {
        DealDamage();
        Debug.Log("Sword Attacked");
    }
}
