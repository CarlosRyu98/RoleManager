namespace RoleManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private readonly ICharacterRepository _characterRepository;
    private readonly IMapper _mapper;

    public CharacterController(ICharacterRepository characterRepository, IMapper mapper)
    {
        _characterRepository = characterRepository;
        _mapper = mapper;
    }

    // GET api/character
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CharacterDto>>> GetAllCharacters()
    {
        var characters = await _characterRepository.GetAllCharactersAsync();
        var characterDtos = _mapper.Map<IEnumerable<CharacterDto>>(characters);
        return Ok(characterDtos);
    }

    // GET api/character/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<CharacterDto>> GetCharacter(int id)
    {
        var character = await _characterRepository.GetCharacterByIdAsync(id);
        if (character == null)
        {
            return NotFound();
        }

        var characterDto = _mapper.Map<CharacterDto>(character);
        return Ok(characterDto);
    }

    // POST api/character
    [HttpPost]
    public async Task<ActionResult<CharacterDto>> CreateCharacter(CharacterCreateDto createCharacterDto)
    {
        var character = _mapper.Map<Character>(createCharacterDto);
        await _characterRepository.AddCharacterAsync(character);

        var characterDto = _mapper.Map<CharacterDto>(character);
        return CreatedAtAction(nameof(GetCharacter), new { id = character.CharacterId }, characterDto);
    }

    // PUT api/character/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCharacter(int id, CharacterUpdateDto updateCharacterDto)
    {
        if (id != updateCharacterDto.CharacterId)
        {
            return BadRequest();
        }

        var character = _mapper.Map<Character>(updateCharacterDto);
        await _characterRepository.UpdateCharacterAsync(character);

        return NoContent();
    }

    // DELETE api/character/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCharacter(int id)
    {
        await _characterRepository.DeleteCharacterAsync(id);
        return NoContent();
    }
}
