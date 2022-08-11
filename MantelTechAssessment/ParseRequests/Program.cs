
// See https://aka.ms/new-console-template for more information
using ParseRequests.Helpers;
using ParseRequests.Models;
using ParseRequests.Repositories;

// Import and Parse File
const string fileName = "programming-task-example-data_(1).log";
List<string> lines = File.ReadAllLines(HTTPRequestParsingHelper.LOG_FOLDER_PATH + fileName).ToList();
HTTPRequestParsingHelper.ParseHTTPRequestStrings(lines.ToArray());

// Run Console Program
Console.WriteLine(@"
Hello, This is the Mantel Tech Assessment completed by Jared Carey on 11/08/22!
    
The purpose of this Tech Assessment will be to parse HTTP Requests and list details of the aforementioned HTTP Requests. The required details about the HTTP Requests can be found below.
");

Console.WriteLine($"Total Unique IP Addresses: {IPAddressRepository.TotalUniqueIPAddresses}");

Console.WriteLine($"\nMost Active IP Addresses:\n");
IPAddressRepository.GetMostActiveIPAddresses(3).ForEach(ip => Console.WriteLine($"- {ip.IPAddress}"));

Console.WriteLine($"\nMost Active Websites:");
// TODO: Website Listings

Console.WriteLine(@"

And thats it to this tech assessment!");
Console.ReadLine();