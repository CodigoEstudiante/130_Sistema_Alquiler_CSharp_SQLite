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

namespace Proyecto.Utilidades
{
    public partial class mdCancelarContrato : Form
    {
        private static Cliente _obj;
        private static string _codigo;
        private static int _idalquiler;
        public mdCancelarContrato(string codigo,int idalquiler)
        {
            _codigo = codigo;
            _idalquiler = idalquiler;
            InitializeComponent();
        }

        private void mdCancelarContrato_Load(object sender, EventArgs e)
        {
            _obj = ClienteLogica.Instancia.Obtener();
            if (_obj.IdCliente != 0)
            {
                lbltexto.Text = "El contrato de alquiler de código: \"" + _codigo + "\" será cancelado.\n\nPara continuar con la operación debe ingresar su contraseña y presionar \"Aceptar\"";
            }
            else
            {
                MessageBox.Show("No se pudo obtener los datos, vuelva a intentarlo más tarde", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            if (txtclaveactual.Text != _obj.Clave)
            {
                MessageBox.Show("La contraseña no es correcta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                string mensaje = string.Empty;
                int respuesta = AlquilerLogica.Instancia.Cancelar(_idalquiler,out mensaje);
                if (respuesta < 1)
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
