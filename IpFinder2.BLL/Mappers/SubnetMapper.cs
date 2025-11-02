using IpFinder2.BLL.Models;
using IpFinder2.DAL.Models;

namespace IpFinder2.BLL.Mappers;

public static class SubnetMapper
{
    public static SubnetInfo ToBll(this SubnetInfoEntity subnet)
    {
        return new SubnetInfo()
        {
            IpVersion = subnet.IpVersion,
            Start = subnet.Start,
            End = subnet.End,
            CountryCode = subnet.CountryCode,
            CountryName = subnet.CountryName,
            StateCode = subnet.StateCode,
            StateName = subnet.StateName
        };
    }
}