using PartnerGroup.Aplicacao.Interfaces;
using PartnerGroup.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PartnerGroup.Persistencia.Repositorios
{
    public class MarcaRepositorio : IMarcaRepositorio
    {
        private readonly string stringConexao = "";

        public Marca Atualize(Marca marca)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("UPDATE MARCA SET NOME = @NOME");
                sb.Append("WHERE ID = @ID");
                string sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@NOME", marca.Nome);
                    command.Parameters.AddWithValue("@ID", marca.Id);
                    command.ExecuteNonQuery();
                }
            }

            return marca;
        }

        public bool Delete(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("DELETE MARCA ");
                sb.Append("WHERE ID = @ID");
                string sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    if (command.ExecuteNonQuery() > 0)
                        return true;
                    else
                        return false;
                }
            }
        }

        public List<Marca> Obtenha()
        {
            var retorno = new List<Marca>();
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT ID, NOME FROM MARCA ");
                string sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retorno.Add(new Marca { Id = Guid.Parse(reader.GetString(0)), Nome = reader.GetString(1) });
                        }
                    }
                }
            }

            return retorno;
        }

        public Marca Obtenha(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT ID, NOME FROM MARCA ");
                sb.Append("WHERE ID = @ID");
                string sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new Marca { Id = Guid.Parse(reader.GetString(0)), Nome = reader.GetString(1) };
                        }
                    }
                }
            }

            return null;
        }

        public Marca Salve(Marca marca)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO MARCA (ID, NOME) VALUES (@ID, @NOME)");
                string sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@NOME", marca.Nome);
                    command.Parameters.AddWithValue("@ID", marca.Id);
                    command.ExecuteNonQuery();
                }
            }

            return marca;
        }
    }
}
