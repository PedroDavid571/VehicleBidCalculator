using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VehicleBidCalculator.Business.Services;
using VehicleBidCalculator.Server.Models;

namespace VehicleBidCalculator.Server.Controllers;

[ApiController]
[Route("api/vehicle-bids")]
public class VehicleBidController(IMapper mapper,
    IVehicleBidService vehicleBidService) : ControllerBase
{
    /// <summary>
    /// Calculates Vehicle Bid.
    /// </summary>
    /// <response code="200">Vehicle Bid Calculation result.</response>
    [HttpPost("calculation")]
    [ProducesResponseType(typeof(VehicleBidCalculationResultDto), (int)HttpStatusCode.OK)]
    public IActionResult CalculateVehicleBid([FromBody] VehicleBidCalculationDto vehicleBidCalculationDto)
    {
        var vehicleBidCalculationResult = vehicleBidService.CalculateVehicleBid(vehicleBidCalculationDto.VehiclePrice,
            vehicleBidCalculationDto.VehicleType);

        var vehicleBidCalculationResultDto = mapper.Map<VehicleBidCalculationResultDto>(vehicleBidCalculationResult);

        return Ok(vehicleBidCalculationResultDto);
    }
}
