using ErrorOr;
using FileUpload.Application.Common.Interfaces.Persistences;
using FileUpload.Application.Common.Interfaces.Services;
using FileUpload.Application.Upload.Common;
using FileUpload.Domain.Common.Errors;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FileUpload.Application;

public class UploadFileHandler : IRequestHandler<UploadFileCommand, ErrorOr<GetFilesResult>>
{

    private readonly IUploadService _uploadService;
    private readonly IEmailService _emailService;
    private readonly IFileRepository _fileRepository;
    private readonly ILogger _logger;

    public UploadFileHandler(IUploadService uploadService, IEmailService emailService, IFileRepository fileRepository, ILogger<UploadFileHandler> logger)
    {
        _uploadService = uploadService;
        _emailService = emailService;
        _fileRepository = fileRepository;
        _logger = logger;
    }

    public async Task<ErrorOr<GetFilesResult>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Start Upload");

            string fileName = await _uploadService.Upload(request.File);

            if (string.IsNullOrEmpty(fileName)) return Errors.UploadFile.UploadFailed;

            await _emailService.SendEmail(request.Email, request.SenderName, fileName);

            _fileRepository.Add(fileName);

            _logger.LogInformation($"End Upload");

            return new GetFilesResult(_fileRepository.Get());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Errors.Default.DefaultMessage("UploadFile", ex.Message);
        }
    }
}
