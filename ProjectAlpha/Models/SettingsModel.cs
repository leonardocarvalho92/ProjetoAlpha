using ProjectAlpha.ViewModels;
namespace ProjectAlpha
{

    public class SettingsModel:BaseViewModel
    {
        /// <summary>
        /// Cadeia de conexão utilizada pelo ADO.NET
        /// </summary>
        public string ADOConnectionString { get; set; }
        /// <summary>
        /// Cadeia de conexão utilizada pelo Entity Framework.
        /// </summary>
        public string EFConnectionString { get; set; }
        /// <summary>
        /// Instancia do sql.
        /// </summary>
        public string SqlInstance { get; set; }

    }
}
