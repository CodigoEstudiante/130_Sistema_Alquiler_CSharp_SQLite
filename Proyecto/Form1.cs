using FontAwesome.Sharp;
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
    public partial class Form1 : Form
    {
        //private static Usuario usuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;
        private static Cliente _cliente = null;

        public Form1(Cliente ocliente)
        {
            _cliente = ocliente;
            InitializeComponent();
        }
        public void Abrir()
        {
            AbrirFormulario(menualquiler, new frmResumen());
        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {

            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            MenuActivo = menu;

            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }

            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.WhiteSmoke;

            contenedor.Controls.Add(formulario);
            formulario.Show();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblusuario.Text = _cliente.Nombre;
            lblfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            AbrirFormulario(menuinicio, new frmInicio());
        }

        private void subtipoinmueble_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuconfiguracion, new frmTipoInmueble());
        }

        private void subinmueble_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuconfiguracion, new frmInmueble());
        }

        private void subtipoalquiler_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuconfiguracion, new frmTipoAlquiler());
        }

        private void subtipomoneda_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuconfiguracion, new frmTipoMoneda());
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menualquiler, new frmAlquiler());
        }

        private void menureportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menureportes, new frmResumen());
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menualquiler, new frmHistorial());
        }

        private void menumisdatos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumisdatos, new frmMisDatos(this));
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menupagos, new frmPagoAlquiler());
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menupagos, new frmPagoDeuda());
        }

        private void verHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menupagos, new frmHistorialPago());
        }

        private void menuinicio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuinicio, new frmInicio());
        }

        private void menuinfo_Click(object sender, EventArgs e)
        {
            mdAcercade form = new mdAcercade();
            form.ShowDialog();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Salir?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
