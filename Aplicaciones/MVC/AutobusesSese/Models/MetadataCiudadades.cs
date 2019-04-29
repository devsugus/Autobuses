using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutobusesSese.Models
{
    [MetadataType(typeof(MetadataCiudadades))]
    public partial class Ciudades { }
    public class MetadataCiudadades
    {
            public int Id { get; set; }

            [MinLength(3)]
            [Remote("VerificarCiudad", "Ciudades", HttpMethod="Post")]
            public string NombreCiudad { get; set; }
        }
    }

