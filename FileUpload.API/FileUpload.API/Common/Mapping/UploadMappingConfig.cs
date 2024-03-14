using FileUpload.Application;
using FileUpload.Contracts;
using Mapster;

namespace FileUpload.API;

public class UploadMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<IFormFile, IFormFile>().MapWith(src => src);
    
    }
}
