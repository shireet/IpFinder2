using IpFinder2.DAL.Models;

namespace IpFinder2.DAL.Interfaces;

public interface ISubnetRepository
{
    IEnumerable<SubnetInfoEntity> LoadSubnets();
}