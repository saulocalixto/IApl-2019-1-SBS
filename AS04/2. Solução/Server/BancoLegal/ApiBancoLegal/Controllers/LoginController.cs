using ApiBancoLegal.Exceptions;
using Microsoft.AspNetCore.Mvc;
using ServicoBancoLegal.Model.LoginModel;
using ServicoBancoLegal.Resources;
using ServicoBancoLegal.Servico;
using System;
using ApiBancoLegal.RequestObjects;
using Microsoft.AspNetCore.Cors;
using ServicoBancoLegal.Model.SessaoModel;

namespace ApiBancoLegal.Controllers
{
    [ApiController]
    [Route("api/login")]
    [EnableCors("SiteCorsPolicy")]
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
                    Internacionalizacao = (EnumInternacionalizacao) login.internacionalizacao,
                    Email = login.email
                };

                sessao.Token = ServicoLogin().EfetueLogin(sessao);

                return Ok(ObjetoResult<Sessao>.ReturnResult(sessao, Strings.Sucess));
            }
            catch(Exception e)
            {
                return BadRequest(ObjetoResult<Sessao>.ReturnResultError(e));
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
