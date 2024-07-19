using VehicleBidCalculator.Domain.Models;

namespace VehicleBidCalculator.Business.Services;

public class VehicleBidService : IVehicleBidService
{
    public async Task<VehicleBidCalculationResult> CalculateVehicleBidAsync(decimal vehiclePrice, VehicleType vehicleType)
    {
        var result = new VehicleBidCalculationResult
        {
            VehiclePrice = 12.34m,
            VehicleType = VehicleType.Luxury,
            BasicFee = 12.34m,
            SpecialFee = 12.34m,
            AssociationFee = 111.77m,
            StorageFee = 12.34m,
            Total = 571.33m
        };

        return await Task.FromResult(result);
    }
}
