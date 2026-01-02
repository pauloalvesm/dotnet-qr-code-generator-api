using QrCode.Api.DTOs;
using QrCode.Api.Models;

namespace QrCode.Api.Mappers;

public class QrCodeRequestMapper
{
    public static QrCodeRequest ToModel(QrCodeRequestDto dto) => new QrCodeRequest(dto.Content);
}