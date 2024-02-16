using Crypto.Platform.Api.Boundary.Request.Abstract;

namespace Crypto.Platform.Api.UseCase.Interface
{
    public interface IBaseUseCase<T>
    {
        public Task<T> ExecuteAsync(RequestViewModel? request);
    }
}
