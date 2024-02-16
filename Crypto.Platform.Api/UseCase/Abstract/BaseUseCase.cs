using Crypto.Platform.Api.Boundary.Request.Abstract;
using Crypto.Platform.Api.UseCase.Interface;

namespace Crypto.Platform.Api.UseCase.Abstract
{
    public abstract class BaseUseCase<T> : IBaseUseCase<T>
    {
        public abstract Task<T> ExecuteAsync(RequestViewModel? request);
    }
}
