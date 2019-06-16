using ServicoBancoLegal.Servico;

namespace ApiBancoLegal.RequestObjects
{
    public class ObjetoValidacao
    {
        public string email { get; set; }
        public string senha { get; set; }
        public int internacionalizacao { get; set; }
    }
}
