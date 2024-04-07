using AutoMapper;
using RS.Parking.Application.DTOs;
using RS.Parking.Domain.Models;

namespace RS.Parking.Application;

public class AutomapperProfile : Profile
{
	public AutomapperProfile()
	{
		CreateMap<VehicleType, VehicleTypeDTO>().ReverseMap();
		CreateMap<AccordType, AccordTypeDTO>().ReverseMap();
		CreateMap<ControlInOut, ControlInOutDTO>().ReverseMap();
	}
}
