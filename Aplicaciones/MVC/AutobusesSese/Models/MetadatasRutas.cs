using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutobusesSese.Models
{
    [MetadataType(typeof(MetadatasRutas))]
    public partial class Rutas { }
    public class MetadatasRutas
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        public int Origen { get; set; }

        [DataType(DataType.Text)]
        public int Destino { get; set; }

        [MaxLength(3)]
        public int Km { get; set; }

        public System.TimeSpan Tiempo { get; set; }

        [Range(0, 99999)]
        [DataType(DataType.Currency)]
        public int Precio { get; set; }

        public virtual Ciudades Ciudades { get; set; }

        public virtual Ciudades Ciudades1 { get; set; }
    }
}