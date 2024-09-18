namespace RoleManager.Infrastructure.Repositories;

public class CampaignRepository : ICampaignRepository
{
    private readonly RoleManagerDbContext _context;

    public CampaignRepository(RoleManagerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Campaign>> GetAllCampaignsAsync()
    {
        return await _context.Campaigns.ToListAsync();
    }

    public async Task<Campaign?> GetCampaignByIdAsync(int id)
    {
        return await _context.Campaigns
            .Include(c => c.Characters)
            .Include(c => c.Factions)
            .Include(c => c.Domains)
            .Include(c => c.Locations)
            .Include(c => c.Quests)
            .FirstOrDefaultAsync(c => c.CampaignId == id);
    }

    public async Task AddCampaignAsync(Campaign campaign)
    {
        await _context.Campaigns.AddAsync(campaign);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateCampaignAsync(Campaign campaign)
    {
        var existingCampaign = await _context.Campaigns.FindAsync(campaign.CampaignId);
        if (existingCampaign == null)
        {
            return false;
        }

        _context.Entry(existingCampaign).CurrentValues.SetValues(campaign);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteCampaignAsync(int id)
    {
        var campaign = await _context.Campaigns.FindAsync(id);
        if (campaign == null)
        {
            return false;
        }

        _context.Campaigns.Remove(campaign);
        await _context.SaveChangesAsync();
        return true;
    }
}