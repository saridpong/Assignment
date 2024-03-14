using ErrorOr;

namespace FileUpload.Domain.Common.Errors;

public partial class Errors
{
    public static class UploadFile
    {
        public static Error UploadFailed => Error.Failure(code: "Upload.Failure",
                                                                  description: "Upload Failed.");
    }

}
