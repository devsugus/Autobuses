using System;

namespace BibliotecaWebAPI
{
    public class Ciudades
    {
        public int Id { get; set; }
        public string NombreCiudad { get; set; }
    }

    public class Ciudades1
    {
        public int Id { get; set; }
        public string NombreCiudad { get; set; }
    }

    public class Ruta
    {
        //public Ciudades Ciudades { get; set; }
        //public Ciudades1 Ciudades1 { get; set; }
        //public int Id { get; set; }
        public int Origen { get; set; }
        public int Destino { get; set; }
        public double Km { get; set; }
        public string Tiempo { get; set; }
        public double Precio { get; set; }
    }
}
