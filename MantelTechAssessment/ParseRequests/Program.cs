
// See https://aka.ms/new-console-template for more information
Console.WriteLine(@"
    Hello, This is the Mantel Tech Assessment!
    
    The purpose of this Tech Assessment will be to parse HTTP Requests and list details the aforementioned HTTP Requests. \n\n
");


const string fileName = "programming-task-example-data_(1).log";


List<string> lines = File.ReadAllLines("../../../" + fileName).ToList();
lines.ForEach(l => Console.WriteLine(l));

Console.WriteLine(@"

    And that is the entire file logged above");