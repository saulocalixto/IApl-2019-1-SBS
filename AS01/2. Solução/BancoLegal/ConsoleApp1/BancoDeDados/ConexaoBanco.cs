namespace BancoLegal.BancoDeDados
{
    public class ConexaoBanco
    {
        public readonly string stringConexao;

        public ConexaoBanco()
        {
            stringConexao = "Server=localhost;User ID=root;Password=123456;Database=bancolegal";
        }

        public ConexaoBanco(string stringConexao)
        {
            this.stringConexao = stringConexao;
        }
    }
}
