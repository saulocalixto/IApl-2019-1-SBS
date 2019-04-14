using BancoLegal.BancoDeDados;
using BancoLegal.Model.PessoaModel;
using MySql.Data.MySqlClient;
using System;
using System.Data.Common;

namespace BancoLegal.BancoDeDados.Repositorio
{
    public class RepositorioPessoa : RepositorioPadrao<Pessoa>
    {
        protected override void MapeieCampos(Pessoa pessoa, MySqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@id", pessoa.Id);
            cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
            cmd.Parameters.AddWithValue("@cpf", pessoa.Cpf);
            cmd.Parameters.AddWithValue("@data", pessoa.DataNascimento);
            cmd.Parameters.AddWithValue("@endereco", pessoa.Endereco);
        }

        protected override Pessoa Consulte(DbDataReader reader)
        {
            Pessoa pessoa = new Pessoa();
            while (reader.Read())
            {
                pessoa.Id = reader.GetInt32(0);
                pessoa.Nome = reader.GetString(1);
                pessoa.Cpf = reader.GetString(2);
                pessoa.DataNascimento = reader.GetDateTime(3);
                pessoa.Endereco = reader.GetString(4);
            }
            return pessoa;
        }

        protected override string StringDeSelect()
        {
            return "SELECT * FROM pessoa WHERE id = @id";
        }

        protected override string StringDeInsert()
        {
            return "Insert into PESSOA (ID, NOME, CPF, DATANASCIMENTO, ENDERECO) Values (@id, @nome, @cpf, @data, @endereco);";
        }
    }
}
