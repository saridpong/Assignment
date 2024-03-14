using FileUpload.Application.Common.Interfaces.Persistences;
using FileUpload.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace FileUpload.Infrastructure;

public class FileRepository : IFileRepository
{
    private readonly List<FileItem> fileList = new List<FileItem>();
    
    public FileItem Add(string fileName)
    {
        FileItem newItem = new FileItem()
        {
            FileId = Guid.NewGuid(),
            FileName = fileName
        };

        fileList.Add(newItem);
        return newItem;
    }

    public List<FileItem> Get()
    {
        return fileList;
    }

    public FileItem? GetById(Guid guid)
    {
        return fileList.FirstOrDefault(p => p.FileId == guid);
    }
}
