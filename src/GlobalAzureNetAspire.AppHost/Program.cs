var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.GlobalAzureNetAspire_ApiService>("apiservice")
    .WithHttpsHealthCheck("/health");

builder.AddProject<Projects.GlobalAzureNetAspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpsHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
