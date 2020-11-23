using ProjectAlpha.ViewModels;
using System.Collections.Generic;

namespace ProjectAlpha.Models
{
    public class WebProviderModel:BaseViewModel
    {
        /// <summary>
        /// Razão Social
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Nome Fantasia
        /// </summary>
        public string alias { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// Telefone
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// Endereço
        /// </summary>
        public Adress adress { get; set; }

    }
    /// <summary>
    /// Classe que receber dados de endereço do webservice.
    /// </summary>
    public class Adress: BaseViewModel
    {
        /// <summary>
        /// Rua
        /// </summary>
        public string street { get; set; }
        /// <summary>
        /// Número
        /// </summary>
        public string number { get; set; }
        /// <summary>
        /// CEP
        /// </summary>
        public string zip { get; set; }
        /// <summary>
        /// Bairro
        /// </summary>
        public string neighborhood { get; set; }
        /// <summary>
        /// Cidade
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// Estado
        /// </summary>
        public string state { get; set; }

    }
}
