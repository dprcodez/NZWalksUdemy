using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalksRepository _walksRepository;
        private readonly IMapper _mapper;

        public WalksController(IWalksRepository walksRepository, IMapper mapper)
        {
            _walksRepository = walksRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWalksAsync()
        {
            var walkDomain = await _walksRepository.GetAllAsync();
            var walksDto = _mapper.Map<List<WalkDto>>(walkDomain);

            return Ok(walksDto);
            
        }
    }

}
