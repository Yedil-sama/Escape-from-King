using UnityEngine;

namespace Core.RealWorld
{
    public class InteractableObject : Item
    {
        public Animator animator;
        public string animationTrigger;

        public override void Interact()
        {
            if (animator != null)
            {
                animator.SetTrigger(animationTrigger);
            }
            Debug.Log($"{itemName} is Interacted");
        }
    }

}
