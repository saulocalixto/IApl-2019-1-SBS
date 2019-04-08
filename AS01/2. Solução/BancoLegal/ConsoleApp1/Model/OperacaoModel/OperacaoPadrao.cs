using BancoLegal.Model.ContaModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLegal.Model.OperacaoModel
{
    public abstract class OperacaoPadrao
    {
        public int Tipo { get; set; }

        public double Valor { get; set; }

        public DateTime DataDaOperacao { get; set; }

        public ContaPadrao ContaOrigem { get; set; }
    }
}
