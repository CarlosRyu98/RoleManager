namespace RoleManager.Infrastructure.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private readonly RoleManagerDbContext _context;

    public CharacterRepository(RoleManagerDbContext context)
    {
        _context = context;
    }

    public async Task<Character> GetCharacterByIdAsync(int id)
    {
        return await _context.Characters
            .Include(c => c.Allies)
            .Include(c => c.Rivals)
            .FirstOrDefaultAsync(c => c.CharacterId == id);
    }

    public async Task<IEnumerable<Character>> GetAllCharactersAsync()
    {
        return await _context.Characters
            .Include(c => c.Allies)
            .Include(c => c.Rivals)
            .ToListAsync();
    }

    public async Task AddCharacterAsync(Character character)
    {
        _context.Characters.Add(character);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCharacterAsync(Character character)
    {
        _context.Characters.Update(character);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCharacterAsync(int id)
    {
        var character = await _context.Characters.FindAsync(id);
        if (character != null)
        {
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }
    }
}
