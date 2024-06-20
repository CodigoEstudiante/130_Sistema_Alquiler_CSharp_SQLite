using Proyecto.Logica;
using Proyecto.Modelo;
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
    public partial class mdEditarAlquiler : Form
    {
        public string NombreCliente { get; set; }
        public string Nrodocumento { get; set; }
        private static string _codigo;
        private static int _id;
        public mdEditarAlquiler(string codigo)
        {
            _codigo = codigo;
            InitializeComponent();
        }

        private void frmEditarAlquiler_Load(object sender, EventArgs e)
        {

            Alquiler obj = AlquilerLogica.Instancia.Listar(_codigo, 0).FirstOrDefault();

            if (obj != null)
            {
                _id = obj.IdAlquiler;
                txtclientenombre.Text = obj.NombreCliente;
                txtclientetipodocumento.Text = obj.TipoDocumentoCliente;
                txtclientedocumento.Text = obj.DocumentoCliente;
                txtclientetelefono.Text = obj.TelefonoCliente;
                txtclientecorreo.Text = obj.CorreoCliente;
                txtclientenacionalidad.Text = obj.NacionalidadCliente;   
                txtclausulas.Text = obj.Clausulas;
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {

            if (txtclientenombre.Text.Trim() == "" || txtclientetipodocumento.Text.Trim() == "" || txtclientedocumento.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar los campos obligatorios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string mensaje = string.Empty;
            int respuesta = AlquilerLogica.Instancia.Editar(new Alquiler() {
                IdAlquiler = _id,
                NombreCliente = txtclientenombre.Text.Trim(),
                TipoDocumentoCliente = txtclientetipodocumento.Text.Trim(),
                DocumentoCliente = txtclientedocumento.Text.Trim(),
                TelefonoCliente = txtclientetelefono.Text.Trim(),
                CorreoCliente = txtclientecorreo.Text.Trim(),
                NacionalidadCliente = txtclientenacionalidad.Text.Trim(),
                Clausulas = txtclausulas.Text
            },out mensaje);
            if (respuesta < 1)
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                NombreCliente = txtclientenombre.Text;
                Nrodocumento = txtclientedocumento.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
