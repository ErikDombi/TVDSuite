using System;
using System.Collections.Generic;
using System.Text;
using TVDSuiteAPI.Interfaces;

namespace TVDSuiteAPI.Classes
{
    class ResponseParser
    {
        public static string Parse(ResponseType type, int code)
        {
            switch (type)
            {
                case ResponseType.Login:
                    switch (code)
                    {
                        case 0:
                            return "Logged in successfully!";
                        case 1:
                            return "Incorrect Password!";
                        case 2:
                            return "Account not found!";
                        case 3:
                            return "Email is not verified.";
                        case 4:
                            return "Account has been deactivated!";
                        case 5:
                            return "Account has not yet been approved.";
                        case 6:
                            return "Account has been suspended indefinitely.";
                        case 7:
                            return "Network username inconsistency! All TVDSuite accounts are linked to one TVDSB account!";
                        default:
                            return "An unknown error occured while trying to log in!";
                    }
                case ResponseType.PermissionGet:
                    switch (code)
                    {
                        case 0:
                            return "Permission Found";
                        case 1:
                            return "Missing Permission";
                        case 2:
                            return "Failed to find user";
                        default:
                            return "An unknown error occured while fetching permissions!";
                    }
                case ResponseType.Register:
                    switch (code)
                    {
                        case 0:
                            return "Registered successfully!";
                        case 1:
                            return "Account with that username already exists!";
                        case 2:
                            return "Account with that email already exists!";
                        case 3:
                            return "Password does not meet requirements!";
                        case 4:
                            return "Please enter a usename!";
                        case 5:
                            return "Please enter a password!";
                        case 6:
                            return "Please enter an email!";
                        case 7:
                            return "Please enter your first name!";
                        case 8:
                            return "Please enter your last name!";
                        default:
                            return "An unknown error occured while trying to log in!";
                    }
                case ResponseType.UpdateInformation:
                    switch (code)
                    {
                        case 0:
                            return "Logged in successfully!";
                        case 1:
                            return "Incorrect Password!";
                        case 2:
                            return "Account not found!";
                        default:
                            return "An unknown error occured while trying to log in!";
                    }
                case ResponseType.Generic:
                    switch(code)
                    {
                        case 0:
                            return "Success";
                        default:
                            return "Unknown error occured.";
                    }
                case ResponseType.ResetRequest:
                    switch(code)
                    {
                        case 0:
                            return "Account is to be reset";
                        case 1:
                            return "No account reset required";
                        case 2:
                            return "Account not found!";
                        default:
                            return "An unknown error occured!";
                    }
                default:
                    return "An unknown error occured!";
            }
        }
    }
}
