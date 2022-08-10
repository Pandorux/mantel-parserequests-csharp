
// See https://aka.ms/new-console-template for more information
using ParseRequests;

Console.WriteLine(@"
    Hello, This is the Mantel Tech Assessment!
    
    The purpose of this Tech Assessment will be to parse HTTP Requests and list details the aforementioned HTTP Requests. \n\n
");


const string fileName = "programming-task-example-data_(1).log";

List<string> lines = File.ReadAllLines("../../../" + fileName).ToList();
lines.ForEach(l => Console.WriteLine(l));

List<string> ips = new List<string>();
lines.ForEach(l =>
{
    string result = HTTPRequestParsingHelper.IP_REGEX.Match(l).Value;

    if (!String.IsNullOrEmpty(result))
    {
        ips.Add(result);
    }
    else
    {
        throw new Exception("IP Not Found");
    }
});

ips.ForEach(l => Console.WriteLine(l));
Console.WriteLine($"There are {ips.Count} IP Addresses Provided");

Console.WriteLine(@"

    And that is the entire file logged above");