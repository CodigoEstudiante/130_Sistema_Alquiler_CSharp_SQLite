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
using Proyecto.Logica;
using Proyecto.Modelo;

namespace Proyecto
{
    public partial class frmInmueble : Form
    {
        public frmInmueble()
        {
            InitializeComponent();
        }

        private void frmInmueble_Load(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            var lista = TipoInmuebleLogica.Instancia.Listar(out mensaje);

            foreach (TipoInmueble item in lista) {
                cbotipoinmueble.Items.Add(new OpcionCombo() { Valor = item.IdTipoInmueble,Texto = item.Descripcion });
            }
            cbotipoinmueble.DisplayMember = "Texto";
            cbotipoinmueble.ValueMember = "Valor";
            cbotipoinmueble.SelectedIndex = 0;

            
            var listainmueble = InmuebleLogica.Instancia.Listar(out mensaje);

            foreach (Inmueble item in listainmueble)
            {
                dgvdata.Rows.Add(new object[] {
                    item.IdInmueble,
                    item.Codigo,
                    item.oTipoInmueble.IdTipoInmueble,
                    item.oTipoInmueble.Descripcion,
                    item.Descripcion,
                    item.Direccion,
                    item.PrecioAlquiler.ToString("0.00"),
                    item.Estado,
                    "", "" });
            }


            foreach (DataGridViewColumn cl in dgvdata.Columns)
            {
                if (cl.Visible == true && cl.Name != "btneditar" && cl.Name != "btneliminar")
                {
                    cbobuscar.Items.Add(new OpcionCombo() { Valor = cl.Name, Texto = cl.HeaderText });
                }
            }
            cbobuscar.DisplayMember = "Texto";
            cbobuscar.ValueMember = "Valor";
            cbobuscar.SelectedIndex = 0;

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            int id = Convert.ToInt32(txtid.Text);
            decimal precioalquiler;

            if (txtdescripcion.Text.Trim() == "" || txtdireccion.Text.Trim() =="" || txtprecioalquiler.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar los campos obligatorios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(txtprecioalquiler.Text, out precioalquiler)) {
                MessageBox.Show("El formato de moneda no es correcto\nFormato ejemplo : 0.00", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



            int existe = InmuebleLogica.Instancia.Existe(txtcodigo.Text, id, out mensaje);

            if (existe == 1)
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (id == 0)
            {
                int idinmueble = InmuebleLogica.Instancia.Guardar(new Inmueble() {
                    Codigo = txtcodigo.Text,
                    oTipoInmueble = new TipoInmueble() { IdTipoInmueble = int.Parse(((OpcionCombo)cbotipoinmueble.SelectedItem).Valor.ToString()) },
                    Descripcion = txtdescripcion.Text,
                    Direccion = txtdireccion.Text,
                    PrecioAlquiler = Convert.ToDecimal(txtprecioalquiler.Text)
                }, out mensaje);

                if (idinmueble < 1)
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                dgvdata.Rows.Add(new object[] { idinmueble,
                    txtcodigo.Text,
                    ((OpcionCombo)cbotipoinmueble.SelectedItem).Valor.ToString(),
                    ((OpcionCombo)cbotipoinmueble.SelectedItem).Texto,
                    txtdescripcion.Text,
                    txtdireccion.Text,
                    Convert.ToDecimal(txtprecioalquiler.Text).ToString("0.00"),
                    "LIBRE",
                    "", "" });
            }
            else
            {
                int respuesta = InmuebleLogica.Instancia.Editar(new Inmueble() {
                    IdInmueble = int.Parse(txtid.Text),
                    Codigo = txtcodigo.Text,
                    oTipoInmueble = new TipoInmueble() { IdTipoInmueble = int.Parse(((OpcionCombo)cbotipoinmueble.SelectedItem).Valor.ToString()) },
                    Descripcion = txtdescripcion.Text,
                    Direccion = txtdireccion.Text,
                    PrecioAlquiler = Convert.ToDecimal(txtprecioalquiler.Text)
                },
                out mensaje);

                if (respuesta < 1)
                {
                    MessageBox.Show("No se pudo editar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    int index = Convert.ToInt32(txtindice.Text);
                    dgvdata.Rows[index].Cells["Codigo"].Value = txtcodigo.Text;
                    dgvdata.Rows[index].Cells["IdTipoInmueble"].Value = ((OpcionCombo)cbotipoinmueble.SelectedItem).Valor.ToString();
                    dgvdata.Rows[index].Cells["TipodeInmueble"].Value = ((OpcionCombo)cbotipoinmueble.SelectedItem).Texto.ToString();
                    dgvdata.Rows[index].Cells["Descripcion"].Value = txtdescripcion.Text;
                    dgvdata.Rows[index].Cells["Direccion"].Value = txtdireccion.Text;
                    dgvdata.Rows[index].Cells["PrecioAlquiler"].Value = txtprecioalquiler.Text;
                }
            }
            Limpiar();
        }

        private void Limpiar() {

            txtindice.Text = "-1";
            txtid.Text = "0";

            txtcodigo.Text = "";
            cbotipoinmueble.SelectedIndex = 0;
            txtdescripcion.Text = "";
            txtdireccion.Text = "";
            txtprecioalquiler.Text = "";
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 8)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.edit16.Width;
                var h = Properties.Resources.edit16.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.edit16, new Rectangle(x, y, w, h));
                e.Handled = true;
            }

            if (e.ColumnIndex == 9)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.delete16.Width;
                var h = Properties.Resources.delete16.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.delete16, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (dgvdata.Columns[e.ColumnIndex].Name == "btneliminar")
            {

                if (index >= 0)
                {
                    if (MessageBox.Show("¿Desea eliminar el inmueble?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int _id = int.Parse(dgvdata.Rows[index].Cells["Id"].Value.ToString());
                        string mensaje = string.Empty;

                        int valida = InmuebleLogica.Instancia.Validar(_id, out mensaje);

                        if (valida > 0)
                        {
                            MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            int respuesta = InmuebleLogica.Instancia.Eliminar(_id);

                            if (respuesta > 0)
                            {
                                dgvdata.Rows.RemoveAt(index);
                            }
                            else
                                MessageBox.Show("No se pudo eliminar el inmueble", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }

                }
            }
            else if (dgvdata.Columns[e.ColumnIndex].Name == "btneditar")
            {
                if (index >= 0)
                {
                    txtindice.Text = index.ToString();
                    txtid.Text = dgvdata.Rows[index].Cells["Id"].Value.ToString();
                    txtcodigo.Text = dgvdata.Rows[index].Cells["Codigo"].Value.ToString();

                    foreach (OpcionCombo oc in cbotipoinmueble.Items) {
                        if ( int.Parse(oc.Valor.ToString()) == int.Parse(dgvdata.Rows[index].Cells["IdTipoInmueble"].Value.ToString())) {
                            int indice = cbotipoinmueble.Items.IndexOf(oc);
                            cbotipoinmueble.SelectedIndex = indice;
                            break;
                        }

                    }

                    txtdescripcion.Text = dgvdata.Rows[index].Cells["Descripcion"].Value.ToString();
                    txtdireccion.Text = dgvdata.Rows[index].Cells["Direccion"].Value.ToString();
                    txtprecioalquiler.Text = dgvdata.Rows[index].Cells["PrecioAlquiler"].Value.ToString();
                    
                    txtdescripcion.Text = dgvdata.Rows[index].Cells["Descripcion"].Value.ToString();
                }
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
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
    }
}
