using AdoApp.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AdoApp.Repositorio
{
    public class ClienteRepository
    {
        protected Contexto bd;

        public void Salvar(Cliente cliente)
        {
            // Se algum Id foi passado, então a operação a ser feita é de atualização.
            if (cliente.Id > 0)
            {
                string sql = "UPDATE Cliente ";
                sql += string.Format("SET Nome = '{0}', " +
                                         "Email = '{1}', " +
                                         "Telefone = '{2}', " +
                                         "DataDeNascimento = '{3:MM/dd/yyyy}', " +
                                         "DataDeCadastro = '{4:MM/dd/yyyy}' " +
                                     "WHERE Id = {5}",
                                     cliente.Nome,
                                     cliente.Email,
                                     cliente.Telefone,
                                     cliente.DataDeNascimento,
                                     cliente.DataDeCadastro,
                                     cliente.Id);
                // Utilizando using, ao final o método Dispose libera recurso/memória.
                using (bd = new Contexto())
                {
                    bd.ExecutaComando(sql);
                };
            }
            // Senão, devemos adicionar um cliente.
            else
            {
                string sql = "INSERT INTO Cliente (Nome, Email, Telefone, DataDeNascimento, DataDeCadastro) VALUES ";
                sql += string.Format("('{0}', '{1}', '{2}', '{3:MM/dd/yyyy}', '{4:MM/dd/yyyy}')",
                                     cliente.Nome,
                                     cliente.Email,
                                     cliente.Telefone,
                                     cliente.DataDeNascimento,
                                     cliente.DataDeCadastro);

                using (bd = new Contexto())
                {
                    bd.ExecutaComando(sql);
                }
            }
        }

        public List<Cliente> ListaTodos()
        {
            SqlDataReader sqlDataReader;
            string sql = "SELECT * FROM Cliente";

            using (bd = new Contexto())
            {
                sqlDataReader = bd.ExecutaConsulta(sql);

                if (sqlDataReader.HasRows)
                {
                    List<Cliente> clientes = new List<Cliente>();

                    while (sqlDataReader.Read())
                    {
                        Cliente cliente = new Cliente()
                        {
                            Id = Convert.ToInt32(sqlDataReader["Id"]),
                            Nome = Convert.ToString(sqlDataReader["Nome"]),
                            Email = Convert.ToString(sqlDataReader["Email"]),
                            Telefone = Convert.ToString(sqlDataReader["Telefone"]),
                            DataDeNascimento = Convert.ToDateTime(sqlDataReader["DataDeNascimento"]),
                            DataDeCadastro = Convert.ToDateTime(sqlDataReader["DataDeCadastro"])
                        };

                        clientes.Add(cliente);
                    }

                    return clientes;
                }

                return null;
            }
        }
    }
}
