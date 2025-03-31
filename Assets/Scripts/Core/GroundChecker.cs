using UnityEngine;

namespace Core
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private float checkRadius = 0.5f;
        [SerializeField] private LayerMask groundMask;
        public bool isGrounded;
        public void Update()
        {
            isGrounded = Physics.CheckSphere(transform.position, checkRadius, groundMask);
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, checkRadius);
        }
    }

}
