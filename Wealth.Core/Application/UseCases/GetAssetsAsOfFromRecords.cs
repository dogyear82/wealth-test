using Wealth.Core.Application.Ports;
using Wealth.Core.Domain;

namespace Wealth.Core.Application.UseCases;

public class GetAssetsAsOfFromRecords
{
    private readonly IAssetRecordRepository _records;

    public GetAssetsAsOfFromRecords(IAssetRecordRepository records)
    {
        _records = records;
    }

    public IQueryable<AssetSnapshot> BuildQuery(DateTime asOf)
    {
        var latestPerAsset = _records.Query()
            .Where(r => r.BalanceAsOf != null && r.BalanceAsOf <= asOf)
            .OrderBy(r => r.AssetId)
            .ThenByDescending(r => r.BalanceAsOf)
            .GroupBy(r => r.AssetId)
            .Select(g => g.First());

        var query = latestPerAsset.Select(latest => new AssetSnapshot
        {
            AssetDbId = 0,
            AssetExternalId = latest.AssetId,
            Nickname = latest.Nickname ?? (latest.AssetInfo != null ? latest.AssetInfo.Nickname : null),
            WealthAssetType = latest.WealthAssetType,
            PrimaryAssetCategory = latest.PrimaryAssetCategory,
            BalanceAsOf = latest.BalanceAsOf ?? default,
            Balance = latest.BalanceCurrent ?? 0m
        });

        return query.OrderBy(x => x.Nickname);
    }
}
