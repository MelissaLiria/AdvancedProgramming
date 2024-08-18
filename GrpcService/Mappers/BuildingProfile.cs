using AutoMapper;
using GrpcProtos;

namespace GrpcService.Mappers
{
    public class BuildingProfile : Profile
    {
        public BuildingProfile()
        {
            //Para convertir de tipo de dato Building a BuildingDTO
            CreateMap<Domain.Entities.ConfigurationData.Building, BuildingDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.Address, o => o.MapFrom(s => s.Address))
                .ForMember(t => t.Number, o => o.MapFrom(s => s.Number));

            //Para convertir de tipo de dato BuildingDTO a Building
            CreateMap<BuildingDTO, Domain.Entities.ConfigurationData.Building>()
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t => t.Address, o => o.MapFrom(s => s.Address))
                .ForMember(t => t.Number, o => o.MapFrom(s => s.Number));
        }
    }
}
