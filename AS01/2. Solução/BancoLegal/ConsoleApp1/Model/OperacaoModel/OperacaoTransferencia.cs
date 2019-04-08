using BancoLegal.Model.ContaModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLegal.Model.OperacaoModel
{
    public class OperacaoTransferencia : OperacaoPadrao
    {
        public ContaPadrao ContaDestino { get; set; }
    }
}
