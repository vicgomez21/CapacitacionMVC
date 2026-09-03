using CapaControlador_Taller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista_Taller
{
    public partial class frmPrincipal : Form
    {
        string nombreTabla = "area_cubierta";
        Controlador controlador = new Controlador();

        public frmPrincipal()
        {
            InitializeComponent();
        }
        public void actualizarDataGridView()
        {
            DataTable dtVista = controlador.llenarTbl(nombreTabla);
            dgvConsulta.DataSource = dtVista;
        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            actualizarDataGridView();
        }
    }
}
