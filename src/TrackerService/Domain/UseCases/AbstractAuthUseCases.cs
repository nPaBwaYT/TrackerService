using Microsoft.AspNetCore.Mvc;
using TrackerService.DataBase;
using TrackerService.Schemas;

namespace TrackerService.Domain.UseCases;

public abstract class AbstractAuthUseCases
{
    public abstract Task<IActionResult> Register(RegisterSchema registration, TrackerContext context, HttpContext httpContext);
    public abstract Task<IActionResult> Login(LoginSchema login, TrackerContext context, HttpContext httpContext);
    public abstract Task<IActionResult> Logout(HttpContext httpContext);
}