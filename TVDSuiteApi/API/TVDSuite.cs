using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using TVDSuiteApi.Classes;
using TVDSuiteAPI.API;
using TVDSuiteAPI.Classes;
using TVDSuiteAPI.Interfaces;

namespace TVDSuiteAPI.API
{
    public class TVDSuite
    {
        #region Definitions

        private bool _auth;
        public bool Authenticated {
            get {
                return _auth;
            }
        }

        private string _username;
        private string _password;

        #endregion

        public Response Login(string username, string password) {
            try
            {
                
                _username = username; _password = password;
                var _res = WebInterface.Request("/login/", new KeyValuePair<string, string>[] {
                    new KeyValuePair<string, string>("Username", username),
                    new KeyValuePair<string, string>("Password", password),
                    new KeyValuePair<string, string>("NetworkUsername", Environment.UserName)
                });
                _auth = _res == "0";
                if (_auth)
                {
                    if (!File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TVDSuite", "UAInfo")))
                        File.Create(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TVDSuite", "UAInfo")).Close();
                    File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TVDSuite", "UAInfo"), username);
                }
                return Response.Create(ResponseType.Login, int.Parse(_res));
            }
            catch { return Response.CreateFailure(); }
        }

        public Response GetPermission(string permission)
        {
            if (!_auth)
                return Response.Create(ResponseType.Generic, 1).WithMessage("User is not logged in!");
            return Response.Create(ResponseType.PermissionGet, int.Parse(WebInterface.Request("/user/permission/", new KeyValuePair<string, string>[] {
                new KeyValuePair<string, string>("Username", _username),
                new KeyValuePair<string, string>("Permission", permission)
            })));
        }

        public Response DoesUserRequireReset()
        {
            try
            {
                if (!File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TVDSuite", "UAInfo")))
                    return Response.CreateFailure().WithMessage("No cached user exists!");
                if (string.IsNullOrWhiteSpace(File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TVDSuite", "UAInfo"))))
                    return Response.CreateFailure().WithMessage("No cached user exists!");
                _username = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TVDSuite", "UAInfo"));
                var _res = WebInterface.Request("/user/toReset/", new KeyValuePair<string, string>[] {
                    new KeyValuePair<string, string>("Username", _username)
                });
                _auth = _res == "0"; return Response.Create(ResponseType.Login, int.Parse(_res));
            }
            catch { return Response.CreateFailure(); }
        }
    }
}
