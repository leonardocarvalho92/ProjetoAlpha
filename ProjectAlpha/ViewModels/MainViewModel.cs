using System;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Input;
using ProjectAlpha.Models;
using ProjectAlpha.Views;
using ProjectAlpha.Helpers;

namespace ProjectAlpha.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        #region Propriedades da Janela

        /// <summary>
        /// Comprimento da janela
        /// </summary>
        public double height { get; set; } = 700;
        /// <summary>
        /// Largura da janela
        /// </summary>
        public double width { get; set; } = 1000;
        /// <summary>
        /// Ponto inicial da coordenada Y de onde a tela esta localizada
        /// </summary>
        public double top { get; set; }
        /// <summary>
        /// Ponto inicial da coordenada X de onde a tela esta localizada
        /// </summary>
        public double left { get; set; }
        /// <summary>
        /// Altura do submenu de cadastros - Utilizado para exibir ou ocultar o submenu.
        /// </summary>
        public int registerSubMenuHeight { get; set; } = 0;

        /// <summary>
        /// Instância da janela principal.
        /// </summary>
        public Window mainWindow { get; set; }

        /// <summary>
        /// Define se a miniatura da janela produto sera exibida ou não.
        /// </summary>
        public string productThumbIsVisible { get; set; } = "Collapsed";

        /// <summary>
        /// Define se a miniatura da janela fornecedor sera exibida ou não.
        /// </summary>
        public string providerThumbIsVisible { get; set; } = "Collapsed";


        #endregion


        #region Propriedades públicas


        /// <summary>
        /// Contexto de dados do Entity Framework
        /// </summary>
        public AlphaEntities EFContext { get; set; }

        public string connectionString = ConfigurationManager.ConnectionStrings["ADO"].ConnectionString;

        /// <summary>
        /// Nome do usuário logado.
        /// </summary>
        public string userFirstName { get; set; }
        /// <summary>
        /// Instância de usuário logado.
        /// </summary>
        public DataTable user { get; set; }
        /// <summary>
        /// Configurações do sistema.
        /// </summary>
        public SettingsModel settings { get; set; }
        #endregion

        #region Janelas Filhas
        /// <summary>
        /// Instância atual da janela de fornecedores.
        /// </summary>
        public Window providerWindow { get; set; }

        /// <summary>
        /// Instância atual da janela de produtos.
        /// </summary>
        public Window productWindow { get; set; }

        #endregion



        #region Comandos da Janela
        /// <summary>
        /// Comando do menu configurações.
        /// </summary>
        public ICommand registerMenuCommand { get; set; }

        /// <summary>
        /// Comando que exibe a tela de fornecedor.
        /// </summary>
        public ICommand showProvidersWindowCommand { get; set; }

        /// <summary>
        /// Comando que exibe a tela de produto.
        /// </summary>
        public ICommand showProductsWindowCommand { get; set; }

        /// <summary>
        /// Comando da miniatura da janela de fornecedor.
        /// </summary>
        public ICommand maxProviderWindowCommand { get; set; }
        /// <summary>
        /// Comando de miniatura da janela de produto.
        /// </summary>
        public ICommand maxProductWindowCommand { get; set; }


        /// <summary>
        /// Comando para deslogar do sistema.
        /// </summary>
        public ICommand signOutCommand { get; set; }
        #endregion


        /// <summary>
        /// Responsável por gerenciar uma janela principal.
        /// </summary>
        public MainViewModel()
        {
            InitializeComponents();
        }

        #region Métodos de exibição de nova janela.

        /// <summary>
        /// Exibe a janela dos fornecedores.
        /// </summary>
        private void ShowProviderWindow()
        {
            if(providerWindow == null)
            {
                providerWindow = new ProviderWindow();
                providerWindow.Owner = mainWindow;
                providerWindow.Show();
            }
            else
            {
                ShowOrHideWindow(providerWindow);
            }            
        }

        /// <summary>
        /// Exibe a janela dos produtos.
        /// </summary>
        private void ShowProductWindow()
        {
            if(productWindow == null)
            {
                productWindow = new ProductWindow();
                productWindow.Owner = mainWindow;             
                productWindow.Show();
            }
            else
            {
                ShowOrHideWindow(productWindow);
            }            
        }

        /// <summary>
        /// Determina a instância da janela principal.
        /// </summary>
        private void GetMainWindow()
        {
            mainWindow =  Application.Current.MainWindow;
        }
        #endregion


        /// <summary>
        /// Define a localização inicial de uma janela filha.
        /// </summary>
        /// <returns></returns>
        private Tuple<double, double> SetChildWindowPosition()
        {
            //Define a localização da janela
            double childTop = top + (SystemParameters.CaptionHeight + 69);
            double childLeft = left;
            return Tuple.Create(childTop, childLeft);
        }


        /// <summary>
        /// Exibe ou esconde uma janela
        /// </summary>
        /// <param name="window">Objeto do tipo <see cref="Window"/> para ter sua propriedade alterada.</param>
        private void ShowOrHideWindow(Window window)        {

            if (window.Visibility == Visibility.Hidden)
            {
                window.Visibility = Visibility.Visible;
                if (window.Title == "ProviderWindow")
                {
                    providerThumbIsVisible = "Collapsed";
                }
                else if (window.Title == "ProductWindow")
                {
                    productThumbIsVisible = "Collapsed";
                }
            }               
            else
            {
                window.Visibility = Visibility.Hidden;
                if(window.Title == "ProviderWindow")
                {
                    providerThumbIsVisible = "Visible";
                }
                else if(window.Title == "ProductWindow")
                {
                    productThumbIsVisible = "Visible";
                }
            }
        }

        #region Métodos da Janela

        /// <summary>
        /// Exibe ou oculta o submenu de cadastros.
        /// </summary>
        private void ShowOrHideSubRegisterSubMenu()
        {
            try
            {
                if (registerSubMenuHeight == 0)
                    registerSubMenuHeight = 80;
                else
                    registerSubMenuHeight = 0;
            }
            catch
            {
                //tratar
            }
            
        }
        /// <summary>
        /// Inicializa componentes da classe.
        /// </summary>
        private void InitializeComponents()
        {
            GetMainWindow();
            settings = JsonHelper.JsonFileReader(@"\AlphaSettings.json");
            EFContext = new AlphaEntities();
            EFHelper.ChangeDatabase(EFContext, "Alpha", settings.SqlInstance, "sa", "sic742", true, "AlphaEntities");
            CenterWindowOnScreen();

            #region Inicialização dos comandos

            registerMenuCommand = new RelayCommand(ShowOrHideSubRegisterSubMenu);
            showProvidersWindowCommand = new RelayCommand(ShowProviderWindow);
            showProductsWindowCommand = new RelayCommand(ShowProductWindow);
            maxProductWindowCommand = new RelayCommand(MaxProductWindow);
            maxProviderWindowCommand = new RelayCommand(MaxProviderWindow);
            signOutCommand = new RelayCommand(SignOut);
            #endregion
        }

        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            left= (screenWidth / 2) - (width / 2);
            top = (screenHeight / 2) - (height / 2);
        }

        /// <summary>
        /// Método para que desloga do sistema.
        /// </summary>
        private void SignOut()
        {
            CloseChildWindow("products");
            CloseChildWindow("providers");
            LoginWindow loginWindow = new LoginWindow();
            LoginViewModel loginViewModel = (LoginViewModel)loginWindow.DataContext;
            Application.Current.MainWindow = loginWindow;
            loginWindow.Show();
            loginViewModel.loginWindow = loginWindow;            
            mainWindow.Close();
            mainWindow = null;

        }


        /// <summary>
        /// Fecha as janelas filhas.
        /// </summary>
        /// <param name="window">nome da janela a ser fechada</param>
        public void CloseChildWindow(string window)
        {
            switch (window)
            {
                case "products":
                    if(productWindow != null)
                    {
                        productWindow.Close();
                        productWindow.DataContext = null;
                        productWindow = null;                        
                    }
                    break;
                case "providers":
                    if (providerWindow != null)
                    {
                        providerWindow.Close();
                        providerWindow.DataContext = null;
                        providerWindow = null;
                    }                    
                    break;
            }
                
            
        }


        /// <summary>
        /// Método para minimizar janelas filhas
        /// </summary>
        /// <param name="window"></param>
        public void MinimizeWindow(string window)
        {
            switch (window)
            {
                case "products":
                    ShowOrHideWindow(productWindow);
                    break;

                case "providers":
                    ShowOrHideWindow(providerWindow);
                    break;
            }

        }

        /// <summary>
        /// Comando da thumb para exibir janela de produto.
        /// </summary>
        private void MaxProductWindow()
        {
            ShowOrHideWindow(productWindow);
        }

        /// <summary>
        /// Comando da thumb para exibir janela de fornecedor.
        /// </summary>
        private void MaxProviderWindow()
        {
            ShowOrHideWindow(providerWindow);
        }

        #endregion
    }
}
