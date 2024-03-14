using FileUpload.Domain.Entities;

namespace FileUpload.Application.Common.Interfaces.Persistences;

public interface IFileRepository
{
    List<FileItem> Get();
    FileItem? GetById(Guid guid);
    FileItem Add(string fileName);

}
