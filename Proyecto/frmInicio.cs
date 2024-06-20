using Proyecto.Modelo;
using Proyecto.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            List<Vista> vistapagopendientes = VistaLogica.Instancia.ListarPagosPendientes();
            if (vistapagopendientes.Count > 0) {
                foreach (Vista v in vistapagopendientes)
                {
                    dgvdatapagos.Rows.Add(new object[] { v.CodigoContrato, v.NombreCliente, v.TipoAlquiler, v.TipoInmueble, v.NumeroPeriodo, v.FechaLimite });
                }
            }

            List<Vista> vistadeudas = VistaLogica.Instancia.ListarDeudas();

            if (vistadeudas.Count > 0)
            {
                foreach (Vista v in vistadeudas)
                {
                    dgvdatadeudas.Rows.Add(new object[] { v.CodigoContrato, v.NombreCliente, v.TipoAlquiler, v.TipoInmueble, v.NumeroPeriodo, v.MontoDeuda });
                }
            }

        }
    }
}
