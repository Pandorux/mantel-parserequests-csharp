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
        // Regex expression for validating IP
        public static readonly Regex IP_REGEX = new Regex("([0-9]{1,3}\\.|\\*\\.){3}([0-9]{1,3}|\\*){1}");
    }
}
