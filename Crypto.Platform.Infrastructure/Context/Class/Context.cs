using Crypto.Platform.Infrastructure.Context.Interface;

namespace Crypto.Platform.Infrastructure.Context.Class
{
    internal class Context<T> : IContext<T> where T : class
    {
        private readonly List<T> _context;
        public Context() {
            this._context = new List<T>();
        }

        public void Add(T content)
        {
            this._context.Add(content);
        }

        public void Remove(T content)
        {
            this._context.Remove(content);
        }

        public void RemoveAll() 
        {
            this._context.Clear();
        }

        public IEnumerable<T> GetAll()
        {
            return this._context;
        }

        public int Count() 
        {
            return this._context.Count;
        }
    }
}
