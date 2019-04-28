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
        protected UtilitarioJson<T> _utilitarioJson;

        #endregion

        #region MÉTODOS PÚBLICOS

        public ServicoPadrao()
        {
            _utilitarioDeImportacao = new UtilitarioDeImportacao();
            _utilitarioJson = new UtilitarioJson<T>();
        }

        /// <summary>
        /// Importa um arquivo de texto e salva-o no banco de dados.
        /// </summary>
        /// <param name="caminhoArquivo">Caminho em que se encontra o arquivo.</param>
        public virtual void ImporteArquivo(string caminhoArquivo)
        {
            var linhas = RetorneLinhasDeArquivo(caminhoArquivo);

            var objetos = RetorneObjetos(caminhoArquivo, linhas);

            foreach (var objeto in objetos)
            {
                if(Consulte(objeto.Id).Equals("Conceito não cadastrado."))
                {
                    Repositorio().Cadastre(objeto);
                }
                else
                {
                    Console.Error.WriteLine("Objeto importado de id " + objeto.Id + " já cadastrado.");
                }
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

        /// <summary>
        /// Atualiza um objeto.
        /// </summary>
        /// <param name="objeto">Objeto a ser atualizado.</param>
        public void Atualize(T objeto)
        {
            if (!Consulte(objeto.Id).Equals("Conceito não cadastrado."))
            {
                Repositorio().Atualize(objeto);
            }
            else
            {
                Console.Error.WriteLine("Objeto importado de id " + objeto.Id + " não foi encontrado.");
            }
        }

        #endregion

        #region MÉTODOS PROTECTED

        protected List<T> RetorneObjetos(string caminhoArquivo, List<string> linhas)
        {
            return caminhoArquivo.EndsWith("txt")
                ? RetorneObjetosDeArquivo(linhas)
                : _utilitarioJson.JsonParaObjeto(linhas);
        }

        protected List<string> RetorneLinhasDeArquivo(string caminho)
        {
            var utilitarioLeitor = new UtilitarioLeitorDeArquivo(caminho);

            var linhas = utilitarioLeitor.RetorneLinhas();

            return linhas;
        }

        protected abstract RepositorioPadrao<T> Repositorio();

        protected abstract string NomeArquivo();
        #endregion

        #region MÉTODOS PRIVADOS

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
