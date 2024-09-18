namespace RoleManager.Infrastructure.Repositories;

public class FactionRepository : IFactionRepository
{
    private readonly RoleManagerDbContext _context;

    public FactionRepository(RoleManagerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Faction>> GetAllFactionsAsync()
    {
        return await _context.Factions
            .Include(f => f.Members)
            .Include(f => f.Leader)
            .Include(f => f.Allies)
            .Include(f => f.Enemies)
            .ToListAsync();
    }

    public async Task<Faction?> GetFactionByIdAsync(int factionId)
    {
        return await _context.Factions
            .Include(f => f.Members)
            .Include(f => f.Leader)
            .Include(f => f.Allies)
            .Include(f => f.Enemies)
            .FirstOrDefaultAsync(f => f.FactionId == factionId);
    }

    public async Task<Faction> CreateFactionAsync(Faction faction)
    {
        _context.Factions.Add(faction);
        await _context.SaveChangesAsync();
        return faction;
    }

    public async Task<bool> UpdateFactionAsync(Faction faction)
    {
        _context.Factions.Update(faction);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteFactionAsync(int factionId)
    {
        var faction = await _context.Factions.FindAsync(factionId);
        if (faction == null)
        {
            return false;
        }

        _context.Factions.Remove(faction);
        return await _context.SaveChangesAsync() > 0;
    }
}