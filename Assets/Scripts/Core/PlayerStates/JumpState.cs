using UnityEngine;

namespace Core.PlayerStates
{
    public class JumpState : PlayerState
    {
        public float walkSpeedMultiplier = 0.5f;
        public JumpState(PlayerMovement playerMovement) : base(playerMovement) { }
        public override void Enter()
        {
            //Debug.Log("Started to Jump");
        }

        public override void Update()
        {
            Transform camTransform = Camera.main.transform;

            Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = camTransform.TransformDirection(moveDirection);
            moveDirection.y = 0;

            if (moveDirection.magnitude > 0.1f)
            {
                playerMovement.Move(moveDirection.normalized, playerMovement.walkSpeed * walkSpeedMultiplier);
            }

            if (playerMovement.groundChecker.isGrounded)
            {
                playerMovement.SwitchState(new WalkState(playerMovement));
            }

            //Debug.Log("Jumping");

        }
        public override void Exit()
        {
            //Debug.Log("No more Jumping");
        }
    }

}
