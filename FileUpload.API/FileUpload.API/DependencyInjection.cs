using FileUpload.API.Common.Errors;
using FileUpload.API.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace FileUpload.API;

public static class DependencyInjection
{
     public static IServiceCollection AddPersentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
        services.AddMappings();
        
        return services;
    }
}
