using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalksRepository
    {
        Task<IEnumerable<Walk>> GetAllAsync();
    }
}
