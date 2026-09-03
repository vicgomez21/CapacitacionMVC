using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_Taller
{
    public class Sentencia
    {
        Conexion conn = new Conexion();
        public OdbcDataAdapter llenarTbl(string nombreTabla)
        {
            string sSQL = "SELECT * FROM " + nombreTabla+";";
            //llenarse con la informacion de la tabla que se le pase por parametro
            OdbcDataAdapter daSentencias = new OdbcDataAdapter(sSQL, conn.conexion());
            return daSentencias;
        }
    }
}
