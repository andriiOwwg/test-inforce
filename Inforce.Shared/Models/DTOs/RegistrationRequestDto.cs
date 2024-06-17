using System.ComponentModel.DataAnnotations;

namespace Inforce.Shared.Models.DTOs;
public class RegReqDto
{
  [Required]
  public string Name { get; set; } = string.Empty;

  [Required]
  public string Email { get; set; } = string.Empty;

  [Required]
  public string Password { get; set; } = string.Empty;
}