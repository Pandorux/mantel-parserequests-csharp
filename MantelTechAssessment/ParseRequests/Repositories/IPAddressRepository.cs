using ParseRequests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseRequests.Repositories
{
    public static class IPAddressRepository
    {
        public static Dictionary<string, IPAddressDetails> IPAddresses = new Dictionary<string, IPAddressDetails>();

        public static int TotalUniqueIPAddresses
        {
            get
            {
                return IPAddressRepository.IPAddresses.Count;
            }
        }

        public static int TotalHTTPRequestsMade
        {
            get
            {
                return IPAddressRepository.IPAddresses.Values.Sum(ip => ip.Requests.Count);
            }
        }

        public static List<IPAddressDetails> GetMostActiveIPAddresses(int limit = 100)
        {
            return IPAddressRepository.IPAddresses.Values
                .ToList()
                .OrderByDescending(ip => ip.Requests.Count())
                .Take(limit)
                .ToList();
        }
    }
}
