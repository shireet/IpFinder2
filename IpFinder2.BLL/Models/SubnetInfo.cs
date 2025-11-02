using System.Numerics;

namespace IpFinder2.BLL.Models;

public class SubnetInfo
{
    public int IpVersion { get; set; } 
    public BigInteger Start { get; set; }
    public BigInteger End { get; set; }
    public string CountryCode { get; set; } = "";
    public string CountryName { get; set; } = "";
    public string StateCode { get; set; } = "";
    public string StateName { get; set; } = "";
}