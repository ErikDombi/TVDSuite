using System;
using System.Collections.Generic;
using System.Text;

namespace TVDSuiteAPI.Interfaces
{
    public enum ResponseType
    {
        Register = 1,
        Login = 0,
        PermissionGet = 2,
        UpdateInformation = 3,
        DeleteAccount = 4,
        Generic = 5,
        ResetRequest = 6
    }
}
