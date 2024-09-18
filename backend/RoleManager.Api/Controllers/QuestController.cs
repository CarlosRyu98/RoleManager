namespace RoleManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestsController : ControllerBase
{
    private readonly IQuestRepository _questRepository;
    private readonly IQuestStageRepository _stageRepository;
    private readonly IMapper _mapper;

    public QuestsController(IQuestRepository questRepository, IQuestStageRepository stageRepository, IMapper mapper)
    {
        _questRepository = questRepository;
        _stageRepository = stageRepository;
        _mapper = mapper;
    }

    // GET: api/Quests
    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuestDto>>> GetAllQuests()
    {
        var quests = await _questRepository.GetAllQuestsAsync();
        return Ok(_mapper.Map<IEnumerable<QuestDto>>(quests));
    }

    // GET: api/Quests/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<QuestDto>> GetQuestById(int id)
    {
        var quest = await _questRepository.GetQuestByIdAsync(id);
        if (quest == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<QuestDto>(quest));
    }

    // POST: api/Quests
    [HttpPost]
    public async Task<ActionResult<QuestDto>> CreateQuest(QuestCreateDto questCreateDto)
    {
        var quest = _mapper.Map<Quest>(questCreateDto);
        var createdQuest = await _questRepository.CreateQuestAsync(quest);
        var questDto = _mapper.Map<QuestDto>(createdQuest);
        return CreatedAtAction(nameof(GetQuestById), new { id = questDto.QuestId }, questDto);
    }

    // PUT: api/Quests/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateQuest(int id, QuestUpdateDto questUpdateDto)
    {
        if (id != questUpdateDto.QuestId) return BadRequest();

        var quest = _mapper.Map<Quest>(questUpdateDto);
        var result = await _questRepository.UpdateQuestAsync(quest);

        if (!result) return NotFound();

        return NoContent();
    }

    // DELETE: api/Quests/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuest(int id)
    {
        var result = await _questRepository.DeleteQuestAsync(id);
        if (!result) return NotFound();

        return NoContent();
    }

    // GET: api/Quests/{questId}/Stages
    [HttpGet("{questId}/Stages")]
    public async Task<ActionResult<IEnumerable<QuestStageDto>>> GetStagesByQuestId(int questId)
    {
        var stages = await _stageRepository.GetStagesByQuestIdAsync(questId);
        return Ok(_mapper.Map<IEnumerable<QuestStageDto>>(stages));
    }

    // POST: api/Quests/{questId}/Stages
    [HttpPost("{questId}/Stages")]
    public async Task<ActionResult<QuestStageDto>> CreateStage(int questId, QuestStageCreateDto stageCreateDto)
    {
        var stage = _mapper.Map<QuestStage>(stageCreateDto);
        stage.QuestId = questId;
        var createdStage = await _stageRepository.CreateStageAsync(stage);

        var stageDto = _mapper.Map<QuestStageDto>(createdStage);
        return CreatedAtAction(nameof(GetStagesByQuestId), new { questId = stageDto.QuestId }, stageDto);
    }

    // PUT: api/Quests/{questId}/Stages/{stageId}
    [HttpPut("{questId}/Stages/{stageId}")]
    public async Task<IActionResult> UpdateStage(int questId, int stageId, QuestStageUpdateDto stageUpdateDto)
    {
        if (stageId != stageUpdateDto.StageId || questId != stageUpdateDto.QuestId) return BadRequest();

        var stage = _mapper.Map<QuestStage>(stageUpdateDto);
        var result = await _stageRepository.UpdateStageAsync(stage);

        if (!result) return NotFound();

        return NoContent();
    }

    // DELETE: api/Quests/{questId}/Stages/{stageId}
    [HttpDelete("{questId}/Stages/{stageId}")]
    public async Task<IActionResult> DeleteStage(int questId, int stageId)
    {
        var result = await _stageRepository.DeleteStageAsync(stageId);
        if (!result) return NotFound();

        return NoContent();
    }
}