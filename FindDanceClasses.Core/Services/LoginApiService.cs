using System;
using System.Threading.Tasks;
using FindDanceClasses.Core.CommandResults;
using FindDanceClasses.Core.Commands;
using Flurl.Http;
using Flurl;
using FindDanceClasses.Core.Services.Base;
using System.Net.Http;
using Flurl.Http.Configuration;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace FindDanceClasses.Core.Services
{
    public interface ILoginApiService
    {
        Task<LoginResponse> Login(LoginBindingModel model);
    }

    public class LoginApiService : BaseApiService, ILoginApiService
    {
        const string BASE_URL = "https://www.finddanceclasses.co.uk/Api/MobileApi";

        const string LOGIN_URL = BASE_URL + "/Login";

        public async Task<LoginResponse> Login(LoginBindingModel model)
        {
            try
            {

                HttpClient client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(15);

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(LOGIN_URL),
                    Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"),
                };

                var response = await client.SendAsync(request).ConfigureAwait(false);


                var responseBody = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<LoginResponse>(responseBody);

                return result;
            }
            catch (Exception ex)
            {
                return new LoginResponse()
                {
                    Message = ex.Message
                };
            }
        }
    }
}
