
using FileUpload.Application.Common.Interfaces.Services;
using FileUpload.Domain.Common.Settings;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

namespace FileUpload.Infrastructure.Common.Services;

public class EmailService : IEmailService
{
    private readonly AppSettings _appSettings;
    private readonly ILogger _logger;

    public EmailService(IOptions<AppSettings> appSettings, ILogger<EmailService> logger)
    {
        _appSettings = appSettings.Value;
        _logger = logger;
    }

    public async Task<string> SendEmail(string receiverEmail, string receivedName, string fileName)
    {
        string result = "";
        var mail = new MimeMessage();

        mail.From.Add(new MailboxAddress(_appSettings.MailSettings.SenderName, _appSettings.MailSettings.SenderEmail));
        mail.To.Add(new MailboxAddress(receivedName, receiverEmail));

        mail.Subject = "[Notification] The image has been uploaded";
        mail.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = $"<b>{fileName} has been uploaded</b>"
        };

        using (var smtp = new SmtpClient())
        {
            await smtp.ConnectAsync(_appSettings.MailSettings.Server, _appSettings.MailSettings.Port, false);

            // Note: only needed if the SMTP server requires authentication
            await smtp.AuthenticateAsync(_appSettings.MailSettings.UserName, _appSettings.MailSettings.Password);

            result = await smtp.SendAsync(mail);

            _logger.LogInformation(result);

            await smtp.DisconnectAsync(true);
        }

        return result;
    }
}
