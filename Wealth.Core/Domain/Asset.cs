namespace Wealth.Core.Domain;

public class Asset
{
    public int Id { get; set; }
    public string? AssetExternalId { get; set; }
    public string? Nickname { get; set; }
    public string? WealthAssetType { get; set; }
    public string? PrimaryAssetCategory { get; set; }
    public string? AssetInfoRaw { get; set; }
    public string? AssetInfoType { get; set; }
    public string? CognitoId { get; set; }
    public string? Wid { get; set; }
    public int? InstitutionId { get; set; }
    public bool? IncludeInNetWorth { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? CreationDate { get; set; }
    public DateTime? ModificationDate { get; set; }
    public DateTime? LastUpdate { get; set; }

    public List<AssetBalance> Balances { get; set; } = new();
}

