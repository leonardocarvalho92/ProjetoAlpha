using PropertyChanged;
using System.ComponentModel;

namespace ProjectAlpha.ViewModels
{/// <summary>
///  Classe  base para implementação do NotifyPropertyChanged
/// </summary>
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Event Handler  
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
