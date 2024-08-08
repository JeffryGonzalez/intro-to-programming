var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");


var apiService = builder.AddProject<Projects.DemoAspire_ApiService>("apiservice");

builder.AddProject<Projects.DemoAspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
