using QrCode.Api.DTOs;
using QrCode.Api.Mappers;
using QRCoder;

namespace QrCode.Api.Services;

public class QrCodeService : IQrCodeService
{
    private readonly ILogger<QrCodeService> _logger;

    public QrCodeService(ILogger<QrCodeService> logger)
    {
        _logger = logger;
    }

    public string GenerateQrCodeBase64(QrCodeRequestDto request)
    {
        _logger.LogInformation("Generating QR Code for content: {Content}", request.Content);

        var model = QrCodeRequestMapper.ToModel(request);

        using var qrGenerator = new QRCodeGenerator();
        var eccLevel = ParseErrorCorrectionLevel(model.ErrorCorrectionLevel);
        using var qrCodeData = qrGenerator.CreateQrCode(model.Content, eccLevel);

        var qrCode = new PngByteQRCode(qrCodeData);
        var qrBytes = qrCode.GetGraphic(model.PixelsPerModule);

        var base64 = Convert.ToBase64String(qrBytes);
        var result = $"data:image/png;base64,{base64}";

        _logger.LogInformation("QR Code generated successfully.");

        return result;
    }

    private QRCodeGenerator.ECCLevel ParseErrorCorrectionLevel(string level) => level.ToUpper() switch
    {
        "L" => QRCodeGenerator.ECCLevel.L,
        "M" => QRCodeGenerator.ECCLevel.M,
        "Q" => QRCodeGenerator.ECCLevel.Q,
        "H" => QRCodeGenerator.ECCLevel.H,
        _ => QRCodeGenerator.ECCLevel.Q
    };
}