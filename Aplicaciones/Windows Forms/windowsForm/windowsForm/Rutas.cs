//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace windowsForm
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rutas
    {
        public int Id { get; set; }
        public int Origen { get; set; }
        public int Destino { get; set; }
        public int Km { get; set; }
        public System.TimeSpan Tiempo { get; set; }
        public int Precio { get; set; }
    
        public virtual Ciudades Ciudades { get; set; }
        public virtual Ciudades Ciudades1 { get; set; }
    }
}