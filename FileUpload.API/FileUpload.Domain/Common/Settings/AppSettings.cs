namespace FileUpload.Domain.Common.Settings;

public class AppSettings
{
    public string Secret { get; set; } = null!;
    public string DestinationPath { get; set; } = null!;
    public MailSettings MailSettings { get; set; } = null!;
}

public class MailSettings
{
    public string Server { get; set; } = null!;
    public int Port { get; set; }
    public string SenderName { get; set; } = null!;
    public string SenderEmail { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}
