using System;
using System.Threading.Tasks;
using FindDanceClasses.Core.CommandResults;
using FindDanceClasses.Core.Commands;
using Flurl.Http;
using Flurl;
using FindDanceClasses.Core.Services.Base;
namespace FindDanceClasses.Core.Services
{
    public interface ILoginApiService
    {
        Task<LoginResponse> Login(LoginBindingModel model);
    }

    public class LoginApiService : BaseApiService, ILoginApiService
    {
        const string LOGIN_ENDPOINT = "";

        public async Task<LoginResponse> Login(LoginBindingModel model)
        {
            try
            {
                var result = await LOGIN_ENDPOINT.SetQueryParams(new
                {
                    LogInName = model.LogInName,
                    Password = model.Password,
                    TokenApp = model.TokenApp
                }).GetJsonAsync<LoginResponse>();

                return result;
            }
            catch (Exception ex)
            {
                return new LoginResponse()
                {
                    IsError = true,
                    ErrorMesssage = ex.Message
                };
            }
        }
    }
}
