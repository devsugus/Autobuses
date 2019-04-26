using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutobusesSese.Models
{
    [MetadataType(typeof(MetadataCiudadades))]
    public partial class Ciudades { }
    public class MetadataCiudadades
    {
            public int Id { get; set; }

            [MaxLength(3)]
            public string NombreCiudad { get; set; }
        }
    }

