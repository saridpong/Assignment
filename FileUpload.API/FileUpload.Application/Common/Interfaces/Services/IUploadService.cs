using Microsoft.AspNetCore.Http;

namespace FileUpload.Application.Common.Interfaces.Services;

public interface IUploadService
{
    Task<string> Upload(IFormFile file);
}
