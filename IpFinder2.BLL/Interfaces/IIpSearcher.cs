using IpFinder2.BLL.Models;

namespace IpFinder2.BLL.Interfaces;

public interface IIpSearcher
{
    SubnetInfo? Find(string ip);
}