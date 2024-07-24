using AutoMapper;
using EnvironmentalVariablesDAQ.GrpcProtos;

namespace GrpcService.Mappers
{
    public class VariableProfile : Profile
    {
        public VariableProfile()
        {
            CreateMap<Domain.Entities.ConfigurationData.Variable, VariableDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.VariableType, o => o.MapFrom(s => new VariableType()
                {
                    Name = s.VariableType.Name,
                    MeasurementUnit = s.VariableType.MeasurementUnit
                }))
                .ForMember(t => t.Code, o => o.MapFrom(s => s.Code))
                .ForMember(t => t.LocationId, o => o.MapFrom(s => s.LocationId.ToString()));
                
                

      
        }
    }
}
