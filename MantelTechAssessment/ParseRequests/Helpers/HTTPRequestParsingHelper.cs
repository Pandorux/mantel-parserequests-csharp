using ParseRequests.Models;
using ParseRequests.Repositories;
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
        public static readonly string LOG_FOLDER_PATH = "../../../Logs/";

        public static readonly Regex IP_REGEX = new Regex("([0-9]{1,3}\\.|\\*\\.){3}([0-9]{1,3}|\\*){1}");
        public static readonly Regex DATE_REGEX = new Regex("(\\d{2}\\/[a-zA-Z0-9].*/\\d{2,4}.*\\+[0-9]{4}){1}");
        public static readonly Regex GETREQUEST_REGEX = new Regex("(GET.*HTTP/1.1){1}");

        public static readonly Regex URL_REGEX = new Regex("(http|https)://[A-Za-z0-9.]+[^/]");
        public static readonly Regex URL_FULLYQUALIFIED_REGEX = new Regex("(http|https)://[.*][^/]([^ ]+)");
        public static readonly Regex URLRESOURCE_REGEX = new Regex("/ |(?<=[^://])/[^/]([^ ]+)");
        public static readonly Regex URL_AND_URLRESOURCE_REGEX = new Regex("(http|https)://[^/]([^ ]+)|(?<=[^://])/[^/]([^ ]+)");

        private static int DAY_DATECOMPONENT = 0;
        private static int MONTH_DATECOMPONENT = 1;
        private static int YEAR_DATECOMPONENT = 2;
        private static int HOUR_DATECOMPONENT = 3;
        private static int MINUTE_DATECOMPONENT = 4;
        private static int SECOND_DATECOMPONENT = 5;

        public static void ParseHTTPRequestStrings(string[] strings)
        {
            strings.ToList().ForEach(s => HTTPRequestParsingHelper.ParseHTTPRequestString(s));
        }

        public static void ParseHTTPRequestString(string s)
        {
            if (HTTPRequestParsingHelper.IsHTTPRequestStringParseable(s))
            {
                string result = HTTPRequestParsingHelper.IP_REGEX.Match(s).Value;

                if (IPAddressRepository.IPAddresses.ContainsKey(result))
                {
                    IPAddressRepository.IPAddresses[result].parsedLines.Add(s);
                }
                else
                {
                    IPAddressRepository.IPAddresses.Add(result, new IPAddressDetails(result));
                }

                string date = HTTPRequestParsingHelper.DATE_REGEX.Match(s).Value;
                string header = HTTPRequestParsingHelper.GETREQUEST_REGEX.Match(s).Value;

                HTTPRequestDetails req = new HTTPRequestDetails(header, HTTPRequestParsingHelper.ParseHTTPRequestStringDateTime(date));
                IPAddressRepository.IPAddresses[result].Requests.Add(req);
            }
            else
            {
                throw new Exception("IP Not Valid");
            }
        }

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

        public static string ParseHTTPRequestStringRequestURL(string s)
        {
            // NOTE:    This originally tried to get each subpart of URL. 
            //          Due to time constraints this has been simplified.

            string requestUrl = HTTPRequestParsingHelper.URL_AND_URLRESOURCE_REGEX.Match(s).Value;

            return requestUrl;
        }
    }
}
