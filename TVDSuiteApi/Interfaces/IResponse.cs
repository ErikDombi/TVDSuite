using System;
using System.Collections.Generic;
using System.Text;
using TVDSuiteAPI.Interfaces;

namespace TVDSuiteAPI.Interfaces
{
    interface IResponse
    {
        ResponseType Type { get; set; }
        int Code { get; set; }
        string Message { get; set; }
    }
}
