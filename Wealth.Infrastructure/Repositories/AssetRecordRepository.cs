using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Wealth.Core.Application.Ports;
using Wealth.Core.Domain;

namespace Wealth.Infrastructure.Repositories;

public class AssetRecordRepository : IAssetRecordRepository
{
    private readonly IMongoCollection<AssetRecordDocument> _collection;

    public AssetRecordRepository(IMongoDatabase db)
    {
        _collection = db.GetCollection<AssetRecordDocument>("asset_records");
    }

    public IQueryable<AssetRecord> Query()
    {
        // Project documents to domain type to keep core decoupled
        return _collection.AsQueryable().Select(d => new AssetRecord
        {
            AssetDescription = d.assetDescription,
            AssetId = d.assetId,
            AssetInfoType = d.assetInfoType,
            AssetMask = d.assetMask,
            AssetName = d.assetName,
            AssetOwnerName = d.assetOwnerName,
            BalanceAsOf = d.balanceAsOf,
            BalanceCostBasis = d.balanceCostBasis,
            BalanceCostFrom = d.balanceCostFrom,
            BalanceCurrent = d.balanceCurrent,
            BalanceFrom = d.balanceFrom,
            BalancePrice = d.balancePrice,
            BalancePriceFrom = d.balancePriceFrom,
            BalanceQuantityCurrent = d.balanceQuantityCurrent,
            BeneficiaryComposition = d.beneficiaryComposition,
            CognitoId = d.cognitoId,
            CreationDate = d.creationDate,
            CurrencyCode = d.currencyCode,
            DeactivateBy = d.deactivateBy,
            DescriptionEstatePlan = d.descriptionEstatePlan,
            HasInvestment = d.hasInvestment,
            IncludeInNetWorth = d.includeInNetWorth,
            InstitutionId = d.institutionId,
            InstitutionName = d.institutionName,
            Integration = d.integration,
            IntegrationAccountId = d.integrationAccountId,
            IsActive = d.isActive,
            IsAsset = d.isAsset,
            IsFavorite = d.isFavorite,
            IsLinkedVendor = d.isLinkedVendor,
            LastUpdate = d.lastUpdate,
            LastUpdateAttempt = d.lastUpdateAttempt,
            LogoName = d.logoName,
            ModificationDate = d.modificationDate,
            NextUpdate = d.nextUpdate,
            Nickname = d.nickname,
            Note = d.note,
            NoteDate = d.noteDate,
            Ownership = d.ownership,
            PrimaryAssetCategory = d.primaryAssetCategory,
            Status = d.status,
            StatusCode = d.statusCode,
            UserInstitutionId = d.userInstitutionId,
            VendorAccountType = d.vendorAccountType,
            VendorContainer = d.vendorContainer,
            VendorResponse = d.vendorResponse,
            VendorResponseType = d.vendorResponseType,
            WealthAssetType = d.wealthAssetType,
            Wid = d.wid,
            AssetInfo = d.assetInfo == null ? null : new Wealth.Core.Domain.AssetInfo
            {
                Nickname = d.assetInfo.nickname,
                DescriptionEstatePlan = d.assetInfo.descriptionEstatePlan,
                EstimateValue = d.assetInfo.estimateValue,
                PurchaseCost = d.assetInfo.purchaseCost,
                AsOfDate = d.assetInfo.asOfDate,
                IsFavorite = d.assetInfo.isFavorite,
                Slug = d.assetInfo.slug,
                Symbol = d.assetInfo.symbol,
                CryptocurrencyName = d.assetInfo.cryptocurrencyName,
                Quantity = d.assetInfo.quantity,
                ManualAddType = d.assetInfo.manualAddType,
                ModelYear = d.assetInfo.modelYear,
                StreetAddress = d.assetInfo.streetAddress,
                StreetAddress2 = d.assetInfo.streetAddress2,
                City = d.assetInfo.city,
                State = d.assetInfo.state,
                ZipCode = d.assetInfo.zipCode,
                CountryCode = d.assetInfo.countryCode,
                UseZillow = d.assetInfo.useZillow,
                Neighborhood = d.assetInfo.neighborhood,
                Holdings = d.assetInfo.holdings == null ? null : new Wealth.Core.Domain.Holdings
                {
                    MajorAssetClasses = d.assetInfo.holdings.majorAssetClasses.Select(mac => new Wealth.Core.Domain.MajorAssetClass
                    {
                        MajorClass = mac.majorClass,
                        AssetClasses = mac.assetClasses.Select(ac => new Wealth.Core.Domain.AssetClass
                        {
                            MinorAssetClass = ac.minorAssetClass,
                            Value = ac.value
                        }).ToList()
                    }).ToList()
                }
            },
            Holdings = d.holdings == null ? null : new Wealth.Core.Domain.Holdings
            {
                MajorAssetClasses = d.holdings.majorAssetClasses.Select(mac => new Wealth.Core.Domain.MajorAssetClass
                {
                    MajorClass = mac.majorClass,
                    AssetClasses = mac.assetClasses.Select(ac => new Wealth.Core.Domain.AssetClass
                    {
                        MinorAssetClass = ac.minorAssetClass,
                        Value = ac.value
                    }).ToList()
                }).ToList()
            }
        });
    }

    private class AssetRecordDocument
    {
        public string? assetDescription { get; set; }
        public string? assetId { get; set; }
        public AssetInfoDocument? assetInfo { get; set; }
        public string? assetInfoType { get; set; }
        public string? assetMask { get; set; }
        public string? assetName { get; set; }
        public string? assetOwnerName { get; set; }
        public DateTime? balanceAsOf { get; set; }
        public decimal? balanceCostBasis { get; set; }
        public string? balanceCostFrom { get; set; }
        public decimal? balanceCurrent { get; set; }
        public string? balanceFrom { get; set; }
        public decimal? balancePrice { get; set; }
        public string? balancePriceFrom { get; set; }
        public decimal? balanceQuantityCurrent { get; set; }
        public string? beneficiaryComposition { get; set; }
        public string? cognitoId { get; set; }
        public DateTime? creationDate { get; set; }
        public string? currencyCode { get; set; }
        public string? deactivateBy { get; set; }
        public string? descriptionEstatePlan { get; set; }
        public bool? hasInvestment { get; set; }
        public HoldingsDocument? holdings { get; set; }
        public bool? includeInNetWorth { get; set; }
        public int? institutionId { get; set; }
        public string? institutionName { get; set; }
        public string? integration { get; set; }
        public string? integrationAccountId { get; set; }
        public bool? isActive { get; set; }
        public bool? isAsset { get; set; }
        public bool? isFavorite { get; set; }
        public bool? isLinkedVendor { get; set; }
        public DateTime? lastUpdate { get; set; }
        public DateTime? lastUpdateAttempt { get; set; }
        public string? logoName { get; set; }
        public DateTime? modificationDate { get; set; }
        public DateTime? nextUpdate { get; set; }
        public string? nickname { get; set; }
        public string? note { get; set; }
        public DateTime? noteDate { get; set; }
        public string? ownership { get; set; }
        public string? primaryAssetCategory { get; set; }
        public string? status { get; set; }
        public string? statusCode { get; set; }
        public string? userInstitutionId { get; set; }
        public string? vendorAccountType { get; set; }
        public string? vendorContainer { get; set; }
        public string? vendorResponse { get; set; }
        public string? vendorResponseType { get; set; }
        public string? wealthAssetType { get; set; }
        public string? wid { get; set; }
    }

    private class AssetInfoDocument
    {
        public string? nickname { get; set; }
        public string? descriptionEstatePlan { get; set; }
        public decimal? estimateValue { get; set; }
        public decimal? purchaseCost { get; set; }
        public DateTime? asOfDate { get; set; }
        public bool? isFavorite { get; set; }
        // Crypto
        public string? slug { get; set; }
        public string? symbol { get; set; }
        public string? cryptocurrencyName { get; set; }
        public decimal? quantity { get; set; }
        // Vehicle
        public int? manualAddType { get; set; }
        public int? modelYear { get; set; }
        // Real estate
        public string? streetAddress { get; set; }
        public string? streetAddress2 { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? zipCode { get; set; }
        public string? countryCode { get; set; }
        public bool? useZillow { get; set; }
        public string? neighborhood { get; set; }
        public HoldingsDocument? holdings { get; set; }
    }

    private class HoldingsDocument
    {
        public List<MajorAssetClassDocument> majorAssetClasses { get; set; } = new();
    }

    private class MajorAssetClassDocument
    {
        public string? majorClass { get; set; }
        public List<AssetClassDocument> assetClasses { get; set; } = new();
    }

    private class AssetClassDocument
    {
        public string? minorAssetClass { get; set; }
        public decimal? value { get; set; }
    }
}
