using ApiBancoLegal.Exceptions;
using Microsoft.AspNetCore.Mvc;
using ServicoBancoLegal.Model;
using ServicoBancoLegal.Resources;
using ServicoBancoLegal.Servico;
using System;
using System.Linq;
using Microsoft.AspNetCore.Cors;

namespace ApiBancoLegal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("SiteCorsPolicy")]
    public abstract class ControllerPadrao<T> : ControllerBase where T : ObjetoPadrao
    {
        [HttpGet]
        public ActionResult<T> Get()
        {
            try
            {
                if (ServicoLogin().TokenIsValid(RetorneToken()))
                {
                    return Ok(Servico().Consulte());
                }

                throw new Exception(Strings.InvalidToken);
            }
            catch (Exception e)
            {
                return BadRequest(ObjetoErro(e));
            }
        }

        [HttpGet("{id}")]
        public ActionResult<T> Get(int id)
        {
            try
            {
                if (ServicoLogin().TokenIsValid(RetorneToken()))
                {
                    return Ok(Servico().Consulte(id));
                }
                   
                throw new Exception(Strings.InvalidToken);
            }
            catch (Exception e)
            {
                return BadRequest(ObjetoErro(e));
            }
        }

        [HttpPost()]
        public ActionResult<T> Cadastre([FromBody] T objeto)
        {
            try
            {
                if (ServicoLogin().TokenIsValid(RetorneToken()))
                {
                    Servico().Insert(objeto);
                    return Ok(Strings.Sucess);
                }
                    
                throw new Exception(Strings.InvalidToken);
            }
            catch (Exception e)
            {
                return BadRequest(ObjetoErro(e));
            }
        }

        [HttpPut()]
        public ActionResult<object> Atualize([FromBody] T objeto)
        {
            try
            {
                if (ServicoLogin().TokenIsValid(RetorneToken()))
                {
                    Servico().Atualize(objeto);
                    return Ok(Strings.Sucess);
                }
                    
                throw new Exception(Strings.InvalidToken);
            }
            catch (Exception e)
            {
                return BadRequest(ObjetoErro(e));
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<T> Delete(int id)
        {
            try
            {
                if (ServicoLogin().TokenIsValid(RetorneToken()))
                {
                    Servico().Delete(id);
                    return Ok(Strings.Sucess);
                }
                    
                throw new Exception(Strings.InvalidToken);
            }
            catch (Exception e)
            {
                return BadRequest(ObjetoErro(e));
            }
        }

        public abstract ServicoPadrao<T> Servico();

        private static ActionResult<object> ObjetoErro(Exception e)
        {
            return new ObjetoErro(e);
        }

        private Guid RetorneToken()
        {
            if (Request.Headers.TryGetValue("Token", out var valoresHeader))
            {
                return Guid.Parse(valoresHeader.First());
            }

            return Guid.Empty;
        }

        private ServicoLogin ServicoLogin()
        {
            return new ServicoLogin();
        }
    }
}
