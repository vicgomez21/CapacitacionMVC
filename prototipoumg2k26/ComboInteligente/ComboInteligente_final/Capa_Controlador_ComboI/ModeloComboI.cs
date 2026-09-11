using Capa_Modelo_ComboI.Repositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Controlador_ComboI
{
    public class ModeloComboI
    {
        RepositorioComboI sentencias = new RepositorioComboI();


        public DataTable enviarDatos(string _tabla, string _campo1, string _campo2)
        {
            var dtTabla = sentencias.obtenerDatos(_tabla, _campo1, _campo2);

            return dtTabla;
        }

        // C# (ejemplo)
        public DataTable obtenerDatos(string tabla, string campo1, string campo2)
        {
            // Validar que tabla y campos coincidan con una lista blanca conocida
            // (evita inyección y errores por nombres incorrectos)
            if (!EsIdentificadorValido(tabla) || !EsIdentificadorValido(campo1) || !EsIdentificadorValido(campo2))
                throw new ArgumentException("Nombre de tabla o columna inválido");

            string sql = $"SELECT `{campo1}`, `{campo2}` FROM `{tabla}`";

            using (var conn = ObtenerConexion())
            using (var cmd = new OdbcCommand(sql, conn))
            using (var adapter = new OdbcDataAdapter(cmd))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

    }
}
