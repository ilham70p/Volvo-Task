using Business.Abstract;
using Core.Security.Hashing;
using Core.Security.TokenHandler;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Volvo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {




        private readonly IAuthManager _authManager;
        private readonly TokenGenerator _tokenGenerator;
        private readonly HashingHandler _hashingHandler;
        private readonly IRoleMananger _roleMananger;

        public AuthController(IAuthManager authManager, TokenGenerator tokenGenerator, HashingHandler hashingHandler, IRoleMananger roleMananger)
        {
            _authManager = authManager;
            _tokenGenerator = tokenGenerator;
            _hashingHandler = hashingHandler;
            _roleMananger = roleMananger;
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register(DtoRegister model)
        {
            var user = _authManager.GetUserByEmail(model.Email);

            if (user != null)
            {
                return Ok(new { status = 201, message = "Email is exist." });
            }
            _authManager.Register(model);

            return Ok(new { status = 200, message = "Okey" });
        }

        [HttpPost("login")]
        public async Task<object> LoginUser(DtoLogin model)
        {
            var user = _authManager.Login(model.Email);
            if (user == null) return Ok(new { status = 404, message = "Bele bir istifadeci tapilmadi." });

            if (user.Email == model.Email && user.Password == _hashingHandler.CreatePasswordHash(model.Password))
            {

                var role = _roleMananger.GetRole(user.Id);
                var resultUser = new DtoUser(user.Id, user.FullName, user.Email);
                resultUser.Token = _tokenGenerator.CreateToken(user, role.Name);

                return Ok(new { status = 200, message = resultUser });
            }

            // return Ok(new { status = 404, message = "Email ve ya sifre sehfdi." });
            return Ok(_hashingHandler.CreatePasswordHash(model.Password));
        }


















        //public static User user = new User();
        //private readonly IConfiguration _configuration;

        //public AuthController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        //[HttpPost("register")]
        //public async Task<ActionResult<User>> Register(DtoUser request) {

        //    CreatePasswordHash(request.Password, out byte[] passwordHash);
        //    user.UserName = request.UserName;
        //    user.PasswordHash = passwordHash;  
        //    return Ok(user);
        //}

        //[HttpPost("login")]
        //public async Task<ActionResult<string>> Login(DtoUser request) {



        //    if (user.UserName!=request.UserName)
        //    {
        //        return BadRequest("User Not Found");
        //    }
        //    if (!VerifyPasswordHash(request))
        //    {
        //        return BadRequest("Wrong password");

        //    }

        //    string token = CreateToken(user);
        //    return Ok(token);
        //}







        //[HttpGet, Authorize]
        //public string GetMe() {

        //    var userName = User?.Identity?.Name;
        //    var userId = User.FindFirstValue(ClaimTypes.Email);
        //    return userName;

        //} 



        //private string CreateToken(User user) {

        //    List<Claim> claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name,user.UserName),
        //        new Claim(ClaimTypes.Role,"Manager")
        //    };

        //    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        //    var token = new JwtSecurityToken(
        //        claims:claims,
        //        expires:DateTime.Now.AddDays(1),
        //        signingCredentials:creds
        //        );
        //    var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        //    return jwt;
        //}




        //private void CreatePasswordHash(string password,out byte[] passwordHash) {

        //    using (var hmac = new HMACSHA512())
        //    {
        //        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));


        //    }        

        //}


        //private bool VerifyPasswordHash(DtoUser model) {


        //        return true;

        //}


    }
}
