using System;
namespace FindDanceClasses.Core.CommandResults
{
    public class LoginResponse
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        public DateTimeOffset TokenExpiryDate { get; set; }

        public string Message { get; set; }
    }
}
