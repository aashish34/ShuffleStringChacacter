using System;
using System.Collections.Generic;
using System.Text;

namespace RandomStringGenerator
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public Fault Fault { get; set; }
        public BaseResponse()
        {
        }
        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
