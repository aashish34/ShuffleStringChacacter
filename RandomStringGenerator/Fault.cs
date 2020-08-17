using System;
using System.Collections.Generic;
using System.Text;

namespace RandomStringGenerator
{
    public class Fault
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public Fault()
        {

        }
        public Fault(ErrorCode code, string message)
        {
            Code = (int)code;
            Message = message;
        }
        public enum ErrorCode
        {
            StringEmpty = 0,
            StringHasSameLetter = 1
        }
    }
}

































