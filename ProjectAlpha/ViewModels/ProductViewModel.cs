using ProjectAlpha.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Input;
using ProjectAlpha.Views;
using ProjectAlpha.Helpers;

namespace ProjectAlpha.ViewModels
{
    public class ProductViewModel:BaseViewModel
    {
        #region Propriedades Públicas
        /// <summary>
        /// Fonte de dados da grid de produtos.
        /// </summary>
        public DataView dataGridSource { get; set; }


        /// <summary>
        /// Instância de produto em uso  na janela.
        /// </summary>
        public product currentProduct { get; set; }


        /// <summary>
        /// Conteúdo do campo de busca.
        /// </summary>
        public string searchFieldText { get; set; } = "";


        /// <summary>
        /// Produto selecionado na grid.
        /// </summary>
        public DataRowView gridCurrentProduct { get; set; }


        /// <summary>
        /// Indice do item selecionado na grid.
        /// </summary>
        public int gridSelectedIndex { get; set; }

        /// <summary>
        /// Lista de fornecedores.
        /// </summary>
        public ObservableCollection<string> providersList { get; set; }

        /// <summary>
        /// Fornecedor selecionado.
        /// </summary>
        public string selectedProvider { get; set; }
        #endregion

        #region Propriedades Privadas
        /// <summary>
        /// Contexto de dados do Entity Framework
        /// </summary>
        private AlphaEntities EFContext { get; set; }
        #endregion

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
        public string SaveBtnIcon { get; set; } = "ShoppingCartArrowDown";

        /// <summary>
        /// Instancia de janela de alerta.
        /// </summary>
        public AlphaMessageBox msgBox { get; set; } 


        /// <summary>
        /// Texto do botão salvar.
        /// </summary>
        public string SaveBtnText { get; set; } = "Salvar";

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
        public bool CanDeleteProduct { get; set; } = false;
        #endregion

        #region Comandos
        /// <summary>
        /// Comando de busca por produto
        /// </summary>
        public ICommand searchProductCommand { get; set; }


        /// <summary>
        /// Comando de clique duplo na grid.
        /// </summary>
        public ICommand gridDoubleClickCommand { get; set; }


        /// <summary>
        /// Comando para resetar a instância do produtoe redirecionar para cadastro.
        /// </summary>
        public ICommand newProductCommand { get; set; }

        /// <summary>
        /// Comando para resetar instãncia sem redirecionamento.
        /// </summary>
        public ICommand resetCurrentProductCommand { get; set; }


        /// <summary>
        /// Comando para salvar o produto atual.
        /// </summary>
        public ICommand saveCurrentProductCommand { get; set; }


        /// <summary>
        /// Comando para remover o produto atual.
        /// </summary>
        public ICommand deleteCurrentProductCommand { get; set; }


        /// <summary>
        /// Comando para remover o produto atual direto da grid
        /// </summary>
        public ICommand deleteGridCurrentProductCommand { get; set; }

        /// <summary>
        /// Comando para fechar a tela.
        /// </summary>
        public ICommand closeWindowCommand { get; set; }

        /// <summary>
        /// Comando para minimizar tela.
        /// </summary>
        public ICommand minimizeWindowCommand { get; set; }

        /// <summary>
        /// Comando para atualizar a lista de fornecedores.
        /// </summary>
        public ICommand refreshListCommand { get; set; }

     

        #endregion

        #region Construtor
        /// <summary>
        /// Classe responsável por controlar uma tela de produtos.
        /// </summary>
        public ProductViewModel()
        {
            InitializeComponents();
            
        }

        #endregion

        #region Métodos DB
        /// <summary>
        /// Busca produto.
        /// </summary>
        private void SearchProduct()
        {
            //RefreshEFContext();
            DataTable products = ADOHelper.QueryProductsByName(mainWindowContext.connectionString, searchFieldText);
            if (products != null)
                dataGridSource = products.DefaultView;
        }


        /// <summary>
        /// Inicia ou atualiza o contexto de dados do Entity Framework.
        /// </summary>
        private void RefreshEFContext()
        {
            EFContext = new AlphaEntities();
            EFHelper.ChangeDatabase(EFContext, "Alpha", mainWindowContext.settings.SqlInstance, "sa", "sic742", true, "AlphaEntities");
        }

        /// <summary>
        /// Insere dados coletados da grid no <see cref="currentProduct"/>
        /// </summary>
        private void SetGridCurrentProduct()
        {
            if (currentProduct == null)
                currentProduct = new product();
            if (gridCurrentProduct != null)
            {
                currentProduct.id = (int)gridCurrentProduct[0];
                currentProduct.name = gridCurrentProduct[1].ToString();
                currentProduct.amount = (int)gridCurrentProduct[2];
                currentProduct.provider_id = (int)gridCurrentProduct[4];
                selectedProvider = gridCurrentProduct[3].ToString();
                isQueryTabFocused = false;
                isRegisterTabFocused = true;
                ButtonsHandler();
            }

        }

        /// <summary>
        /// Insere ou atualiza dados do produto atual.
        /// </summary>
        private void InsertOrUpdateProduct()
        {
            //Verifica se todos os campos obrigatórios estão preenchidos.
            if ((currentProduct.name != null && selectedProvider != null) && (currentProduct.name != "" && selectedProvider != ""))
            {
                //Insere um novo Produto
                if (currentProduct.id == 0)
                {                    
                    DataTable providerFounded = ADOHelper.QueryProvidersByName(mainWindowContext.connectionString, selectedProvider);
                    currentProduct.provider_id = (int)providerFounded.Rows[0][0];
                    DataTable productFounded = ADOHelper.QueryProductsByName(mainWindowContext.connectionString, currentProduct.name,"=");
                    if(productFounded.Rows.Count == 0)
                    {
                        EFContext.products.Add(currentProduct);
                        EFContext.SaveChanges();
                        RefreshEFContext();
                        productFounded = ADOHelper.QueryProductsByName(mainWindowContext.connectionString, currentProduct.name);
                        currentProduct.id = (int)productFounded.Rows[0][0];
                        ResetProductFields();
                        ButtonsHandler();
                        SearchProduct();
                        isRegisterTabFocused = false;
                        isQueryTabFocused = true;
                    }
                    else
                    {
                        msgBox = new AlphaMessageBox( mainWindowContext.productWindow,"Já existe um produto com este nome.");
                        msgBox.ShowDialog();
                    }
                    
                }
                else
                {
                    product oldProduct = EFContext.products.Find(currentProduct.id);
                    DataTable providerFounded = ADOHelper.QueryProvidersByName(mainWindowContext.connectionString, selectedProvider,"","=");
                    currentProduct.provider_id = (int)providerFounded.Rows[0][0];
                    UpdateProduct(oldProduct);
                    EFContext.SaveChanges();
                    ResetProductFields();
                    ButtonsHandler();
                    SearchProduct();
                    isRegisterTabFocused = false;
                    isQueryTabFocused = true;
                }            
            }
            else
            {
                msgBox = new AlphaMessageBox(mainWindowContext.productWindow, "Preencha os campos obrigatórios.");
                msgBox.ShowDialog();
            }
        }

        /// <summary>
        /// Atualiza dados do produto do DB
        /// </summary>
        /// <param name="old">Produto do contexto</param>
        private void UpdateProduct(product old)
        {
            old.name = currentProduct.name;
            old.amount = currentProduct.amount;
            old.provider_id = currentProduct.provider_id;
        }


        /// <summary>
        /// Remove Produto
        /// </summary>
        private void RemoveProduct()
        {
            //Verifica se o fornecedor atual existe no banco.
            if (currentProduct.id != 0)
            {
                try
                {
                    //RefreshEFContext();
                    product dBProduct = EFContext.products.Find(currentProduct.id);
                    EFContext.products.Remove(dBProduct);
                    EFContext.SaveChanges();
                    ResetProductFields();
                    ButtonsHandler();
                    SearchProduct();
                    isRegisterTabFocused = false;
                    isQueryTabFocused = true;
                }
                catch
                {
                    msgBox = new AlphaMessageBox(mainWindowContext.productWindow, "Não foi possivel excluir este Produto.");
                    msgBox.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Método para remover produto através da grid.
        /// </summary>
        private void RemoveGridProduct()
        {
            //Seta os dados do produto na instância
            UpdateProductOnSelect();
            //Verifica se o fornecedor atual existe no banco.
            if (currentProduct.id != 0)
            {
                try
                {
                    //RefreshEFContext();
                    product dBProduct = EFContext.products.Find(currentProduct.id);
                    EFContext.products.Remove(dBProduct);
                    EFContext.SaveChanges();
                    currentProduct = new product();
                    CanDeleteProduct = false;
                    ButtonsHandler();
                    SearchProduct();
                }
                catch 
                {
                    msgBox = new AlphaMessageBox(mainWindowContext.productWindow, "Não foi possivel excluir este Produto.");
                    msgBox.ShowDialog();
                }
            }
            else {
                msgBox = new AlphaMessageBox(mainWindowContext.productWindow, "Selecione um produto para excluir.");
                msgBox.ShowDialog();
            }
        }



        /// <summary>
        /// Seta dados do produto durante a seleção na grid.
        /// </summary>
        private void UpdateProductOnSelect()
        {
            if (currentProduct == null)
                currentProduct = new product();
            if (gridCurrentProduct != null)
            {
                currentProduct.id = (int)gridCurrentProduct[0];
                currentProduct.name = gridCurrentProduct[1].ToString();
                currentProduct.amount = (int)gridCurrentProduct[2];
                currentProduct.provider_id = (int)gridCurrentProduct[4];
                selectedProvider = gridCurrentProduct[3].ToString();
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
                width = mainWindowContext.width - 17;
            }
            else
            {
                height = SystemParameters.PrimaryScreenHeight - (SystemParameters.CaptionHeight + SystemParameters.MenuBarHeight + 75);
                width = SystemParameters.PrimaryScreenWidth;
            }
        }


        /// <summary>
        /// Reseta a instância de produto atual.
        /// </summary>
        private void ResetProductFields()
        {
            currentProduct = new product();
            CanDeleteProduct = false;
            ButtonsHandler();            
        }

        /// <summary>
        /// Reinicia campos e redireciona para aba cadastro.
        /// </summary>
        private void ResetAndRedirect()
        {
            ResetProductFields();
            isQueryTabFocused = false;
            isRegisterTabFocused = true;           
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
        /// Ativa ou desativa botão de remover produto.
        /// </summary>
        private void DeleteBtnHandler()
        {
            if (currentProduct != null)
            {
                if (currentProduct.id != 0)
                    CanDeleteProduct = true;

                else
                    CanDeleteProduct = false;
            }
        }

        /// <summary>
        /// Atualiza icone e texto do botão salvar.
        /// </summary>
        private void SaveBtnHandler()
        {
            if (currentProduct != null)
            {
                if (currentProduct.id != 0)
                {
                    SaveBtnIcon = "ShoppingCartArrowDown";
                    SaveBtnText = "Salvar Edição";
                }
                else
                {
                    SaveBtnIcon = "ShoppingCartPlus";
                    SaveBtnText = "Salvar";
                }
            }
        }

        /// <summary>
        /// Atualiza lista de fornecedores ativos.
        /// </summary>
        private void RefreshList()
        {
            if(providersList == null)
                providersList = new ObservableCollection<string>();
            if (providersList.Count > 0)
                providersList.Clear();
            DataTable providerFounded = ADOHelper.QueryProvidersByName(mainWindowContext.connectionString, "", "1");
            for (int i = 0; i < providerFounded.Rows.Count; i++)
            {
                providersList.Add((string)providerFounded.Rows[i][1]);
            }
        }        

        /// <summary>
        /// Inicializa componentes da classe.
        /// </summary>
        private void InitializeComponents()
        {
            mainWindowContext = (MainViewModel)Application.Current.MainWindow.DataContext; //Define contexto de dados da janela principal.
            EFContext = mainWindowContext.EFContext;
            UpdateWindowSizeAndPosition();
            SearchProduct();
            currentProduct = new product();
            RefreshList();

            #region Eventos            
            mainWindowContext.mainWindow.LocationChanged += WindowPositionHandler;
            mainWindowContext.mainWindow.SizeChanged += WindowSizeHandler;
            mainWindowContext.mainWindow.StateChanged += UpdateWindowSizeAndPosition;
            #endregion
            #region Comandos
            searchProductCommand = new RelayCommand(SearchProduct);
            gridDoubleClickCommand = new RelayCommand(SetGridCurrentProduct);
            newProductCommand = new RelayCommand(ResetAndRedirect);
            resetCurrentProductCommand = new RelayCommand(ResetProductFields);
            saveCurrentProductCommand = new RelayCommand(InsertOrUpdateProduct);
            deleteCurrentProductCommand = new RelayCommand(RemoveProduct);
            deleteGridCurrentProductCommand = new RelayCommand(RemoveGridProduct);
            closeWindowCommand = new RelayCommand(CloseWindow);
            minimizeWindowCommand = new RelayCommand(MinimizeWindow);
            refreshListCommand = new RelayCommand(RefreshList);
            #endregion
        }



        /// <summary>
        /// Método que encerra a janela e suas propriedades.
        /// </summary>
        public void CloseWindow()
        {
            mainWindowContext.CloseChildWindow("products");
        }

        /// <summary>
        /// Método que minimiza a janela.
        /// </summary>
        private void MinimizeWindow()
        {
            mainWindowContext.MinimizeWindow("products");
        }
        #endregion

    }
}

