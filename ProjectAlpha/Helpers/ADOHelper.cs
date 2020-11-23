using System.Data;
using System.Data.SqlClient;

namespace ProjectAlpha
{
    public class ADOHelper
    {
        const string _CONNECTION_STRING = @"Server=.;Database=Alpha;User Id=sa;Password=sic742;";
        /// <summary>
        /// Cria uma conexão com o banco de dados.
        /// </summary>
        /// <returns>Retorna uma conexão <see cref="SqlConnection"/> com o banco de dados.</returns>
        private static SqlConnection CreateConnection(string connectionString)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString;
            return conn;
        }

        /// <summary>
        /// Executa uma consulta no banco de dados.
        /// </summary>
        /// <returns>Retorna um objeto <see cref="DataTable"/> com os dados da consulta executada.</returns>
        private DataTable ExecuteSQLCommand()
        {

            return null;
        }

        /// <summary>
        /// Busca fornecedores pelo nome
        /// </summary>
        /// <param name="connectionString">cadeia de conexão</param>
        /// <param name="name">nome do fornecedor</param>
        /// <param name="active">buscar por ativos 1 inativos 0 ou ambos ""</param>
        /// <param name="condition"> buscar com like ou = </param>
        /// <returns></returns>
        public static DataTable QueryProvidersByName(string connectionString, string name = "", string active = "", string condition="")
        {
            string sqlQuery = "SELECT TOP 100 * FROM view_show_providers";
            SqlConnection conn = CreateConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = sqlQuery;
            if (name != "")
            {
                switch (condition)
                {
                    case "=":
                        sqlQuery += " WHERE name = @name";
                        sqlCmd.CommandText = sqlQuery;
                        AddParameter(sqlCmd, "@name", name);
                        break;
                    case "":
                        sqlQuery += " WHERE name like @name";
                        sqlCmd.CommandText = sqlQuery;
                        AddParameter(sqlCmd, "@name", string.Format("%{0}%", name));
                        break;
                }             
                
            }
            if (active != "")
            {
                sqlQuery += " WHERE active = @active";
                sqlCmd.CommandText = sqlQuery;
                switch (active)
                {
                    case "1":
                        AddParameter(sqlCmd, "@active", "1");
                        break;
                    case "0":
                        AddParameter(sqlCmd, "@active", "0");
                        break;
                }
            }
            sqlCmd.Connection = conn;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
            DataTable providers = new DataTable();
            try
            {
                adapter.Fill(providers);
                return providers;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Busca fornecedores pelo id
        /// </summary>
        /// <param name="connectionString">Cadeia de conexão</param>
        /// <param name="id"> id do fornecedor</param>
        /// <param name="active">buscar por ativos 1 ou inativos 0 ou ambos ""</param>
        /// <returns></returns>

        public static DataTable QueryProvidersByID(string connectionString, int id = 0, string active = "")
        {
            string sqlQuery = "SELECT TOP 100 * FROM view_show_providers";
            SqlConnection conn = CreateConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = sqlQuery;
            if (id != 0)
            {
                sqlQuery += " WHERE name providers.id = @id";
                sqlCmd.CommandText = sqlQuery;
                AddParameter(sqlCmd, "@id", id.ToString());

            }            
            if (active != "")
            {
                sqlQuery += " WHERE active = @active";
                sqlCmd.CommandText = sqlQuery;
                switch (active)
                {
                    case "1":
                        AddParameter(sqlCmd, "@active", "1");
                        break;
                    case "0":
                        AddParameter(sqlCmd, "@active", "0");
                        break;
                }
            }
            sqlCmd.Connection = conn;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
            DataTable providers = new DataTable();
            try
            {
                adapter.Fill(providers);
                return providers;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Busca produtos pelo nome
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static DataTable QueryProductsByName(string connectionString, string name = "", string condition="")
        {
            string sqlQuery = "SELECT TOP 100 * FROM view_show_products";
            SqlConnection conn = CreateConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = sqlQuery;
            if (name != "")
            {
                switch (condition)
                {
                    case "=":
                        sqlQuery += " WHERE name = @name";
                        sqlCmd.CommandText = sqlQuery;
                        AddParameter(sqlCmd, "@name", name);
                        break;
                    case "":
                        sqlQuery += " WHERE name like @name";
                        sqlCmd.CommandText = sqlQuery;
                        AddParameter(sqlCmd, "@name", string.Format("%{0}%", name));
                        break;
                }

            }

            sqlCmd.Connection = conn;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
            DataTable products = new DataTable();

            try
            {
                adapter.Fill(products);
                return products;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Busca username no banco de dados.
        /// </summary>
        /// <param name="connectionString"> Cadeia de Conexão com o banco de dados.</param>
        /// <param name="username">Username digitado pelo usuário.</param>
        /// <returns></returns>
        public static DataTable QueryUserByUsername(string connectionString, string username = "")
        {
            string sqlQuery = "SELECT TOP 10 * FROM users";
            SqlConnection conn = CreateConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandText = sqlQuery;
            if (username != "")
            {
                sqlQuery += " WHERE username = @username";
                sqlCmd.CommandText = sqlQuery;
                AddParameter(sqlCmd, "@username", username);
            }
            sqlCmd.Connection = conn;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
            DataTable products = new DataTable();

            try
            {
                adapter.Fill(products);
                return products;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }


        public static void AddParameter(SqlCommand sqlCmd, string name, string value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = name;
            param.Value = value;
            sqlCmd.Parameters.Add(param);
        }
    }

}

