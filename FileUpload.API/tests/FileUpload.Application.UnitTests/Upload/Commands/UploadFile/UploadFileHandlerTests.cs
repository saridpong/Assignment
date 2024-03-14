using FileUpload.Application.Upload.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Moq;

namespace FileUpload.Application.UnitTests.Upload.Commands.UploadFile;

[Collection(WebAppFactoryCollection.CollectionName)]
public class UploadFileHandlerTests(WebAppFactory webAppFactory)
{
    private readonly IMediator _mediator = webAppFactory.CreateMediator();

    [Fact]
    public async Task UploadFile_WhenValidFileType_ShouldReturnSuccess()
    {
        // Arrange
        //Setup mock file using a memory stream
        var content = "Hello World from a Fake File";
        var fileName = "test.png";
        var ms = new MemoryStream();
        var writer = new StreamWriter(ms);
        writer.Write(content);
        writer.Flush();
        ms.Position = 0;

        Mock<IFormFile> _file = new();
        _file.Setup(_ => _.OpenReadStream()).Returns(ms);
        _file.Setup(_ => _.FileName).Returns(fileName);
        _file.Setup(_ => _.Length).Returns(ms.Length);
        _file.Setup(_ => _.ContentType).Returns("image/png");

        var command = new UploadFileCommand(_file.Object,"test@gmail.com","test");
        
        // Act
        var result = await _mediator.Send(command);

        // Assert
        Assert.IsType<GetFilesResult>(result.Value);
    }
}