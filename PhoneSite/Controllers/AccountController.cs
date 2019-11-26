using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PhoneSite.Data;
using PhoneSite.Dtos;
using PhoneSite.Models;

namespace PhoneSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        public AccountController(IAuthRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            //валідація 
            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();
            if(await _repo.UserExists(userForRegisterDto.UserName))
            return BadRequest("Користувач вже існує");

            var userToCreate = new User
            {
                UserName = userForRegisterDto.UserName
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
    {
      var userFromRepo = await _repo.Login(userForLoginDto.UserName.ToLower(), userForLoginDto.Password);
      if (userFromRepo == null)
        return Unauthorized();
      //Створюємо токен який потім відправимо користувачу, він буде мати 2-бітну інфу про користувача(username и password) 
      //Сервер може заглянути всередину токена і отримати дані про користувача, тому що токен валідований сервером без використання бд
      var claims = new[]
      {
        new Claim(ClaimTypes.NameIdentifier,userFromRepo.Id.ToString()),         // NameIdentifier = id
        new Claim(ClaimTypes.Name,userFromRepo.UserName)
      };
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
      //створюємо токен
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.Now.AddDays(1),
        SigningCredentials = creds
      };
      //прописуєм handler, який дозволяє створювати token оснований на tokenDescriptor
      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return Ok(new {
        token = tokenHandler.WriteToken(token) // отправляем токен в response 
      });
    }
    }
}