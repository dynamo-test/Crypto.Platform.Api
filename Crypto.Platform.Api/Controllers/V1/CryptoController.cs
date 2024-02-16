using Asp.Versioning;
using Crypto.Platform.Api.Boundary.Response;
using Crypto.Platform.Api.UseCase.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crypto.Platform.Api.Controllers.V1
{
    //[Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}")]
    public class CryptoController : Controller
    {
        private readonly ILogger<CryptoController> _logger;
        private readonly IBaseUseCase<IList<CryptoCurrencyResponse>> _getAllCryptoCurrency;

        public CryptoController(IBaseUseCase<IList<CryptoCurrencyResponse>> getAllCryptoCurrency, ILogger<CryptoController> logger)
        {
            this._logger = logger;
            this._getAllCryptoCurrency = getAllCryptoCurrency;
        }

        /// <summary>
        /// This API returns a list of all cryptocurrencies.
        /// </summary>
        ///<response code="401">Unauthorized</response>
        ///<response code="204">No Content</response>
        ///<response code="500">Internal server error</response>
        ///<response code="200">Returns list of all cryptocurrencies</response>
        [HttpGet]
        [Route("crypto")]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(FileUploadResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCryptoCurrency()
        {
            this._logger.LogInformation("Getting crypto currencies details");

            var currencyList = await this._getAllCryptoCurrency.ExecuteAsync(default).ConfigureAwait(false);

            if (currencyList == null || currencyList.Count == 0)
            {
                return NoContent();
            }

            return Ok(currencyList);
        }
    }
}
