using CapaModelo_prototipoumg2k26.Contratos;
using CapaModelo_prototipoumg2k26.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_prototipoumg2k26.Repositorios
{
    public class RepositorioAreascubiertas : RepositorioMaestro, IRepositorioAreascubiertas
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;
        public RepositorioAreascubiertas()
        {
            selectAll = "SELECT * FROM area_cubierta";
            insert = "INSERT INTO area_cubierta (zona_area_cubierta, municipio_area_cubierta, departamento_area_cubierta, descripcion_area_cubierta) VALUES (?, ?, ?, ?)";
            update = "UPDATE area_cubierta SET zona_area_cubierta=?, municipio_area_cubierta=?, departamento_area_cubierta=?, descripcion_area_cubierta=? WHERE id_area=?";
            delete = "DELETE FROM area_cubierta WHERE id_area=?";
        }
        public int Agregar(Areascubiertas entidad)
        {
            var _parametros = new List<OdbcParameter>();
            _parametros.Add(new OdbcParameter("p_zona_area_cubierta", entidad.zona_area_cubierta));
            _parametros.Add(new OdbcParameter("p_municipio_area_cubierta", entidad.municipio_area_cubierta));
            _parametros.Add(new OdbcParameter("p_departamento_area_cubierta", entidad.departamento_area_cubierta));
            _parametros.Add(new OdbcParameter("p_descripcion_area_cubierta", entidad.descripcion_area_cubierta));

            return EjecucionNonQuery(insert, _parametros, CommandType.Text);
        }

        public int Editar(Areascubiertas entidad)
        {
            var _parametros = new List<OdbcParameter>();
            _parametros.Add(new OdbcParameter("p_zona_area_cubierta", entidad.zona_area_cubierta));
            _parametros.Add(new OdbcParameter("p_municipio_area_cubierta", entidad.municipio_area_cubierta));
            _parametros.Add(new OdbcParameter("p_departamento_area_cubierta", entidad.departamento_area_cubierta));
            _parametros.Add(new OdbcParameter("p_descripcion_area_cubierta", entidad.descripcion_area_cubierta));
            _parametros.Add(new OdbcParameter("p_id_area", entidad.id_area));
            return EjecucionNonQuery(update, _parametros, CommandType.Text);
        }
        public int Remover(Areascubiertas entidad)
        {
            var _parametros = new List<OdbcParameter>();
            _parametros.Add(new OdbcParameter("p_id_area", entidad.id_area));
            return EjecucionNonQuery(delete, _parametros, CommandType.Text);
        }
        public IEnumerable<Areascubiertas> GetAll()
        {
            var lst = new List<Areascubiertas>();
            var tblTabla = EjecucionConsulta(selectAll, CommandType.Text);
            foreach (DataRow row in tblTabla.Rows)
            {
                var item = new Areascubiertas();
                item.id_area = Convert.ToInt32(row[0]);
                item.zona_area_cubierta = row[1]?.ToString();
                item.municipio_area_cubierta = row[2]?.ToString();
                item.departamento_area_cubierta = row[3]?.ToString();
                item.descripcion_area_cubierta = row[4]?.ToString();
                lst.Add(item);
            }
            tblTabla.Clear();
            tblTabla = null;
            return lst;
        }

    }
}
