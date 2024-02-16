namespace Crypto.Platform.Infrastructure.Context.Interface
{
    internal interface IContext<T> where T : class
    {
        public void Add(T content);

        public void Remove(T content);

        public void RemoveAll();

        public IEnumerable<T> GetAll();

        public int Count();
    }
}
