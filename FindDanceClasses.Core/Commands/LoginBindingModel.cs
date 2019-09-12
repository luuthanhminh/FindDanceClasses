using System;
namespace FindDanceClasses.Core.Commands
{
    public class LoginBindingModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string RememberMe { get; set; }
    }
}
