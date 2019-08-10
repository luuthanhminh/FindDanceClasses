using System;
namespace FindDanceClasses.Core.Helpers
{
    public class NoInternetException : Exception
    {
        public NoInternetException(string message) : base(message)
        {

        }
    }
}
