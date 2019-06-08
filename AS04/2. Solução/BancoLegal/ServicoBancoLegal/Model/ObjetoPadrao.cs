using ServicoBancoLegal.Model.DataAnnotations;

namespace ServicoBancoLegal.Model
{
    public abstract class ObjetoPadrao
    {
        [Importacao(NomeCampo = "Id", Tamanho = 5, Posicao = 1, Tipo = TiposEnum.Numerico)]
        public int Id { get; set; }
    }
}
