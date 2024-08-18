using AutoMapper;

namespace GrpcService.Mappers
{
    public class SampleIntProfile : Profile
    {
        public SampleIntProfile()
        {
            CreateMap<Domain.Entities.HistoricalData.SampleInt,
                GrpcProtos.SampleIntDTO>()
                .ForMember(t => t.VariableId, o => o.MapFrom(s => s.VariableId.ToString()))
                .ForMember(t => t.Value, o => o.MapFrom(s => s.Value))
                .ForMember(t => t.DateTime, o => o.MapFrom(s => s.DateTime.ToString()));

            CreateMap<GrpcProtos.SampleIntDTO, 
                Domain.Entities.HistoricalData.SampleInt>()
                .ForMember(t => t.VariableId, o => o.MapFrom(s => new Guid(s.VariableId)))
                .ForMember(t => t.Value, o => o.MapFrom(s => s.Value))
                .ForMember(t => t.DateTime, o => o.MapFrom(s => DateTime.Parse(s.DateTime)));
        }
    }
}
