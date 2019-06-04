using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoLegal.Model.OperacaoModel;
using BancoLegal.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBancoLegal.Controllers
{
    public class OperacaoController : ControllerPadrao<Operacao>
    {
        public override ServicoPadrao<Operacao> Servico()
        {
            return new ServicoOperacaoTransferencia();
        }
    }
}