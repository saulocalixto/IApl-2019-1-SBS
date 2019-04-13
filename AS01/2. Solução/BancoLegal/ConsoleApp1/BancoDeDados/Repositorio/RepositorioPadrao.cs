using BancoLegal.BancoDeDados.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Data.Common;

namespace BancoLegal.BancoDeDados.Repositorio
{
    public abstract class RepositorioPadrao<T> : ConexaoBanco, IRepositorio<T>
    {
        #region MÉTODOS PÚBLICOS
        /// <summary>
        /// Consulte um conceito pelo id.
        /// </summary>
        /// <param name="id">Id do conceito consultado.</param>
        /// <returns>Retorna o objeto relacionado àquele conceito.</returns>
        public T Consulte(int id)
        {
            try
            {
                using (var conn = new MySqlConnection(stringConexao))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand(StringDeSelect(), conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            return Consulte(reader);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return default(T);
        }

        /// <summary>
        /// Cadastre um conceito.
        /// </summary>
        /// <param name="objeto">Objeto a ser cadastrado.</param>
        public void Cadastre(T objeto)
        {
            try
            {
                using (var conn = new MySqlConnection(stringConexao))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand(StringDeInsert(), conn))
                    {
                        MapeieCampos(objeto, cmd);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        #endregion

        #region MÉTODOS PROTECTED
        protected abstract void MapeieCampos(T conta, MySqlCommand cmd);
        protected abstract T Consulte(DbDataReader reader);
        protected abstract string StringDeSelect();
        protected abstract string StringDeInsert();
        #endregion
    }
}
