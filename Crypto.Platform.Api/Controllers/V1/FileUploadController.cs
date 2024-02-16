using Asp.Versioning;
using Crypto.Platform.Api.Boundary.Request.Class;
using Crypto.Platform.Api.Boundary.Response;
using Crypto.Platform.Api.UseCase.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Crypto.Platform.Api.Controllers.V1
{
    //[Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/file")]
    public class FileUploadController : Controller
    {
        private readonly ILogger<FileUploadController> _logger;
        private readonly IBaseUseCase<FileUploadResponse> _setFileUploadedContent;

        public FileUploadController(IBaseUseCase<FileUploadResponse> setFileUploadedContent, ILogger<FileUploadController> logger)
        {
            this._logger = logger;
            this._setFileUploadedContent = setFileUploadedContent;
        }

        /// <summary>
        /// This API is used to upload the cryptocurrency file.
        /// </summary>
        ///<response code="401">Unauthorized</response>
        ///<response code="400">The request is not valid according to requirements</response>
        ///<response code="500">Internal server error</response>
        ///<response code="200">Returns information with the file's metadata</response>
        [HttpPost]
        [Route("upload")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(FileUploadResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> FileUpload(IFormFile file)
        {
            this._logger.LogInformation("Getting file details");

            if (file == null || file.Length == 0)
            {
                return BadRequest(new BaseErrorResponse((int)HttpStatusCode.BadRequest, "No file uploaded"));
            }

            FileUploadQuery request = new() { content = file };

            var response = await this._setFileUploadedContent.ExecuteAsync(request).ConfigureAwait(false);

            this._logger.LogInformation("File uploaded successfully");

            return Ok(response);
        }
    }
}
