using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("regions")]
    public class RegionController : Controller
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _regionRepository.GetAllAsync();

            /* Exchange domain model for DTO model.
            var regionsDto = new List<Models.DTO.Region>();
            
            regions.ToList().ForEach(region =>
            {
                var regionDto = new Models.DTO.Region()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    Area = region.Area,
                    Latitude = region.Latitude,
                    Long = region.Long,
                    Population = region.Population
                };

                regionsDto.Add(regionDto);
            });
            */

            // Exchange domain model for DTO model via AutoMapper.
            var regionsDto = _mapper.Map<List<Models.DTO.Region>>(regions);

            return Ok(regionsDto);
        }
    }
}