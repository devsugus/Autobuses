using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AppBuscadorRutas.Services.Interfaces;
using Newtonsoft.Json;

namespace AppBuscadorRutas.Services.Implementaciones
{
    class ServicioAPI <T> : IServicioAPI<T> where T:class
    {
        public string URL;
        public ServicioAPI(string URL)
        {
            this.URL = URL;
        }
        public async Task<List<T>> ObtenerListaDatosAsync()
        {
            List<T> ListaDeDatos = new List<T>();
            HttpWebRequest requestCliente = (HttpWebRequest)WebRequest.Create(this.URL);
            using (HttpWebResponse response = (HttpWebResponse)requestCliente.GetResponse())
            {
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader rd = new StreamReader(response.GetResponseStream());
                    string str = rd.ReadToEnd();
                    ListaDeDatos = JsonConvert.DeserializeObject<List<T>>(str);
                    return ListaDeDatos;
                }
                else
                {
                    return default(List<T>);
                }
            }
        }
    }
}
