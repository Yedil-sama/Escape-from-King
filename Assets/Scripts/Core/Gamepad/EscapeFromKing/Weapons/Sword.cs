using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Core.Gamepad.EscapeFromKing
{
    public class Sword : Weapon
    {
        [SerializeField] private Transform swordTransform;
        [SerializeField] private Transform attackPoint;
        [SerializeField] private float swingSpeed = 10f;
        [SerializeField] private float swingAngle = 90f;

        private bool isSwinging = false;
        private HashSet<IDamageable> hitTargets = new HashSet<IDamageable>();

        private void Start()
        {
            if (swordTransform == null)
            {
                swordTransform = transform;
            }
            if (attackPoint == null)
            {
                attackPoint = transform;
            }
        }

        public override void Attack()
        {
            if (!isSwinging)
            {
                StartCoroutine(Swing());
            }
        }

        private IEnumerator Swing()
        {
            isSwinging = true;
            hitTargets.Clear();

            float elapsedTime = 0f;
            float halfSwingTime = 1f / swingSpeed;

            Quaternion startRotation = swordTransform.localRotation;
            Quaternion endRotation = startRotation * Quaternion.Euler(swingAngle, 0, 0);

            while (elapsedTime < halfSwingTime)
            {
                elapsedTime += Time.deltaTime;
                swordTransform.localRotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / halfSwingTime);
                CheckHits();
                yield return null;
            }

            elapsedTime = 0f;
            while (elapsedTime < halfSwingTime)
            {
                elapsedTime += Time.deltaTime;
                swordTransform.localRotation = Quaternion.Slerp(endRotation, startRotation, elapsedTime / halfSwingTime);
                CheckHits();
                yield return null;
            }

            isSwinging = false;
        }

        private void CheckHits()
        {
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                if (enemy.TryGetComponent<IDamageable>(out IDamageable damageable) && !hitTargets.Contains(damageable))
                {
                    damageable.ApplyDamage(damage);
                    hitTargets.Add(damageable);
                }
            }
        }

    }

}
