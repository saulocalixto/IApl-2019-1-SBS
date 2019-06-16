using ServicoBancoLegal.Resources;

namespace ServicoBancoLegal.BancoDeDados
{
    public class ConexaoBanco
    {
        public readonly string stringConexao;

        public ConexaoBanco()
        {
            stringConexao = Database.ConnectionString;
        }

        public ConexaoBanco(string stringConexao)
        {
            this.stringConexao = stringConexao;
        }
    }
}
