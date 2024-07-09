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
    private AbstractAuthUseCases _authUC;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthController(TrackerContext context, IHttpContextAccessor httpContextAccessor)
    {
        _authUC = new AuthUseCases();
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// Logs the user in
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    [HttpPost(nameof(Login))]
    public async Task<IActionResult> Login(LoginSchema login)
    {
        return await _authUC.Login(login, _context, _httpContextAccessor.HttpContext);
    }

    /// <summary>
    /// Logs the user out
    /// </summary>
    /// <returns></returns>
    [HttpPost(nameof(Logout))]
    public async Task<IActionResult> Logout()
    {
        return await _authUC.Logout(_httpContextAccessor.HttpContext);
    }
    
    /// <summary>
    /// Registers a new user
    /// </summary>
    /// <param name="register"></param>
    /// <returns></returns>
    [HttpPost(nameof(Register))]
    public async Task<IActionResult> Register(RegisterSchema register)
    {
        return await _authUC.Register(register, _context, _httpContextAccessor.HttpContext);
    }
}