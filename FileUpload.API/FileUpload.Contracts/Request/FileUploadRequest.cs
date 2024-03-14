using Microsoft.AspNetCore.Http;

namespace FileUpload.Contracts;

public record FileUploadRequest(IFormFile File,string Email,string SenderName);
