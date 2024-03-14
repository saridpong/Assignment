using FileUpload.Application.Common.Interfaces.Persistences;
using FileUpload.Application.Common.Interfaces.Services;
using FileUpload.Domain.Common.Settings;
using FileUpload.Infrastructure.Common.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileUpload.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        var appSettingsSection = configuration.GetSection("AppSettings");
        services.Configure<AppSettings>(appSettingsSection);

        AppSettings appSettings = appSettingsSection.Get<AppSettings>()!;
        services.AddPersistance();

        return services;
    }

    public static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        services.AddScoped<IFileRepository, FileRepository>();
        services.AddTransient<IEmailService, EmailService>();
        services.AddScoped<IUploadService, UploadService>();
        return services;
    }

}
