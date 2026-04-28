using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class WalksRepository : IWalksRepository
    {
        private readonly NZWalksDbContext _context;

        public WalksRepository(NZWalksDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await _context.Walks.ToListAsync();
            
        }
    }
}
