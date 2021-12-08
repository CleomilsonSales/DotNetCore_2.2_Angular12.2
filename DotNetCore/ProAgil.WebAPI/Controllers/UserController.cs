using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProAgil.Domain.Identity;
using ProAgil.WebAPI.Dtos;

namespace ProAgil.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public UserController(IConfiguration config,
                    UserManager<User> userManager,
                    SignInManager<User> signInManager,
                    IMapper mapper)
            {
                _signInManager = signInManager;
                _mapper = mapper;
                _config = config;
                _userManager = userManager;
            }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(){
            return Ok(new UserDto());
        }

        [HttpPost("Register")]
        /* esse item [AllowAnonymous] permite que possamos transitar nesse post(register) sem a necessidade de estar autenticado
         visto que é a criação de um usuário novo e não tem como este usuário se autenticar sem antes se cadastrar
        */
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserDto userDto){
            try
            {
                var user = _mapper.Map<User>(userDto);
                var result = await _userManager.CreateAsync(user, userDto.Password);
                var userToReturn = _mapper.Map<UserDto>(user);

                // se eu tiver sucesso no retorno do banco...
                if(result.Succeeded){
                    return Created("GetUser", userToReturn);
                }

                return BadRequest(result.Errors);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou {ex.Message}");
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto userLogin){
            try
            {
                // Aqui verifico se existe algum usuário com o nome enviado dentro do json userLoginDto
                var user = await _userManager.FindByNameAsync(userLogin.UserName);

                // aqui em baixo verifico a senha desse usuário que foi consultado e armazenado na variável acima
                var result = await _signInManager.CheckPasswordSignInAsync(user, userLogin.Password, false);


                if(result.Succeeded){
                   var appUser = await _userManager.Users
                        .FirstOrDefaultAsync(u => u.NormalizedUserName == userLogin.UserName.ToUpper()); 
                

                    var userToReturn = _mapper.Map<UserLoginDto>(appUser);

                    return Ok(new {
                        token = GenerateJWToken(appUser).Result,
                        user = userToReturn
                    });
                }

                return Unauthorized();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou {ex.Message}");
            }
        }

        // método de gerar o token
        private async Task<string> GenerateJWToken(User user)
        {   
            var claims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.ASCII
                        .GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}