using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProyectoTaller
{
    public class api
    {
        public string GetHorseName()
        {
            string url = "https://fakerapi.it/api/v1/users?_quantity=1&_gender=male";
            string jsonResponse = MakeRequest(url);
            string name = ExtractName(jsonResponse);
            string lastname = ExtractLastname(jsonResponse);
            string nameHorse = name + " " + lastname;
            return nameHorse;
        }
        static string MakeRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            string jsonResponse;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        jsonResponse = reader.ReadToEnd();
                    }
                }
            }

            return jsonResponse;
        }
        private string ExtractName(string jsonResponse)
        {
            string name = string.Empty;

            // Parsear la respuesta JSON
            using (JsonDocument jsonDocument = JsonDocument.Parse(jsonResponse))
            {
                // Extraer el arreglo de personas
                JsonElement root = jsonDocument.RootElement;
                if (root.TryGetProperty("data", out JsonElement dataArray))
                {
                    if (dataArray.ValueKind == JsonValueKind.Array && dataArray.GetArrayLength() > 0)
                    {
                        // Tomar el primer nombre de la lista (siempre hay uno en este caso)
                        if (dataArray[0].TryGetProperty("firstname", out JsonElement nameElement))
                        {
                            name = nameElement.GetString();
                        }
                    }
                }
            }

            return name;
        }

        private string ExtractLastname(string jsonResponse)
        {
            string lastname = string.Empty;

            // Parsear la respuesta JSON
            using (JsonDocument jsonDocument = JsonDocument.Parse(jsonResponse))
            {
                // Extraer el arreglo de personas
                JsonElement root = jsonDocument.RootElement;
                if (root.TryGetProperty("data", out JsonElement dataArray))
                {
                    if (dataArray.ValueKind == JsonValueKind.Array && dataArray.GetArrayLength() > 0)
                    {
                        // Tomar el primer nombre de la lista (siempre hay uno en este caso)
                        if (dataArray[0].TryGetProperty("lastname", out JsonElement lastnameElement))
                        {
                            lastname = lastnameElement.GetString();
                        }
                    }
                }
            }

            return lastname;
        }
    }
}
