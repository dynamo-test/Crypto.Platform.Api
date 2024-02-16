namespace Crypto.Platform.Infrastructure.Patterns.Repository.Interface
{
    public interface IAsyncRepository<T> where T : class
    {
        public void AddContent(T content);

        public void RemoveContent();

        public IList<T> GetContent();

        public int GetCount();
    }
}
