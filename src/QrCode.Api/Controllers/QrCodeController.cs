using Microsoft.AspNetCore.Mvc;
using QrCode.Api.DTOs;
using QrCode.Api.Services;

namespace QrCode.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QrCodeController : ControllerBase
{
    private readonly IQrCodeService _qrCodeService;

    public QrCodeController(IQrCodeService qrCodeService)
    {
        _qrCodeService = qrCodeService;
    }

    [HttpPost]
    public IActionResult GenerateQrCode([FromBody] QrCodeRequestDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var imageBase64 = _qrCodeService.GenerateQrCodeBase64(request);
        return Ok(new { imageBase64 });
    }
}