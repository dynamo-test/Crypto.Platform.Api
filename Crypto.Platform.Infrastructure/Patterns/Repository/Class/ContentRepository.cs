using Crypto.Platform.Infrastructure.Context.Interface;
using Crypto.Platform.Infrastructure.Entities;
using Crypto.Platform.Infrastructure.Patterns.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;


namespace Crypto.Platform.Infrastructure.Patterns.Repository.Class
{
    public class ContentRepository : IContentRepository
    {
        private readonly IContext<ContentEntity> _context;

        public ContentRepository(IServiceProvider provider)
        {
            IServiceScope scope = provider.CreateScope();

            this._context = scope.ServiceProvider.GetRequiredService<IContext<ContentEntity>>();
        }

        public void AddContent(ContentEntity content)
        {
            this._context.Add(content);
        }

        public void RemoveContent() 
        {
            this._context.RemoveAll();
        }

        public IList<ContentEntity> GetContent()
        {
            return this._context.GetAll().ToList();
        }

        public int GetCount()
        {
            return this._context.Count();
        }
    }
}
