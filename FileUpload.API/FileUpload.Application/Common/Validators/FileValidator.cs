using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace FileUpload.Application.Common.Validators;

public class FileValidator : AbstractValidator<IFormFile>
{
    public FileValidator()
    {
        RuleFor(x => x.Length).NotNull().LessThanOrEqualTo(10485760) //10MB
            .WithMessage("File size is larger than allowed");

        RuleFor(x => x.ContentType).NotNull().Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
            .WithMessage("File type does not correct.");

    }
}