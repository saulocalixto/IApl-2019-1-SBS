using MySql.Data.MySqlClient;
using ServicoBancoLegal.BancoDeDados.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using Strings = ServicoBancoLegal.Resources.Strings;

namespace ServicoBancoLegal.BancoDeDados.Repositorio
{
    public abstract class RepositorioPadrao<T> : ConexaoBanco, IRepositorio<T>
    {
        #region MÉTODOS PÚBLICOS
        /// <summary>
        /// Consulte um conceito pelo id.
        /// </summary>
        /// <param name="id">Id do conceito consultado.</param>
        /// <returns>Retorna o objeto relacionado àquele conceito.</returns>
        public T Get(int id)
        {
            using (var conn = new MySqlConnection(stringConexao))
            {
                conn.Open();

                using (var cmd = new MySqlCommand(StringDeSelect(), conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        return Consulte(reader).FirstOrDefault();
                    }
                }
            }
        }

        /// <summary>
        /// Consulte todos os conceitos.
        /// </summary>
        /// <returns>Retorna Lista de objetos.</returns>
        public List<T> ConsulteTodos()
        {
            using (var conn = new MySqlConnection(stringConexao))
            {
                conn.Open();

                using (var cmd = new MySqlCommand(StringDeSelectTodos(), conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        return Consulte(reader);
                    }
                }
            }
        }

        /// <summary>
        /// Cadastre um conceito.
        /// </summary>
        /// <param name="objeto">Objeto a ser cadastrado.</param>
        public void Insert(T objeto)
        {
            ExecuteQuery(objeto, StringDeInsert());
        }

        /// <summary>
        /// Deleta um item no banco.
        /// </summary>
        /// <param name="id">Id do item a ser deletado.</param>
        public void Delete(int id)
        {
            try
            {
                var query = StringDeDelete();
                ExecuteQuery(string.Format(query, id));
            }
            catch (Exception e)
            {
                throw new Exception(Strings.DeleteError);
            }
            
        }

        /// <summary>
        /// Verifica se item está cadastrado.
        /// </summary>
        /// <param name="id">Id do item cadastrado.</param>
        /// <returns>Retorna se o item existe ou não.</returns>
        public bool ObjectExists(int id)
        {
            try
            {
                using (var conn = new MySqlConnection(stringConexao))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand(StringDeExisteItem(), conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            return reader.HasRows;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public void Update(T objeto)
        {
            try
            {
                ExecuteQuery(objeto, StringDeUpdate());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Cadastre um conceito.
        /// </summary>
        /// <param name="objeto">Objeto a ser cadastrado.</param>
        private void ExecuteQuery(T objeto, string query)
        {
            using (var conn = new MySqlConnection(stringConexao))
            {
                conn.Open();

                using (var cmd = new MySqlCommand(query, conn))
                {
                    MapeieCampos(objeto, cmd);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Cadastre um conceito.
        /// </summary>
        /// <param name="query">Query a ser executada.</param>
        private void ExecuteQuery(string query)
        {
            using (var conn = new MySqlConnection(stringConexao))
            {
                conn.Open();

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region MÉTODOS PROTECTED
        protected abstract void MapeieCampos(T objeto, MySqlCommand cmd);
        protected abstract List<T> Consulte(DbDataReader reader);
        protected abstract string StringDeInsert();
        protected abstract string StringDeUpdate();
        protected abstract string NomeTabela();

        #endregion

        #region MÉTODOS PRIVATES

        private string StringDeSelectTodos()
        {
            var stringBuilder = new StringBuilder();

            MonteQuerySelect(stringBuilder);

            return stringBuilder.ToString();
        }

        private string StringDeDelete()
        {
            var stringBuilder = new StringBuilder();

            MonteQueryDelete(stringBuilder);

            return stringBuilder.ToString();
        }

        private string StringDeSelect()
        {
            var stringBuilder = new StringBuilder();
            MonteQuerySelect(stringBuilder);

            FiltrePorId(stringBuilder);

            return stringBuilder.ToString();
        }

        private string StringDeExisteItem()
        {
            var stringBuilder = new StringBuilder();
            MonteQueryExisteItem(stringBuilder);

            FiltrePorId(stringBuilder);

            return stringBuilder.ToString();
        }

        private void MonteQuerySelect(StringBuilder stringBuilder)
        {
            stringBuilder.Append("SELECT * FROM ")
                            .Append(NomeTabela());
        }

        private void MonteQueryExisteItem(StringBuilder stringBuilder)
        {
            stringBuilder.Append("SELECT ID FROM ")
                .Append(NomeTabela());
        }

        private void MonteQueryDelete(StringBuilder stringBuilder)
        {
            stringBuilder.Append("DELETE FROM ")
                .Append(NomeTabela())
                .Append(" WHERE ID = {0};");
        }

        private static void FiltrePorId(StringBuilder stringBuilder)
        {
            stringBuilder.Append(" WHERE ID = @id");
        }

        #endregion
    }
}
