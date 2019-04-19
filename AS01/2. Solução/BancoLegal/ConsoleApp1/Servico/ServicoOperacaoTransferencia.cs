using BancoLegal.BancoDeDados.Repositorio;
using BancoLegal.Model.OperacaoModel;
using BancoLegal.Servico.Utilitario;

namespace BancoLegal.Servico
{
    public class ServicoOperacaoTransferencia : ServicoPadrao<Operacao>
    {
        public override void ImporteArquivo(string caminhoArquivo)
        {
            var linhas = RetorneLinhasDeArquivo(caminhoArquivo);

            var objetos = RetorneObjetos(caminhoArquivo, linhas);

            foreach (var objeto in objetos)
            {
                var operacaoFoiAplicada = ApliqueOperacao(objeto);

                if (operacaoFoiAplicada)
                {
                    Repositorio().Cadastre(objeto);
                }
            }
        }

        protected override string NomeArquivo()
        {
            return "operacao";
        }

        protected override RepositorioPadrao<Operacao> Repositorio()
        {
            return _repositorio ?? (_repositorio = new RepositorioOperacao());
        }

        public bool ApliqueOperacao(Operacao operacao)
        {
            return (new UtilitarioDeOperacoes(operacao)).ApliqueOperacao();
        }
    }
}
