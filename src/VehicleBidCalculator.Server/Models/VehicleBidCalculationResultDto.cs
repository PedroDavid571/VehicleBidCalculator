namespace VehicleBidCalculator.Server.Models;

public class VehicleBidCalculationResultDto : VehicleBidCalculationDto
{
    public decimal BasicFee { get; set; }
    public decimal SpecialFee { get; set; }
    public decimal AssociationFee { get; set; }
    public decimal StorageFee { get; set; }
    public decimal Total { get; set; }
}
