namespace RoleManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DomainsController : ControllerBase
{
    private readonly IDomainRepository _domainRepository;
    private readonly IMapper _mapper;

    public DomainsController(IDomainRepository domainRepository, IMapper mapper)
    {
        _domainRepository = domainRepository;
        _mapper = mapper;
    }

    // GET: api/Domains
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DomainDto>>> GetAllDomains()
    {
        var domains = await _domainRepository.GetAllDomainsAsync();
        return Ok(_mapper.Map<IEnumerable<DomainDto>>(domains));
    }

    // GET: api/Domains/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<DomainDto>> GetDomainById(int id)
    {
        var domain = await _domainRepository.GetDomainByIdAsync(id);
        if (domain == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<DomainDto>(domain));
    }

    // POST: api/Domains
    [HttpPost]
    public async Task<ActionResult<DomainDto>> CreateDomain(DomainCreateDto domainCreateDto)
    {
        var domain = _mapper.Map<Domain>(domainCreateDto);
        var createdDomain = await _domainRepository.CreateDomainAsync(domain);

        var domainDto = _mapper.Map<DomainDto>(createdDomain);
        return CreatedAtAction(nameof(GetDomainById), new { id = domainDto.DomainId }, domainDto);
    }

    // PUT: api/Domains/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDomain(int id, DomainUpdateDto domainUpdateDto)
    {
        if (id != domainUpdateDto.DomainId)
        {
            return BadRequest();
        }

        var domain = _mapper.Map<Domain>(domainUpdateDto);
        var result = await _domainRepository.UpdateDomainAsync(domain);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/Domains/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDomain(int id)
    {
        var result = await _domainRepository.DeleteDomainAsync(id);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}