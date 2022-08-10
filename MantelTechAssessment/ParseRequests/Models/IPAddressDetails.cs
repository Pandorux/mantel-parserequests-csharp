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
        public List<string> parsedLines = new List<string>();

        public IPAddressDetails(string IPAddress)
        {
            this.IPAddress = IPAddress;
        }
    }
}
