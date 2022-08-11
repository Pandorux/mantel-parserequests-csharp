using ParseRequests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseRequests.Models
{
    public class HTTPRequestDetails
    {
        public static readonly Dictionary<string, int> RequestURLAccessCounts = new Dictionary<string, int>();

        public readonly string HTTPRequest;
        public DateTime TimeOfRequest { get; private set; }

        public HTTPRequestDetails(string HTTPRequest, DateTime TimeOfRequest)
        {
            this.HTTPRequest = HTTPRequest;
            this.TimeOfRequest = TimeOfRequest;

            HTTPRequestDetails.CompileURLRequest(HTTPRequest);
        }
        private static void CompileURLRequest(string HTTPRequest)
        {
            string route = HTTPRequestParsingHelper.ParseHTTPRequestStringRequestURL(HTTPRequest);

            if (HTTPRequestDetails.RequestURLAccessCounts.ContainsKey(route))
            {
                HTTPRequestDetails.RequestURLAccessCounts[route] += 1;
            }
            else
            {
                HTTPRequestDetails.RequestURLAccessCounts.Add(route, 1);
            }
        }
    }
}
