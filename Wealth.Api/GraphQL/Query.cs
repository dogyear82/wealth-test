using HotChocolate;
using HotChocolate.Data;
using Wealth.Core.Application.Ports;
using Wealth.Core.Application.UseCases;
using AssetSnapshotDto = Wealth.Core.Application.UseCases.AssetSnapshot;

namespace Wealth.Api.GraphQL;

public class Query
{
    [UseFiltering]
    [UseSorting]
    public IQueryable<AssetSnapshotDto> AssetsAsOf([Service] IAssetRecordRepository records, DateTime asOf)
        => new GetAssetsAsOfFromRecords(records).BuildQuery(asOf);
}
