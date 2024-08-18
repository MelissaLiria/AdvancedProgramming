using AutoMapper;
using GrpcProtos;

namespace GrpcService.Mappers
{
    public class FloorProfile : Profile
    {
        public FloorProfile()
        {

            //Para convertir de tipo de dato Floor a FloorDTO
            CreateMap<Domain.Entities.ConfigurationData.Floor, FloorDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.Location, o => o.MapFrom(s => s.Location))
                .ForMember(t => t.Building, o => o.MapFrom(s => s.Building))
                .ForMember(t => t.BuildingId, o => o.MapFrom(s => s.BuildingId.ToString()));

            //Para convertir de tipo de dato FloorDTO a Floor
            CreateMap<FloorDTO, Domain.Entities.ConfigurationData.Floor>()
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t => t.Location, o => o.MapFrom(s => s.Location))
                .ForMember(t => t.Building, o => o.MapFrom(s => s.Building))
                .ForMember(t => t.BuildingId, o => o.MapFrom(s => new Guid(s.BuildingId)));
        }
    }
}
