using System.Data;
using System.Windows;
using ProjectAlpha.Views;
using ProjectAlpha.Models;
using System.Windows.Input;
using ProjectAlpha.Helpers;
using System;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace ProjectAlpha.ViewModels
{
    public class ProvidersViewModel : BaseViewModel
    {
        #region Propriedades da Janela

        /// <summary>
        /// Contexto de dados da janela principal.
        /// </summary>
        public MainViewModel mainWindowContext { get; set; }


        /// <summary>
        /// Altura da janela.
        /// </summary>
        public double height { get; set; }


        /// <summary>
        /// Largura da janela.
        /// </summary>
        public double width { get; set; }


        /// <summary>
        /// Posiçao da janela no eixo Y.
        /// </summary>
        public double top { get; set; }


        /// <summary>
        /// Posição da janela no eixo X.
        /// </summary>
        public double left { get; set; }


        /// <summary>
        /// Icone do botão salvar.
        /// </summary>
        public string SaveBtnIcon { get; set; } = "PersonCheck";


        /// <summary>
        /// Texto do botão salvar.
        /// </summary>
        public string SaveBtnText { get; set; } = "Salvar";

        #endregion

        #region Propriedades Públicas
        /// <summary>
        /// Fonte de dados da grid de fornecedores.
        /// </summary>
        public DataView dataGridSource { get; set; }


        /// <summary>
        /// Instância de fornecedor em uso  na janela.
        /// </summary>
        public provider currentProvider { get; set; }


        /// <summary>
        /// Conteúdo do campo de busca.
        /// </summary>
        public string searchFieldText { get; set; } = "";


        /// <summary>
        /// Fornecedor selecionado na grid.
        /// </summary>
        public DataRowView gridCurrentProvider { get; set; }
        #endregion

        #region Propriedades Privadas
        /// <summary>
        /// Contexto de dados do Entity Framework
        /// </summary>
        private AlphaEntities EFContext { get; set; }

        #endregion

        #region Booleanos
        /// <summary>
        /// Foco da aba consulta.
        /// </summary>
        public bool isQueryTabFocused { get; set; } = true;


        /// <summary>
        /// Foco da aba cadastro.
        /// </summary>
        public bool isRegisterTabFocused { get; set; } = false;


        /// <summary>
        /// Define se é possivel ou não remover um fornecedor.
        /// </summary>
        public bool CanDeleteProvider { get; set; } = false;


        /// <summary>
        /// Instancia de janela de alerta.
        /// </summary>
        public AlphaMessageBox msgBox { get; set; }

        #endregion

        #region Comandos
        /// <summary>
        /// Comando de busca por fornecedor
        /// </summary>
        public ICommand searchProviderCommand { get; set; }


        /// <summary>
        /// Comando de clique duplo na grid.
        /// </summary>
        public ICommand gridDoubleClickCommand { get; set; }


        /// <summary>
        /// Comando para resetar a instância do fornecedor.
        /// </summary>
        public ICommand resetCurrentProviderCommand { get; set; }


        /// <summary>
        /// Comando para salvar o fornecedor atual.
        /// </summary>
        public ICommand saveCurrentProviderCommand { get; set; }


        /// <summary>
        /// Comando para remover o fornecedor atual.
        /// </summary>
        public ICommand deleteCurrentProviderCommand { get; set; }

        /// <summary>
        /// Comando para excluir um fornecedor através da grid.
        /// </summary>
        public ICommand deleteGridProviderCommand { get; set; }

        /// <summary>
        /// Comando para criar um novo fornecedor.
        /// </summary>
        public ICommand newProviderCommand { get; set; }


        /// <summary>
        /// Comando que fecha janela.
        /// </summary>
        public ICommand closeWindowCommand { get; set; }


        /// <summary>
        /// Comando para minimizar tela.
        /// </summary>
        public ICommand minimizeWindowCommand { get; set; }



        /// <summary>
        /// Comando usado como trigger para validar o campo telefone.
        /// </summary>
        public ICommand validatePhoneCommand { get; set; }

        /// <summary>
        /// Comando para buscar cnpj na API.
        /// </summary>
        public ICommand GetWebProviderCommand { get; set; }


        #endregion

        #region Construtor

        public ProvidersViewModel()
        {
            InitializeComponents();
        }

        #endregion

        #region Métodos DB
        /// <summary>
        /// Busca fornecedor.
        /// </summary>
        private void SearchProvider()
        {
            //RefreshEFContext();
            DataTable providers = ADOHelper.QueryProvidersByName(mainWindowContext.connectionString, searchFieldText);
            if (providers != null)
                dataGridSource = providers.DefaultView;
        }


        /// <summary>
        /// Inicia ou atualiza o contexto de dados do Entity Framework
        /// </summary>
        private void RefreshEFContext()
        {

            EFContext = new AlphaEntities();
            EFHelper.ChangeDatabase(EFContext, "Alpha", mainWindowContext.settings.SqlInstance, "sa", "sic742", true, "AlphaEntities");
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");            
            Console.WriteLine(connectionStringsSection.ConnectionStrings["AlphaEntities"].ConnectionString);
        }


        /// <summary>
        /// Insere dados coletados da grid no <see cref="currentProvider"/>
        /// </summary>
        private void SetGridCurrentProvider()
        {
            if (currentProvider == null)
                currentProvider = new provider();
            if (gridCurrentProvider != null)
            {
                currentProvider.id = (int)gridCurrentProvider[0];
                currentProvider.name = gridCurrentProvider[1].ToString();
                currentProvider.social_name = gridCurrentProvider[2].ToString();
                currentProvider.cnpj = gridCurrentProvider[3].ToString();
                currentProvider.adress = gridCurrentProvider[4].ToString();
                currentProvider.phone = gridCurrentProvider[5].ToString();
                currentProvider.email = gridCurrentProvider[6].ToString();
                currentProvider.main_activity = gridCurrentProvider[7].ToString();
                currentProvider.active = (bool)gridCurrentProvider[8];
                isQueryTabFocused = false;
                isRegisterTabFocused = true;
                ButtonsHandler();
            }          
        }


        /// <summary>
        /// Insere ou atualiza dados do fornecedor atual.
        /// </summary>
        private void InsertOrUpdateProvider()
        {
            //Verifica se todos os campos obrigatórios estão preenchidos.
            if ((currentProvider.name != null && currentProvider.social_name != null && currentProvider.cnpj != null && currentProvider.adress != null) && (currentProvider.name != "" && currentProvider.social_name != "" && currentProvider.cnpj != "" && currentProvider.adress != ""))
            {
                RefreshEFContext();
                //Insere um novo fornecedor.
                if (currentProvider.id == 0)
                {
                    try
                    {
                        DataTable providerFounded = ADOHelper.QueryProvidersByName(mainWindowContext.connectionString, currentProvider.name,"","=");
                        if(providerFounded.Rows.Count == 0)
                        {
                            EFContext.providers.Add(currentProvider);
                            EFContext.SaveChanges();
                            providerFounded = ADOHelper.QueryProvidersByName(mainWindowContext.connectionString, currentProvider.name);
                            currentProvider.id = (int)providerFounded.Rows[0][0];
                            ResetProviderFields();
                            ButtonsHandler();
                            SearchProvider();
                            isRegisterTabFocused = false;
                            isQueryTabFocused = true;
                        }
                        else
                        {
                            msgBox = new AlphaMessageBox(mainWindowContext.productWindow, "Já existe um fornecedor com esse nome.");
                            msgBox.ShowDialog();    

                        }
                        
                    }
                    catch
                    {
                        msgBox = new AlphaMessageBox(mainWindowContext.productWindow, "Não foi possível inserir este fornecedor.");
                        msgBox.ShowDialog();
                        currentProvider = new provider();
                    }                    
                }
                //Atualiza dados do fornecedor.
                else
                {
                    try
                    {
                        provider oldProvider = EFContext.providers.Find(currentProvider.id);
                        UpdateProvider(oldProvider);
                        EFContext.SaveChanges();
                        ResetProviderFields();
                        ButtonsHandler();
                        SearchProvider();
                        isRegisterTabFocused = false;
                        isQueryTabFocused = true;
                    }
                    catch
                    {
                        msgBox = new AlphaMessageBox(mainWindowContext.productWindow, "Não foi possível inserir este fornecedor.");
                        msgBox.ShowDialog();
                        currentProvider = new provider();
                    }                    
                }
                
            }
            else
            {
                msgBox = new AlphaMessageBox(mainWindowContext.productWindow, "Preencha os campos obrigatórios.");
                msgBox.ShowDialog();
            }                   
        }


        /// <summary>
        /// Atualiza dados do fornecedor do DB
        /// </summary>
        /// <param name="old">Fornecedor do contexto</param>
        private void UpdateProvider(provider old)
        {
            old.adress = currentProvider.adress;
            old.cnpj = currentProvider.cnpj;
            old.email = currentProvider.email;
            old.main_activity = currentProvider.main_activity;
            old.name = currentProvider.name;
            old.phone = currentProvider.phone;
            old.active = currentProvider.active;
            old.social_name = currentProvider.social_name;
        }


        /// <summary>
        /// Remove Fornecedor
        /// </summary>
        private void RemoveProvider()
        {
            //Verifica se o fornecedor atual existe no banco.
            if (currentProvider.id != 0)
            {
                RefreshEFContext();
                try
                {                    
                    provider dBProvider = EFContext.providers.Find(currentProvider.id);
                    EFContext.providers.Remove(dBProvider);
                    EFContext.SaveChanges();
                    ResetProviderFields();
                    ButtonsHandler();
                    SearchProvider();
                    isRegisterTabFocused = false;
                    isQueryTabFocused = true;
                }
                catch
                {
                    msgBox = new AlphaMessageBox(mainWindowContext.productWindow, "Náo foi possivel excluir este fornecedor.");
                    msgBox.ShowDialog();
                }
            }
        }


        /// <summary>
        /// Remove Fornecedor através da grid.
        /// </summary>
        private void RemoveGridProvider()
        {
            /// Seta os dados do fornecedor selecionado na grid.
            UpdateProviderOnSelect();
            //Verifica se o fornecedor atual existe no banco.
            if (currentProvider.id != 0)
            {
                RefreshEFContext();
                try
                {
                    provider dBProvider = EFContext.providers.Find(currentProvider.id);
                    EFContext.providers.Remove(dBProvider);
                    EFContext.SaveChanges();
                    ResetProviderFields();
                    ButtonsHandler();
                    SearchProvider();
                }
                catch {
                    msgBox = new AlphaMessageBox(mainWindowContext.productWindow, "Não foi possivel excluir este fornecedor.");
                    msgBox.ShowDialog();
                }
            }
            else 
            {
                msgBox = new AlphaMessageBox(mainWindowContext.productWindow, "Selecione um fornecedor para excluir.");
                msgBox.ShowDialog();
             }
        }


        /// <summary>
        /// Insere dados coletados da grid no <see cref="currentProvider"/>
        /// </summary>
        private void UpdateProviderOnSelect()
        {
            if (currentProvider == null)
                currentProvider = new provider();
            if (gridCurrentProvider != null)
            {
                currentProvider.id = (int)gridCurrentProvider[0];
                currentProvider.name = gridCurrentProvider[1].ToString();
                currentProvider.social_name = gridCurrentProvider[2].ToString();
                currentProvider.cnpj = gridCurrentProvider[3].ToString();
                currentProvider.adress = gridCurrentProvider[4].ToString();
                currentProvider.phone = gridCurrentProvider[5].ToString();
                currentProvider.email = gridCurrentProvider[6].ToString();
                currentProvider.main_activity = gridCurrentProvider[7].ToString();
                currentProvider.active = (bool)gridCurrentProvider[8];
                ButtonsHandler();
            }
        }

        #endregion

        #region Métodos da janela

        /// <summary>
        /// Handler que atualiza a localização da janela.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowPositionHandler(object sender, System.EventArgs e)
        {
            UpdateWindowPosition();
        }

        /// <summary>
        /// Atualiza a localização da janela.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateWindowPosition()
        {
            if (mainWindowContext.mainWindow.WindowState != WindowState.Maximized)
            {
                top = mainWindowContext.top + (SystemParameters.CaptionHeight + 69);
                left = mainWindowContext.left + 8;
            }
            else
            {
                top = SystemParameters.CaptionHeight + 62;
                left = 2;
            }

        }


        /// <summary>
        /// Handler de evento que atualiza o tamanho da janela.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowSizeHandler(object sender, System.EventArgs e)
        {
            UpdateWindowSize();

        }
        /// <summary>
        /// Atualiza ambas propriedades da janela.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateWindowSizeAndPosition(object sender = null, System.EventArgs e = null)
        {
            UpdateWindowSize();
            UpdateWindowPosition();
        }

        /// <summary>
        /// Detecta se a janela principal esta maximizada ou não e define tamanho da janela filha.
        /// </summary>
        private void UpdateWindowSize()
        {
            if (mainWindowContext.mainWindow.WindowState != WindowState.Maximized)
            {
                height = mainWindowContext.height - (SystemParameters.CaptionHeight + 76);
                width = mainWindowContext.width-17;
            }
            else
            {
                height = SystemParameters.PrimaryScreenHeight - (SystemParameters.CaptionHeight + SystemParameters.MenuBarHeight + 75);
                width = SystemParameters.PrimaryScreenWidth;
            }
        }

        /// <summary>
        /// Define uma nova instância de fornecedor e redireciona para aba de cadastro.
        /// </summary>
        private void NewProvider()
        {
            ResetProviderFields();
            isQueryTabFocused = false;
            isRegisterTabFocused = true;
        }

        /// <summary>
        /// Reseta a instância de fornecedor atual.
        /// </summary>
        private void ResetProviderFields()
        {
            currentProvider = new provider();
            CanDeleteProvider = false;
            ButtonsHandler();
        }

        /// <summary>
        /// Gerencia os botões.
        /// </summary>
        private void ButtonsHandler()
        {
            SaveBtnHandler();
            DeleteBtnHandler();
        }

        /// <summary>
        /// Ativa ou desativa botão de remover fornecedor.
        /// </summary>
        private void DeleteBtnHandler()
        {
            if (currentProvider != null)
            {
                if (currentProvider.id != 0)
                    CanDeleteProvider = true;

                else
                    CanDeleteProvider = false;
            }
        }

        /// <summary>
        /// Atualiza icone e texto do botão salvar.
        /// </summary>
        private void SaveBtnHandler()
        {
            if (currentProvider != null)
            {
                if (currentProvider.id != 0)
                {
                    SaveBtnIcon = "PersonEdit";
                    SaveBtnText = "Salvar Edição";
                }
                else
                {
                    SaveBtnIcon = "PersonCheck";
                    SaveBtnText = "Salvar";
                }
            }
        }
        #endregion

        #region Inicializa componentes

        /// <summary>
        /// Inicializa componentes necessários para uso da classe.
        /// </summary>
        private void InitializeComponents()
        {
            mainWindowContext = (MainViewModel)Application.Current.MainWindow.DataContext; //Define contexto de dados da janela principal.
            EFContext = mainWindowContext.EFContext;
            UpdateWindowSizeAndPosition();
            currentProvider = new provider();
            SearchProvider();

            #region Eventos            
            mainWindowContext.mainWindow.LocationChanged += WindowPositionHandler;
            mainWindowContext.mainWindow.SizeChanged += WindowSizeHandler;
            mainWindowContext.mainWindow.StateChanged += UpdateWindowSizeAndPosition;
            #endregion

            #region Comandos
            searchProviderCommand = new RelayCommand(SearchProvider);
            gridDoubleClickCommand = new RelayCommand(SetGridCurrentProvider);
            resetCurrentProviderCommand = new RelayCommand(ResetProviderFields);
            saveCurrentProviderCommand = new RelayCommand(InsertOrUpdateProvider);
            deleteCurrentProviderCommand = new RelayCommand(RemoveProvider);
            deleteGridProviderCommand = new RelayCommand(RemoveGridProvider);
            newProviderCommand = new RelayCommand(NewProvider);
            closeWindowCommand = new RelayCommand(CloseWindow);
            minimizeWindowCommand = new RelayCommand(MinimizeWindow); 
            GetWebProviderCommand = new RelayCommand(GetProviderFromWeb);
            #endregion
        }
        /// <summary>
        /// Captura dados do fornecedor no webservice e preenche o cadastro
        /// </summary>
        private void GetProviderFromWeb()
        {
            if(currentProvider.cnpj.Length == 14)
            {
                string webResponse = HttpHelper.GetRequest(currentProvider.cnpj);
                WebProviderModel webProvider = JsonHelper.GetJsonProvider(webResponse);
                if(webProvider != null)
                {
                    currentProvider.name = webProvider.alias;
                    currentProvider.social_name = webProvider.name;                    
                    currentProvider.email = webProvider.email;
                    currentProvider.phone = webProvider.phone;
                }
                else
                {
                    msgBox = new AlphaMessageBox(mainWindowContext.productWindow, "Não foi possível encontrar dados deste CNPJ.");
                    msgBox.ShowDialog();
                }
                
            }
            
        }


        /// <summary>
        /// Método que encerra a janela e suas propriedades.
        /// </summary>
        public void CloseWindow()
        {
            mainWindowContext.CloseChildWindow("providers");
        }

        /// <summary>
        /// Método que minimiza a janela.
        /// </summary>
        private void MinimizeWindow()
        {
            mainWindowContext.MinimizeWindow("providers");
        }

        #endregion
    }
}
