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
    }
}
