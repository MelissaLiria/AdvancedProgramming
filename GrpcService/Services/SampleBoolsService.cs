using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcProtos;

namespace GrpcService.Services
{
    public class SampleBoolsService : SampleBool.SampleBoolBase
    {
        public override Task<SampleBoolDTO> CreateSampleBool(CreateSampleBoolRequest request, ServerCallContext context)
        {
            return base.CreateSampleBool(request, context);
        }

        public override Task<Empty> DeleteSampleBool(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteSampleBool(request, context);
        }

        public override Task<SampleBools> GetAllSampleBools(Empty request, ServerCallContext context)
        {
            return base.GetAllSampleBools(request, context);
        }

        public override Task<SampleBools> GetSampleBoolByTimeSpan(GrpcProtos.TimeSpan request, ServerCallContext context)
        {
            return base.GetSampleBoolByTimeSpan(request, context);
        }

        public override Task<NullableSampleBoolDTO> GetSampleBoolByVariableId(GetRequest request, ServerCallContext context)
        {
            return base.GetSampleBoolByVariableId(request, context);
        }

        public override Task<Empty> UpdateSampleBool(SampleBoolDTO request, ServerCallContext context)
        {
            return base.UpdateSampleBool(request, context);
        }
    }
}
