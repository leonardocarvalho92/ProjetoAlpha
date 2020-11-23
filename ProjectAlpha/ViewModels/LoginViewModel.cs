using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Input;
using ProjectAlpha.Views;
namespace ProjectAlpha.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        /// <summary>
        /// Usuario
        /// </summary>
        public string username { get; set; } = "";
        /// <summary>
        /// Senha
        /// </summary>
        public string password { get; set; } = "";

        /// <summary>
        /// Hash Bcrypt da senha
        /// </summary>
        private string hashPswd { get; set; }


        /// <summary>
        /// Conection string 
        /// </summary>
        private string connectionString = ConfigurationManager.ConnectionStrings["ADO"].ConnectionString;

        #region Comandos
        /// <summary>
        /// Comando de efetuar login.
        /// </summary>
        public ICommand signInCommand { get; set; }


        /// <summary>
        /// Comando para fechar a tela de login.
        /// </summary>
        public ICommand closeWindowCommand { get; set; }


        /// <summary>
        /// Apenas para fins de testes, F1 exibir hash.
        /// </summary>
        public ICommand showHashCommand { get; set; }

        #endregion


        public Window loginWindow { get; set; }

        public LoginViewModel()
        {
            loginWindow = Application.Current.MainWindow;


            signInCommand = new RelayCommand(ValidateLogin);
            closeWindowCommand = new RelayCommand(CloseWindow);
            showHashCommand = new RelayCommand(ShowHash);
        }

        /// <summary>
        /// Gera um salt aleatorio para o hash.
        /// </summary>
        /// <returns></returns>
        private static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        /// <summary>
        /// Adiciona o salt e gera o hash do password
        /// </summary>
        /// <param name="password">Senha em texto puro</param>
        /// <returns></returns>
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
        }
        /// <summary>
        /// Valida a senha digitada.
        /// </summary>
        /// <param name="password"> Senha em texto puro.</param>
        /// <param name="correctHash">Hash da senha extraido do banco.</param>
        /// <returns></returns>
        public static bool ValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }

        /// <summary>
        /// Faz a validação do login.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private void ValidateLogin()
        {
            if(username !="" && password != "")
            {
                bool isFailed = true;
                DataTable user = ADOHelper.QueryUserByUsername(connectionString, username);
                if (user != null)
                {
                    try
                    {
                        hashPswd = user.Rows[0][3].ToString();
                    }
                    catch
                    {
                        //tratar
                    }
                    
                }
                if (hashPswd != null)
                {
                    if (ValidatePassword(password, hashPswd))
                    {
                        isFailed = false;
                    }
                }
                if (!isFailed)
                {
                    SignIn(user);
                }
                else
                {
                    AlphaMessageBox msg = new AlphaMessageBox(loginWindow, "Usuário ou senha inválidos.");
                    msg.Show();
                }
            }
            else
            {
                AlphaMessageBox msg = new AlphaMessageBox(loginWindow, "Ops. Usuário e senha precisam estar preenchidos.");
                msg.Show();
            }
            
        }
        /// <summary>
        /// Efetua o login
        /// </summary>
        /// <param name="user"></param>
        public void SignIn(DataTable user)
        {
            MainWindow mainWindow = new MainWindow();
            MainViewModel mViewModel = (MainViewModel)mainWindow.DataContext;
            mViewModel.user = user;
            mViewModel.userFirstName = user.Rows[0][2].ToString();
            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
            mViewModel.mainWindow = mainWindow;
            loginWindow.Close();
        }

        /// <summary>
        /// Fecha a janela de login
        /// </summary>
        private void CloseWindow()
        {
            loginWindow.Close();
        }

        /// <summary>
        /// Apenas para fins de teste, exibe o hash no console.
        /// </summary>
        private void ShowHash()
        {
            System.Console.WriteLine(HashPassword(password));
        }

    }
}
