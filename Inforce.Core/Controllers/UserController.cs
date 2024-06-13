using Microsoft.AspNetCore.Mvc;

namespace test_inforce_test_1.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
  private IUserService _UserService { get; set; }

  public UserController(IUserService userService)
  {
    _UserService = userService;
  }

  [HttpPost("Register")]
  public async Task<IActionResult> Register([FromBody] UserModel body)
  {
    await _UserService.CreateUser(body);

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
