using FileUpload.Application.Common.Validators;
using FluentValidation;

namespace FileUpload.Application.Upload.Commands;

public class UploadFileValidator : AbstractValidator<UploadFileCommand>
{
    public UploadFileValidator()
    {
        RuleFor(x => x.File).SetValidator(new FileValidator());
        RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
        RuleFor(x => x.SenderName).NotNull().NotEmpty().MaximumLength(100);
    }
}
