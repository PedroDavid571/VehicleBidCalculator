using System.Net;
using Microsoft.AspNetCore.Mvc;
using VehicleBidCalculator.Server.Models;

namespace VehicleBidCalculator.Server.Controllers;

[ApiController]
[Route("api/vehicle-bids")]
public class VehicleBidController : ControllerBase
{
    /// <summary>
    /// Calculates Vehicle Bid.
    /// </summary>
    /// <response code="200">Vehicle Bid Calculation result.</response>
    [HttpPost("calculation")]
    [ProducesResponseType(typeof(VehicleBidCalculationResultDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CalculateVehicleBidAsync([FromBody] VehicleBidCalculationDto vehicleBidCalculationDto)
    {
        var resultDto = await Task.FromResult(new VehicleBidCalculationResultDto
        {
            VehiclePrice = 12.34m,
            VehicleType = VehicleType.Luxury,
            BasicFee = 12.34m,
            SpecialFee = 12.34m,
            AssociationFee = 111.77m,
            StorageFee = 12.34m,
            Total = 571.33m
        });

        return Ok(resultDto);
    }
}
