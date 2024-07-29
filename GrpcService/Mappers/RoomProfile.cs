using AutoMapper;
using GrpcProtos;

namespace GrpcService.Mappers
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            //Para convertir de tipo de dato Room a RoomDTO
            CreateMap<Domain.Entities.ConfigurationData.Room, RoomDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.Number, o => o.MapFrom(s => s.Number))
                .ForMember(t => t.IsProduction, o => o.MapFrom(s => s.IsProduction))
                .ForMember(t => t.Description, o => o.MapFrom(s => s.Description))
                .ForMember(t => t.Floor, o => o.MapFrom(s => s.Floor))
                .ForMember(t => t.FloorId, o => o.MapFrom(s => s.FloorId.ToString()));

            //Para convertir de tipo de dato RoomDTO a Room
            CreateMap<RoomDTO, Domain.Entities.ConfigurationData.Room>()
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t => t.Number, o => o.MapFrom(s => s.Number))
                .ForMember(t => t.IsProduction, o => o.MapFrom(s => s.IsProduction))
                .ForMember(t => t.Description, o => o.MapFrom(s => s.Description))
                .ForMember(t => t.Floor, o => o.MapFrom(s => s.Floor))
                .ForMember(t => t.FloorId, o => o.MapFrom(s => new Guid(s.FloorId)));
        }



    }
}
