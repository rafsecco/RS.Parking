using AutoMapper;
using AutoMapper.Execution;
using RS.Parking.Application.DTOs;
using RS.Parking.Domain.Models;

namespace RS.Parking.Application;

public class AutomapperProfile : Profile
{
	public AutomapperProfile()
	{
		CreateMap<VehicleType, VehicleTypeDTO>().ReverseMap();
		CreateMap<AccordType, AccordTypeDTO>().ReverseMap();
		CreateMap<ControlInOut, ControlInOutDTO>()
			//.ForMember(dto => dto.Price, opt => opt.MapFrom<PriceResolver>())
			.ForMember(dto => dto.Price, opt => opt.MapFrom(src => src.CalculatePrice()))
			.ReverseMap();
	}
}

//public class PriceResolver : IValueResolver<ControlInOut, ControlInOutDTO, string>
//{
//	public string Resolve(ControlInOut source, ControlInOutDTO destination, string destMember, ResolutionContext context)
//	{
//		var result = source.CalculatePrice();
//		return result;
//	}
//}
