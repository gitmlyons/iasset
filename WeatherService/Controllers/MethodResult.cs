using System;
using System.Collections.Generic;

namespace WeatherService.Controllers
{
    public class MethodResult<ResultType>
    {
        public bool Succeeded { get; set; }

        public ResultType Result { get; set; }

        public string Messages { get; set; }

        public MethodResult()
        {
            Succeeded = false;
            Messages = string.Empty;
        }

        public MethodResult(bool succeeded, ResultType result)
        {
            Succeeded = succeeded;
            Result = result;
            Messages = string.Empty;
        }

        public MethodResult(bool succeeded, ResultType result, string message)
        {
            Succeeded = succeeded;
            Result = result;
            Messages = string.Empty;
        }
    }
}
