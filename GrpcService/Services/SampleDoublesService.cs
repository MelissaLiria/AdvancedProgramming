using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcProtos;

namespace GrpcService.Services
{
    public class SampleDoublesService : SampleDouble.SampleDoubleBase
    {
        public override Task<SampleDoubleDTO> CreateSampleDouble(CreateSampleDoubleRequest request, ServerCallContext context)
        {
            return base.CreateSampleDouble(request, context);
        }

        public override Task<Empty> DeleteSampleDouble(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteSampleDouble(request, context);
        }

        public override Task<SampleDoubles> GetAllSampleDoubles(Empty request, ServerCallContext context)
        {
            return base.GetAllSampleDoubles(request, context);
        }

        public override Task<SampleDoubles> GetSampleDoubleByTimeSpan(GrpcProtos.TimeSpan request, ServerCallContext context)
        {
            return base.GetSampleDoubleByTimeSpan(request, context);
        }

        public override Task<NullableSampleDoubleDTO> GetSampleDoubleByVariableId(GetRequest request, ServerCallContext context)
        {
            return base.GetSampleDoubleByVariableId(request, context);
        }

        public override Task<Empty> UpdateSampleDouble(SampleDoubleDTO request, ServerCallContext context)
        {
            return base.UpdateSampleDouble(request, context);
        }
    }
}
