

using ErrorOr;
using FileUpload.Application.Upload.Common;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Moq;

namespace FileUpload.Application.UnitTests;

[Collection(WebAppFactoryCollection.CollectionName)]
public class UploadFileValidationTests(WebAppFactory webAppFactory)
{
    private readonly IMediator _mediator = webAppFactory.CreateMediator();

    [Fact]
    public async Task UploadFile_WhenInvalidFileType_ShouldReturnValidationError()
    {
        // Arrange
        //Setup mock file using a memory stream
        var content = "Hello World from a Fake File";
        var fileName = "test.pdf";
        var ms = new MemoryStream();
        var writer = new StreamWriter(ms);
        writer.Write(content);
        writer.Flush();
        ms.Position = 0;

        Mock<IFormFile> _file = new();
        _file.Setup(_ => _.OpenReadStream()).Returns(ms);
        _file.Setup(_ => _.FileName).Returns(fileName);
        _file.Setup(_ => _.Length).Returns(ms.Length);
        _file.Setup(_ => _.ContentType).Returns("application/pdf");

        var command = new UploadFileCommand(_file.Object, "test@gmail.com", "test");
        // Act
        var result = await _mediator.Send(command);

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Type.Should().Be(ErrorType.Validation);
    }

    [Fact]
    public async Task UploadFile_WhenInvalidEmailFormat_ShouldReturnValidationError()
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

        var command = new UploadFileCommand(_file.Object, "wrongemailformat", "test");
        // Act
        var result = await _mediator.Send(command);

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Code.Should().Be("Email");
    }

    [Fact]
    public async Task UploadFile_WhenEmailIsEmpty_ShouldReturnValidationError()
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

        var command = new UploadFileCommand(_file.Object, "", "test");
        // Act
        var result = await _mediator.Send(command);

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Code.Should().Be("Email");
    }

    [Fact]
    public async Task UploadFile_WhenSenderNameIsEmpty_ShouldReturnValidationError()
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

        var command = new UploadFileCommand(_file.Object, "test@email.com", "");
        // Act
        var result = await _mediator.Send(command);

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Code.Should().Be("SenderName");
    }

     [Fact]
    public async Task UploadFile_WhenSenderNameMoreThan100Characters_ShouldReturnValidationError()
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

        var command = new UploadFileCommand(_file.Object, "test@email.com", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        // Act
        var result = await _mediator.Send(command);

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Code.Should().Be("SenderName");
    }
}
