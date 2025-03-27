using UnityEngine;

namespace Core.Gamepad.EscapeFromKing
{
    public class WalkState : PlayerState
    {
        public WalkState(PlayerMovement playerMovement) : base(playerMovement) { }
        public override void Enter()
        {
            Debug.Log("Started to Walk");
        }
        public override void Update()
        {
            Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            playerMovement.Move(playerMovement.transform.TransformDirection(moveDirection), playerMovement.walkSpeed);

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                playerMovement.SwitchState(new CrouchState(playerMovement));
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                playerMovement.SwitchState(new RunState(playerMovement));
            }
            else if (Input.GetButtonDown("Jump"))
            {
                playerMovement.Jump();
            }

            Debug.Log("Walking");
        }
        public override void Exit()
        {
            Debug.Log("No more Walking");
        }
    }

}
