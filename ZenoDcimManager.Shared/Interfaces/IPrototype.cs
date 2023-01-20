namespace ZenoDcimManager.Shared.Interfaces
{
    public interface IPrototype<T>
    {
        T Clone();
    }

    public interface IDuplicate<T>
    {
        T Duplicate();
    }
}