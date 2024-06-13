using Inforce.Services.Interface;
using Inforce.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace test_inforce_test_1.Controllers;

[ApiController]
[Route("[controller]")]
public class UrlController: ControllerBase
{
    public IUrlService  _UrlService { get; set; }

    public UrlController(IUrlService service)
    {
        _UrlService = service;
    }
    
    [HttpPost("CreateUrl")]
    public async Task<IActionResult> CreateUrl([FromBody] UrlCreateModel model)
    {
        await _UrlService.CreateUrl(model);

        return Ok("Successful added!");
    }
    
    [HttpGet("GetAllUrls")]
    public async Task<List<UrlViewModel>> GetAllUrls()
    {
        return await _UrlService.GetUrls();
    }
    
    [HttpGet("DeleteUrl")]
    public async Task<IActionResult> DeleteUrl(Guid urlId)
    {
        await _UrlService.DeleteAsync(urlId);

        return Ok("Successful!");
    }
}