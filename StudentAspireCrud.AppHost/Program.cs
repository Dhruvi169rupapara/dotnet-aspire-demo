var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.StudentAspireCrud_ApiService>("apiservice");

builder.AddProject<Projects.StudentAspireCrud_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
