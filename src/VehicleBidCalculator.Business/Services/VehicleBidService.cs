using VehicleBidCalculator.Business.Helpers;
using VehicleBidCalculator.Domain.Models;

namespace VehicleBidCalculator.Business.Services;

public class VehicleBidService : IVehicleBidService
{
    public VehicleBidCalculationResult CalculateVehicleBid(decimal vehiclePrice, VehicleType vehicleType)
    {
        var normalizedVehiclePrice = Math.Round(vehiclePrice, 2);

        var basicFee = VehicleBidHelper.CalculateBasicFee(normalizedVehiclePrice, vehicleType);
        var specialFee = VehicleBidHelper.CalculateSpecialFee(normalizedVehiclePrice, vehicleType);
        var associationFee = VehicleBidHelper.CalculateAssociationFee(normalizedVehiclePrice);
        var storageFee = VehicleBidHelper.CalculateStorageFee();
        var total = vehiclePrice + basicFee + specialFee + associationFee + storageFee;

        var result = new VehicleBidCalculationResult(
            vehiclePrice,
            vehicleType,
            basicFee, 
            specialFee,
            associationFee,
            storageFee, 
            total);

        return result;
    }
}
