using System;
using ServicoBancoLegal.Model.DataAnnotations;
using ServicoBancoLegal.Model.SessaoModel;

namespace ServicoBancoLegal.Model.LoginModel
{
    public class Sessao : ObjetoPadrao
    {
        [Importacao(NomeCampo = "IdConta", Tamanho = 5, Posicao = 1, Tipo = TiposEnum.Numerico)]
        public int IdConta { get; set; }

        [Importacao(NomeCampo = "Email", Tamanho = 50, Posicao = 2, Tipo = TiposEnum.Texto)]
        public string Email { get; set; }

        [Importacao(NomeCampo = "Token", Tamanho = 40, Posicao = 3, Tipo = TiposEnum.Texto)]
        public Guid Token { get; set; }

        [Importacao(NomeCampo = "Internacionalizacao", Tamanho = 4, Posicao = 3, Tipo = TiposEnum.Enumerador)]
        public EnumInternacionalizacao Internacionalizacao { get; set; }
    }
}
