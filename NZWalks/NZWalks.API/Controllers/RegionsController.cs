using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;


namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        // GET: api/<RegionsController>
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionRepository.GetAllAsync();

            // Map domain regions to DTOs
            var RegionDto = mapper.Map<List<RegionDto>>(regions);

            return Ok(RegionDto);
        }

        [HttpGet("{id:guid}", Name = "GetRegion")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await regionRepository.GetAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            var regionDto = mapper.Map<RegionDto>(region);
            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(AddRegionDto addRegionDto)
        {
            // Convert DTO to Domain Model
            var region = new Region()
            {

                Code = addRegionDto.Code,
                Name = addRegionDto.Name,
                Area = addRegionDto.Area,
                Lat = addRegionDto.Lat,
                Long = addRegionDto.Long,
                Population = addRegionDto.Population
            };

            // Persist
            region = await regionRepository.AddAsync(region);

            // Convert back to DTO
            var regionDto = new RegionDto()
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Population = region.Population
            };

            // Use CreatedAtRoute referencing the named route "GetRegion"
            return CreatedAtRoute("GetRegion", new { id = regionDto.Id }, regionDto);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            var region = await regionRepository.DeleteAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            var regionDto = mapper.Map<RegionDto>(region);
            return Ok(regionDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateRegion(Guid id, UpdateRegionDto updateRegionDto)
        {
            // Convert DTO to Domain Model
            var region = new Region()
            {
                Code = updateRegionDto.Code,
                Name = updateRegionDto.Name,
                Area = updateRegionDto.Area,
                Lat = updateRegionDto.Lat,
                Long = updateRegionDto.Long,
                Population = updateRegionDto.Population
            };
            // Update Region using repository
            region = await regionRepository.UpdateAsync(id, region);
            // If null is returned then NotFound
            if (region == null)
            {
                return NotFound();
            }
            // Convert back to DTO
            var regionDto = new RegionDto()
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Population = region.Population
            };
            // Return Ok response with the updated DTO
            return Ok(regionDto);
        }
    }
}
