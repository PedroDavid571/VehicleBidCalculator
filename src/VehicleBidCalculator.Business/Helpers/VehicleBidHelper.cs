using VehicleBidCalculator.Domain.Models;

namespace VehicleBidCalculator.Business.Helpers;

public static class VehicleBidHelper
{
    private const int RoundFractionDigits = 2;

    private const int BasicFeeDefaultPercent = 10;
    private const decimal BasicFeeCommonLowerLimit = 10m;
    private const decimal BasicFeeCommonUpperLimit = 50m;
    private const decimal BasicFeeLuxuryLowerLimit = 25m;
    private const decimal BasicFeeLuxuryUpperLimit = 200m;

    private const int SpecialFeeCommonPercent = 2;
    private const int SpecialFeeLuxuryPercent = 4;

    private const decimal AssociationFeeLowerLimitFirstTier = 0m;
    private const decimal AssociationFeeUpperLimitFirstTier = 500m;
    private const decimal AssociationFeeDefaultFirstTier = 5m;
    private const decimal AssociationFeeUpperLimitSecondTier = 1000m;
    private const decimal AssociationFeeDefaultSecondTier = 10m;
    private const decimal AssociationFeeUpperLimitThirdTier = 3000m;
    private const decimal AssociationFeeDefaultThirdTier = 15m;
    private const decimal AssociationFeeDefaultFourthTier = 20m;

    public static decimal CalculateBasicFee(decimal vehiclePrice, VehicleType vehicleType)
    {
        var vehiclePriceTenPercent = GetPercent(vehiclePrice, BasicFeeDefaultPercent);

        var basicFee = vehicleType switch
        {
            VehicleType.Common => vehiclePriceTenPercent < BasicFeeCommonLowerLimit
                ? BasicFeeCommonLowerLimit
                : (vehiclePriceTenPercent > BasicFeeCommonUpperLimit 
                    ? BasicFeeCommonUpperLimit 
                    : vehiclePriceTenPercent),
            VehicleType.Luxury => vehiclePriceTenPercent < BasicFeeLuxuryLowerLimit
                ? BasicFeeLuxuryLowerLimit
                : (vehiclePriceTenPercent > BasicFeeLuxuryUpperLimit 
                    ? BasicFeeLuxuryUpperLimit 
                    : vehiclePriceTenPercent),
            _ => vehiclePriceTenPercent
        };

        return basicFee;
    }

    public static decimal CalculateSpecialFee(decimal vehiclePrice, VehicleType vehicleType)
    {
        var specialFee = vehicleType switch
        {
            VehicleType.Common => GetPercent(vehiclePrice, SpecialFeeCommonPercent),
            VehicleType.Luxury => GetPercent(vehiclePrice, SpecialFeeLuxuryPercent),
            _ => 0m
        };

        return specialFee;
    }

    public static decimal CalculateAssociationFee(decimal vehiclePrice)
    {
        var associationFee = vehiclePrice is > AssociationFeeLowerLimitFirstTier and <= AssociationFeeUpperLimitFirstTier
            ? AssociationFeeDefaultFirstTier
            : (vehiclePrice is > AssociationFeeLowerLimitFirstTier and <= AssociationFeeUpperLimitSecondTier
                ? AssociationFeeDefaultSecondTier
                : (vehiclePrice is > AssociationFeeUpperLimitSecondTier and <= AssociationFeeUpperLimitThirdTier
                    ? AssociationFeeDefaultThirdTier
                    : AssociationFeeDefaultFourthTier));

        return associationFee;
    }

    public static decimal CalculateStorageFee() => 100m;

    private static decimal GetPercent(decimal value, int percent)
    {
        var percentValue = (value * percent) / 100;

        var result = Math.Round(percentValue, RoundFractionDigits);

        return result;
    }
}
