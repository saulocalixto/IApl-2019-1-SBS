using BancoLegal.Model.ContaModel;
using MySql.Data.MySqlClient;
using System;
using System.Data.Common;

namespace BancoLegal.BancoDeDados.Repositorio
{
    class RepositorioContaCorrente : RepositorioPadrao<ContaCorrente>
    {
        protected override void MapeieCampos(ContaCorrente conta, MySqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@id", conta.Id);
            cmd.Parameters.AddWithValue("@numero", conta.Numero);
            cmd.Parameters.AddWithValue("@agencia", conta.Agencia);
            cmd.Parameters.AddWithValue("@titular", conta.Titular);
            cmd.Parameters.AddWithValue("@senha", conta.Senha);
            cmd.Parameters.AddWithValue("@saldo", conta.Saldo);
            cmd.Parameters.AddWithValue("@limite", conta.Limite);
            cmd.Parameters.AddWithValue("@status", conta.Ativo);
        }

        protected override ContaCorrente Consulte(DbDataReader reader)
        {
            ContaCorrente conta = new ContaCorrente();
            while (reader.Read())
            {
                conta.Id = reader.GetInt32(0);
                conta.Numero = reader.GetInt32(1);
                conta.Agencia = reader.GetInt32(2);
                conta.Titular = reader.GetInt32(3);
                conta.Senha = reader.GetString(4);
                conta.Saldo = reader.GetDecimal(5);
                conta.Limite = reader.GetDecimal(6);
                conta.Ativo = reader.GetBoolean(7);
            }
            return conta;
        }

        protected override string StringDeSelect()
        {
            return "SELECT * FROM conta WHERE id = @id";
        }

        protected override string StringDeInsert()
        {
            return "Insert into CONTA (ID, NUMERO, AGENCIA, TITULAR, SENHA," +
                " SALDO, LIMITE, STATUS, TIPO) Values (@id, @numero, @agencia, @titular, @senha, @saldo, @limite, @status, 1);";
        }
    }
}
