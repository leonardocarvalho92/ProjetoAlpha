using System;
using System.Windows.Input;

namespace ProjectAlpha
{
    /// <summary>
    /// Classe responsável por executar um comando de forma dinâmica.
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region MEMBROS PUBLICOS
        /// <summary>
        /// Event Handler
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        #endregion

        #region MEMBROS PRIVADOS
        /// <summary>
        /// Comando que será executado.
        /// </summary>
        private Action mAction;
        #endregion

        #region CONSTRUTOR
        /// <summary>
        /// Executa um comando de forma dinâmica.
        /// </summary>
        /// <param name="action"> Comando que será executado. </param>
        public RelayCommand(Action action)
        {
            mAction = action;
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Método que verifica se é possível executar o comando passado - PROVISORIAMENTE
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Executa o comando
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            mAction();
        }
        #endregion
    }
}
