using System;
using System.Collections.Generic;
using System.Linq;
using ServicoBancoLegal.BancoDeDados.Repositorio;
using ServicoBancoLegal.Model;
using ServicoBancoLegal.Resources;

namespace ServicoBancoLegal.Servico
{
    public abstract class ServicoPadrao<T> : IServico<T> where T : ObjetoPadrao
    {
        #region PROPRIEDADES
        protected RepositorioPadrao<T> _repositorio;
        #endregion

        #region MÉTODOS PÚBLICOS

        /// <summary>
        /// Importa um arquivo de texto e salva-o no banco de dados.
        /// </summary>
        /// <param name="objeto">Objeto a ser cadastrado.</param>
        public virtual void Insert(T objeto)
        {
            if (!ObjetoExiste(objeto.Id))
            {
                Repositorio().Cadastre(objeto);
            }
        }

        /// <summary>
        /// Consulta um conceito por id e o retorna para o usuário em formato de arquivo de texto.
        /// </summary>
        /// <param name="Id">Id do conceito pesquisado.</param>
        /// <returns>Retorna a string que representa o objeto pesquisado.</returns>
        public T Consulte(int Id)
        {
            T objeto = Repositorio().Consulte(Id);

            if (objeto == null || Id != objeto.Id)
            {
                throw new Exception(Strings.ObjectNotFound);
            }

            return objeto;
        }

        /// <summary>
        /// Consulta uma lista de objetos.
        /// </summary>
        /// <returns>Retorna lista de objetos.</returns>
        public List<T> Consulte()
        {
            var lista = Repositorio().ConsulteTodos();

            if (!lista.Any())
            {
                throw new Exception(Strings.ObjectsNotFound);
            }

            return lista;
        }

        /// <summary>
        /// Atualiza um objeto.
        /// </summary>
        /// <param name="objeto">Objeto a ser atualizado.</param>
        public void Atualize(T objeto)
        {
            if (ObjetoExiste(objeto.Id))
            {
                Repositorio().Atualize(objeto);
            }
            else
            {
                Console.Error.WriteLine(string.Format(Strings.ObjectAlreadyRegistered, objeto.Id));
            }
        }

        /// <summary>
        /// Verifica se objeto existe no banco.
        /// </summary>
        /// <param name="Id">Id do objeto a ser consultado.</param>
        /// <returns>Retorna indicador de sua existência.</returns>
        public bool ObjetoExiste(int Id)
        {
            return Repositorio().ExisteObjeto(Id);
        }

        public void Delet(int id)
        {
            if (ObjetoExiste(id))
            {
                Repositorio().Delet(id);
            }
            else
            {
                throw new Exception(Strings.ObjectsNotFound);
            }
        }

        #endregion

        #region MÉTODOS PROTECTED

        protected abstract RepositorioPadrao<T> Repositorio();

        #endregion

        #region MÉTODOS PRIVADOS
        #endregion
    }
}
