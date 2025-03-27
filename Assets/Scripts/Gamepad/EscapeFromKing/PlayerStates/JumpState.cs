using UnityEngine;

namespace Core.Gamepad.EscapeFromKing
{
    public class JumpState : PlayerState
    {
        public JumpState(PlayerMovement playerMovement) : base(playerMovement) { }
        public override void Enter()
        {
            Debug.Log("Started to Jump");
        }
        public override void Update()
        {
            if (playerMovement.groundChecker.isGrounded)
            {
                playerMovement.SwitchState(new WalkState(playerMovement));
            }

            Debug.Log("Jumping");
        }
        public override void Exit()
        {
            Debug.Log("No more Jumping");
        }
    }

}
