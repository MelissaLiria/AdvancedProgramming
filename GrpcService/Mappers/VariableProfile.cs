using AutoMapper;
using GrpcProtos;

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
                .ForMember(t => t.LocationId, o => o.MapFrom(s => s.LocationId.ToString()))
                .ForMember(t => t.Building, o => o.MapFrom(
                    s => s.Location is Domain.Entities.ConfigurationData.Building ? s.Location as Domain.Entities.ConfigurationData.Building : null))
                .ForMember(t => t.Floor, o => o.MapFrom(
                    s => s.Location is Domain.Entities.ConfigurationData.Floor ? s.Location as Domain.Entities.ConfigurationData.Floor : null))
                .ForMember(t => t.Room, o => o.MapFrom(
                    s => s.Location is Domain.Entities.ConfigurationData.Room ? s.Location as Domain.Entities.ConfigurationData.Room : null));


            CreateMap<VariableDTO, Domain.Entities.ConfigurationData.Variable>()
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t => t.VariableType, o => o.MapFrom(s => new Domain.ValueObjects.VariableType(s.VariableType.Name, s.VariableType.MeasurementUnit)))
                .ForMember(t => t.Code, o => o.MapFrom(s => s.Code))
                .ForMember(t => t.LocationId, o => o.MapFrom(s => new Guid(s.LocationId)))
                .ForMember(t => t.Location, o =>
                {
                    o.Condition(s => s.LocationCase == VariableDTO.LocationOneofCase.Building);
                    o.MapFrom(s => s.Building);
                })
                .ForMember(t => t.Location, o =>
                {
                    o.Condition(s => s.LocationCase == VariableDTO.LocationOneofCase.Floor);
                    o.MapFrom(s => s.Floor);
                })
                .ForMember(t => t.Location, o =>
                {
                    o.Condition(s => s.LocationCase == VariableDTO.LocationOneofCase.Room);
                    o.MapFrom(s => s.Room);
                });



        }
    }

}
