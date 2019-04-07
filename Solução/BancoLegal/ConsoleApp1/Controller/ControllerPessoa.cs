using BancoLegal.Model.PessoaModel;
using MySql.Data.MySqlClient;
using System;
using System.Data.Common;

namespace BancoLegal.Controller
{
    class ControllerPessoa : ConexaoBanco
    {
        public Pessoa GetPessoa(int id)
        {
            try
            {
                using (var conn = new MySqlConnection(stringConexao))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand("SELECT * FROM pessoa WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            return GetPessoa(reader);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return null;
        }

        private Pessoa GetPessoa(DbDataReader reader)
        {
            Pessoa p = new Pessoa();
            while (reader.Read())
            {
                p.Id = int.Parse(reader.GetString(0));
                p.Nome = reader.GetString(1);
                p.Cpf = reader.GetString(2);
                p.DataNascimento = reader.GetDateTime(3);
                p.Endereco = reader.GetString(4);
            }
            return p;
        }
    }
}
