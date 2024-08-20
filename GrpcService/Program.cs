using Application;
using Contracts;
using Contracts.Samples;
using Contracts.Structures;
using Contracts.Variables;
using DataAccess;
using DataAccess.Contexts;
using DataAccess.Repositories.Samples;
using DataAccess.Repositories.Structures;
using DataAccess.Repositories.Variables;
using GrpcService.Services;


namespace GrpcService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS,
            // visit https://go.microsoft.com/fwlink/?linkid=2099682

            // Add services to the container.
            builder.Services.AddGrpc();

            builder.Services.AddSingleton("Data Source=Data.sqlite");
            builder.Services.AddScoped<ApplicationContext>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IStructureRepository, StructureRepository>();
            builder.Services.AddScoped<IVariableRepository, VariableRepository>();
            builder.Services.AddScoped<ISampleRepository, SampleRepository>();

            builder.Services.AddMediatR(new MediatRServiceConfiguration()
                {
                    AutoRegisterRequestProcessors = true
                }
                .RegisterServicesFromAssemblies(typeof(AssemblyReference).Assembly));
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<VariablesService>();
            app.MapGrpcService<BuildingsService>();
            app.MapGrpcService<FloorsService>();
            app.MapGrpcService<RoomsService>();
            app.MapGrpcService<SampleIntsService>();
            app.MapGrpcService<SampleDoublesService>();
            app.MapGrpcService<SampleBoolsService>();

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through " +
            "a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}

