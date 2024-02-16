using Crypto.Platform.Api.Boundary.Request.Abstract;
using Crypto.Platform.Api.Boundary.Response;
using Crypto.Platform.Api.Settings;
using Crypto.Platform.Api.UseCase.Abstract;
using Newtonsoft.Json.Linq;

namespace Crypto.Platform.Api.UseCase.Class
{
    public class GetAllExchanges : BaseUseCase<IList<ExchangeResponse>>
    {
        private readonly ApiSettings _apiSettings;

        public GetAllExchanges(IConfiguration config)
        {
            this._apiSettings = config.GetSection("Api").Get<ApiSettings>();
        }

        public override async Task<IList<ExchangeResponse>> ExecuteAsync(RequestViewModel? request)
        {
            List<ExchangeResponse> exchanges = new();

            using (var httpClient = new HttpClient()) 
            {
                using (var response = await httpClient.GetAsync(this._apiSettings.Exchanges)) 
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    if (apiResponse != null)
                    {
                        IEnumerable<JToken> token = JToken.Parse(apiResponse).Values();

                        foreach (JToken token2 in token)
                        {
                            exchanges.Add(token2.ToObject<ExchangeResponse>()!);
                        }
                    }
                }
            }

            return exchanges;
        }
    }
}
