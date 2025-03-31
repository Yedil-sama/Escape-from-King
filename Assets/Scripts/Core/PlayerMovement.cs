using UnityEngine;
using Core.PlayerStates;

namespace Core
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Objects")]
        public GroundChecker groundChecker;

        [Header("Movement Settings")]
        public float walkSpeed = 5f;
        public float runSpeed = 10f;
        public float crouchSpeed = 2f;
        [SerializeField] private float jumpHeight = 2f;
        [SerializeField] private float gravity = -9.8f;

        [Header("Crouch Settings")]
        public float normalHeight = 2f;
        public float crouchHeight = 1f;

        private Vector3 velocity;
        private CharacterController characterController;

        private PlayerState currentState;

        public void Start()
        {
            characterController = GetComponent<CharacterController>();
            groundChecker = GetComponentInChildren<GroundChecker>();
            SwitchState(new WalkState(this));
        }

        public void Update()
        {
            currentState?.Update();
            ApplyGravity();
        }

        public void Move(Vector3 direction, float speed)
        {
            velocity.x = direction.x * speed;
            velocity.z = direction.z * speed;
            characterController.Move(velocity * Time.deltaTime);
        }


        public void Jump()
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            SwitchState(new JumpState(this));
        }

        public void ApplyGravity()
        {
            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }

        public void SwitchState(PlayerState newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState?.Enter();
        }
    }
}
