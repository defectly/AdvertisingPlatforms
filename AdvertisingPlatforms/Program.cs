using Domain.Entities;
using Infrastructure;
using Infrastructure.Repositories;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

builder.Services.AddInfrastructure();

var app = builder.Build();

var platformRepository = app.Services.GetService<IPlatformRepository>();

if (platformRepository == null)
    throw new NullReferenceException("Platform repository is null");

var platformsApi = app.MapGroup("/platforms");

platformsApi.MapPut("/", (Platform[] platforms) =>
{
    platformRepository.Put(platforms);
    return Results.Ok();
});

platformsApi.MapGet("/", (string? location) =>
Results.Ok(platformRepository.Get(location)));

app.Run();
