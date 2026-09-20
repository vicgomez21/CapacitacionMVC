using Microsoft.Reporting.WinForms;
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

namespace CapaVista_prototipoumg2k26.Reportes
{
    public partial class FrmReporteAreaCubierta : Form
    {
        private ModeloAreascubiertas Areas = new ModeloAreascubiertas();
        public FrmReporteAreaCubierta()
        {
            InitializeComponent();
        }

        private void FrmReporteAreaCubierta_Load(object sender, EventArgs e)
        {
            ReportDataSource reportDataSource1 = new ReportDataSource("DataSet1", Areas.GetAll());
            reportViewer1.LocalReport.ReportEmbeddedResource = "CapaVista_prototipoumg2k26.Reportes.ReportAreaCubierta.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource1);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
