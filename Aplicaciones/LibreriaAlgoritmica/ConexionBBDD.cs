using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public class ConexionBBDD
    {   /*
         * Declaración de variables.
         */
        SqlConnectionStringBuilder builder;

        /*
         * Constructor.
         */
        public ConexionBBDD(string servidor, string usuario, string pass, string BBDD)
        {
            builder = new SqlConnectionStringBuilder();
            builder.DataSource = servidor;
            builder.UserID = usuario;
            builder.Password = pass;
            builder.InitialCatalog = BBDD;
        }
        /*
         * Método para establecer la conexión.
         */
        public SqlConnection conexion()
        {
            SqlConnection cnn = new SqlConnection(builder.ConnectionString);
            cnn.Open();
            return cnn;
        }
    }
}
