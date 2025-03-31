using UnityEngine;

namespace Core.PlayerStates
{
    public class CrouchState : PlayerState
    {
        public CrouchState(PlayerMovement playerMovement) : base(playerMovement) { }
        public override void Enter()
        {
            playerMovement.GetComponent<CharacterController>().height = playerMovement.crouchHeight;
            //Debug.Log("Started to Crouch");
        }
        public override void Update()
        {
            Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            playerMovement.Move(playerMovement.transform.TransformDirection(moveDirection), playerMovement.crouchSpeed);

            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                playerMovement.SwitchState(new WalkState(playerMovement));
                Exit();
            }

            //Debug.Log("Crouching");
        }
        public override void Exit()
        {
            playerMovement.GetComponent<CharacterController>().height = playerMovement.normalHeight;

            //Debug.Log("No more Crouching");
        }
    }

}
