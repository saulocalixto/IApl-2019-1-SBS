using BancoLegal.Model.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLegal.Model.LoginModel
{
    public class Login 
    {
        [Importacao(NomeCampo = "IdConta", Tamanho = 5, Posicao = 5, Tipo = TiposEnum.Numerico)]
        public int IdConta { get; set; }

        [Importacao(NomeCampo = "Senha", Tamanho = 40, Posicao = 5, Tipo = TiposEnum.Texto)]
        public string Senha { get; set; }
    }
}
