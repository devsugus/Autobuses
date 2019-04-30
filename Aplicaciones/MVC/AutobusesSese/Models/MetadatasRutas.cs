using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

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

        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]        
        public double Km { get; set; }

        public System.TimeSpan Tiempo { get; set; }

        [Range(0, 99999)]
        [DataType(DataType.Currency)]
        
        public int Precio { get; set; }

        public virtual Ciudades Ciudades { get; set; }

        public virtual Ciudades Ciudades1 { get; set; }
    }
}