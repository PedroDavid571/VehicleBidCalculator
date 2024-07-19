using VehicleBidCalculator.Business.Helpers;
using VehicleBidCalculator.Domain.Models;

namespace VehicleBidCalculator.Business.Services;

public class VehicleBidService : IVehicleBidService
{
    public async Task<VehicleBidCalculationResult> CalculateVehicleBidAsync(decimal vehiclePrice, VehicleType vehicleType)
    {
        var normalizedVehiclePrice = Math.Round(vehiclePrice, 2);

        var basicFee = VehicleBidHelper.CalculateBasicFee(normalizedVehiclePrice, vehicleType);
        var specialFee = VehicleBidHelper.CalculateSpecialFee(normalizedVehiclePrice, vehicleType);
        var associateFee = VehicleBidHelper.CalculateAssociationFee(normalizedVehiclePrice);
        var storageFee = VehicleBidHelper.CalculateStorageFee();
        var total = vehiclePrice + basicFee + specialFee + associateFee + storageFee;

        var result = new VehicleBidCalculationResult
        {
            VehiclePrice = normalizedVehiclePrice,
            VehicleType = vehicleType,
            BasicFee = basicFee,
            SpecialFee = specialFee,
            AssociationFee = associateFee,
            StorageFee = storageFee,
            Total = total
        };

        return await Task.FromResult(result);
    }
}
