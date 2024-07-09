using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackerService.DataBase;
using TrackerService.Domain.UseCases;
using TrackerService.Models;
using TrackerService.Schemas;

namespace TrackerService.UseCases;

public class AuthUseCases: AbstractAuthUseCases
{
    private PasswordHasher<User> hasher;
    public AuthUseCases()
    {
        hasher = new PasswordHasher<User>();
    }
    public override async Task<IActionResult> Register(RegisterSchema register, TrackerContext context, HttpContext httpContext)
    {
        User user = await context.Users.FirstOrDefaultAsync(u => u.Email == register.Email);
        if (user == null)
        {
            User regUser = new User() { Email = register.Email, Password = register.Password };
            regUser.Password = hasher.HashPassword(regUser, regUser.Password);
            context.Users.Add(regUser);
            await context.SaveChangesAsync();

            await Authenticate(register.Email, httpContext); // аутентификация

            return new OkResult();
        }

        return new AuthErrorResponse();
    }

    public override async Task<IActionResult> Login(LoginSchema login, TrackerContext context, HttpContext httpContext)
    {
        User user = await context.Users.FirstOrDefaultAsync(u => u.Email == login.Email);
        if (user != null)
        {
            if (hasher.VerifyHashedPassword(user, user.Password, login.Password) == PasswordVerificationResult.Failed)
            {
                return new AuthErrorResponse();
            }
            await Authenticate(login.Email, httpContext);

            return new OkResult();
        }

        return new AuthErrorResponse();
    }

    public override async Task<IActionResult> Logout(HttpContext httpContext)
    {
        // await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return new OkResult();
    }
    
    private async Task Authenticate(string userName, HttpContext context)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
        };
        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        // await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
    }
}