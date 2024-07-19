using VehicleBidCalculator.Domain.Models;

namespace VehicleBidCalculator.Business.Services;

public interface IVehicleBidService
{
    /// <summary>
    /// Calculates Vehicle Bid.
    /// </summary>
    /// <param name="vehiclePrice">Vehicle Price.</param>
    /// <param name="vehicleType">Vehicle Type.</param>
    /// <returns>Vehicle Bid.</returns>
    VehicleBidCalculationResult CalculateVehicleBid(decimal vehiclePrice, VehicleType vehicleType);
}
