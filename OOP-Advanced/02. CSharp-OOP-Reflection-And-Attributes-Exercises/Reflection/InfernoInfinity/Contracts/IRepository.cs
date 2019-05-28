namespace InfernoInfinity.Contracts
{
    public interface IRepository<T>
        where T : IIdentifiable
    {
        void Add(T item);

        T GetItem(string name);

        void Remove(T item);
    }
}
