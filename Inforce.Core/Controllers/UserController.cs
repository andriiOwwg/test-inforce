using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using test_inforce_test_1.Configurations;
using Inforce.Shared.Models.DTOs;
using test_inforce_test_1.Helpers;

namespace test_inforce_test_1.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
  private readonly UserManager<IdentityUser> _userManager;
  private IUserService UserService { get; set; }
  private JwtGenerator JwtGenerator { get; set; }

  public UserController(
    JwtGenerator jwtGenerator,
    UserManager<IdentityUser> userManager,
    IUserService userService
  )
  {
    _userManager = userManager;
    UserService = userService;
    JwtGenerator = jwtGenerator;
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

    var token = JwtGenerator.GenerateJwtToken(user);

    return Ok(new RegistrationResponse()
    {
      Result = true,
      Token = token
      });
  }

  [HttpGet("All")]
  public async Task<List<UserModel>> GetUsers()
  {
      return await UserService.GetUsers();
  }

  [HttpPost("login")]
  public async Task<UserModel> Login([FromBody] LoginModel body)
  {
    return await UserService.Login(body);
  }

}
