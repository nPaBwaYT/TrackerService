using Microsoft.AspNetCore.Mvc;
using TrackerService.DataBase;
using TrackerService.Domain.UseCases;
using TrackerService.Schemas;
using TrackerService.UseCases;

namespace TrackerService.ApiControllers;


[ApiController]
[Route("[controller]")]
public class AuthController
{
    private readonly TrackerContext _context;
    private readonly HttpContext _httpContext;
    private AbstractAuthUseCases _authUC;

    public AuthController(TrackerContext context)
    {
        _authUC = new AuthUseCases();
        _context = context;
        _httpContext = new DefaultHttpContext();
    }

    [HttpPost(nameof(Login))]
    public async Task<IActionResult> Login(LoginSchema login)
    {
        return await _authUC.Login(login, _context, _httpContext);
    }

    [HttpPost(nameof(Logout))]
    public async Task<IActionResult> Logout()
    {
        return await _authUC.Logout(_httpContext);
    }
    
    [HttpPost(nameof(Register))]
    public async Task<IActionResult> Register(RegisterSchema register)
    {
        return await _authUC.Register(register, _context, _httpContext);
    }
}