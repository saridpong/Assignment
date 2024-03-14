using ErrorOr;
using FileUpload.Application.Upload.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FileUpload.Application;

public record UploadFileCommand(IFormFile File, string Email, string SenderName) : IRequest<ErrorOr<GetFilesResult>>;
