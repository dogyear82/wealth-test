using Wealth.Core.Domain;

namespace Wealth.Core.Application.Ports;

public interface IAssetRepository
{
    IQueryable<Asset> Query();
    Task<Asset?> GetByIdAsync(int id, CancellationToken ct = default);
}
