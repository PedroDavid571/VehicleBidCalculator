namespace VehicleBidCalculator.Domain.Models;

public class VehicleBidCalculationResult
{
    public decimal VehiclePrice { get; set; }
    public VehicleType VehicleType { get; set; }
    public decimal BasicFee { get; set; }
    public decimal SpecialFee { get; set; }
    public decimal AssociationFee { get; set; }
    public decimal StorageFee { get; set; }
    public decimal Total { get; set; }
}
