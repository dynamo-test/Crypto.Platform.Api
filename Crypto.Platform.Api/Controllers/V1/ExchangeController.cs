using Asp.Versioning;
using Crypto.Platform.Api.Boundary.Request.Class;
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
    public class ExchangeController : Controller
    {
        private readonly ILogger<ExchangeController> _logger;
        private readonly IBaseUseCase<IList<ExchangeResponse>> _getAllExchanges;
        private readonly IBaseUseCase<ExchangeItemResponse> _getExchangeById;

        public ExchangeController(IBaseUseCase<IList<ExchangeResponse>> getAllExchanges, IBaseUseCase<ExchangeItemResponse> getExchangeById, ILogger<ExchangeController> logger)
        {
            this._logger = logger;
            this._getAllExchanges = getAllExchanges;
            this._getExchangeById = getExchangeById;
        }


        /// <summary>
        /// This API returns a list of all exchanges.
        /// </summary>
        ///<response code="401">Unauthorized</response>
        ///<response code="204">No Content</response>
        ///<response code="500">Internal server error</response>
        ///<response code="200">Returns list of all exchanges</response>
        [HttpGet]
        [Route("exchange")]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ExchangeResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllExchanges()
        {
            this._logger.LogInformation("Getting exchange market details");

            var exchanges = await this._getAllExchanges.ExecuteAsync(default).ConfigureAwait(false);

            if (exchanges.Count == 0)
            {
                return NoContent();
            }

            return Ok(exchanges);
        }

        /// <summary>
        /// This API returns specific exchange by ID (Returns Top 100 Pairs).
        /// </summary>
        ///<response code="401">Unauthorized</response>
        ///<response code="204">No Content</response>
        ///<response code="500">Internal server error</response>
        ///<response code="200">Returns list of pairs</response>
        [HttpGet]
        [Route("exchange/{id}")]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ExchangeItemResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetExchangeById([FromRoute] string id)
        {
            ExchangeItemQuery request = new() { Id = id };

            this._logger.LogInformation($"Getting exchange list details by id: {id}");

            var exchangeItem = await this._getExchangeById.ExecuteAsync(request).ConfigureAwait(false);

            if (exchangeItem == null)
            {
                return NoContent();
            }

            return Ok(exchangeItem.Pairs);
        }
    }
}
