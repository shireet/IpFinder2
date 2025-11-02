using IpFinder2.BLL.Interfaces;
using IpFinder2.BLL.Mappers;
using IpFinder2.BLL.Models;
using IpFinder2.DAL.Common;
using IpFinder2.DAL.Interfaces;

namespace IpFinder2.BLL.Implementations;

public class IpSearcher(ISubnetRepository repo) : IIpSearcher
{
    private readonly List<SubnetInfo> _subnets = repo.LoadSubnets()
        .Select(x => x.ToBll())
        .OrderBy(s => s.Start)
        .ToList();
    
    public SubnetInfo? Find(string ip)
    {
        var ipNum = IpUtils.IpToBigInteger(ip);
        int left = 0, right = _subnets.Count - 1;

        while (left <= right)
        {
            var mid = (left + right) / 2;
            var subnet = _subnets[mid];

            if (ipNum < subnet.Start) right = mid - 1;
            else if (ipNum > subnet.End) left = mid + 1;
            else return subnet;
        }
        return null;
    }
}