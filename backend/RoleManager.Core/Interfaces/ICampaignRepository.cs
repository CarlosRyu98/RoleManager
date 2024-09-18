namespace RoleManager.Core.Interfaces;

public interface ICampaignRepository
{
    Task<IEnumerable<Campaign>> GetAllCampaignsAsync();

    Task<Campaign?> GetCampaignByIdAsync(int id);

    Task AddCampaignAsync(Campaign campaign);

    Task<bool> UpdateCampaignAsync(Campaign campaign);

    Task<bool> DeleteCampaignAsync(int id);
}