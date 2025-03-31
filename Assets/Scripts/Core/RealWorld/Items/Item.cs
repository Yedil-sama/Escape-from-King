using UnityEngine;

namespace Core.RealWorld
{
    public abstract class Item : MonoBehaviour, IInteractable
    {
        public string itemName;
        public bool isInteractable = true;

        public virtual void Interact()
        {
            if (isInteractable)
            {
                Debug.Log($"{itemName} is Interacted");
            }

        }

    }
}
