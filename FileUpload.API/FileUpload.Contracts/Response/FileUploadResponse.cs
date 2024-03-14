using FileUpload.Domain.Entities;

namespace FileUpload.Contracts;

public record FileUploadResponse(List<FileItem> Files);
