using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;
using backend.Services;

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
            return Challenge(props, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet("callback")]
    public async Task<IActionResult> Callback()
    {
        var result = await HttpContext.AuthenticateAsync("Google");
        if (!result.Succeeded) return BadRequest();

        var claims = result.Principal!.Identities.FirstOrDefault()!.Claims;
        var email = claims.First(c => c.Type.Contains("emailaddress")).Value;
        var name = claims.First(c => c.Type.Contains("name")).Value;
        var providerId = claims.First(c => c.Type.Contains("nameidentifier")).Value;

        // 유저가 존재하지 않으면 저장
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

        // ✅ JWT 토큰 발급
        var token = _jwtService.GenerateToken(user.id, user.Email, user.Name);

        // ✅ 응답
        return Redirect($"http://localhost:5173/login/success?token={token}&email={user.Email}&name={user.Name}");

}}}
