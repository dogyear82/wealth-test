using Wealth.Core.Domain;

namespace Wealth.Core.Application.Ports;

public interface IAssetRecordRepository
{
    IQueryable<AssetRecord> Query();
}

