using Crypto.Platform.Api.Boundary.Request.Abstract;
using Crypto.Platform.Api.Boundary.Request.Class;
using Crypto.Platform.Api.Boundary.Response;
using Crypto.Platform.Api.Settings;
using Crypto.Platform.Api.UseCase.Abstract;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crypto.Platform.Api.UseCase.Class
{
    public class GetExchangeById : BaseUseCase<ExchangeItemResponse>
    {
        private readonly ApiSettings _apiSettings;

        public GetExchangeById(IConfiguration config)
        {
            this._apiSettings = config.GetSection("Api").Get<ApiSettings>();
        }

        public override async Task<ExchangeItemResponse> ExecuteAsync(RequestViewModel? request)
        {
            ExchangeItemResponse? exchangeItem = default;

            using (var httpClient = new HttpClient())
            {
                string id = ((ExchangeItemQuery)request!).Id;

                using (var response = await httpClient.GetAsync(this._apiSettings.Exchange.Replace("{id}", id)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    IEnumerable<JToken> token = JToken.Parse(apiResponse).Values();

                    if (token.Count() == 2) exchangeItem = JsonConvert.DeserializeObject<ExchangeItemResponse>(apiResponse)!;
                }
            }

            return exchangeItem!;
        }
    }
}
