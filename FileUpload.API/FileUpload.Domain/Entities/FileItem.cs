namespace FileUpload.Domain.Entities;

public class FileItem
{
    public Guid FileId { get; set; }
    public string FileName { get; set; } = null!;
}
