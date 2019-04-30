using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using AppBuscadorRutas.Services.Interfaces;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;

namespace AppBuscadorRutas.Services.Implementaciones
{
    class ServicioAPIRest<T> : IServicioAPIRest<T> where T:class 
    {
        public string URL;
        public ServicioAPIRest(string URL)
        {
            this.URL = URL;
        }
        public List<T> Obtener()
        {
            List<T> ListaDeDatos = new List<T>();
            HttpWebRequest requestCliente = (HttpWebRequest)WebRequest.Create(this.URL);
            using (HttpWebResponse response = (HttpWebResponse)requestCliente.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var json = reader.ReadToEnd();
                    ListaDeDatos = JsonConvert.DeserializeObject<List<T>>(json);
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
