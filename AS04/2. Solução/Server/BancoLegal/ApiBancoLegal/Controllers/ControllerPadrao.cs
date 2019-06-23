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
                if (ServiceLogin().TokenIsValid(RetorneToken()))
                {
                    return Ok(ObjetoResult<T>.ReturnResult(Service().Consulte(), Strings.Sucess));
                }

                throw new Exception(Strings.InvalidToken);
            }
            catch (Exception e)
            {
                return BadRequest(ObjetoResult<T>.ReturnResultError(e));
            }
        }

        [HttpGet("{id}")]
        public ActionResult<T> Get(int id)
        {
            try
            {
                if (ServiceLogin().TokenIsValid(RetorneToken()))
                {
                    return Ok(ObjetoResult<T>.ReturnResult(Service().Consulte(id), Strings.Sucess));
                }
                   
                throw new Exception(Strings.InvalidToken);
            }
            catch (Exception e)
            {
                return BadRequest(ObjetoResult<T>.ReturnResultError(e));
            }
        }

        [HttpPost]
        public ActionResult<T> Cadastre([FromBody] T objeto)
        {
            try
            {
                if (ServiceLogin().TokenIsValid(RetorneToken()))
                {
                    ExecuteServiceInsert(objeto);
                    return Ok(ObjetoResult<T>.ReturnResult(Strings.Sucess));
                }
                    
                throw new Exception(Strings.InvalidToken);
            }
            catch (Exception e)
            {
                return BadRequest(ObjetoResult<T>.ReturnResultError(e));
            }
        }

        [HttpPut]
        public ActionResult<object> Atualize([FromBody] T objeto)
        {
            try
            {
                if (ServiceLogin().TokenIsValid(RetorneToken()))
                {
                    Service().Atualize(objeto);
                    return Ok(ObjetoResult<T>.ReturnResult(Strings.Sucess));
                }
                    
                throw new Exception(Strings.InvalidToken);
            }
            catch (Exception e)
            {
                return BadRequest(ObjetoResult<T>.ReturnResultError(e));
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<T> Delete(int id)
        {
            try
            {
                if (ServiceLogin().TokenIsValid(RetorneToken()))
                {
                    Service().Delete(id);
                    return Ok(ObjetoResult<T>.ReturnResult(Strings.Sucess));
                }
                    
                throw new Exception(Strings.InvalidToken);
            }
            catch (Exception e)
            {
                return BadRequest(ObjetoResult<T>.ReturnResultError(e));
            }
        }

        public abstract ServicoPadrao<T> Service();

        protected virtual void ExecuteServiceInsert(T obj)
        {
            Service().Insert(obj);
        }

        private Guid RetorneToken()
        {
            if (Request.Headers.TryGetValue("Token", out var valoresHeader))
            {
                return Guid.Parse(valoresHeader.First());
            }

            return Guid.Empty;
        }

        private ServicoLogin ServiceLogin()
        {
            return new ServicoLogin();
        }
    }
}
