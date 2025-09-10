using Wealth.Core.Domain;

namespace Wealth.Core.Application.Ports;

public interface IAssetBalanceRepository
{
    IQueryable<AssetBalance> Query();
}

