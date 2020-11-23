using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;
using System.Windows.Input;
using Microsoft.SqlServer.Management.Common;
using System.Windows;
using ProjectAlpha.Views;
using System.Configuration;
using ProjectAlpha.Helpers;
using System.Data.SqlClient;
using System.IO;

namespace ProjectAlpha.ViewModels
{
    public class StartupViewModel : BaseViewModel
    {
        /// <summary>
        /// Lista das instâncias
        /// </summary>
        public ObservableCollection<string> sqlInstances { get; set; }

        /// <summary>
        /// Instância sql selecionada
        /// </summary>
        public string selectedSqlInstance { get; set; }

        /// <summary>
        /// texto a ser exibido ao usuario.
        /// </summary>
        public string statusText { get; set; }

        /// <summary>
        /// define se o metodo de busca vai testar uma configuraçao existente ou uma nova.
        /// </summary>
        public bool testConnection { get; set; }

        public SettingsModel systemSettings { get; set; }

        /// <summary>
        /// Comando avançar
        /// </summary>
        public ICommand nextCommand { get; set; }

        /// <summary>
        /// Comando fechar a tela.
        /// </summary>
        public ICommand closeWindowCommand { get; set; }

        public StartupViewModel()
        {

            TryToConnect();
            GetAsyncInstances();
            nextCommand = new RelayCommand(GetAsyncDatabases);
            closeWindowCommand = new RelayCommand(CloseWindow);
        }

        /// <summary>
        /// Fecha o sistema
        /// </summary>
        private void CloseWindow()
        {
            Application.Current.MainWindow.Close();
        }
        
        /// <summary>
        /// Caller da  TryToConnect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallMethods(object sender = null, System.EventArgs e = null)
        {
             Task.Run(TryToConnect);
        }
        /// <summary>
        /// Método para tentar a conexao com o banco.
        /// </summary>
        /// <returns></returns>
        private async Task TryToConnect()
        {
            GetSettings();
            testConnection = true;
            bool success = Task.Run(SearchForAlphaDatabase).Result;
            
            if (success)
            {
                SetConnectionString();
                StartSystem();
            }
            else
            {
                testConnection = false;
            }
        }

        /// <summary>
        /// Chamada assincrona 
        /// </summary>
        /// <returns></returns>
        private async void GetAsyncInstances()
        {
            await Task.Run(GetInstances);
        }
        /// <summary>
        /// Método para listar instâncias do SQL server disponíveis no computador.
        /// </summary>
        /// <returns>Sem retorno</returns>
        private async Task GetInstances()
        {

            sqlInstances = new ObservableCollection<string>();
            string ServerName = Environment.MachineName;
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);//Instalação 64bits
                if (instanceKey != null)
                {
                    foreach (var instanceName in instanceKey.GetValueNames())
                    {
                        if (instanceName == "MSSQLSERVER")//Instancia padrao
                            sqlInstances.Add(ServerName);
                        else
                            sqlInstances.Add(string.Format(@"{0}\{1}", ServerName, instanceName));
                    }
                }
                else
                {
                    instanceKey = hklm.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);//Instalação 32bits
                    if (instanceKey != null)
                    {
                        foreach (var instanceName in instanceKey.GetValueNames())
                        {
                            if (instanceName == "MSSQLSERVER") //Instancia padrao
                                sqlInstances.Add(ServerName);
                            else
                                sqlInstances.Add(string.Format(@"{0}\{1}", ServerName, instanceName));
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Chamada assincrona 
        /// </summary>
        /// <returns></returns>
        private async void GetAsyncDatabases()
        {
            statusText = "Buscando por banco de dados...";
            bool alphaExists = await Task.Run(SearchForAlphaDatabase);
            if (alphaExists)
            {
                SetConnectionString();
                UpdateSettings();
                StartSystem();
            }
            else
            {
                statusText = "Banco de dados não foi encontrado e será criado agora...";
                SetUpDatabase();
                SetConnectionString();
                UpdateSettings();
                StartSystem();
            }
        }
        /// <summary>
        /// Lista bancos de dados na instancia.
        /// </summary>
        /// <returns>True se o banco existir e false se não</returns>
        private async Task<bool> SearchForAlphaDatabase()
        {
            string sqlServerLogin = "sa";
            string password = "sic742";
            ServerConnection serverConnection = new ServerConnection();
            if (!testConnection)
            {
                //serverConnection.ServerInstance = selectedSqlInstance;
                //serverConnection.LoginSecure = false;   // true = logon do windows  
                //serverConnection.Login = sqlServerLogin;
                //serverConnection.Password = password;

                serverConnection.ConnectionString = string.Format(@"data source ={0}; initial catalog = master; user id = sa; password = sic742;", selectedSqlInstance);
            }
            else
            {
                serverConnection.ConnectionString = systemSettings.ADOConnectionString;
            }

            Server server = new Server(serverConnection);
            try
            {
                foreach (Database database in server.Databases)
                {
                    if (database.Name == "Alpha")
                    {

                        // Se for tentativa de conexão incial mantem a string do arquivo de configuração.
                        if (testConnection)
                        {
                           return true;
                        }
                        else//se não for a tentativa inicial, entao atualiza a string para a instancia passada pela listbox.
                        {
                            systemSettings.ADOConnectionString = string.Format(@"data source ={0}; initial catalog = Alpha; user id = sa; password = sic742;", selectedSqlInstance);
                            return true;
                        }
                        
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        /// <summary>
        /// Inicia o sistema
        /// </summary>
        private void StartSystem()
        {
            Window startupWindow = Application.Current.MainWindow;
            LoginWindow loginWindow = new LoginWindow();
            Application.Current.MainWindow = loginWindow;
            loginWindow.Show();
            LoginViewModel loginViewModel = (LoginViewModel)loginWindow.DataContext;
            loginViewModel.loginWindow = loginWindow;
            startupWindow.Close();
        }

        /// <summary>
        /// Define a connection string no app.config
        /// </summary>
        private void SetConnectionString()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            if (!testConnection)
            {
                systemSettings.ADOConnectionString = string.Format(@"data source ={0}; initial catalog = Alpha; user id = sa; password = sic742;", selectedSqlInstance);
                connectionStringsSection.ConnectionStrings["ADO"].ConnectionString = string.Format(@"data source ={0}; initial catalog = Alpha; user id = sa; password = sic742;", selectedSqlInstance);
            }
            else
            {
                connectionStringsSection.ConnectionStrings["ADO"].ConnectionString = systemSettings.ADOConnectionString;
            }           
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
        }
        /// <summary>
        /// Obtem a configuração do sistema.
        /// </summary>
        private void GetSettings()
        {
            string fileName = @"\AlphaSettings.json";
            SettingsModel settings = JsonHelper.JsonFileReader(fileName);
            if(settings != null)
            {
                systemSettings = settings;
            }
            else
            {
                CreateSettingsFile();
            }
        }


        /// <summary>
        /// Cria arquivo de configuração do sistema.
        /// </summary>
        private void CreateSettingsFile()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

            systemSettings = new SettingsModel();
            systemSettings.ADOConnectionString = @"data source =.; initial catalog = Alpha; user id = sa; password = sic742;";
            systemSettings.EFConnectionString = connectionStringsSection.ConnectionStrings["AlphaEntities"].ConnectionString;
            systemSettings.SqlInstance = ".";
            JsonHelper.JsonFileWriter(systemSettings, @"\AlphaSettings.json");    

        }

        /// <summary>
        /// Atualiza arquivo de configuração dos sistema.
        /// </summary>
        private void UpdateSettings()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            systemSettings.EFConnectionString = connectionStringsSection.ConnectionStrings["AlphaEntities"].ConnectionString;//.Replace(@"data source=.", string.Format(@"data source={0}", selectedSqlInstance)); ;
            systemSettings.SqlInstance = selectedSqlInstance;
            JsonHelper.JsonFileWriter(systemSettings, @"\AlphaSettings.json");

        }

        /// <summary>
        /// Executa script de criação e população do banco de dados.
        /// </summary>
        private void SetUpDatabase()
        {
            try
            {
                string path = Directory.GetCurrentDirectory();
                string createDb = @"\CREATE_DB.sql";
                string script = File.ReadAllText(path + createDb);
                ServerConnection serverConnection = new ServerConnection();
                serverConnection.ConnectionString = string.Format(@"data source ={0}; initial catalog = master; user id = sa; password = sic742;", selectedSqlInstance);
                serverConnection.ExecuteNonQuery(script);
            }
            catch
            {
                Console.WriteLine("Não foi possivel configurar o banco de dados.");
            }
           
        }
    }
}
