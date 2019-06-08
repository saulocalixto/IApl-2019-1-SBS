using System;
using ServicoBancoLegal.Model.DataAnnotations;

namespace ServicoBancoLegal.Model.OperacaoModel
{
    public class Operacao : ObjetoPadrao
    {
        [Importacao(NomeCampo = "Tipo", Tamanho = 1, Posicao = 2, Tipo = TiposEnum.Enumerador)]
        public EnumTipoOperacao Tipo { get; set; }

        [Importacao(NomeCampo = "Valor", Tamanho = 20, Posicao = 3, Tipo = TiposEnum.Decimal)]
        public decimal Valor { get; set; }

        [Importacao(NomeCampo = "Data da Operação", Tamanho = 10, Posicao = 4, Tipo = TiposEnum.Data)]
        public DateTime DataDaOperacao { get; set; }

        [Importacao(NomeCampo = "Conta Origem", Tamanho = 5, Posicao = 5, Tipo = TiposEnum.Numerico)]
        public int ContaOrigem { get; set; }

        [Importacao(NomeCampo = "Conta Destino", Tamanho = 5, Posicao = 6, Tipo = TiposEnum.Numerico)]
        public int ContaDestino { get; set; }
    }
}
