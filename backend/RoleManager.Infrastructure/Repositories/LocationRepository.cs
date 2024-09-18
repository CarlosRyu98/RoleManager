namespace RoleManager.Infrastructure.Repositories;

public class LocationRepository : ILocationRepository
{
    private readonly RoleManagerDbContext _context;

    public LocationRepository(RoleManagerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Location>> GetAllLocationsAsync()
    {
        return await _context.Locations
            .Include(l => l.Domain)
            .Include(l => l.Characters)
            .ToListAsync();
    }

    public async Task<Location?> GetLocationByIdAsync(int locationId)
    {
        return await _context.Locations
            .Include(l => l.Domain)
            .Include(l => l.Characters)
            .FirstOrDefaultAsync(l => l.LocationId == locationId);
    }

    public async Task<IEnumerable<Location>> GetLocationsByCampaignAsync(int campaignId)
    {
        return await _context.Locations
            .Where(l => l.CampaignId == campaignId)
            .Include(l => l.Domain)
            .Include(l => l.Characters)
            .ToListAsync();
    }

    public async Task<Location> CreateLocationAsync(Location location)
    {
        _context.Locations.Add(location);
        await _context.SaveChangesAsync();
        return location;
    }

    public async Task<bool> UpdateLocationAsync(Location location)
    {
        _context.Locations.Update(location);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteLocationAsync(int locationId)
    {
        var location = await _context.Locations.FindAsync(locationId);
        if (location == null)
        {
            return false;
        }

        _context.Locations.Remove(location);
        return await _context.SaveChangesAsync() > 0;
    }
}