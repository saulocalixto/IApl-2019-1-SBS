using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Text;
using MySql.Data.MySqlClient;
using ServicoBancoLegal.Model.LoginModel;
using ServicoBancoLegal.Model.SessaoModel;

namespace ServicoBancoLegal.BancoDeDados.Repositorio
{
    public class RepositorioSessao : RepositorioPadrao<Sessao>
    {
        protected override void MapeieCampos(Sessao objeto, MySqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@id", objeto.Id);
            cmd.Parameters.AddWithValue("@idConta", objeto.IdConta);
            cmd.Parameters.AddWithValue("@token", objeto.Token);
            cmd.Parameters.AddWithValue("@inter", objeto.Internacionalizacao);
        }

        protected override List<Sessao> Consulte(DbDataReader reader)
        {
            var lista = new List<Sessao>();
            while (reader.Read())
            {
                var sessao = new Sessao
                {
                    Id = reader.GetInt32(0),
                    IdConta = reader.GetInt32(1),
                    Token = reader.GetGuid(2),
                    Internacionalizacao = (EnumInternacionalizacao)reader.GetInt32(3)
                };

                lista.Add(sessao);
            }

            return lista;
        }

        public Guid GetToken(int idConta)
        {
            using (var conn = new MySqlConnection(stringConexao))
            {
                conn.Open();

                using (var cmd = new MySqlCommand(RetorneConsultaToken(idConta), conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader.GetGuid(0);
                        }

                        return Guid.Empty;
                    }
                }
            }
        }

        public bool TokenIsValid(Guid token)
        {
            using (var conn = new MySqlConnection(stringConexao))
            {
                conn.Open();

                using (var cmd = new MySqlCommand(RetorneConsultaTokenValido(token), conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return true;
                        }

                        return false;
                    }
                }
            }
        }

        protected override string StringDeInsert()
        {
            return "Insert into SESSAO(IDCONTA, TOKEN, INTER) Values(@idConta, @token, @inter);";
        }

        protected override string StringDeUpdate()
        {
            var query = new StringBuilder();

            query.Append("UPDATE SESSAO ")
                .AppendLine("SET Token = @token")
                .AppendLine("WHERE ID = @id");

            return query.ToString();
        }

        protected override string NomeTabela()
        {
            return "SESSAO";
        }

        private string RetorneConsultaToken(int idConta)
        {
            return $"SELECT TOKEN FROM SESSAO WHERE IDCONTA = {idConta};";
        }

        private string RetorneConsultaTokenValido(Guid token)
        {
            return $"SELECT ID FROM SESSAO WHERE TOKEN = '{token.ToString().ToUpperInvariant()}';";
        }
    }
}
