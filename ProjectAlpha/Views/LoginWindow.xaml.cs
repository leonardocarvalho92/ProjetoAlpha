using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using ProjectAlpha.ViewModels;

namespace ProjectAlpha.Views
{
    /// <summary>
    /// Lógica interna para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Passa a senha para a viewmodel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void passwordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            LoginViewModel vM = (LoginViewModel)this.DataContext;
            vM.password = passwordTextBox.Password;
        }
        /// <summary>
        /// Valida campos de texto.
        /// </summary>
        /// <param name="sender"></param>
        /// <par
        private void ValidatePassword(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^\w\.,@-\\*]");
            e.Handled = regex.IsMatch(e.Text);
        }
        /// <summary>
        /// Valida campos de texto.
        /// </summary>
        /// <param name="sender"></param>
        /// <par
        private void ValidateUsername(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^\w]");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Bloqueia a tecla espaço
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpaceKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }        
        /// <summary>
        ///Lowercase ao sair do campo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            LoginViewModel viewModel = (LoginViewModel)this.DataContext;
            viewModel.username = viewModel.username.ToLower();
        }
    }
}
