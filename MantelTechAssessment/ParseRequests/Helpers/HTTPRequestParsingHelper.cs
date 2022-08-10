using ParseRequests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParseRequests.Helpers
{
    static class HTTPRequestParsingHelper
    {
        public static readonly Regex IP_REGEX = new Regex("([0-9]{1,3}\\.|\\*\\.){3}([0-9]{1,3}|\\*){1}");
        public static readonly Regex DATE_REGEX = new Regex("(\\d{2}\\/[a-zA-Z0-9].*/\\d{2,4}.*\\+[0-9]{4}){1}");
        public static readonly Regex GETREQUEST_REGEX = new Regex("(GET.*HTTP/1.1){1}");

        public static bool IsHTTPRequestStringParseable(string s)
        {
            return HTTPRequestParsingHelper.IP_REGEX.IsMatch(s) 
                && HTTPRequestParsingHelper.DATE_REGEX.IsMatch(s)
                && HTTPRequestParsingHelper.GETREQUEST_REGEX.IsMatch(s);
        }
    }
}
