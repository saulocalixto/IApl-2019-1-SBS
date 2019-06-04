using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoLegal.Model.PessoaModel;
using BancoLegal.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBancoLegal.Controllers
{
    public class PessoaController : ControllerPadrao<Pessoa>
    {
        public override ServicoPadrao<Pessoa> Servico()
        {
            return new ServicoPessoa();
        }
    }
}