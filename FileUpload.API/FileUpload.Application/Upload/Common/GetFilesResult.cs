using FileUpload.Domain.Entities;

namespace FileUpload.Application.Upload.Common;

public record GetFilesResult(List<FileItem> Files);
