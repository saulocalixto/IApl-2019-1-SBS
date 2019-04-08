using BancoLegal.Model.ContaModel;
using MySql.Data.MySqlClient;
using System;
using System.Data.Common;

namespace BancoLegal.Controller
{
    class ControllerContaCorrente : ConexaoBanco
    {
        public ContaCorrente GetContaCorrente(int id)
        {
            try
            {
                using (var conn = new MySqlConnection(stringConexao))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand("SELECT * FROM conta WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            return GetContaCorrente(reader);
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

        private ContaCorrente GetContaCorrente(DbDataReader reader)
        {
            ContaCorrente c = new ContaCorrente();
            while (reader.Read())
            {
                c.Id = int.Parse(reader.GetString(0));
                c.Numero = reader.GetInt32(1);
                c.Agencia = reader.GetInt32(2);
                c.Titular = reader.GetString(3);
                c.Senha = reader.GetString(4);
                c.Saldo = reader.GetDecimal(5);
                c.Limite = reader.GetDecimal(6);
                c.Ativo = reader.GetBoolean(7);
            }
            return c;
        }

        public void CadastrarContaCorrente(ContaCorrente c)
        {
            try
            {
                using (var conn = new MySqlConnection(stringConexao))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand(
                        "Insert into CONTA (ID, NUMERO, AGENCIA, TITULAR, SENHA, SALDO, LIMITE, STATUS, TIPO) Values (@id, @numero, @agencia, @titular, @senha, @saldo, @limite, @status, 1);", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", c.Id);
                        cmd.Parameters.AddWithValue("@numero", c.Numero);
                        cmd.Parameters.AddWithValue("@agencia", c.Agencia);
                        cmd.Parameters.AddWithValue("@titular", c.Titular);
                        cmd.Parameters.AddWithValue("@senha", c.Senha);
                        cmd.Parameters.AddWithValue("@saldo", c.Saldo);
                        cmd.Parameters.AddWithValue("@limite", c.Limite);
                        cmd.Parameters.AddWithValue("@status", c.Ativo);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
