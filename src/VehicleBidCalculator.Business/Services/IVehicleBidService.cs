using VehicleBidCalculator.Domain.Models;

namespace VehicleBidCalculator.Business.Services;

public interface IVehicleBidService
{
    Task<VehicleBidCalculationResult> CalculateVehicleBidAsync(decimal vehiclePrice, VehicleType vehicleType);
}
