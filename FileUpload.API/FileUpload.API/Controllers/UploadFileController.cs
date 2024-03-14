using ErrorOr;
using FileUpload.Application;
using FileUpload.Application.Upload.Common;
using FileUpload.Contracts;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.API;

[Route("api/upload")]
public class UploadFileController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public UploadFileController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileUploadResponse))]
    public async Task<IActionResult> Register([FromForm]FileUploadRequest request)
    {
        var command = _mapper.Map<UploadFileCommand>(request);
        ErrorOr<GetFilesResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<FileUploadResponse>(authResult)),
            errors => Problem(errors)
        );
    }
}
