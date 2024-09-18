namespace RoleManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FactionsController : ControllerBase
{
    private readonly IFactionRepository _factionRepository;
    private readonly IMapper _mapper;

    public FactionsController(IFactionRepository factionRepository, IMapper mapper)
    {
        _factionRepository = factionRepository;
        _mapper = mapper;
    }

    // GET: api/Factions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FactionDto>>> GetAllFactions()
    {
        var factions = await _factionRepository.GetAllFactionsAsync();
        return Ok(_mapper.Map<IEnumerable<FactionDto>>(factions));
    }

    // GET: api/Factions/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<FactionDto>> GetFactionById(int id)
    {
        var faction = await _factionRepository.GetFactionByIdAsync(id);
        if (faction == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<FactionDto>(faction));
    }

    // POST: api/Factions
    [HttpPost]
    public async Task<ActionResult<FactionDto>> CreateFaction(FactionCreateDto factionCreateDto)
    {
        var faction = _mapper.Map<Faction>(factionCreateDto);
        var createdFaction = await _factionRepository.CreateFactionAsync(faction);

        var factionDto = _mapper.Map<FactionDto>(createdFaction);
        return CreatedAtAction(nameof(GetFactionById), new { id = factionDto.FactionId }, factionDto);
    }

    // PUT: api/Factions/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFaction(int id, FactionUpdateDto factionUpdateDto)
    {
        if (id != factionUpdateDto.FactionId)
        {
            return BadRequest();
        }

        var faction = _mapper.Map<Faction>(factionUpdateDto);
        var result = await _factionRepository.UpdateFactionAsync(faction);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/Factions/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFaction(int id)
    {
        var result = await _factionRepository.DeleteFactionAsync(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}