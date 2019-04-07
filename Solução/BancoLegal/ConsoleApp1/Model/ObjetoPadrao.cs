using BancoLegal.Model.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoLegal.Model
{
    public abstract class ObjetoPadrao
    {
        [Importacao(NomeCampo = "Id", Tamanho = 5, Posicao = 1, Tipo = TiposEnum.Numerico)]
        public int Id { get; set; }
    }
}
