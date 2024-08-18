using AutoMapper;

namespace GrpcService.Mappers
{
    public class SampleBoolProfile : Profile
    {
        public SampleBoolProfile()
        {
            CreateMap<Domain.Entities.HistoricalData.SampleBool,
                GrpcProtos.SampleBoolDTO>()
                .ForMember(t => t.VariableId, o => o.MapFrom(s => s.VariableId.ToString()))
                .ForMember(t => t.Value, o => o.MapFrom(s => s.Value))
                .ForMember(t => t.DateTime, o => o.MapFrom(s => s.DateTime.ToString()));

            CreateMap<GrpcProtos.SampleBoolDTO,
                Domain.Entities.HistoricalData.SampleBool>()
                .ForMember(t => t.VariableId, o => o.MapFrom(s => new Guid(s.VariableId)))
                .ForMember(t => t.Value, o => o.MapFrom(s => s.Value))
                .ForMember(t => t.DateTime, o => o.MapFrom(s => DateTime.Parse(s.DateTime)));
        }
    }
}
