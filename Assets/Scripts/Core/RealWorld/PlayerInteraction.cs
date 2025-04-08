using System.Collections;
using UnityEngine;

namespace Core.RealWorld
{
    public class PlayerInteraction : MonoBehaviour
    {
        public float interactRange = 3f;
        public float holdTime = 0;
        public LayerMask interactableLayer;
        public KeyCode interactButton;
        public KeyCode throwButton;

        private Camera cam;
        private Coroutine holdCoroutine;

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

            if (Input.GetKeyUp(interactButton) && holdCoroutine != null)
            {
                StopCoroutine(holdCoroutine);
                holdCoroutine = null;
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
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    if (interactable is IHoldInteractable holdInteractable)
                    {
                        holdCoroutine = StartCoroutine(HoldInteraction(holdInteractable));
                    }
                    else
                    {
                        interactable.Interact();
                    }
                }
            }
        }

        private IEnumerator HoldInteraction(IHoldInteractable holdInteractable)
        {
            float progress = 0;
            while (progress < holdInteractable.timeToHold)
            {
                if (!Input.GetKey(interactButton))
                {
                    yield break;
                }
                progress += Time.deltaTime;
                holdInteractable.HoldInteraction(progress / holdInteractable.timeToHold);
                yield return null;
            }

            holdInteractable.Interact();
        }

    }

}
