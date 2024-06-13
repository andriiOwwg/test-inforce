using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Inforce.Shared.Entities;
using Inforce.Persistence.Contexts;
using Inforce.Shared.Enums;

namespace test_inforce_test_1.Controllers;

[ApiController]
[Route("[controller]")]
public class RegisterController : ControllerBase
{
  private readonly ILogger<RegisterController> _logger;
  private readonly PlatformDbContext _context;

  public RegisterController(ILogger<RegisterController> logger, PlatformDbContext context)
  {
    _logger = logger;
    _context = context;
  }

  [HttpPost(Name = "Register")]
  public async Task<IActionResult> Register([FromBody] RegisterRequest request)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    var userExists = _context.Users.Any(u => u.Email == request.Email);
    if (userExists)
    {
      return BadRequest("User already exists.");
    }

    var newUser = new User
    {
      Name = request.Name,
      Email = request.Email,
      Password = request.Password,
      AccountStatus = AccountStatus.User,
    };
    _context.Users.Add(newUser);
    await _context.SaveChangesAsync();

    _logger.LogInformation("Registered user with email {Email}", request.Email);
    return Ok("User registered successfully.");
  }

  [HttpGet("users")]
    public async Task<List<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

  public class RegisterRequest
  {
    public string Name { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }
  }
}
