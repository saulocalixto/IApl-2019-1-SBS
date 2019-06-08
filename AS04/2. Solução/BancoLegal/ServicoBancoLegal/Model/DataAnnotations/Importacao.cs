using System;

namespace ServicoBancoLegal.Model.DataAnnotations
{
    public class Importacao : Attribute
    {
        public string NomeCampo { get; set; }
        public int Tamanho { get; set; }
        public int Posicao { get; set; }
        public TiposEnum Tipo { get; set; }
    }
}
