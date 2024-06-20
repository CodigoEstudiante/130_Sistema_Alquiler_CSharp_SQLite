using Proyecto.Logica;
using Proyecto.Modelo;
using Proyecto.Utilidades;
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
    public partial class frmResumen : Form
    {
        public frmResumen()
        {
            InitializeComponent();
        }

        private static string clausulas = "";
        private void frmResumen_Load(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            rbcodigocontrato.Checked = true;
            rbcodigoinmueble.Checked = false;
            txtcodigoalquiler.Enabled = true;
            cbocodigoinmueble.Enabled = false;

            var listainmueble = InmuebleLogica.Instancia.Listar(out mensaje);
            if (listainmueble.Count > 0) {
                foreach (Inmueble item in listainmueble)
                {
                    cbocodigoinmueble.Items.Add(new OpcionCombo() { Valor = item.IdInmueble, Texto = item.Codigo });
                }
                cbocodigoinmueble.DisplayMember = "Texto";
                cbocodigoinmueble.ValueMember = "Valor";
                cbocodigoinmueble.SelectedIndex = 0;
            }
            
        }

        private void rbcodigocontrato_CheckedChanged(object sender, EventArgs e)
        {
            txtcodigoalquiler.Enabled = true;
            cbocodigoinmueble.Enabled = false;
            txtcodigoalquiler.Text = "";
            if(cbocodigoinmueble.Items.Count > 0)
                cbocodigoinmueble.SelectedIndex = 0;
        }

        private void rbcodigoinmueble_CheckedChanged(object sender, EventArgs e)
        {
            txtcodigoalquiler.Enabled = false;
            cbocodigoinmueble.Enabled = true;
            txtcodigoalquiler.Text = "";
            if (cbocodigoinmueble.Items.Count > 0)
                cbocodigoinmueble.SelectedIndex = 0;
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string codigoaquiler = string.Empty;
            int idinmueble = 0;


            
            if (rbcodigocontrato.Checked)
            {
                if (txtcodigoalquiler.Text.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar un codigo de contrato", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                codigoaquiler = txtcodigoalquiler.Text;
            }
            else {
                if (cbocodigoinmueble.Items.Count > 0)
                    idinmueble = Convert.ToInt32(((OpcionCombo)cbocodigoinmueble.SelectedItem).Valor.ToString());
            }

            Alquiler obj = AlquilerLogica.Instancia.Obtener(codigoaquiler, idinmueble);

            if (obj.IdAlquiler != 0)
            {
                txtclientenombre.Text = obj.NombreCliente;
                txtclientetipodocumento.Text = obj.TipoDocumentoCliente;
                txtclientedocumento.Text = obj.DocumentoCliente;
                txtclientetelefono.Text = obj.TelefonoCliente;
                txtclientecorreo.Text = obj.CorreoCliente;
                txtclientenacionalidad.Text = obj.NacionalidadCliente;

                txtinmueblecodigo.Text = obj.oInmueble.Codigo;
                txtinmuebletipo.Text = obj.oInmueble.oTipoInmueble.Descripcion;
                txtinmuebledescripcion.Text = obj.oInmueble.Descripcion;

                txttipoalquiler.Text = obj.oTipoAlquiler.Descripcion;
                txtcantidadperiodo.Text = obj.CantidadPeriodo.ToString();
                txttipomoneda.Text = obj.oTipoMoneda.Descripcion;
                txtprecioalquiler.Text = obj.PrecioAlquiler.ToString("0.00");
                txtfechainicioalquiler.Text = obj.FechaInicioAlquiler;
                clausulas = obj.Clausulas;

                lblestado.Text = obj.Estado;
                if (obj.Estado == "CANCELADO")
                    lblestado.ForeColor = Color.Firebrick;
                else if (obj.Estado == "CERRADO")
                    lblestado.ForeColor = Color.RoyalBlue;
                else
                    lblestado.ForeColor = Color.ForestGreen;

                dgvdata.Rows.Clear();
                List<Periodo> listaPeriodo = PeriodoLogica.Instancia.Listar(obj.IdAlquiler);
                foreach (Periodo item in listaPeriodo)
                {
                    dgvdata.Rows.Add(new object[] {
                    item.NumeroPeriodo,
                    item.FechaLimitePeriodo,
                    item.EstadoPeriodo
                    });
                }

            }
            else {
                limpiar();
                MessageBox.Show("No se encontraron resultados con los datos de búsqueda solicitados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }


        private void limpiar() {

            txtcodigoalquiler.Text = "";
            if (cbocodigoinmueble.Items.Count > 0)
                cbocodigoinmueble.SelectedIndex = 0;

            txtclientenombre.Text = "";
            txtclientetipodocumento.Text = "";
            txtclientedocumento.Text = "";
            txtclientetelefono.Text = "";
            txtclientecorreo.Text = "";
            txtclientenacionalidad.Text = "";

            txtinmueblecodigo.Text = "";
            txtinmuebletipo.Text = "";
            txtinmuebledescripcion.Text = "";

            txttipoalquiler.Text = "";
            txtcantidadperiodo.Text = "";
            txttipomoneda.Text = "";
            txtprecioalquiler.Text = "";
            txtfechainicioalquiler.Text = "";
            clausulas = "";
            lblestado.Text = "";
            dgvdata.Rows.Clear();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnclausulas_Click(object sender, EventArgs e)
        {
            using (var form = new mdClausula())
            {
                form.Clausulas = clausulas;
                form.txtclausulas.ReadOnly = true;
                form.btnguardar.Visible = false;
                form.btncancelar.Text = "Aceptar";
                form.btncancelar.Focus();
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    clausulas = form.Clausulas;
                }
            }
        }
    }
}
