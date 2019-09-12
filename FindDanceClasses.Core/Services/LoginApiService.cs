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
using RestSharp;

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

                var client = new RestClient(LOGIN_URL);

                var request = new RestRequest(Method.GET);

                var t = JsonConvert.SerializeObject(model);

                request.AddJsonBody(model);
                request.AddHeader("Content-Type", "application/json");
                //request.AddParameter("", "{\n\t\t\"UserName\" : \"daniel_filipe@outlook.com\", \n\t\t\"Password\" : \"TestyTesting99\", \n\t\t\"RememberMe\" : \"true\"\n}", ParameterType.RequestBody);
                request.AddHeader("Authorization", "Basic ZmRjX0FwcGxlczpfaG93RG9Zb3VMaWtlVGhlbTkxX19f");


                var asyncHandle = client.ExecuteAsync<LoginResponse>(request, response =>
                {
                    var result = response.Data;
                });

                return null;
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
