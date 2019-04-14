using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BancoLegal.Model.DataAnnotations
{
    public class Importacao : Attribute
    {
        public string NomeCampo { get; set; }
        public int Tamanho { get; set; }
        public int Posicao { get; set; }
        public TiposEnum Tipo { get; set; }
        public string valor { get; set; }
    }
}
