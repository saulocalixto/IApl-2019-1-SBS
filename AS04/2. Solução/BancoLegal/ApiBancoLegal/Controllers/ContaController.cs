using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoLegal.Model.ContaModel;
using BancoLegal.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBancoLegal.Controllers
{
    public class ContaController : ControllerPadrao<ContaCorrente>
    {
        public override ServicoPadrao<ContaCorrente> Servico()
        {
            return new ServicoContaCorrente();
        }
    }
}