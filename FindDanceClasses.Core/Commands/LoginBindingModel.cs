using System;
namespace FindDanceClasses.Core.Commands
{
    public class LoginBindingModel
    {
        public string LogInName { get; set; }

        public string Password { get; set; }

        public string TokenApp { get; set; }
    }
}
