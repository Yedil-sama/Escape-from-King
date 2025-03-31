using UnityEngine;

namespace Core.RealWorld
{
    public class Player : MonoBehaviour
    {
        public Transform itemHolder;
        [SerializeField] private PlayerMovement movement;
        [SerializeField] private PlayerInteraction interaction;

        public void Start()
        {
            movement = GetComponent<PlayerMovement>();
            interaction = GetComponent<PlayerInteraction>();
        }
    }

}
