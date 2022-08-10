using ParseRequests.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        private static int DAY_DATECOMPONENT = 1;
        private static int MONTH_DATECOMPONENT = 2;
        private static int YEAR_DATECOMPONENT = 3;
        private static int HOUR_DATECOMPONENT = 4;
        private static int MINUTE_DATECOMPONENT = 5;
        private static int SECOND_DATECOMPONENT = 6;

        public static bool IsHTTPRequestStringParseable(string s)
        {
            return HTTPRequestParsingHelper.IP_REGEX.IsMatch(s) 
                && HTTPRequestParsingHelper.DATE_REGEX.IsMatch(s)
                && HTTPRequestParsingHelper.GETREQUEST_REGEX.IsMatch(s);
        }

        public static DateTime ParseHTTPRequestStringDateTime(string s)
        {
            try
            {
                string dateString = HTTPRequestParsingHelper.DATE_REGEX.Match(s).Value;
                string[] components = dateString.Split('/', ':', '+');

                int day = Int32.Parse(components[DAY_DATECOMPONENT]);
                // TODO: This will error if format doesn't match or month is provided as an int
                int month = DateTime.ParseExact(components[MONTH_DATECOMPONENT], "MMM", CultureInfo.InvariantCulture).Month;
                int year = Int32.Parse(components[YEAR_DATECOMPONENT]);
                int hour = Int32.Parse(components[HOUR_DATECOMPONENT]);
                int minute = Int32.Parse(components[MINUTE_DATECOMPONENT]);
                int second = Int32.Parse(components[SECOND_DATECOMPONENT]);

                return new DateTime(year, month, day, hour, minute, second);
            }
            catch
            {
                throw new InvalidCastException();
            }
        }
    }
}
