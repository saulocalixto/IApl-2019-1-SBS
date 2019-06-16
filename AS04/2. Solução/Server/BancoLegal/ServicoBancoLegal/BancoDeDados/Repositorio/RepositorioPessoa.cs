using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using MySql.Data.MySqlClient;
using ServicoBancoLegal.Model.PessoaModel;

namespace ServicoBancoLegal.BancoDeDados.Repositorio
{
    public class RepositorioPessoa : RepositorioPadrao<Pessoa>
    {
        protected override void MapeieCampos(Pessoa pessoa, MySqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@id", pessoa.Id);
            cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
            cmd.Parameters.AddWithValue("@email", pessoa.Email);
            cmd.Parameters.AddWithValue("@cpf", pessoa.Cpf);
            cmd.Parameters.AddWithValue("@data", pessoa.DataNascimento);
            cmd.Parameters.AddWithValue("@endereco", pessoa.Endereco);
        }

        protected override List<Pessoa> Consulte(DbDataReader reader)
        {
            var lista = new List<Pessoa>();
            while (reader.Read())
            {
                var pessoa = new Pessoa
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Email = reader.GetString(2),
                    Cpf = reader.GetString(3),
                    DataNascimento = reader.GetDateTime(4),
                    Endereco = reader.GetString(5)
                };

                lista.Add(pessoa);
            }
            return lista;
        }

        protected override string StringDeInsert()
        {
            return "Insert into PESSOA (NOME, EMAIL, CPF, DATANASCIMENTO, ENDERECO) Values (@nome, @email, @cpf, @data, @endereco);";
        }

        protected override string StringDeUpdate()
        {
            var query = new StringBuilder();

            query.Append("UPDATE PESSOA ")
                .AppendLine("SET Nome = @nome,")
                .AppendLine("CPF = @cpf,")
                .AppendLine("EMAIL = @email,")
                .AppendLine("DATANASCIMENTO = @data,")
                .AppendLine("ENDERECO = @endereco")
                .AppendLine("WHERE ID = @id");

            return query.ToString();
        }

        protected override string NomeTabela()
        {
            return "PESSOA";
        }
    }
}
