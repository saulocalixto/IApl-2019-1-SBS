using BancoLegal.BancoDeDados.Repositorio;
using BancoLegal.Model;
using BancoLegal.Model.DataAnnotations;
using BancoLegal.Servico.Utilitario;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BancoLegal.Servico
{
    public abstract class ServicoPadrao<T> : IServico<T> where T : ObjetoPadrao
    {
        #region PROPRIEDADES
        protected RepositorioPadrao<T> _repositorio;
        protected UtilitarioDeImportacao _utilitarioDeImportacao;
        #endregion

        #region MÉTODOS PÚBLICOS
        public ServicoPadrao()
        {
            _utilitarioDeImportacao = new UtilitarioDeImportacao();
        }

        /// <summary>
        /// Importa um arquivo de texto e salva-o no banco de dados.
        /// </summary>
        /// <param name="caminhoArquivo">Caminho em que se encontra o arquivo.</param>
        public void ImporteArquivo(string caminhoArquivo)
        {
            var linhas = RetorneLinhasDeArquivo(caminhoArquivo);

            foreach (var objeto in RetorneObjetosDeArquivo(linhas))
            {
                Repositorio().Cadastre(objeto);
            }
        }

        /// <summary>
        /// Consulta um conceito por id e o retorna para o usuário em formato de arquivo de texto.
        /// </summary>
        /// <param name="Id">Id do conceito pesquisado.</param>
        /// <returns>Retorna a string que representa o objeto pesquisado.</returns>
        public string Consulte(int Id)
        {
            T objeto = Repositorio().Consulte(Id);

            if (objeto == null || Id != objeto.Id)
            {
                return "Conceito não cadastrado.";
            }

            var linha = _utilitarioDeImportacao.TransformeObjetoEmLinha(objeto);

            SalveArquivo(linha);

            return linha;
        }
        #endregion

        #region MÉTODOS PROTECTED

        protected abstract RepositorioPadrao<T> Repositorio();

        protected abstract string NomeArquivo();
        #endregion

        #region MÉTODOS PRIVADOS
        private List<string> RetorneLinhasDeArquivo(string caminho)
        {
            var utilitarioLeitor = new UtilitarioLeitorDeArquivo(caminho);

            var linhas = utilitarioLeitor.RetorneLinhas();

            return linhas;
        }

        private List<T> RetorneObjetosDeArquivo(List<string> linhas)
        {
            var objetos = _utilitarioDeImportacao.TransformeLinhaEmObjeto<T>(linhas);
            return objetos;
        }

        private void SalveArquivo(string linha)
        {
            string caminho = string.Concat(Environment.CurrentDirectory, @"\" + NomeArquivo() + ".txt");
            using (StreamWriter file = new StreamWriter(caminho))
            {
                file.Write(linha);
                Console.WriteLine("Arquivo salvo em " + caminho);
            }
        }
        #endregion
    }
}
