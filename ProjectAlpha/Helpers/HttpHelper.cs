
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProjectAlpha.Helpers
{
    public class HttpHelper
    {

        public const string API_URL = @"https://api.cnpja.com.br/companies/";
        public const string KEY = @"987ab156-4e70-4b2b-9c50-19bd67fada51-0930134a-6aab-4e02-ba65-539034d55903";



        /// <summary>
        /// Metodo que realiza request do tipo GET.
        /// </summary>
        /// <returns>string contendo dados da api.</returns>
        public static string GetRequest(string cnpj)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(KEY);
                string result = client.GetStringAsync(API_URL + cnpj).Result;
                TimeSpan.FromSeconds(10);
                return result;
            }
            catch
            {
                return String.Empty;
            }

        }
    }
}
