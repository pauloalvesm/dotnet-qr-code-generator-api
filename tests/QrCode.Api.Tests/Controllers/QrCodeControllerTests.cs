using Microsoft.AspNetCore.Mvc;
using Moq;
using QrCode.Api.Controllers;
using QrCode.Api.DTOs;
using QrCode.Api.Services;

namespace QrCode.Api.Tests.Controllers;

public class QrCodeControllerTests
{
    private readonly Mock<IQrCodeService> _serviceMock;
    private readonly QrCodeController _controller;

    public QrCodeControllerTests()
    {
        _serviceMock = new Mock<IQrCodeService>();
        _controller = new QrCodeController(_serviceMock.Object);
    }

    [Fact(DisplayName = "GenerateQrCode - Valid request should return 200 OK with Base64 image")]
    public void GenerateQrCode_ValidRequest_ReturnsOkWithImage()
    {
        // Arrange
        var dto = new QrCodeRequestDto { Content = "https://example.com" };
        var fakeBase64 = "data:image/png;base64,fakeBase64";
        _serviceMock.Setup(s => s.GenerateQrCodeBase64(dto)).Returns(fakeBase64);

        // Act
        var result = _controller.GenerateQrCode(dto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);

        var imageBase64Value = okResult.Value?
            .GetType()
            .GetProperty("imageBase64")?
            .GetValue(okResult.Value, null);

        Assert.Equal(fakeBase64, imageBase64Value);
        _serviceMock.Verify(s => s.GenerateQrCodeBase64(dto), Times.Once);
    }

    [Fact(DisplayName = "GenerateQrCode - Invalid model state should return 400 BadRequest")]
    public void GenerateQrCode_InvalidModelState_ReturnsBadRequest()
    {
        // Arrange
        var dto = new QrCodeRequestDto();
        _controller.ModelState.AddModelError("Content", "The content is mandatory.");

        // Act
        var result = _controller.GenerateQrCode(dto);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.IsType<SerializableError>(badRequestResult.Value);

        _serviceMock.Verify(s => s.GenerateQrCodeBase64(It.IsAny<QrCodeRequestDto>()), Times.Never);
    }
}