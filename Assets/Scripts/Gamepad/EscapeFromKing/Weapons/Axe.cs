using UnityEngine;

namespace Core.Gamepad.EscapeFromKing
{
    public class Axe : Weapon
    {
        public float attackDelay = 0.5f;
        public override void Attack()
        {
            Debug.Log("Started to prepare a big swing");
            Invoke(nameof(DelayedAttack), attackDelay);
        }
        private void DelayedAttack()
        {
            Attack();
            Debug.Log("Bonk");
        }
    }

}
