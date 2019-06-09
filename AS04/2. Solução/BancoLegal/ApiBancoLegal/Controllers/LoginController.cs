using ApiBancoLegal.Exceptions;
using Microsoft.AspNetCore.Mvc;
using ServicoBancoLegal.Model.LoginModel;
using ServicoBancoLegal.Servico;
using System;

namespace ApiBancoLegal.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public ActionResult<object> Login([FromBody] Login login)
        {
            var result = new ServicoLogin().EfetueLogin(login);
            if (result)
            {
                return new ServicoLogin().GerarToken(login.IdConta);
            }
            else
            {
                return new ObjetoErro(new Exception("Senha inválida! Não foi possível realizar o login."));
            }
        }
    }
}
