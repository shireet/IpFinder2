using System.Net;
using IpFinder2.BLL.Interfaces;
using IpFinder2.Presentation.Interfaces;

namespace IpFinder2.Presentation.Implementations;

public class IpSearchManager(IIpSearcher ipSearcher) : IIpSearchManager
{
    public void Run()
    {
        Console.WriteLine("=== IP Searcher ===");
        Console.WriteLine("Enter an IP address (IPv4 or IPv6). Type 'exit' to quit.\n");

        while (true)
        {
            Console.Write("Enter IP: ");
            var input = Console.ReadLine()?.Trim();

            if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Please enter a non-empty value.\n");
                continue;
            }

            if (!IPAddress.TryParse(input, out var _))
            {
                Console.WriteLine("Invalid IP address format. Try again.\n");
                continue;
            }
           
            var info = ipSearcher.Find(input);
            Console.WriteLine(info == null
                ? "Ip not found.\n"
                : $"{info.CountryCode}–{info.CountryName}, {info.StateCode}–{info.StateName}\n");
            
        }
    }
}