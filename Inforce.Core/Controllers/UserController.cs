using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using test_inforce_test_1.Configurations;
using Inforce.Shared.Models.DTOs;

namespace test_inforce_test_1.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
  private readonly UserManager<IdentityUser> _userManager;
  private readonly JwtConfig _jwtConfig;
  private IUserService _UserService { get; set; }

  public UserController(
    UserManager<IdentityUser> userManager,
    IOptionsMonitor<JwtConfig> _optionsMonitor,
    IUserService userService
  )
  {
    _userManager = userManager;
    _jwtConfig = _optionsMonitor.CurrentValue;
    _UserService = userService;
  }

  [HttpPost("Register")]
  public async Task<IActionResult> Register([FromBody] RegReqDto body)
  {
    if (!ModelState.IsValid) return BadRequest("Invalid data.");

    var emailExist = await _userManager.FindByEmailAsync(body.Email);

    if (emailExist != null) return BadRequest("Not able to register user. Email already exists.");

    var user = new IdentityUser()
    {
      Email = body.Email,
      UserName = body.Email
    }; 
    var isCreated = await _userManager.CreateAsync(user, body.Password);

    if (!isCreated.Succeeded) return BadRequest("Not able to register user. DB error.");

    // TODO: generate token

    return Ok("User registered successfully.");
  }

  [HttpGet("All")]
  public async Task<List<UserModel>> GetUsers()
  {
      return await _UserService.GetUsers();
  }

  [HttpPost("login")]
  public async Task<UserModel> Login([FromBody] LoginModel body)
  {
    return await _UserService.Login(body);
  }
}
