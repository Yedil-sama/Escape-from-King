using UnityEngine;

namespace Core.RealWorld
{
    public class PlayerInteraction : MonoBehaviour
    {
        public float interactRange = 3f;
        public LayerMask interactableLayer;
        public KeyCode interactButton;
        public KeyCode throwButton;
        private Camera cam;
        public void Start()
        {
            cam = Camera.main;
        }
        public void Update()
        {
            if (Input.GetKeyDown(interactButton))
            {
                if (InventoryManager.Instance.selectedItem == null)
                {
                    Interact();
                }
                else
                {
                    InventoryManager.Instance.selectedItem.Use();
                }
            }
            if (Input.GetKeyDown(throwButton))
            {
                InventoryManager.Instance.ThrowSelectedItem();
            }
        }
        public void Interact()
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactRange, interactableLayer))
            {
                IInteractable item = hit.collider.GetComponent<IInteractable>();
                if (item != null)
                {
                    item.Interact();
                }
            }
        }

    }

}
