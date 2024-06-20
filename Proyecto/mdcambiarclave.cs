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
    public partial class mdcambiarclave : Form
    {
        public string clave { get; set; }

        public mdcambiarclave()
        {
            InitializeComponent();
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            if (txtclaveactual.Text != clave)
            {
                MessageBox.Show("La contraseña actual no es correcta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                if (txtnuevaclave.Text.Trim() == "" || txtconfirmarnuevaclave.Text.Trim() == "")
                {
                    MessageBox.Show("La nueva contraseña no puede ser vacia", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else {
                    if (txtnuevaclave.Text != txtconfirmarnuevaclave.Text)
                    {
                        MessageBox.Show("La nueva contraseña no coincide con la confirmación", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        string mensaje = string.Empty;
                        int respuesta = ClienteLogica.Instancia.cambiarClave(txtnuevaclave.Text, out mensaje);
                        if (respuesta < 1)
                        {
                            MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    };
                }

                
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mdcambiarclave_Load(object sender, EventArgs e)
        {

        }
    }
}
