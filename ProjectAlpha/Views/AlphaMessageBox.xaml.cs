using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectAlpha.Views
{
    /// <summary>
    /// Lógica interna para AlphaMessageBox.xaml
    /// </summary>
    public partial class AlphaMessageBox : Window
    {
        /// <summary>
        /// Mensagem a ser exibida.
        /// </summary>
        /// <param name="message">Texto da mensagem.</param>
        public AlphaMessageBox(Window owner, string message)
        {
            
            this.Owner = owner;
            InitializeComponent();
            msg.Text = message;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
