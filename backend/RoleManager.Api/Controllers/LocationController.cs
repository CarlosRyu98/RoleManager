namespace RoleManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    private readonly ILocationRepository _locationRepository;
    private readonly IMapper _mapper;

    public LocationsController(ILocationRepository locationRepository, IMapper mapper)
    {
        _locationRepository = locationRepository;
        _mapper = mapper;
    }

    // GET: api/Locations
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LocationDto>>> GetAllLocations()
    {
        var locations = await _locationRepository.GetAllLocationsAsync();
        return Ok(_mapper.Map<IEnumerable<LocationDto>>(locations));
    }

    // GET: api/Locations/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<LocationDto>> GetLocationById(int id)
    {
        var location = await _locationRepository.GetLocationByIdAsync(id);
        if (location == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<LocationDto>(location));
    }

    // POST: api/Locations
    [HttpPost]
    public async Task<ActionResult<LocationDto>> CreateLocation(LocationCreateDto locationCreateDto)
    {
        var location = _mapper.Map<Location>(locationCreateDto);
        var createdLocation = await _locationRepository.CreateLocationAsync(location);

        var locationDto = _mapper.Map<LocationDto>(createdLocation);
        return CreatedAtAction(nameof(GetLocationById), new { id = locationDto.LocationId }, locationDto);
    }

    // PUT: api/Locations/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLocation(int id, LocationUpdateDto locationUpdateDto)
    {
        if (id != locationUpdateDto.LocationId)
        {
            return BadRequest();
        }

        var location = _mapper.Map<Location>(locationUpdateDto);
        var result = await _locationRepository.UpdateLocationAsync(location);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/Locations/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLocation(int id)
    {
        var result = await _locationRepository.DeleteLocationAsync(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}