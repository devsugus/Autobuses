using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutobusesSese.Models.Metadatas
{
    [MetadataType(typeof(MetadatasRutas))]
    public partial class Rutas { }
    public class MetadatasRutas
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public int Origen { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public int Destino { get; set; }

        
        //[Range(0, 3,ErrorMessage ="madafakerhuevon")]
        [MaxLength(3)]
        public int Km { get; set; }


        //[DataType(DataType.Time)]
        [DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{HH: mm}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime Tiempo { get; set; }
        //public System.TimeSpan Tiempo { get; set; }

        [Range(0, 99999)]
        [DataType(DataType.Currency)]
        public int Precio { get; set; }

        [Required]
        public virtual Ciudades Ciudades { get; set; }

        [Required]
        public virtual Ciudades Ciudades1 { get; set; }
    }
}