using AutoMapper;
using VehicleBidCalculator.Domain.Models;
using VehicleBidCalculator.Server.Models;

namespace VehicleBidCalculator.Server.Mappings;

public class CommonProfile : Profile
{
    public CommonProfile()
    {
        CreateMap<VehicleBidCalculationResult, VehicleBidCalculationResultDto>();
    }
}
