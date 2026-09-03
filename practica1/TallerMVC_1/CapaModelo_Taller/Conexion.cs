using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_Taller
{
    class Conexion
    {
        public OdbcConnection conexion()
        {
            OdbcConnection conn = new OdbcConnection("Dsn=sistema_reparto;");
            try
            {
                conn.Open();
                Console.WriteLine("Conexion exitosa");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de conexion: " + ex.Message);
            }
            return conn;
        }

        public void desconexion(OdbcConnection conn)
        {
            try
            {
                conn.Close();

            }
            catch (OdbcException)
            {
                Console.WriteLine("Error Se Desconecto");
            }
        }
    }
}
