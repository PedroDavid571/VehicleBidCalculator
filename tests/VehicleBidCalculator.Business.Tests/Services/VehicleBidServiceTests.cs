using FluentAssertions;
using VehicleBidCalculator.Business.Services;
using VehicleBidCalculator.Domain.Models;
using Xunit;

namespace VehicleBidCalculator.Business.Tests.Services;

public class VehicleBidServiceTests
{
    private readonly VehicleBidService _vehicleBidService = new();

    [Theory]
    [InlineData("398.00", VehicleType.Common, "39.80", "7.96", 
        "5.00", "100.00", "550.76")]
    [InlineData("501.00", VehicleType.Common, "50.00", "10.02", 
        "10.00", "100.00", "671.02")]
    [InlineData("57.00", VehicleType.Common, "10.00", "1.14", 
        "5.00", "100.00", "173.14")]
    [InlineData("1800.00", VehicleType.Luxury, "180.00", "72.00",
        "15.00", "100.00", "2167.00")]
    [InlineData("1100.00", VehicleType.Common, "50.00", "22.00",
        "15.00", "100.00", "1287.00")]
    [InlineData("1000000.00", VehicleType.Luxury, "200.00", "40000",
        "20.00", "100.00", "1040320.00")]
    public void CalculateVehicleBid_WhenCalledWithPriceAndType_ReturnsCalculatedVehicleBid(
        string vehiclePrice, VehicleType vehicleType, string expectedBasicFee, string expectedSpecialFee,
        string expectedAssociationFee, string expectedStorageFee, string expectedTotal)
    {
        // Arrange and Act
        var vehicleBidCalculation = _vehicleBidService.CalculateVehicleBid(
            decimal.Parse(vehiclePrice), vehicleType);

        // Assert
        vehicleBidCalculation.VehiclePrice.Should().Be(decimal.Parse(vehiclePrice));
        vehicleBidCalculation.VehicleType.Should().Be(vehicleType);
        vehicleBidCalculation.BasicFee.Should().Be(decimal.Parse(expectedBasicFee));
        vehicleBidCalculation.SpecialFee.Should().Be(decimal.Parse(expectedSpecialFee));
        vehicleBidCalculation.AssociationFee.Should().Be(decimal.Parse(expectedAssociationFee));
        vehicleBidCalculation.StorageFee.Should().Be(decimal.Parse(expectedStorageFee));
        vehicleBidCalculation.Total.Should().Be(decimal.Parse(expectedTotal));
    }
}
