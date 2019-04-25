using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutobusesSese.Models.Metadatas
{
    [MetadataType(typeof(MetadatasCiudades))]
    public partial class Ciudades { }
    public class MetadatasCiudades
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string NombreCiudad { get; set; }
    }
}