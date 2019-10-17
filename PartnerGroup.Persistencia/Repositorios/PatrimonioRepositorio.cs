using Microsoft.Extensions.Configuration;
using PartnerGroup.Aplicacao.Interfaces;
using PartnerGroup.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PartnerGroup.Persistencia.Repositorios
{
    public class PatrimonioRepositorio : IPatrimonioRepositorio
    {
        private readonly string _stringConexao;

        public PatrimonioRepositorio(IConfiguration configuracao)
        {
            _stringConexao = configuracao.GetConnectionString("DefaultConnection");
        }

        public Patrimonio Atualize(Patrimonio patrimonio)
        {
            using (SqlConnection connection = new SqlConnection(_stringConexao))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("UPDATE PATRIMONIO SET NOME = @NOME, DESCRICAO = @DESCRICAO, MARCAID = @MARCAID");
                sb.Append("WHERE ID = @ID");
                string sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@NOME", patrimonio.Nome);
                    command.Parameters.AddWithValue("@ID", patrimonio.Id);
                    command.Parameters.AddWithValue("@DESCRICAO", patrimonio.Descricao);
                    command.Parameters.AddWithValue("@MARCAID", patrimonio.MarcaId);

                    command.ExecuteNonQuery();
                }
            }

            return patrimonio;
        }

        public bool Delete(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_stringConexao))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("DELETE PATRIMONIO ");
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

        public List<Patrimonio> Obtenha()
        {
            var retorno = new List<Patrimonio>();
            using (SqlConnection connection = new SqlConnection(_stringConexao))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT ID, NOME, DESCRICAO, NUMEROTOMBO, MARCAID FROM PATRIMONIO ");
                string sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retorno.Add(new Patrimonio
                            {
                                Id = Guid.Parse(reader.GetString(0)),
                                Nome = reader.GetString(1),
                                Descricao = reader.GetString(2),
                                NumeroTombo = reader.GetInt32(3),
                                MarcaId = Guid.Parse(reader.GetString(4))
                            });
                        }
                    }
                }
            }

            return retorno;
        }

        public Patrimonio Obtenha(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_stringConexao))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT ID, NOME, DESCRICAO, NUMEROTOMBO, MARCAID FROM PATRIMONIO ");
                sb.Append("WHERE ID = @ID");
                string sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new Patrimonio { Id = Guid.Parse(reader.GetString(0)), Nome = reader.GetString(1) };
                        }
                    }
                }
            }

            return null;
        }

        public List<Patrimonio> ObtenhaPorMarca(Guid marcaId)
        {
            var retorno = new List<Patrimonio>();
            using (SqlConnection connection = new SqlConnection(_stringConexao))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT ID, NOME, DESCRICAO, NUMEROTOMBO, MARCAID FROM PATRIMONIO ");
                sb.Append("WHERE MARCAID = @MARCAID");

                string sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MARCAID", marcaId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retorno.Add(new Patrimonio
                            {
                                Id = Guid.Parse(reader.GetString(0)),
                                Nome = reader.GetString(1),
                                Descricao = reader.GetString(2),
                                NumeroTombo = reader.GetInt32(3),
                                MarcaId = Guid.Parse(reader.GetString(4))
                            });
                        }
                    }
                }
            }

            return retorno;
        }

        public Patrimonio Salve(Patrimonio patrimonio)
        {
            using (SqlConnection connection = new SqlConnection(_stringConexao))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO PATRIMONIO (ID, NOME, DESCRICAO, MARCAID) VALUES (@ID, @NOME, @DESCRICAO, @MARCAID)");
                string sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@NOME", patrimonio.Nome);
                    command.Parameters.AddWithValue("@ID", patrimonio.Id);
                    command.Parameters.AddWithValue("@DESCRICAO", patrimonio.Descricao);
                    command.Parameters.AddWithValue("@MARCAID", patrimonio.MarcaId);
                    command.ExecuteNonQuery();
                }
            }

            return patrimonio;
        }
    }
}
