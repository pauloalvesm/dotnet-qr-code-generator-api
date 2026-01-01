using System.ComponentModel.DataAnnotations;

namespace QrCode.Api.DTOs;

public class QrCodeRequestDto
{
    [Required(ErrorMessage = "The content is mandatory.")]
    [StringLength(100, ErrorMessage = "The content can be no longer than 100 characters.")]
    public string Content { get; set; } = string.Empty;
}