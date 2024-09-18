namespace RoleManager.Core.Interfaces;

public interface IFactionRepository
{
    Task<IEnumerable<Faction>> GetAllFactionsAsync();

    Task<Faction?> GetFactionByIdAsync(int factionId);

    Task<Faction> CreateFactionAsync(Faction faction);

    Task<bool> UpdateFactionAsync(Faction faction);

    Task<bool> DeleteFactionAsync(int factionId);
}