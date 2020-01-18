using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AdoApp.Repositorio
{
    public class Contexto : IDisposable
    {
        private readonly SqlConnection sqlConnection;

        // Com o construtor, temos uma conexão aberta toda vez que instanciarmos a classe Contexto.
        public Contexto()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AdoAppDb"].ConnectionString);

            sqlConnection.Open();
        }

        // Executa um comando SQL qualquer, e não retorna nada.
        // Aqui podemos executar, por exemplo, operações para : Adicionar, Atualizar e Excluir.
        public void ExecutaComando(string sql)
        {
            SqlCommand sqlCmd = new SqlCommand(sql, sqlConnection);

            sqlCmd.ExecuteNonQuery();
        }

        // Executa um comando SQL para retornar algum objeto do tipo SqlDataReader.
        public SqlDataReader ExecutaConsulta(string sql)
        {
            SqlCommand sqlCmd = new SqlCommand(sql, sqlConnection);

            return sqlCmd.ExecuteReader();
        }

        // Este método é utilizado para liberar recursos/memória, sem esperar o Garbage Collector.
        public void Dispose()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
    }
}
