using System.Collections.Generic;
using BancoLegal.Model;
using BancoLegal.Servico;
using Microsoft.AspNetCore.Mvc;

namespace ApiBancoLegal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ControllerPadrao<T> : ControllerBase where T : ObjetoPadrao
    {
        [HttpGet]
        public ActionResult<IEnumerable<T>> Get()
        {
            return Servico().Consulte();
        }

        [HttpGet("{id}")]
        public ActionResult<T> Get(int id)
        {
            return Servico().Consulte(id);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            Servico().ImporteArquivo(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public abstract ServicoPadrao<T> Servico();
    }
}
