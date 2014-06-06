using System.Threading.Tasks;
using MapLink.Domain;

namespace MapLink.Proxy.Contracts
{
    public interface ICoordinateFinder
    {
        Task<Coordinate> FindCoordinateAsync(AddressSearch search);
    }
}
