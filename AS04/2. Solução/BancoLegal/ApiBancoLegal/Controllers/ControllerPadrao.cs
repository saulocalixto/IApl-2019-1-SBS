using ApiBancoLegal.Exceptions;
using ApiBancoLegal.RequestObjects;
using Microsoft.AspNetCore.Mvc;
using ServicoBancoLegal.Model;
using ServicoBancoLegal.Resources;
using ServicoBancoLegal.Servico;
using System;

namespace ApiBancoLegal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ControllerPadrao<T> : ControllerBase where T : ObjetoPadrao
    {
        [HttpGet]
        public ActionResult<object> Get([FromBody] ObjetoRequisicao<T> requisicao)
        {
            try
            {
                if (ValidarToken(requisicao.token))
                    return Servico().Consulte();
                else
                    throw new Exception(Strings.InvalidToken);
            }
            catch (Exception e)
            {
                return ObjetoErro(e);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<object> Get(int id, [FromBody] ObjetoRequisicao<T> requisicao)
        {
            try
            {
                if (ValidarToken(requisicao.token))
                    return Servico().Consulte(id);
                else
                    throw new Exception(Strings.InvalidToken);
            }
            catch (Exception e)
            {
                return ObjetoErro(e);
            }
        }

        [HttpPost()]
        public ActionResult<object> Cadastre([FromBody] ObjetoRequisicao<T> requisicao)
        {
            try
            {
                if (ValidarToken(requisicao.token))
                    return Servico().Insert(requisicao.objeto);
                else
                    throw new Exception(Strings.InvalidToken);
            }
            catch (Exception e)
            {
                return ObjetoErro(e);
            }
        }

        [HttpPut()]
        public ActionResult<object> Atualize([FromBody] ObjetoRequisicao<T> requisicao)
        {
            try
            {
                if (ValidarToken(requisicao.token))
                    return Servico().Atualize(requisicao.objeto);
                else
                    throw new Exception(Strings.InvalidToken);
            }
            catch (Exception e)
            {
                return ObjetoErro(e);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<object> Delete(int id, [FromBody] ObjetoRequisicao<T> requisicao)
        {
            try
            {
                if (ValidarToken(requisicao.token))
                    return Servico().Delete(id);
                else
                    throw new Exception(Strings.InvalidToken);
            }
            catch (Exception e)
            {
                return ObjetoErro(e);
            }
        }

        public abstract ServicoPadrao<T> Servico();

        private static ActionResult<object> ObjetoErro(Exception e)
        {
            return new ObjetoErro(e);
        }

        private static bool ValidarToken(string token)
        {
            return new ServicoLogin().ValidarToken(token);
        }
    }
}
