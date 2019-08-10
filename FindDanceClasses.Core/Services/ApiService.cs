using System;
using FindDanceClasses.Core.Services.Base;
using System.Threading.Tasks;
using FindDanceClasses.Core.CommandResults;
using Flurl;
using FindDanceClasses.Core.Helpers;
using Flurl.Http;
using FindDanceClasses.Core.Infrastructure;
using FindDanceClasses.Core.Commands;


namespace FindDanceClasses.Core.Services
{
    public interface IApiService
    {

    }

    public class ApiService : BaseApiService, IApiService
    {

    }
}
