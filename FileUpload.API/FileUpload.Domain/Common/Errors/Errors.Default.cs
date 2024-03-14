using ErrorOr;

namespace FileUpload.Domain.Common.Errors;

public partial class Errors
{
    public static class Default
    {
        public static Error DefaultMessage(string title, string message) => Error.Failure(code: $"Default.{title}",
                                                                  description: message);
    }

}
