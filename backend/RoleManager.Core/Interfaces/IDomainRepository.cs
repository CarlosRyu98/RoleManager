namespace RoleManager.Core.Interfaces;

public interface IDomainRepository
{
    Task<IEnumerable<Domain>> GetAllDomainsAsync();

    Task<Domain?> GetDomainByIdAsync(int domainId);

    Task<IEnumerable<Domain>> GetDomainsByCampaignAsync(int campaignId);

    Task<Domain> CreateDomainAsync(Domain domain);

    Task<bool> UpdateDomainAsync(Domain domain);

    Task<bool> DeleteDomainAsync(int domainId);
}