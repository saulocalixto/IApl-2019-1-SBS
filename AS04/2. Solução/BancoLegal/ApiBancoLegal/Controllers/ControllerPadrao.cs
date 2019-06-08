using ApiBancoLegal.Exceptions;
using Microsoft.AspNetCore.Mvc;
using ServicoBancoLegal.Model;
using ServicoBancoLegal.Servico;
using System;

namespace ApiBancoLegal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ControllerPadrao<T> : ControllerBase where T : ObjetoPadrao
    {
        [HttpGet]
        public ActionResult<object> Get()
        {
            try
            {
                return Servico().Consulte();
            }
            catch (Exception e)
            {
                return ObjetoErro(e);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<object> Get(int id)
        {
            try
            {
                return Servico().Consulte(id);
            }
            catch (Exception e)
            {
                return ObjetoErro(e);
            }
        }

        [HttpPost()]
        public ActionResult<object> Cadastre([FromBody] T objeto)
        {
            try
            {
                return Servico().Insert(objeto);
            }
            catch (Exception e)
            {
                return ObjetoErro(e);
            }
        }

        [HttpPut()]
        public ActionResult<object> Atualize([FromBody] T objeto)
        {
            try
            {
                return Servico().Atualize(objeto);
            }
            catch (Exception e)
            {
                return ObjetoErro(e);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<object> Delete(int id)
        {
            try
            {
                return Servico().Delete(id);
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
    }
}
