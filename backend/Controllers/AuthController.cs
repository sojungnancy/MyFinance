using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;
using backend.Services;
using System.Security.Claims;

namespace backend.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        private readonly JwtTokenService _jwtService;

        public AuthController(AppDbContext context, JwtTokenService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            var props = new AuthenticationProperties { RedirectUri = "/auth/callback" };
                Console.WriteLine("🚀 Google login challenge triggered at: " + DateTime.Now);
            return Challenge(props, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet("callback")]
    public async Task<IActionResult> Callback()
    {
        var result = await HttpContext.AuthenticateAsync("Google");
        if (!result.Succeeded) return BadRequest();

        var claims = result.Principal!.Identities.FirstOrDefault()!.Claims;
var email = claims.First(c => c.Type == ClaimTypes.Email).Value;
var name = claims.First(c => c.Type == ClaimTypes.Name).Value;
var providerId = claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
    //if user is not exist = save it to the database
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user == null)
        {
            user = new User
            {
                Email = email,
                Name = name,
                Provider = "Google",
                ProviderId = providerId
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        // ✅ JWT token
        var token = _jwtService.GenerateToken(user.id, user.Email, user.Name);

        // ✅ response
        return Redirect($"http://localhost:5173/login/success?token={token}&email={user.Email}&name={user.Name}");

}}}
