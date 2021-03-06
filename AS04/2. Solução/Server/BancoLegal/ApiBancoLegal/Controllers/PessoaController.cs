﻿using ServicoBancoLegal.Model.PessoaModel;
using ServicoBancoLegal.Servico;

namespace ApiBancoLegal.Controllers
{
    public class PessoaController : ControllerPadrao<Pessoa>
    {
        public override ServicoPadrao<Pessoa> Service()
        {
            return new ServicoPessoa();
        }
    }
}