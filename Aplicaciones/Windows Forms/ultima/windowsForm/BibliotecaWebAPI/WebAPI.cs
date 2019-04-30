using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace BibliotecaWebAPI
{
    public class WebAPI : IWebAPIcs
    {
        public List<Ciudades> DameCiudades()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://localhost:42549/api/Ciudades");
            using (HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse())
            using (Stream stream = respuesta.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json_ = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Ciudades>>(json_);
            }
        }

        public List<Ruta> DameRutas(int ciudadOrigen, int ciudadDestino)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://localhost:42549/api/Ruta/" + ciudadOrigen + "/" + ciudadDestino);
            using (HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse())
            using (Stream stream = respuesta.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json_ = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Ruta>>(json_);
            }
        }
    }
}
