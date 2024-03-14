namespace FileUpload.Application.Common.Interfaces.Services;

public interface IEmailService
{
    Task<string> SendEmail(string receiverEmail, string receivedName, string fileName);
}
