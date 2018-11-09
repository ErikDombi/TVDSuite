using System;
using System.Collections.Generic;
using System.Text;
using TVDSuiteAPI.Interfaces;

namespace TVDSuiteAPI.Classes
{
    public class Response
    {
        public int Code;
        public bool Success;
        public string Message;
        public ResponseType Type;

        public static Response CreateSuccess()
        {
            return new Response() { Success = true };
        }

        public static Response CreateFailure()
        {
            return new Response() { Success = false };
        }

        public static Response Create(ResponseType type, int code)
        {
            return new Response() { Success = code == 0, Message = ResponseParser.Parse(type, code), Code = code, Type = type};
        }

        
    }

    static internal class ResponseExtensions
    {
        public static Response WithMessage(this Response response, string message)
        {
            response.Message = message;
            return response;
        }
    }
}
