using FileUpload.Application.Common.Interfaces.Services;
using FileUpload.Domain.Common.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FileUpload.Infrastructure.Common.Services;

public class UploadService : IUploadService
{
    private readonly AppSettings _appSettings;
    private readonly ILogger _logger;

    public UploadService(IOptions<AppSettings> appSettings, ILogger<UploadService> logger)
    {
        _appSettings = appSettings.Value;
        _logger = logger;
    }

    public async Task<string> Upload(IFormFile file)
    {
        _logger.LogInformation("Start Upload File");
        string randomFileName = Path.GetRandomFileName();
        var filePath = Path.Combine(_appSettings.DestinationPath,
          $"{randomFileName}{Path.GetExtension(file.FileName)}");

        _logger.LogDebug($"file path : {filePath}");

        using (var stream = System.IO.File.Create(filePath))
        {
            await file.CopyToAsync(stream);
        }
        
        _logger.LogInformation("End Upload File");
        return randomFileName;
    }
}
