namespace RoleManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CampaignController : ControllerBase
{
    private readonly ICampaignRepository _campaignRepository;
    private readonly IMapper _mapper;

    public CampaignController(ICampaignRepository campaignRepository, IMapper mapper)
    {
        _campaignRepository = campaignRepository;
        _mapper = mapper;
    }

    // GET api/campaign
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CampaignDto>>> GetCampaigns()
    {
        var campaigns = await _campaignRepository.GetAllCampaignsAsync();
        var campaignDtos = _mapper.Map<IEnumerable<CampaignDto>>(campaigns);
        return Ok(campaignDtos);
    }

    // GET api/campaign/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<CampaignDto>> GetCampaign(int id)
    {
        var campaign = await _campaignRepository.GetCampaignByIdAsync(id);
        if (campaign == null)
        {
            return NotFound();
        }

        var campaignDto = _mapper.Map<CampaignDto>(campaign);
        return Ok(campaignDto);
    }

    // POST api/campaign
    [HttpPost]
    public async Task<ActionResult<CampaignDto>> CreateCampaign(CampaignCreateDto campaignCreateDto)
    {
        var campaign = _mapper.Map<Campaign>(campaignCreateDto);
        await _campaignRepository.AddCampaignAsync(campaign);

        // Mapear la campaña recién creada al DTO para devolverla
        var campaignDto = _mapper.Map<CampaignDto>(campaign);

        return CreatedAtAction(nameof(GetCampaign), new { id = campaign.CampaignId }, campaignDto);
    }

    // PUT api/campaign/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCampaign(int id, CampaignUpdateDto campaignUpdateDto)
    {
        if (id != campaignUpdateDto.CampaignId)
        {
            return BadRequest();
        }

        var campaign = _mapper.Map<Campaign>(campaignUpdateDto);

        var result = await _campaignRepository.UpdateCampaignAsync(campaign);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE api/campaign/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCampaign(int id)
    {
        var result = await _campaignRepository.DeleteCampaignAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}