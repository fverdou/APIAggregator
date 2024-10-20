using APIAggregator.Models;

namespace APIAggregator.Interfaces
{
    public interface IWordsService
    {
        Task<WordApiResponse> GetWordDetailsAsync(string word);
    }
}
