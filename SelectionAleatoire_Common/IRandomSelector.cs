namespace SelectionAleatoire_Common
{
    public interface IRandomSelector<T>
    {
        T Select();
        T Pop();
        int Count();
        void Reset();
        string ToString(bool complete);

    }
}
