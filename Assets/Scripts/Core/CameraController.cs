using UnityEngine;

namespace Core
{
    public class CameraController : MonoBehaviour
    {
        public float sensitivity = 2f;
        public Transform playerTransform;

        private float verticalRotation = 0f;
        public void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        
        }
        public void Update()
        {
            Rotate();
        }
        private void Rotate()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            playerTransform.Rotate(Vector3.up * mouseX * sensitivity);
            verticalRotation -= mouseY * sensitivity;

            verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        }
    }

}
