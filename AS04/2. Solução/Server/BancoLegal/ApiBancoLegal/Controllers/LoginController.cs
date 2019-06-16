using ApiBancoLegal.Exceptions;
using Microsoft.AspNetCore.Mvc;
using ServicoBancoLegal.Model.LoginModel;
using ServicoBancoLegal.Resources;
using ServicoBancoLegal.Servico;
using System;
using ApiBancoLegal.RequestObjects;
using ServicoBancoLegal.Model.SessaoModel;

namespace ApiBancoLegal.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public ActionResult Login([FromBody] ObjetoValidacao login)
        {
            try
            {
                var idConta = ServicoContaCorrente().ConsulteIdDaConta(login.senha, login.email);

                var sessao = new Sessao
                {
                    IdConta = idConta,
                    Internacionalizacao = (EnumInternacionalizacao) login.internacionalizacao
                };

                var token = ServicoLogin().EfetueLogin(sessao);

                return Ok(new { Token =  token });
            }
            catch(Exception e)
            {
                return BadRequest(new ObjetoErro(e));
            }
        }

        private ServicoContaCorrente ServicoContaCorrente()
        {
            return new ServicoContaCorrente();
        }

        private ServicoLogin ServicoLogin()
        {
            return new ServicoLogin();
        }
    }
}
