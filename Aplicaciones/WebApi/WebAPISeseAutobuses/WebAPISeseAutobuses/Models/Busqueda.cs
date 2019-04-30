using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WebAPISeseAutobuses.Models
{
    public class Busqueda
    {
        Ruta ruta;
        ConexionBBDD cnn;

        public Busqueda(ConexionBBDD conexionBBDD)
        {
            this.cnn = conexionBBDD;

        }

        /**
         Método que devuelve un listado con las diferentes rutas entre una ciudad de origen y
            un destino dependiendo de los Km, precio y tiempo
             */
        public List<Ruta> rutas(string ciudadOrigen, string ciudadDestino)
        {
            List<Ruta> rutas = new List<Ruta>();


            string sql0 = "usp_Dijkstra_KM";
            string sql1 = "usp_Dijkstra_Precio";
            string sql2 = "usp_Dijkstra_Tiempo";

            rutas.Add(devuelveRutaKm(ciudadOrigen, ciudadDestino, sql0));
            rutas.Add(devuelveRutaPrecio(ciudadOrigen, ciudadDestino, sql1));
            rutas.Add(devuelveRutaTiempo(ciudadOrigen, ciudadDestino, sql2));

            /*foreach (var item in rutas) {
                Console.WriteLine(item.CiudadOrigen + " -- " + item.CiudadDestino + " -- " + item.Camino + " -- " + item.IdValor + " -- " + item.Valor);
            }
            Console.ReadLine();*/

            return rutas;
        }
        /*
         * Método que devuelve la ruta dependiendo de los Km.
         */
        private Ruta devuelveRutaKm(string ciudadOrigen, string ciudadDestino, string sql)
        {

            try
            {
                SqlCommand command = new SqlCommand(sql, cnn.conexion());

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@StartNode", SqlDbType.Int).Value = devolverCiudad(ciudadOrigen);
                command.Parameters.Add("@EndNode", SqlDbType.Int).Value = devolverCiudad(ciudadDestino);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                Ruta ruta = new Ruta();
                ruta.CiudadOrigen = ciudadOrigen;
                ruta.CiudadDestino = ciudadDestino;
                ruta.Camino = reader.GetString(4);
                ruta.IdValor = "KM";
                ruta.Valor = reader.GetDecimal(2);

                return ruta;
            }
            catch (SqlException e)
            {

            }
            return ruta;
        }
        /*
         * Método que devuelve la ruta dependiendo del precio.
         */
        private Ruta devuelveRutaPrecio(string ciudadOrigen, string ciudadDestino, string sql)
        {

            try
            {
                SqlCommand command = new SqlCommand(sql, cnn.conexion());

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@StartNode", SqlDbType.Int).Value = devolverCiudad(ciudadOrigen);
                command.Parameters.Add("@EndNode", SqlDbType.Int).Value = devolverCiudad(ciudadDestino);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                Ruta ruta = new Ruta();
                ruta.CiudadOrigen = ciudadOrigen;
                ruta.CiudadDestino = ciudadDestino;
                ruta.Camino = reader.GetString(4);
                ruta.IdValor = "Precio";
                ruta.Valor = reader.GetDecimal(2);

                return ruta;
            }
            catch (SqlException e)
            {

            }
            return ruta;
        }
        /*
         * Método que devuelve la ruta dependiendo del tiempo.
         */
        private Ruta devuelveRutaTiempo(string ciudadOrigen, string ciudadDestino, string sql)
        {
            try
            {
                SqlCommand command = new SqlCommand(sql, cnn.conexion());

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@StartNode", SqlDbType.Int).Value = devolverCiudad(ciudadOrigen);
                command.Parameters.Add("@EndNode", SqlDbType.Int).Value = devolverCiudad(ciudadDestino);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                Ruta ruta = new Ruta();
                ruta.CiudadOrigen = ciudadOrigen;
                ruta.CiudadDestino = ciudadDestino;
                ruta.Camino = reader.GetString(4);
                ruta.IdValor = "Tiempo";
                ruta.Valor = reader.GetDecimal(2);

                return ruta;
            }
            catch (SqlException e)
            {

            }
            return ruta;
        }

        /*
         * Método para obtención del ID perteneciente a las ciudades de origen y destino.
         */
        private int devolverCiudad(string ciudad)
        {
            string sql = "SELECT Id, NombreCiudad FROM Ciudades WHERE NombreCiudad = '" + ciudad + "'";
            try
            {
                using (SqlCommand command = new SqlCommand(sql, cnn.conexion()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader.GetInt32(0);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return 0;
        }
    }
}

