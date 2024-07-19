using VehicleBidCalculator.Domain.Models;

namespace VehicleBidCalculator.Server.Models;

public readonly record struct VehicleBidCalculationResultDto(
    decimal VehiclePrice,
    VehicleType VehicleType,
    decimal BasicFee,
    decimal SpecialFee,
    decimal AssociationFee,
    decimal StorageFee,
    decimal Total);
