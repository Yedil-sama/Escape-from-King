namespace Core.Gamepad.EscapeFromKing
{
    public class PlayerState
    {
        protected PlayerMovement playerMovement;
        public PlayerState(PlayerMovement playerMovement) => this.playerMovement = playerMovement;
        public virtual void Enter() { }
        public virtual void Update() { }
        public virtual void Exit() { }
    }

}
