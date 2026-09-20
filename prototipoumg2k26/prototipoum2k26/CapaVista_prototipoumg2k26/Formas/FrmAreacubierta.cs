using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador_prototipoumg2k26;
using CapaVista_prototipoumg2k26.Reportes;

namespace CapaVista_prototipoumg2k26.Formas
{
    public partial class FrmAreacubierta : Form
    {
        private ModeloAreascubiertas areacubierta = new ModeloAreascubiertas();
        public FrmAreacubierta()
        {
            InitializeComponent();
            panIngresoDatos.Enabled = false;
            CargarDatos();
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            listaEmpleados();
        }
        private void listaEmpleados()
        {
            try
            {
                dgvAreascubiertas.DataSource = areacubierta.GetAll();
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvAreascubiertas.DataSource = areacubierta.FindbyId(txtSearch.Text);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvAreascubiertas.DataSource = areacubierta.FindbyId(txtSearch.Text);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            areacubierta.ZonaAreaCubierta = txtZona.Text;
            areacubierta.MunicipioAreaCubierta = txtmunicipio.Text;
            areacubierta.DepartamentoAreaCubierta = txtDepartamento.Text;
            areacubierta.DescripcionAreaCubierta = txtDescripcion.Text;
            bool valido = new Ayudas.ValidacionDatos(areacubierta).Validar();
            if (valido == true)
            {
                string resultado = areacubierta.GrabarCambios();
                MessageBox.Show(resultado);
                listaEmpleados();
                Reinicio();
            }
        }
        private void Reinicio()
        {
            panIngresoDatos.Enabled = false;
            txtZona.Clear();
            txtmunicipio.Clear();
            txtDepartamento.Clear();
            txtDescripcion.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            panIngresoDatos.Enabled = true;
            areacubierta.Estado = EstadoEntidad.Added;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvAreascubiertas.SelectedRows.Count > 0)
            {
                panIngresoDatos.Enabled = true;
                areacubierta.Estado = EstadoEntidad.Modified;
                areacubierta.IdArea = Convert.ToInt32(dgvAreascubiertas.CurrentRow.Cells[0].Value);
                txtZona.Text = dgvAreascubiertas.CurrentRow.Cells[1].Value.ToString();
                txtmunicipio.Text = dgvAreascubiertas.CurrentRow.Cells[2].Value.ToString();
                txtDepartamento.Text = dgvAreascubiertas.CurrentRow.Cells[3].Value.ToString();
                txtDescripcion.Text = dgvAreascubiertas.CurrentRow.Cells[4].Value.ToString();
            }
            else MessageBox.Show("Seleccione una fila");
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvAreascubiertas.SelectedRows.Count > 0)
            {
                areacubierta.Estado = EstadoEntidad.Deleted;
                areacubierta.IdArea = Convert.ToInt32(dgvAreascubiertas.CurrentRow.Cells[0].Value);
                string resultado = areacubierta.GrabarCambios();
                MessageBox.Show(resultado);
                listaEmpleados();
            }
            else MessageBox.Show("Seleccione una fila");
        }
        void CargarDatos()
        {
            comboI1.llenarCombo("area_cubierta", "zona_area_cubierta", "municipio_area_cubierta");

        }

        private void dgvAreascubiertas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmReporteAreaCubierta reporte = new FrmReporteAreaCubierta();
            reporte.Show();
        }
    }
}