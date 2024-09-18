namespace RoleManager.Core.Interfaces;

public interface ILocationRepository
{
    Task<IEnumerable<Location>> GetAllLocationsAsync();

    Task<Location?> GetLocationByIdAsync(int locationId);

    Task<Location> CreateLocationAsync(Location location);

    Task<bool> UpdateLocationAsync(Location location);

    Task<bool> DeleteLocationAsync(int locationId);
}