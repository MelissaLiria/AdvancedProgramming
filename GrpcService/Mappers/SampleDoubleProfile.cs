using AutoMapper;
using System.Globalization;

namespace GrpcService.Mappers
{
    public class SampleDoubleProfile : Profile
    {
        public SampleDoubleProfile()
        {
            CreateMap<Domain.Entities.HistoricalData.SampleDouble,
                GrpcProtos.SampleDoubleDTO>()
                .ForMember(t => t.VariableId, o => o.MapFrom(s => s.VariableId.ToString()))
                .ForMember(t => t.Value, o => o.MapFrom(s => s.Value))
                .ForMember(t => t.DateTime, o => o.MapFrom(s => s.DateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK")));

            CreateMap<GrpcProtos.SampleDoubleDTO,
                Domain.Entities.HistoricalData.SampleDouble>()
                .ForMember(t => t.VariableId, o => o.MapFrom(s => new Guid(s.VariableId)))
                .ForMember(t => t.Value, o => o.MapFrom(s => s.Value))
                .ForMember(t => t.DateTime, o => o.MapFrom(s => DateTime.ParseExact(s.DateTime, "yyyy-MM-ddTHH:mm:ss.fffffffK", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind)));
        }
    }
}
