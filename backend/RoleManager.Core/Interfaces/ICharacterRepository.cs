namespace RoleManager.Core.Interfaces;

public interface ICharacterRepository
{
    Task<Character> GetCharacterByIdAsync(int id);

    Task<IEnumerable<Character>> GetAllCharactersAsync();

    Task AddCharacterAsync(Character character);

    Task UpdateCharacterAsync(Character character);

    Task DeleteCharacterAsync(int id);
}