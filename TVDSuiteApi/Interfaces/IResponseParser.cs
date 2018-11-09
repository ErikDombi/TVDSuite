using System;
using System.Collections.Generic;
using System.Text;

namespace TVDSuiteAPI.Interfaces
{
    interface IResponseParser
    {
         string Parse(ResponseType type, int code);
    }
}
