namespace Wealth.Core.Domain;

public class AssetBalance
{
    public int Id { get; set; }
    public int AssetId { get; set; }
    public DateTime BalanceAsOf { get; set; }
    public decimal Balance { get; set; }
    public decimal? BalanceCostBasis { get; set; }
    public string? BalanceCostFrom { get; set; }
    public string? BalanceFrom { get; set; }
    public decimal? BalancePrice { get; set; }
    public string? BalancePriceFrom { get; set; }
    public decimal? BalanceQuantityCurrent { get; set; }
}

