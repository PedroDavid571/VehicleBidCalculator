using VehicleBidCalculator.Domain.Models;

namespace VehicleBidCalculator.Server.Models;

public readonly record struct VehicleBidCalculationDto(
    decimal VehiclePrice,
    VehicleType VehicleType);