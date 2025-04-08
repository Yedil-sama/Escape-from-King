namespace Core.RealWorld
{
    public interface IHoldInteractable : IInteractable
    {
        float timeToHold { get; }
        void HoldInteraction(float progress);
    }

}
