using UnityEngine;

namespace Core.RealWorld
{
    [RequireComponent(typeof(Rigidbody))]
    public class PickableItem : Item, IUsable
    {
        public bool canUse;
        protected Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        public override void Interact()
        {
            base.Interact();

            rb.useGravity = false;
            rb.isKinematic = true;
            InventoryManager.Instance.PickUpItem(this);
        }

        public void Use()
        {
            if (canUse)
            {
                Debug.Log($"{itemName} is Used");
            }
        }

        public virtual void Throw(float throwForce = 5f)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
            transform.SetParent(null);

            Vector3 throwDirection = InventoryManager.Instance.player.transform.forward;
            rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

            InventoryManager.Instance.RemoveItem(this);

            Debug.Log($"{itemName} was thrown!");
        }
    }
}
