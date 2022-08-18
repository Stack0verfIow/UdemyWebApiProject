using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using UdemyWebApiProject.Data;
using UdemyWebApiProject.DTOs;
using UdemyWebApiProject.Entities;
using UdemyWebApiProject.Interfaces;

namespace UdemyWebApiProject.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;

        public AccountController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest("The username has been taken");

            using var hmac = new HMACSHA512();

            var appuser = new AppUser()
            {
                Username = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Add(appuser);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                Username = appuser.Username,
                Token = _tokenService.CreateToken(appuser)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<AppUser>> Login(LoginDto loginDto)
        {
            if (!await UserExists(loginDto.Username)) return Unauthorized("Invalid username");

            var user = await _context.AppUser.FirstOrDefaultAsync( x=> x.Username == loginDto.Username.ToLower());

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for(int i = 0; i < user.PasswordHash.Length; i++)
            {
                if (user.PasswordHash[i] != computedHash[i]) return Unauthorized("Invalid password");
            }

            return user;
        }

        private async Task<bool> UserExists(string username)
        {
            var user = await _context.AppUser.FirstOrDefaultAsync(x => x.Username == username.ToLower());

            if (user == null) return false;

            return true;
        }

    }
}
