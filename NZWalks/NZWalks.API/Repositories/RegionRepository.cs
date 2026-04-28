using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;

namespace NZWalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _context;

        public RegionRepository(NZWalksDbContext context)
        {
            _context = context;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await _context.Regions.AddAsync(region);
            await _context.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null)
            {
                return null;
            }
            _context.Regions.Remove(region);
            await _context.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _context.Regions.ToListAsync();
        }


        public async Task<Region> GetAsync(Guid id)
        {
            return await _context.Regions.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existRegion = await _context.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (existRegion == null)
            {
                return null;
            }

            existRegion.Code = region.Code;
            existRegion.Name = region.Name;
            existRegion.Area = region.Area;
            existRegion.Lat = region.Lat;
            existRegion.Long = region.Long;
            existRegion.Population = region.Population;

            await _context.SaveChangesAsync();
            return existRegion;
        }       
        
    }
}
