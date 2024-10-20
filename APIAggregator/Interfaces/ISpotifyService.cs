using APIAggregator.Enums;
using APIAggregator.Models;

namespace APIAggregator.Interfaces
{
    public interface ISpotifyService
    {
        Task<SpotifyApiResponse> GetSpotifyDetailsAsync(string searchQuery, int? offset, int? limit, int? numberOfTopResults, MediaType type);
    }
}
