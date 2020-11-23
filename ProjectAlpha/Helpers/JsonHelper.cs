using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using ProjectAlpha.Models;
namespace ProjectAlpha.Helpers
{
    public class JsonHelper
    {
        /// <summary>
        /// Lê um arquivo Json.
        /// </summary>
        /// <param name="fileName">Arquivo para ser lido.</param>
        /// <returns>Retorna uma instancia de conficuração ou null.</returns>
        public static SettingsModel JsonFileReader(string fileName)
        {
            SettingsModel settings = new SettingsModel();
            try
            {
                string path = Directory.GetCurrentDirectory();
                using (StreamReader reader = new StreamReader(path+fileName))
                {
               
                    string json = reader.ReadToEnd();
                    settings = JsonConvert.DeserializeObject<SettingsModel>(json);
                    return settings;
                }
            }
            catch
            {
                return null;
            }
           
        }
        /// <summary>
        /// Grava dados em um arquivo json.
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool JsonFileWriter(object obj, string fileName)
        {
            try
            {
                string path = Directory.GetCurrentDirectory();
                using (StreamWriter file = File.CreateText(path+fileName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, obj);
                }
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        /// <summary>
        /// Metodo para deserializar a resposta json.
        /// </summary>
        /// <param name="response">Retorna um fornecedor do tipo web ou nulo.</param>
        /// <returns></returns>
        public static WebProviderModel GetJsonProvider(string response)
        {
            try
            {
                return JsonConvert.DeserializeObject<WebProviderModel>(response);
            }
            catch
            {
                return null;
            }
            
        }

        /// <summary>
        /// Metodo para deserializar a resposta json.
        /// </summary>
        /// <param name="response">Retorna o endereco ou nulo.</param>
        /// <returns></returns>
        public static Adress GetJsonAdress(string response)
        {
            try
            {
                return JsonConvert.DeserializeObject<Adress>(response);
            }
            catch
            {
                return null;
            }

        }
    }
}
