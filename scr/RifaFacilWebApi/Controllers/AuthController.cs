using BibliotecaBusiness.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RifaFacilWebApi.Controllers
{
    [ApiController]
    [Route("api/conta")]
    public class AuthController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;    
        private readonly JwtSettings _jwtSettings;  

        public AuthController(SignInManager<IdentityUser> signInManager,
                             RoleManager<IdentityRole> _roleManager,
                             UserManager<IdentityUser> userManager,
                             IOptions<JwtSettings> jwtSettings)
        {
            this._signInManager = signInManager;   
            this._userManager = userManager;
            this._jwtSettings = jwtSettings.Value;
            this._roleManager = _roleManager;
        }
        //REGISTRAR RIFADOR

        [Authorize(Roles = "admin")]
        [HttpPost("registrarRifador")]
        public async Task<ActionResult> RegistrarRifador(RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                //ATRIBUIÇÃO DA ROLE RIFADOR AO USUÁRIO
                var rolesResult = await _userManager.AddToRoleAsync(user, "rifador");

                if (rolesResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return Ok(await GerarJwt(user.Email));
                }
                return Problem("Falha ao registrar o usuário");
            }

            return Problem("Falha ao registrar o usuário");
        }

        //REGISTRAR AFILIADO

        [Authorize(Roles = "admin, rifador")]
        [HttpPost("registrarAfiliado")]
        public async Task<ActionResult> RegistrarAfiliado(RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                //ATRIBUIÇÃO DA ROLE AFILIADO AO USUÁRIO
                var rolesResult = await _userManager.AddToRoleAsync(user, "afiliado");

                if (rolesResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return Ok(await GerarJwt(user.Email));
                }
                return Problem("Falha ao registrar o usuário");
            }

            return Problem("Falha ao registrar o usuário");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                return Ok(await GerarJwt(loginUser.Email));
            }
            return Problem("Usuário ou senha incorretos");
        }


        private async Task<string> GerarJwt(string email) 
        {
            var user = await _userManager.FindByNameAsync(email);
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            // Adicionar roles como claims
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenHadler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Segredo);

            var token = tokenHadler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _jwtSettings.Emissor,
                Audience = _jwtSettings.Audiencia,
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHadler.WriteToken(token);

            return encodedToken;
        }
    }
}
