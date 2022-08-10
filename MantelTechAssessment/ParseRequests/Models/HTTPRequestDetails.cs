using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseRequests.Models
{
    public class HTTPRequestDetails
    {
        public readonly string HTTPRequest;
        public DateTime TimeOfRequest { get; private set; }

        public HTTPRequestDetails(string HTTPRequest, DateTime TimeOfRequest)
        {
            this.HTTPRequest = HTTPRequest;
            this.TimeOfRequest = TimeOfRequest;
        }
    }
}
