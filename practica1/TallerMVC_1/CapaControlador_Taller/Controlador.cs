using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo_Taller;

namespace CapaControlador_Taller
{
    public class Controlador
    {
        Sentencia sentencia = new Sentencia();
        public DataTable llenarTbl(string nombreTabla)
        {
        
            OdbcDataAdapter daControlador =sentencia.llenarTbl(nombreTabla);
           
            DataTable dtControlador = new DataTable();

            daControlador.Fill(dtControlador);
            
            return dtControlador;
        }
    }
}
