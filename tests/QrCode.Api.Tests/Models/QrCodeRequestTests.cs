using QrCode.Api.Models;
using QrCode.Api.Validations;

namespace QrCode.Api.Tests.Models;

public class QrCodeRequestTests
{
    [Fact(DisplayName = "Constructor - With valid content should create object with default values")]
    public void Constructor_WithValidContent_ShouldCreateObjectSuccessfully()
    {
        // Arrange
        var validContent = "This is a valid QR code content.";

        // Act
        var qrCodeRequest = new QrCodeRequest(validContent);

        // Assert
        Assert.Equal(validContent, qrCodeRequest.Content);
        Assert.Equal(10, qrCodeRequest.PixelsPerModule);
        Assert.Equal("#000000", qrCodeRequest.ForegroundColorHex);
        Assert.Equal("#FFFFFF", qrCodeRequest.BackgroundColorHex);
        Assert.Equal("Q", qrCodeRequest.ErrorCorrectionLevel);
    }

    [Theory(DisplayName = "Constructor - With empty or whitespace content should throw validation exception")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("     ")]
    public void Constructor_WithEmptyOrWhitespaceContent_ShouldThrowValidationException(string invalidContent)
    {
        // Act & Assert
        var ex = Assert.Throws<ModelExceptionValidation>(() => new QrCodeRequest(invalidContent));
        Assert.Equal("The content of the QR Code is mandatory", ex.Message);
    }

    [Fact(DisplayName = "Constructor - With content exceeding 100 characters should throw validation exception")]
    public void Constructor_WithContentExceedingMaxLength_ShouldThrowValidationException()
    {
        // Arrange
        var longContent = new string('A', 101);

        // Act & Assert
        var ex = Assert.Throws<ModelExceptionValidation>(() => new QrCodeRequest(longContent));
        Assert.Equal("The content can be no longer than 100 characters.", ex.Message);
    }
}