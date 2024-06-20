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
using Proyecto.Utilidades;
namespace Proyecto
{
    public partial class mdInmueble : Form
    {
        public mdInmueble()
        {
            InitializeComponent();
        }
        public string IdInmueble { get; set; }
        public string CodigoAlquiler { get; set; }
        public string TipoInmueble { get; set; }
        public string DescripcionInmueble { get; set; }
        public decimal Precio { get; set; }

        private void mdInmueble_Load(object sender, EventArgs e)
        {
            string mensaje;
            var listainmueble = InmuebleLogica.Instancia.Listar(out mensaje).Where(i => i.Estado == "LIBRE");

            foreach (Inmueble item in listainmueble)
            {
                dgvdata.Rows.Add(new object[] {
                    item.IdInmueble,
                    "",
                    item.Codigo,
                    item.oTipoInmueble.Descripcion,
                    item.Descripcion,
                    item.Direccion,
                    item.PrecioAlquiler.ToString("0.00")});
            }


            foreach (DataGridViewColumn cl in dgvdata.Columns)
            {
                if (cl.Visible == true && cl.Name != "btnseleccionar")
                {
                    cbobuscar.Items.Add(new OpcionCombo() { Valor = cl.Name, Texto = cl.HeaderText });
                }
            }
            cbobuscar.DisplayMember = "Texto";
            cbobuscar.ValueMember = "Valor";
            cbobuscar.SelectedIndex = 0;

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbobuscar.SelectedItem).Valor.ToString();

            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbuscar.Text.ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            txtbuscar.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 1)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.check20.Width;
                var h = Properties.Resources.check20.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check20, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    IdInmueble = dgvdata.Rows[index].Cells["Id"].Value.ToString();
                    CodigoAlquiler = dgvdata.Rows[index].Cells["Codigo"].Value.ToString();
                    TipoInmueble = dgvdata.Rows[index].Cells["Tipodeinmueble"].Value.ToString();
                    DescripcionInmueble = dgvdata.Rows[index].Cells["Descripcion"].Value.ToString();
                    Precio = Convert.ToDecimal(dgvdata.Rows[index].Cells["PrecioAlquiler"].Value.ToString());
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

        //          public string IdInmueble { get; set; }
        //public string CodigoAlquiler { get; set; }
        //public string TipoInmueble { get; set; }
        //public string DescripcionInmueble { get; set; }
        //public string PrecioAlquiler { get; set; }
            }
        }
    }
}
