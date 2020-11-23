using System;
using System.Text.RegularExpressions;

namespace ProjectAlpha.Helpers
{
    public class ValidateHelper
    {

        /// <summary>
        /// Método que substitui caracteres  inválidos.
        /// </summary>
        /// <param name="strIn">String que contem o texto a ser limpo.</param>
        /// <returns></returns>
        public static string CleanTextInput(string strIn)
        {
            //Aqui tentamos substituir os caracteres inválidos utilizando um tempo limite, caso seja ultrapassado, retornamos uma string vazia.
            try
            {
                return Regex.Replace(strIn, @"[^\w\.@-\\*]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }
        /// <summary>
        /// Valida dados numericos
        /// </summary>
        /// <param name="text">string a ser validada</param>
        /// <returns>apenas digitos ou string vazia</returns>
        public static string OnlyNumbers(string text)
        {                
            try
            {
                return Regex.Replace(text, "[^0-9.-]+", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            catch
            {
                return text.Substring(0,text.Length-2);
            }

        }
    }
}
