namespace VehicleBidCalculator.Domain.Models;

public readonly record struct VehicleBidCalculationResult(
    decimal VehiclePrice,
    VehicleType VehicleType,
    decimal BasicFee,
    decimal SpecialFee,
    decimal AssociationFee,
    decimal StorageFee,
    decimal Total);
