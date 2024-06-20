using Proyecto.Logica;
using Proyecto.Modelo;
using Proyecto.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class frmPagoAlquiler : Form
    {
        public frmPagoAlquiler()
        {
            InitializeComponent();
        }
        private static string clausulas = "";
        private void frmPagoAlquiler_Load(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            rbcodigocontrato.Checked = true;
            rbcodigoinmueble.Checked = false;
            txtcodigoalquiler.Enabled = true;
            cbocodigoinmueble.Enabled = false;

            var listainmueble = InmuebleLogica.Instancia.Listar(out mensaje);
            if (listainmueble.Count > 0)
            {
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
            if (cbocodigoinmueble.Items.Count > 0)
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
            else
            {
                if (cbocodigoinmueble.Items.Count > 0)
                    idinmueble = Convert.ToInt32(((OpcionCombo)cbocodigoinmueble.SelectedItem).Valor.ToString());
            }

            Alquiler obj = AlquilerLogica.Instancia.Obtener(codigoaquiler, idinmueble);

            if (obj.IdAlquiler != 0)
            {
                if (obj.Estado.ToUpper() == "EN CURSO")
                {

                    txtidalquiler.Text = obj.IdAlquiler.ToString();

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
                    txtimportepagar.Text = obj.PrecioAlquiler.ToString("0.00");
                    clausulas = obj.Clausulas;


                    Periodo oPeriodo = PeriodoLogica.Instancia.Listar(obj.IdAlquiler).Where(p => p.ProximoPagar == 1).FirstOrDefault();
                    if (oPeriodo != null)
                    {
                        if (oPeriodo.IdPeriodo != 0)
                        {
                            txtperiodopagar.Text = oPeriodo.NumeroPeriodo.ToString();
                            txtfechalimite.Text = oPeriodo.FechaLimitePeriodo;
                            txtidperiodo.Text = oPeriodo.IdPeriodo.ToString();
                        }
                    }
                }
                else {
                    MessageBox.Show(string.Format("El contrato de alquiler {0} se encuentra {1}",obj.CodigoAlquiler,obj.Estado), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                

            }
            else
            {
                limpiar();
                MessageBox.Show("No se encontraron resultados con los datos de búsqueda solicitados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void limpiar()
        {

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
            txtperiodopagar.Text = "";
            clausulas = "";
            lblestado.Text = "";

            txtperiodopagar.Text = "";
            txtfechalimite.Text = "";
            txtprecioalquiler.Text = "";
            txtimportepagar.Text = "";

            txtidalquiler.Text = "0";
            txtidperiodo.Text = "0";

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

        private void txtimportepagar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtimportepagar.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }

            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            bool _tienedeuda = false;
            decimal _montodeuda = 0;
            string mensaje = string.Empty;
            decimal _importepagar = 0;


            if (!decimal.TryParse(txtimportepagar.Text, out _importepagar))
            {
                MessageBox.Show("El formato de moneda no es correcto\nFormato ejemplo : 0.00", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Alquiler _oAlquiler = new Alquiler()
            {
                IdAlquiler = int.Parse(txtidalquiler.Text),
                CantidadPeriodo = int.Parse(txtcantidadperiodo.Text)
            };

            Periodo _oPeriodo = new Periodo()
            {
                IdPeriodo = int.Parse(txtidperiodo.Text),
                NumeroPeriodo = int.Parse(txtperiodopagar.Text),
                Monto = Convert.ToDecimal(txtimportepagar.Text),
                FechaPago = DateTime.Now.ToString("yyyy-MM-dd", new CultureInfo("en-US"))
            };

            _montodeuda = decimal.Parse(txtprecioalquiler.Text) - _importepagar;

            _tienedeuda = _montodeuda > 0 ? true : false;


            int respuesta = AlquilerLogica.Instancia.Pagar(_oAlquiler, _oPeriodo, _tienedeuda, _montodeuda, out mensaje);
            if (respuesta < 1)
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                limpiar();
                if(_tienedeuda)
                    MessageBox.Show("El pago fue registrado con una deuda pendiente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("El pago fue registrado existosamente!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
    }
}
