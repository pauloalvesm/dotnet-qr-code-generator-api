using QrCode.Api.DTOs;

namespace QrCode.Api.Services;

public interface IQrCodeService
{
    string GenerateQrCodeBase64(QrCodeRequestDto request);
}