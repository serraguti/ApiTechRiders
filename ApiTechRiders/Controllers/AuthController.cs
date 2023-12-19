using ApiTechRiders.Helpers;
using ApiTechRiders.Models;
using ApiTechRiders.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ApiTechRiders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private RepositoryTechRiders repo;
        private HelperToken helper;

        public AuthController(HelperToken helper,
            RepositoryTechRiders repo)
        {
            this.repo = repo;
            this.helper = helper;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Login(LoginModel model)
        {
            Usuario user = await
                this.repo.FindUsuarioPasswordAsync(model.Email,
                model.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            else
            {
                //UN TOKEN CONTIENE UNAS CREDENCIALES
                SigningCredentials credentials =
                    new SigningCredentials(this.helper.GetKeyToken()
                    , SecurityAlgorithms.HmacSha256);
                string jsonUser = JsonConvert.SerializeObject(user);
                Claim[] infoUser = new[]
                {
                    new Claim("UserData", jsonUser)
                };
                //ES EL MOMENTO DE GENERAR EL TOKEN
                //EL TOKEN ESTARA COMPUESTO POR ISSUER, AUDIENCE, CREDENTIALS
                //TIME
                JwtSecurityToken token =
                    new JwtSecurityToken(
                        claims: infoUser,
                        issuer: this.helper.Issuer,
                        audience: this.helper.Audience,
                        signingCredentials: credentials,
                        expires: DateTime.UtcNow.AddMinutes(30),
                        notBefore: DateTime.UtcNow
                        );
                //DEVOLVEMOS UNA RESPUESTA CORRECTA CON EL TOKEN
                return Ok(
                    new
                    {
                        response =
                        new JwtSecurityTokenHandler().WriteToken(token)
                    });
            }
        }
    }
}
