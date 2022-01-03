namespace Cahoots.Core
{
    //public abstract class IMission
    //{
    //    public bool IsCompleted { get; private set; }
    //    public void Complete() => IsCompleted = true;

    //    private IMission()
    //    {
    //        IsCompleted = false;
    //    }

    //    public abstract bool CanBeCompleted(CardSet cardSet);
    //}
    public interface IMission
    {
        bool CanBeCompleted(CardSet cardSet);
    }
}
