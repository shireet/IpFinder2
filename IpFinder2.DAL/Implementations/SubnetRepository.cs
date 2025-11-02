using IpFinder2.DAL.Common;
using IpFinder2.DAL.Interfaces;
using IpFinder2.DAL.Models;

namespace IpFinder2.DAL.Implementations;

public class SubnetRepository(string filePath) : ISubnetRepository
{
    public IEnumerable<SubnetInfoEntity> LoadSubnets()
    {
        foreach (var line in File.ReadLines(filePath))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var parts = line.Split(',');
            if (parts.Length < 10) continue;

            var cidr = parts[0];
            if (!IpUtils.TryParseCidr(cidr, out var start, out var end, out var version))
                continue;

            yield return new SubnetInfoEntity
            {
                IpVersion = version,
                Start = start,
                End = end,
                CountryCode = parts[3],
                CountryName = parts[4],
                StateCode = parts[5],
                StateName = parts[6]
            };
        }
    }
}