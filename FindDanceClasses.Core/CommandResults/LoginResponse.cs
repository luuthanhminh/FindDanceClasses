using System;
namespace FindDanceClasses.Core.CommandResults
{
    public class LoginResponse
    {
        public bool IsAppValid { get; set; }

        public bool IsUserValid { get; set; }

        public string TokenUser { get; set; }

        public bool IsError { get; set; }

        public string ErrorMesssage { get; set; }

        public int DefaultListID { get; set; }
    }
}
