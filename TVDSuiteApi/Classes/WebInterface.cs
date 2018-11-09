using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace TVDSuiteApi.Classes
{
    class WebInterface : WebClient
    {
        public static string Request(string Endpoint, KeyValuePair<string, string>[] Headers)
        {
            Endpoint = Endpoint.TrimStart('/');
            const string baseAddress = "https://api.tvdsuite.com/api/v1/";
            WebClient WC = new WebClient();
            Headers.ToList().ForEach(x => WC.Headers.Add(x.Key, x.Value));
            return WC.DownloadString(baseAddress + Endpoint);
        }
    }
}
