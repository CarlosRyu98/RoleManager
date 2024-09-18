namespace RoleManager.Infrastructure.Repositories;

public class DomainRepository : IDomainRepository
{
    private readonly RoleManagerDbContext _context;

    public DomainRepository(RoleManagerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Domain>> GetAllDomainsAsync()
    {
        return await _context.Domains.ToListAsync();
    }

    public async Task<Domain?> GetDomainByIdAsync(int domainId)
    {
        return await _context.Domains
            .Include(d => d.Locations)
            .Include(d => d.Characters)
            .Include(d => d.Factions)
            .FirstOrDefaultAsync(d => d.DomainId == domainId);
    }

    public async Task<IEnumerable<Domain>> GetDomainsByCampaignAsync(int campaignId)
    {
        return await _context.Domains
            .Where(d => d.CampaignId == campaignId)  // Filtra por CampaignId
            .ToListAsync();
    }

    public async Task<Domain> CreateDomainAsync(Domain domain)
    {
        _context.Domains.Add(domain);
        await _context.SaveChangesAsync();
        return domain;
    }

    public async Task<bool> UpdateDomainAsync(Domain domain)
    {
        _context.Domains.Update(domain);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteDomainAsync(int domainId)
    {
        var domain = await _context.Domains.FindAsync(domainId);
        if (domain == null)
        {
            return false;
        }

        _context.Domains.Remove(domain);
        return await _context.SaveChangesAsync() > 0;
    }
}