using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MyFullStackNotes.Api.DTO;
using MyFullStackNotes.Application.Interfaces;

namespace MyFullStackNotes.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordHasher _passwordHasher;
        public AuthController(IUserService userService, IJwtTokenGenerator jwtTokenGenerator, IPasswordHasher passwordHasher) 
        {
            _userService = userService;
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordHasher = passwordHasher;
        }
        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register(RegisterRequest registerRequest)
        {
            var user = await _userService.RegisterAsync(registerRequest.Email, registerRequest.Name, registerRequest.Password);
            var token = _jwtTokenGenerator.GenerateToken(user);
            return Ok(new AuthResponse
            {
                Token = token,
                Email = user.Email,
                Role = user.Role.ToString() //без ролі можливо краще повертати, чисто токен
            });
        }
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(LoginRequest loginRequest) 
        {
            var user = await _userService.GetByEmailAsync(loginRequest.Email);

            if(user == null || _passwordHasher.Verify(user.PasswordHash, loginRequest.Password))
                return Unauthorized("Невірний email або пароль");

            var token = _jwtTokenGenerator.GenerateToken(user);

            return Ok(new AuthResponse
            {
                Token = token,
                Email = user.Email,
                Role = user.Role.ToString()
            });
        }
    }
}
