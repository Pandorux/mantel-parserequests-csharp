
// See https://aka.ms/new-console-template for more information
using ParseRequests.Helpers;
using ParseRequests.Models;
using ParseRequests.Repositories;

Console.WriteLine(@"
    Hello, This is the Mantel Tech Assessment!
    
    The purpose of this Tech Assessment will be to parse HTTP Requests and list details the aforementioned HTTP Requests. \n\n
");


const string fileName = "programming-task-example-data_(1).log";

List<string> lines = File.ReadAllLines("../../../" + fileName).ToList();
lines.ForEach(l => Console.WriteLine(l));


lines.ForEach(l =>
{
    if (HTTPRequestParsingHelper.IsHTTPRequestStringParseable(l))
    {
        string result = HTTPRequestParsingHelper.IP_REGEX.Match(l).Value;

        if (IPAddressRepository.IPAddresses.ContainsKey(result))
        {
            IPAddressRepository.IPAddresses[result].parsedLines.Add(l);
        }
        else
        {
            IPAddressRepository.IPAddresses.Add(result, new IPAddressDetails(result));
        }
    }
    else
    {
        throw new Exception("IP Not Valid");
    }
});

IPAddressRepository.IPAddresses.ToList().ForEach(l => Console.WriteLine(l));
Console.WriteLine($"There are {IPAddressRepository.IPAddresses.Count} IP Addresses Provided");

Console.WriteLine(@"

    And that is the entire file logged above");