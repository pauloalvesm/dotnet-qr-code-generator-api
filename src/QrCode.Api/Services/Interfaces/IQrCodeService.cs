using QrCode.Api.DTOs;

namespace QrCode.Api.Services.Interfaces;

public interface IQrCodeService
{
    string GenerateQrCodeBase64(QrCodeRequestDto request);
}