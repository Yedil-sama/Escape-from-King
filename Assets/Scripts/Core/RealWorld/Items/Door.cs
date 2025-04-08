using System.Collections;
using UnityEngine;

namespace Core.RealWorld
{
    public class Door : InteractableObject, IHoldInteractable
    {
        public float holdTime = 2f;
        public float timeToHold => holdTime;

        public bool isOpened = false;
        public float rotationSpeed = 2f;
        private Quaternion initialRotation;
        private Quaternion targetRotation;
        public void Start()
        {
            initialRotation = transform.rotation;
            targetRotation = initialRotation * Quaternion.Euler(0, 90, 0);
        }
        public void HoldInteraction(float progress)
        {
            Debug.Log($"{progress * 100}%");
        }

        public override void Interact()
        {
            base.Interact();

            if (!isOpened)
            {
                StartCoroutine(DoInteract(initialRotation, targetRotation));
                isOpened = true;

                Debug.Log($"Door is Opened");
            }
            else
            {
                StartCoroutine(DoInteract(targetRotation, initialRotation));
                isOpened= false;

                Debug.Log($"Door is Closed");
            }
        }
        private IEnumerator DoInteract(Quaternion start, Quaternion target)
        {
            float elapsedTime = 0;
            while (elapsedTime < 1f)
            {
                transform.rotation = Quaternion.Slerp(start, target, elapsedTime);
                elapsedTime += Time.deltaTime * rotationSpeed;
                yield return null;
            }
            transform.rotation = target;
        }
    }

}
