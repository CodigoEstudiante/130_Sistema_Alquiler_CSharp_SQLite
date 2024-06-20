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
    public partial class frmMisDatos : Form
    {
        private static Form formularioPadre;
        public frmMisDatos(Form _formulariopadre)
        {
            formularioPadre = _formulariopadre;
            InitializeComponent();
        }
        static string _clave;
        private void frmMisDatos_Load(object sender, EventArgs e)
        {
            Cliente obj = ClienteLogica.Instancia.Obtener();
            if (obj.IdCliente != 0)
            {
                txtnombrecompleto.Text = obj.Nombre;
                txttipodocumento.Text = obj.TipoDocumento;
                txtnrodocumento.Text = obj.Documento;
                txtcorreo.Text = obj.Correo;
                txttelefono.Text = obj.Telefono;
                _clave = obj.Clave;
            }
            else {
                MessageBox.Show("No se pudo obtener los datos, vuelva a intentarlo más tarde", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            

        }

        private void btnguardarcambios_Click(object sender, EventArgs e)
        {
            Modificar(false);
            string mensaje;
            int respuesta = ClienteLogica.Instancia.Guardar(new Cliente() {
                Nombre = txtnombrecompleto.Text,
                TipoDocumento = txttipodocumento.Text,
                Documento = txtnrodocumento.Text,
                Correo = txtcorreo.Text,
                Telefono = txttelefono.Text
            },out mensaje);

            if (respuesta < 1)
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                Modificar(false);

                MessageBox.Show("Se guardaron los cambios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnmodificardatos_Click(object sender, EventArgs e)
        {
            Modificar(true);
        }

        private void Modificar(bool estado) {
            btnmodificardatos.Visible = !estado;
            btnguardarcambios.Visible = estado;

            txtnombrecompleto.Enabled = estado;
            txttipodocumento.Enabled = estado;
            txtnrodocumento.Enabled = estado;
            txtcorreo.Enabled = estado;
            txttelefono.Enabled = estado;

        }

        private void btncambiarclave_Click(object sender, EventArgs e)
        {
            using (var form = new mdcambiarclave())
            {
                form.clave = _clave;
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _clave = form.clave;
                    if (MessageBox.Show("La contraseña fue cambiada exitosamente.\nEs necesario cerrar sesión y volver a ingresar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        formularioPadre.Close();
                    }
                }
            }
        }
    }
}
