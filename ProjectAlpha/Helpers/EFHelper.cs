using ProjectAlpha.Models;
using System;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;

namespace ProjectAlpha
{
    public class EFHelper
    {
        /// <summary>
        /// OBSOLETO - Configuração de connection string do Entity Framework.
        /// </summary>
        /// <param name="connectionString">Cadeia de conexâo antiga</param>
        /// <param name="newInstance">Instancia nova</param>
        /// <returns>Nova cadeia de coexao ou a antiga em caso de falha.</returns>
        public static string EFSetConnectionString(string connectionString, string newInstance)
        {
            if (connectionString.Length > 0 && newInstance.Length > 0)
                return connectionString.Replace("data source=.;", string.Format("data source ={0};", newInstance));
            else
                return connectionString;
        }
        /// <summary>
        /// Classe responsável por alterar a conexão do Entity Framework.
        /// </summary>
        /// <param name="source">Contexto de dados</param>
        /// <param name="initialCatalog">Banco de dados</param>
        /// <param name="dataSource">Instância</param>
        /// <param name="userId">Usuário</param>
        /// <param name="password">Senha</param>
        /// <param name="integratedSecurity"></param>
        /// <param name="configConnectionStringName"></param>
        public static void ChangeDatabase(AlphaEntities source, string initialCatalog = "", string dataSource = "", string userId = "",  string password = "",  bool integratedSecurity = true, string configConnectionStringName = "")
        {
            try
            {
                var configNameEf = string.IsNullOrEmpty(configConnectionStringName)
                    ? source.GetType().Name
                    : configConnectionStringName;

                // Adiciona a referencia ao Configuration Manager.
                var entityCnxStringBuilder = new EntityConnectionStringBuilder
                    (System.Configuration.ConfigurationManager
                        .ConnectionStrings[configNameEf].ConnectionString);

                // Inicia o sqlbuilder com a cadeia de conexão
                var sqlCnxStringBuilder = new SqlConnectionStringBuilder
                    (entityCnxStringBuilder.ProviderConnectionString);

                // Adiciona apenas os campos passados por parâmetros.
                if (!string.IsNullOrEmpty(initialCatalog))
                    sqlCnxStringBuilder.InitialCatalog = initialCatalog;
                if (!string.IsNullOrEmpty(dataSource))
                    sqlCnxStringBuilder.DataSource = dataSource;
                if (!string.IsNullOrEmpty(userId))
                    sqlCnxStringBuilder.UserID = userId;
                if (!string.IsNullOrEmpty(password))
                    sqlCnxStringBuilder.Password = password;

                // Define o estado integrated security 
                sqlCnxStringBuilder.IntegratedSecurity = integratedSecurity;

                // Muda as propriedades
                source.Database.Connection.ConnectionString
                    = sqlCnxStringBuilder.ConnectionString;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
