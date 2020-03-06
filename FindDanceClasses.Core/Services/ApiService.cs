using System;
using FindDanceClasses.Core.Services.Base;
using System.Threading.Tasks;
using FindDanceClasses.Core.CommandResults;
using Flurl;
using FindDanceClasses.Core.Helpers;
using Flurl.Http;
using FindDanceClasses.Core.Infrastructure;
using FindDanceClasses.Core.Commands;
using System.Collections.Generic;
using FindDanceClasses.Core.Models;


namespace FindDanceClasses.Core.Services
{
    public interface IApiService
    {
        Task<ApiResponse<List<Event>>> GetEvents(int companyId);

        Task<ApiResponse<List<Ticket>>> GetTickets(int companyId, int eventId);

        Task<ApiResponse<List<Ticket>>> SearchTickets(int companyId, int eventId, string keyword);

        Task<ApiResponse<bool>> CheckInQrCode(int companyId, int classId, string qrCode, bool checkIn);
    }

    public class ApiService : BaseApiService, IApiService
    {
        const string BASE_URL = "https://www.finddanceclasses.co.uk/Api/MobileApi";

        const string GET_EVENTS_BY_COMPANY = BASE_URL + "/GetAllEventsByCompanyId";

        const string GET_TICKETS_BY_COMPANY_AND_EVENT = BASE_URL + "/GetAllTicketsByCompanyAndEventId";

        const string SEARCH_TICKET = BASE_URL + "/GetAllTicketsByCompanyAndEventIdSearch";

        const string CHECK_IN_USER_BY_QR_CODE = BASE_URL + "/CheckInUserByQrCode";

        public async Task<ApiResponse<bool>> CheckInQrCode(int companyId, int classId, string qrCode, bool checkIn)
        {
            try
            {
                var result = await CHECK_IN_USER_BY_QR_CODE.SetQueryParam("companyId", companyId)
                    .SetQueryParam("classId", classId)
                    .SetQueryParam("qrCode", qrCode)
                    .SetQueryParam("checkIn", checkIn)
                    .WithHeader("Token", AppSettings.Token).GetStringAsync();

                return new ApiResponse<bool>
                {
                    Result = true
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    Err = new Result()
                    {
                        IsError = true,
                        Message = "An error occurred"
                    }
                };
            }
        }

        public async Task<ApiResponse<List<Event>>> GetEvents(int companyId)
        {
            try
            {
                var result = await GET_EVENTS_BY_COMPANY.SetQueryParam("companyId", companyId)
                    .WithHeader("Token", AppSettings.Token).GetJsonAsync<List<Event>>();

                return new ApiResponse<List<Event>>
                {
                    Result = result
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Event>>
                {
                    Err = new Result()
                    {
                        IsError = true,
                        Message = ex.Message
                    }
                };
            }
        }

        public async Task<ApiResponse<List<Ticket>>> GetTickets(int companyId, int eventId)
        {
            try
            {
                var result = await GET_TICKETS_BY_COMPANY_AND_EVENT.SetQueryParam("companyId", companyId)
                    .SetQueryParam("eventId", eventId)
                    .WithHeader("Token", AppSettings.Token).GetJsonAsync<List<Ticket>>();

                return new ApiResponse<List<Ticket>>
                {
                    Result = result
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Ticket>>
                {
                    Err = new Result()
                    {
                        IsError = true,
                        Message = ex.Message
                    }
                };
            }
        }

        public async Task<ApiResponse<List<Ticket>>> SearchTickets(int companyId, int eventId, string keyword)
        {
            try
            {
                var result = await SEARCH_TICKET.SetQueryParam("companyId", companyId)
                    .SetQueryParam("eventId", eventId)
                    .SetQueryParam("ticketIdnameOrEmail", keyword)
                    .WithHeader("Token", AppSettings.Token).GetJsonAsync<List<Ticket>>();

                return new ApiResponse<List<Ticket>>
                {
                    Result = result
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Ticket>>
                {
                    Err = new Result()
                    {
                        IsError = true,
                        Message = ex.Message
                    }
                };
            }
        }
    }
}
