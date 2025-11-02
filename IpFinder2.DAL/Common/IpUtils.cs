using System.Net;
using System.Numerics;

namespace IpFinder2.DAL.Common;

public static class IpUtils
{
    public static bool TryParseCidr(string cidr, out BigInteger end, out int version)
    {
        return TryParseCidr(cidr, out _, out end, out version);
    }

    public static bool TryParseCidr(string cidr, out BigInteger start, out BigInteger end, out int version)
    {
        start = end = 0;
        version = 0;
        var parts = cidr.Split('/');
        if (parts.Length != 2) return false;

        if (!IPAddress.TryParse(parts[0], out var ip)) return false;
        if (!int.TryParse(parts[1], out var prefix)) return false;

        var bytes = ip.GetAddressBytes();
        version = bytes.Length == 4 ? 4 : 6;
        var ipNum = new BigInteger(bytes.Reverse().Concat(new byte[] { 0 }).ToArray());

        var totalBits = version == 4 ? 32 : 128;
        var hostBits = totalBits - prefix;
        var rangeSize = BigInteger.One << hostBits;

        start = ipNum;
        end = ipNum + rangeSize - 1;
        return true;
    }
    
    public static BigInteger IpToBigInteger(string ipStr)
    {
        var ip = IPAddress.Parse(ipStr);
        var bytes = ip.GetAddressBytes();
        return new BigInteger(bytes.Reverse().Concat(new byte[] { 0 }).ToArray());
    }
}