using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using AppBuscadorRutas.Services.Interfaces;
using Newtonsoft.Json;

namespace AppBuscadorRutas.Services.Implementaciones
{
    class ServicioAPIOData<T> : IServicioAPIOData<T> where T : class
    {
        public string URL;
        public ServicioAPIOData(string URL)
        {
            this.URL = URL;
        }
        public T Obtener()
        {
            T TEntity;
            HttpWebRequest requestCliente = (HttpWebRequest)WebRequest.Create(this.URL);
            using (HttpWebResponse response = (HttpWebResponse)requestCliente.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var json = reader.ReadToEnd();
                    TEntity = JsonConvert.DeserializeObject<T>(json);
                    return TEntity;
                }
                else
                {
                    return default(T);
                }
            }
        }
    }
}
