using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomStringGenerator
{
    public interface IRequestValidator
    {
        RequestValidatorResponse Validate(string originalString);
    }
    public class RequestValidator : IRequestValidator
    {
        public RequestValidatorResponse Validate(string originalString)
        {
            var response = new RequestValidatorResponse
            {
                Success = true
            };

            if (string.IsNullOrEmpty(originalString.Trim()))
            {
                return BuildResponse((int)Fault.ErrorCode.StringEmpty,
                    "Invalid request. Please enter the string.");
            }

            var sameCharacter = new string(originalString.Distinct().ToArray());
            if (sameCharacter.Length == 1)
            {
                return BuildResponse((int)Fault.ErrorCode.StringHasSameLetter,
                    "Invalid request. Please enter the string which has different characters.");
            }

            return response;
        }

        private RequestValidatorResponse BuildResponse(int errorCode, string message)
        {
            var fault = new Fault { Code = errorCode, Message = message };
            return new RequestValidatorResponse
            {
                Fault = fault,
                Message = message,
                Success = false
            };
        }
    }
}
