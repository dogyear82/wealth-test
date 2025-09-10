namespace Wealth.Core.Domain;

public class AssetRecord
{
    public string? AssetDescription { get; set; }
    public string? AssetId { get; set; }
    public AssetInfo? AssetInfo { get; set; }
    public string? AssetInfoType { get; set; }
    public string? AssetMask { get; set; }
    public string? AssetName { get; set; }
    public string? AssetOwnerName { get; set; }
    public DateTime? BalanceAsOf { get; set; }
    public decimal? BalanceCostBasis { get; set; }
    public string? BalanceCostFrom { get; set; }
    public decimal? BalanceCurrent { get; set; }
    public string? BalanceFrom { get; set; }
    public decimal? BalancePrice { get; set; }
    public string? BalancePriceFrom { get; set; }
    public decimal? BalanceQuantityCurrent { get; set; }
    public string? BeneficiaryComposition { get; set; }
    public string? CognitoId { get; set; }
    public DateTime? CreationDate { get; set; }
    public string? CurrencyCode { get; set; }
    public string? DeactivateBy { get; set; }
    public string? DescriptionEstatePlan { get; set; }
    public bool? HasInvestment { get; set; }
    public Holdings? Holdings { get; set; }
    public bool? IncludeInNetWorth { get; set; }
    public int? InstitutionId { get; set; }
    public string? InstitutionName { get; set; }
    public string? Integration { get; set; }
    public string? IntegrationAccountId { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsAsset { get; set; }
    public bool? IsFavorite { get; set; }
    public bool? IsLinkedVendor { get; set; }
    public DateTime? LastUpdate { get; set; }
    public DateTime? LastUpdateAttempt { get; set; }
    public string? LogoName { get; set; }
    public DateTime? ModificationDate { get; set; }
    public DateTime? NextUpdate { get; set; }
    public string? Nickname { get; set; }
    public string? Note { get; set; }
    public DateTime? NoteDate { get; set; }
    public string? Ownership { get; set; }
    public string? PrimaryAssetCategory { get; set; }
    public string? Status { get; set; }
    public string? StatusCode { get; set; }
    public string? UserInstitutionId { get; set; }
    public string? VendorAccountType { get; set; }
    public string? VendorContainer { get; set; }
    public string? VendorResponse { get; set; }
    public string? VendorResponseType { get; set; }
    public string? WealthAssetType { get; set; }
    public string? Wid { get; set; }
}

public class AssetInfo
{
    public string? Nickname { get; set; }
    public string? DescriptionEstatePlan { get; set; }
    public decimal? EstimateValue { get; set; }
    public decimal? PurchaseCost { get; set; }
    public DateTime? AsOfDate { get; set; }
    public bool? IsFavorite { get; set; }
    // Crypto fields
    public string? Slug { get; set; }
    public string? Symbol { get; set; }
    public string? CryptocurrencyName { get; set; }
    public decimal? Quantity { get; set; }
    // Vehicle fields
    public int? ManualAddType { get; set; }
    public int? ModelYear { get; set; }
    // Real estate/address fields
    public string? StreetAddress { get; set; }
    public string? StreetAddress2 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? CountryCode { get; set; }
    public bool? UseZillow { get; set; }
    public string? Neighborhood { get; set; }
    public Holdings? Holdings { get; set; }
}

public class Holdings
{
    public List<MajorAssetClass> MajorAssetClasses { get; set; } = new();
}

public class MajorAssetClass
{
    public string? MajorClass { get; set; }
    public List<AssetClass> AssetClasses { get; set; } = new();
}

public class AssetClass
{
    public string? MinorAssetClass { get; set; }
    public decimal? Value { get; set; }
}
