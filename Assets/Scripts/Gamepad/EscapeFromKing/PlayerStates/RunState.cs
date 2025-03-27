using UnityEngine;

namespace Core.Gamepad.EscapeFromKing
{
    public class RunState : PlayerState
    {
        public RunState(PlayerMovement playerMovement) : base(playerMovement) { }
        public override void Enter()
        {
            Debug.Log("Started to Run");
        }
        public override void Update()
        {
            Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            playerMovement.Move(playerMovement.transform.TransformDirection(moveDirection), playerMovement.runSpeed);

            if (!Input.GetKey(KeyCode.LeftShift))
            {
                playerMovement.SwitchState(new WalkState(playerMovement));
            }
            else if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                playerMovement.SwitchState(new CrouchState(playerMovement));
            }
            else if (Input.GetButtonDown("Jump"))
            {
                playerMovement.Jump();
            }

            Debug.Log("Running");
        }
        public override void Exit()
        {
            Debug.Log("No more Runing");
        }
    }

}
