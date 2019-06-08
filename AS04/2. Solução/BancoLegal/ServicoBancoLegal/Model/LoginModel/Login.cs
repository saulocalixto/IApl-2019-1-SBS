using ServicoBancoLegal.Model.DataAnnotations;

namespace ServicoBancoLegal.Model.LoginModel
{
    public class Login 
    {
        [Importacao(NomeCampo = "IdConta", Tamanho = 5, Posicao = 5, Tipo = TiposEnum.Numerico)]
        public int IdConta { get; set; }

        [Importacao(NomeCampo = "Senha", Tamanho = 40, Posicao = 5, Tipo = TiposEnum.Texto)]
        public string Senha { get; set; }
    }
}
