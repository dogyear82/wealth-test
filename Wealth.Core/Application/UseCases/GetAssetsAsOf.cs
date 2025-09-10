using Wealth.Core.Application.Ports;

namespace Wealth.Core.Application.UseCases;

public class GetAssetsAsOf
{
    private readonly IAssetRepository _assets;
    private readonly IAssetBalanceRepository _balances;

    public GetAssetsAsOf(IAssetRepository assets, IAssetBalanceRepository balances)
    {
        _assets = assets;
        _balances = balances;
    }

    public IQueryable<AssetSnapshot> BuildQuery(DateTime asOf)
    {
        var maxDatesQuery = _balances.Query()
            .Where(b => b.BalanceAsOf <= asOf)
            .GroupBy(b => b.AssetId)
            .Select(g => new { AssetId = g.Key, MaxDate = g.Max(b => b.BalanceAsOf) });

        var query = from b in _balances.Query()
                    join md in maxDatesQuery
                        on new { b.AssetId, b.BalanceAsOf } equals new { md.AssetId, BalanceAsOf = md.MaxDate }
                    join a in _assets.Query() on b.AssetId equals a.Id
                    select new AssetSnapshot
                    {
                        AssetDbId = a.Id,
                        AssetExternalId = a.AssetExternalId,
                        Nickname = a.Nickname,
                        WealthAssetType = a.WealthAssetType,
                        PrimaryAssetCategory = a.PrimaryAssetCategory,
                        BalanceAsOf = b.BalanceAsOf,
                        Balance = b.Balance
                    };

        return query.OrderBy(x => x.Nickname);
    }
}

public class AssetSnapshot
{
    public int AssetDbId { get; set; }
    public string? AssetExternalId { get; set; }
    public string? Nickname { get; set; }
    public string? WealthAssetType { get; set; }
    public string? PrimaryAssetCategory { get; set; }
    public DateTime BalanceAsOf { get; set; }
    public decimal Balance { get; set; }
}
