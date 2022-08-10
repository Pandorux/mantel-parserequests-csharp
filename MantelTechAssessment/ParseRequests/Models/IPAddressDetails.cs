using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseRequests.Models
{
    public class IPAddressDetails
    {
        public readonly string IPAddress;
        public string parsedLine { get; private set; }

        public IPAddressDetails(string IPAddress, string parsedLine)
        {
            this.IPAddress = IPAddress;
            this.parsedLine = parsedLine;
        }
    }
}
