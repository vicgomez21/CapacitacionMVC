using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo_prototipoumg2k26.Contratos;
using CapaModelo_prototipoumg2k26.Entidades;
using CapaModelo_prototipoumg2k26.Repositorios;
using System.ComponentModel.DataAnnotations;

namespace CapaControlador_prototipoumg2k26
{
    public class ModeloAreascubiertas
    {
        private int _id_area;
        private string _zona_area_cubierta;
        private string _municipio_area_cubierta;
        private string _departamento_area_cubierta;
        private string _descripcion_area_cubierta;
        private IRepositorioAreascubiertas _repositorioAreas;

        public EstadoEntidad Estado { private get; set; }
        private List<ModeloAreascubiertas> ListaAreas;

        public int IdArea { get => _id_area; set => _id_area = value; }

        [Required(ErrorMessage = "El campo zona es requerido")]
        [StringLength(100, ErrorMessage = "La zona debe tener máximo 100 caracteres")]
        public string ZonaAreaCubierta { get => _zona_area_cubierta; set => _zona_area_cubierta = value; }

        [Required(ErrorMessage = "El campo municipio es requerido")]
        [StringLength(100, ErrorMessage = "El municipio debe tener máximo 100 caracteres")]
        public string MunicipioAreaCubierta { get => _municipio_area_cubierta; set => _municipio_area_cubierta = value; }

        [Required(ErrorMessage = "El campo departamento es requerido")]
        [StringLength(100, ErrorMessage = "El departamento debe tener máximo 100 caracteres")]
        public string DepartamentoAreaCubierta { get => _departamento_area_cubierta; set => _departamento_area_cubierta = value; }

        [StringLength(255, ErrorMessage = "La descripción debe tener máximo 255 caracteres")]
        public string DescripcionAreaCubierta { get => _descripcion_area_cubierta; set => _descripcion_area_cubierta = value; }

        public ModeloAreascubiertas()
        {
            _repositorioAreas = new RepositorioAreascubiertas();
        }

        public string GrabarCambios()
        {
            string mensaje = null;
            try
            {
                var entidad = new Areascubiertas();
                entidad.id_area = _id_area;
                entidad.zona_area_cubierta = _zona_area_cubierta;
                entidad.municipio_area_cubierta = _municipio_area_cubierta;
                entidad.departamento_area_cubierta = _departamento_area_cubierta;
                entidad.descripcion_area_cubierta = _descripcion_area_cubierta;

                switch (Estado)
                {
                    case EstadoEntidad.Added:
                        _repositorioAreas.Agregar(entidad);
                        mensaje = "Grabación exitosa";
                        break;
                    case EstadoEntidad.Modified:
                        _repositorioAreas.Editar(entidad);
                        mensaje = "Actualización exitosa";
                        break;
                    case EstadoEntidad.Deleted:
                        _repositorioAreas.Remover(entidad);
                        mensaje = "Eliminación exitosa";
                        break;
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.ToString();
            }
            return mensaje;
        }

        public List<ModeloAreascubiertas> GetAll()
        {
            var datos = _repositorioAreas.GetAll();
            ListaAreas = new List<ModeloAreascubiertas>();
            foreach (Areascubiertas item in datos)
            {
                ListaAreas.Add(new ModeloAreascubiertas
                {
                    _id_area = item.id_area,
                    _zona_area_cubierta = item.zona_area_cubierta,
                    _municipio_area_cubierta = item.municipio_area_cubierta,
                    _departamento_area_cubierta = item.departamento_area_cubierta,
                    _descripcion_area_cubierta = item.descripcion_area_cubierta
                });
            }
            return ListaAreas;
        }

        // Búsqueda simple por zona o municipio (ajustable según necesidad)
        public IEnumerable<ModeloAreascubiertas> FindbyId(string filter)
        {
            if (ListaAreas == null) GetAll();
            if (string.IsNullOrWhiteSpace(filter)) return ListaAreas ?? new List<ModeloAreascubiertas>();

            return ListaAreas.FindAll(e =>
                (!string.IsNullOrEmpty(e.MunicipioAreaCubierta) &&
                 e.MunicipioAreaCubierta.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                ||
                (!string.IsNullOrEmpty(e.DepartamentoAreaCubierta) &&
                 e.DepartamentoAreaCubierta.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
            );
        }
    }
}
