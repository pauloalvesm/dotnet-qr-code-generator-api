using Microsoft.Extensions.Logging;
using Moq;
using QrCode.Api.DTOs;
using QrCode.Api.Services;
using QrCode.Api.Validations;

namespace QrCode.Api.Tests.Services;

public class QrCodeServiceTests
{
    private readonly Mock<ILogger<QrCodeService>> _loggerMock;
    private readonly IQrCodeService _service;

    public QrCodeServiceTests()
    {
        _loggerMock = new Mock<ILogger<QrCodeService>>();
        _service = new QrCodeService(_loggerMock.Object);
    }

    [Fact(DisplayName = "GenerateQrCodeBase64 - With valid content should return base64 image and log info twice")]
    public void GenerateQrCodeBase64_WithValidContent_ShouldReturnBase64Image()
    {
        // Arrange
        var dto = new QrCodeRequestDto
        {
            Content = "https://example.com"
        };

        // Act
        var result = _service.GenerateQrCodeBase64(dto);

        // Assert
        Assert.NotNull(result);
        Assert.StartsWith("data:image/png;base64,", result);
        _loggerMock.Verify(
            x => x.Log(
                It.Is<LogLevel>(l => l == LogLevel.Information),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((_, __) => true),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Exactly(2)
        );
    }

    [Fact(DisplayName = "GenerateQrCodeBase64 - With empty content should throw validation exception")]
    public void GenerateQrCodeBase64_WithEmptyContent_ShouldThrowException()
    {
        // Arrange
        var invalidDto = new QrCodeRequestDto
        {
            Content = ""
        };

        // Act & Assert
        var exception = Assert.Throws<ModelExceptionValidation>(() => _service.GenerateQrCodeBase64(invalidDto));
        Assert.Contains("mandatory", exception.Message, StringComparison.OrdinalIgnoreCase);
    }
}