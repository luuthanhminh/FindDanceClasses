using System;
using System.Collections.Generic;

namespace FindDanceClasses.Core.Infrastructure
{
    public class ApiResponse<T>
    {
        public T Result { get; set; }
        public Result Err { get; set; }
    }

    public class ApiResponse
    {
        public Result Err { get; set; }
    }

    public class Result
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
    }
}
