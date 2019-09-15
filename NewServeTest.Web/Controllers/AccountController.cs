﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace NewServeTest.Web.Controllers
{
    public class LoginViewvModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class UserViewvModel
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
    }

    [Route("api/[controller]")]
    public class AccountController : Controller
    {

        public AccountController()
        {
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody]LoginViewvModel loginViewvModel)
        {
            if (ModelState.IsValid)
            {

                if (loginViewvModel.Username == "rr1980" && loginViewvModel.Password == "12003")
                {
                    var claims = new List<Claim>()
                    {
                        new Claim("UserId", (99).ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

                    //foreach (var role in result.Benutzer.UserRights)
                    //{
                    //    claims.Add(new Claim("role", role));
                    //}

                    var now = DateTime.UtcNow;

                    var token = new JwtSecurityToken
                    (
                        issuer: "dotnetthoughts.net",
                        audience: "dotnetthoughts.net",
                        claims: claims.ToArray(),
                        notBefore: now,
                        expires: now.Add(TimeSpan.FromMinutes(100)),
                        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ur390348490tsjf8sdjkdf0348490ts34849d2ad")), SecurityAlgorithms.HmacSha256)
                    );


                    var rt = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(new UserViewvModel
                    {
                        Username = "rr1980",
                        FirstName = "Rene",
                        LastName = "Riesner",
                        Token = rt
                    });
                }
                else
                {
                    return StatusCode(403,"Benutzer oder Passwort falsch!!!") ;
                }
            }

            return BadRequest("Eingabe konnte nicht verarbeitet werden!");
        }

        //[HttpPost("Login")]
        //public async Task<LoginResultViewModel> Login([FromBody]LoginViewvModel loginViewvModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = new BenutzerValidationResultModel();

        //        if (loginViewvModel.Username == "rr1980" && loginViewvModel.Password == "12003")
        //        {
        //            result.Benutzer = new UserViewvModel
        //            {
        //                Id = 99,
        //                Username = "rr1980",
        //                FirstName = "Rene",
        //                LastName = "Riesner"
        //            };
        //        }
        //        else
        //        {
        //            result.Fail = true;
        //            result.ErrMsg = "Benutzer oder Passwort falsch!!!";
        //        }

        //        if (result.Fail)
        //        {
        //            return new LoginResultViewModel
        //            {
        //                Ok = false,
        //                Msg = result.ErrMsg
        //            };
        //        }

        //        if (result.Benutzer == null)
        //        {
        //            throw new NullReferenceException();
        //        }

        //        var claims = new List<Claim>()
        //        {
        //            new Claim("UserId", result.Benutzer.Id.ToString()),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //        };

        //        //foreach (var role in result.Benutzer.UserRights)
        //        //{
        //        //    claims.Add(new Claim("role", role));
        //        //}

        //        var now = DateTime.UtcNow;

        //        var token = new JwtSecurityToken
        //        (
        //            issuer: "dotnetthoughts.net",
        //            audience: "dotnetthoughts.net",
        //            claims: claims.ToArray(),
        //            notBefore: now,
        //            expires: now.Add(TimeSpan.FromMinutes(100)),
        //            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ur390348490tsjf8sdjkdf0348490ts34849d2ad")), SecurityAlgorithms.HmacSha256)
        //        );


        //        var rt = new JwtSecurityTokenHandler().WriteToken(token);

        //        return new LoginResultViewModel
        //        {
        //            Ok = true,
        //            Token = rt
        //        };
        //    }

        //    return new LoginResultViewModel
        //    {
        //        Ok = false,
        //        Msg = "Eingabe konnte nicht verarbeitet werden!"
        //    };
        //}

        //[Authorize]
        //[HttpPost("UserInfo")]
        //public async Task<IActionResult> UserInfo()
        //{
        //    long userId = long.Parse(User.FindFirst("UserId").Value, CultureInfo.CurrentCulture);

        //    UserViewvModel userInfo = await _benutzerService.GetUserInfo(userId);

        //    var claims = new List<Claim>()
        //        {
        //            new Claim("UserId", userInfo.Id.ToString()),
        //            new Claim("UserName", userInfo.Username),
        //            new Claim("FirstName", userInfo.FirstName),
        //            new Claim("LastName", userInfo.LastName),

        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //        };

        //    foreach (var rights in userInfo.UserRights)
        //    {
        //        claims.Add(new Claim("role", rights));
        //    }

        //    var now = DateTime.UtcNow;

        //    var token = new JwtSecurityToken
        //    (
        //        issuer: _options.Security.Issuer,
        //        audience: _options.Security.Audience,
        //        claims: claims.ToArray(),
        //        notBefore: now,
        //        expires: now.Add(TimeSpan.FromMinutes(_options.Security.LoginExpires)),
        //        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Security.SecurityKey)), SecurityAlgorithms.HmacSha256)
        //    );

        //    var rt = new JwtSecurityTokenHandler().WriteToken(token);
        //    return Ok(new { token = rt });
        //}
    }
}