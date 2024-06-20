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
    public partial class frmAlquiler : Form
    {

        static List<TipoAlquiler> listaTipoAlquiler = new List<TipoAlquiler>();
        static string clausulas;
        public frmAlquiler()
        {
            InitializeComponent();
        }

        private void frmAlquiler_Load(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            int idcorrelativo = AlquilerLogica.Instancia.ObtenerCorrelativo(out mensaje);

            if (idcorrelativo < 1) {
                txtcodigoalquiler.Text = "";
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                txtcodigoalquiler.Text = String.Format("{0:000000}", idcorrelativo);


            txtfechaalquiler.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txtclientenombre.Focus();
            listaTipoAlquiler = TipoAlquilerLogica.Instancia.Listar(out mensaje);
            
            foreach (TipoAlquiler item in listaTipoAlquiler)
            {
                cbotipoalquiler.Items.Add(new OpcionCombo() { Valor = item.IdTipoAlquiler, Texto = item.Descripcion });
            }
            cbotipoalquiler.DisplayMember = "Texto";
            cbotipoalquiler.ValueMember = "Valor";
            cbotipoalquiler.SelectedIndex = 0;

            var listamoneda = TipoMonedaLogica.Instancia.Listar(out mensaje);

            foreach (TipoMoneda item in listamoneda)
            {
                cbotipomoneda.Items.Add(new OpcionCombo() { Valor = item.IdTipoMoneda, Texto = item.Descripcion });
            }
            cbotipomoneda.DisplayMember = "Texto";
            cbotipomoneda.ValueMember = "Valor";
            cbotipomoneda.SelectedIndex = 0;
        }

        private void btnbuscarinmuebles_Click(object sender, EventArgs e)
        {
            using (var form = new mdInmueble())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtinmueblecodigo.Text = form.CodigoAlquiler;
                    txtinmuebletipo.Text = form.TipoInmueble;
                    txtinmuebledescripcion.Text = form.DescripcionInmueble;
                    txtidinmueble.Text = form.IdInmueble;
                    txtprecioalquiler.Text = form.Precio.ToString();
                }
            }
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            decimal precioalquiler;

            if (txtcodigoalquiler.Text == "") {
                MessageBox.Show("No se pudo generar un codigo para el contrato de alquiler.\nFavor vuelva a intentarlo luego", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtclientenombre.Text.Trim() == "" || txtclientetipodocumento.Text.Trim() == "" || txtclientedocumento.Text.Trim() == "" || txtprecioalquiler.Text.Trim() =="" || txtidinmueble.Text == "0") {
                MessageBox.Show("Debe ingresar los campos obligatorios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



            if (!decimal.TryParse(txtprecioalquiler.Text, out precioalquiler))
            {
                MessageBox.Show("El formato de moneda no es correcto\nFormato ejemplo : 0.00", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            DateTime fechaInicioAlquiler;
            int cantidadperiodo = 0;
            TipoAlquiler otipoalquiler = listaTipoAlquiler.Where(ta => 
            ta.IdTipoAlquiler == Convert.ToInt32(((OpcionCombo)cbotipoalquiler.SelectedItem).Valor.ToString())).FirstOrDefault();

            fechaInicioAlquiler = Convert.ToDateTime(txtfechainicioalquiler.Text);
            cantidadperiodo = Convert.ToInt32(txtcantidadperiodo.Value.ToString());



            DateTime fechafinperiodo = fechaInicioAlquiler;
            List<Periodo> listaPeriodos = new List<Periodo>();
            if (otipoalquiler.AplicaDias == 1)
            {
                fechafinperiodo = fechafinperiodo.AddDays(-1);
                for (int i = 1; i<= cantidadperiodo; i++ ) {
                    fechafinperiodo = fechafinperiodo.AddDays(otipoalquiler.Dias);

                    listaPeriodos.Add(new Periodo() {
                        NumeroPeriodo = i,
                        FechaLimitePeriodo = fechafinperiodo.ToString("yyyy-MM-dd", new CultureInfo("en-US")),
                        EstadoPeriodo = "PENDIENTE",
                        ProximoPagar = i == 1 ? 1 : 0
                    });
                }
            }
            else {
                for (int i = 1; i <= cantidadperiodo; i++)
                {
                    fechafinperiodo = fechafinperiodo.AddMonths(1);
                    listaPeriodos.Add(new Periodo()
                    {
                        NumeroPeriodo = i,
                        FechaLimitePeriodo = fechafinperiodo.ToString("yyyy-MM-dd", new CultureInfo("en-US")),
                        EstadoPeriodo = "PENDIENTE",
                        ProximoPagar = i == 1 ? 1 : 0
                    });
                }
            }

            Alquiler oAlquiler = new Alquiler()
            {
                CodigoAlquiler = txtcodigoalquiler.Text,
                NombreCliente = txtclientenombre.Text.Trim(),
                TipoDocumentoCliente = txtclientetipodocumento.Text.Trim(),
                DocumentoCliente = txtclientedocumento.Text.Trim(),
                TelefonoCliente = txtclientetelefono.Text.Trim(),
                CorreoCliente = txtclientecorreo.Text.Trim(),
                NacionalidadCliente = txtclientenacionalidad.Text.Trim(),
                oInmueble = new Inmueble() { IdInmueble = int.Parse(txtidinmueble.Text.Trim()) },
                oTipoAlquiler = new TipoAlquiler() { IdTipoAlquiler = Convert.ToInt32(((OpcionCombo)cbotipoalquiler.SelectedItem).Valor.ToString()) },
                oTipoMoneda = new TipoMoneda() { IdTipoMoneda = Convert.ToInt32(((OpcionCombo)cbotipomoneda.SelectedItem).Valor.ToString()) },
                CantidadPeriodo = int.Parse(txtcantidadperiodo.Value.ToString()),
                PrecioAlquiler = precioalquiler,
                FechaInicioAlquiler = fechaInicioAlquiler.ToString("yyyy-MM-dd", new CultureInfo("en-US")),
                FechaFinAlquiler = fechafinperiodo.ToString("yyyy-MM-dd", new CultureInfo("en-US")),
                FechaRegistro = DateTime.Now.ToString("yyyy-MM-dd", new CultureInfo("en-US")),
                Clausulas = clausulas
            };

            string mensaje = string.Empty;
            int operacionesRealizadas = AlquilerLogica.Instancia.Registrar(oAlquiler, listaPeriodos, out mensaje);

            if (operacionesRealizadas > 0)
            {
                MessageBox.Show(string.Format("Registro Exitoso!.\nCodigo de contrato generado: \"{0}\".\n\nEn la opción de \"Resumen\" podrá ver todo el detalle.", txtcodigoalquiler.Text), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void Limpiar() {
            string mensaje = string.Empty;


            txtcodigoalquiler.Text = "";
            txtfechaalquiler.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txtclientenombre.Text = "";
            txtclientetipodocumento.Text = "";
            txtclientedocumento.Text = "";
            txtclientetelefono.Text = "";
            txtclientecorreo.Text = "";
            txtclientenacionalidad.Text = "";

            txtinmueblecodigo.Text = "";
            txtinmuebletipo.Text = "";
            txtinmuebledescripcion.Text = "";
            txtidinmueble.Text = "0";

            cbotipoalquiler.SelectedIndex = 0;
            txtcantidadperiodo.Value = 1;
            cbotipomoneda.SelectedIndex = 0;
            txtprecioalquiler.Text = "";
            txtfechainicioalquiler.Value = DateTime.Now;
            clausulas = "";

            int idcorrelativo = AlquilerLogica.Instancia.ObtenerCorrelativo(out mensaje);

            if (idcorrelativo < 1) {
                
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }else
                txtcodigoalquiler.Text = String.Format("{0:000000}", idcorrelativo);
        }

        private void txtprecioalquiler_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtprecioalquiler.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void btnclausulas_Click(object sender, EventArgs e)
        {
            using (var form = new mdClausula())
            {
                form.Clausulas = clausulas;
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    clausulas = form.Clausulas;
                }
            }
        }
    }
}
