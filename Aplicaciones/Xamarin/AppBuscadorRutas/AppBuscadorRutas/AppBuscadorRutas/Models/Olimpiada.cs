using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AppBuscadorRutas.Models
{
    public class Value
    {
        public int Dorsal { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string VISA { get; set; }
        public string Premio { get; set; }
        public int NumeroHijos { get; set; }
    }
    public class Olimpiada
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string Context { get; set; }
        public List<Value> value { get; set; }
    }
}
