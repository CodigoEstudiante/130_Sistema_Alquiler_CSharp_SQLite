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
    public partial class frmTipoAlquiler : Form
    {
        public frmTipoAlquiler()
        {
            InitializeComponent();
        }


        private void frmTipoAlquiler_Load(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            var lista = TipoAlquilerLogica.Instancia.Listar(out mensaje);

            foreach (TipoAlquiler item in lista)
            {
                dgvdata.Rows.Add(new object[] { item.IdTipoAlquiler, item.Descripcion,item.Dias, "", "" });
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            int id = Convert.ToInt32(txtid.Text);

            if (txtdescripcion.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una descripcion correcta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            int existe = TipoAlquilerLogica.Instancia.Existe(txtdescripcion.Text, id, out mensaje);

            if (existe == 1)
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (id == 0)
            {
                int idgenerado = TipoAlquilerLogica.Instancia.Guardar(new TipoAlquiler() { Descripcion = txtdescripcion.Text,Dias = int.Parse(txtcantidaddias.Value.ToString()) }, out mensaje);

                if (idgenerado < 1)
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                dgvdata.Rows.Add(new object[] { idgenerado, txtdescripcion.Text,txtcantidaddias.Value.ToString(), "", "" });
            }
            else
            {
                int respuesta = TipoAlquilerLogica.Instancia.Editar(new TipoAlquiler() { Descripcion = txtdescripcion.Text, Dias = int.Parse(txtcantidaddias.Value.ToString()), IdTipoAlquiler = id }, out mensaje);

                if (respuesta < 1)
                {
                    MessageBox.Show("No se pudo editar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    int index = Convert.ToInt32(txtindice.Text);
                    dgvdata.Rows[index].Cells["Descripcion"].Value = txtdescripcion.Text;
                    dgvdata.Rows[index].Cells["CantidadDias"].Value = txtcantidaddias.Value.ToString();
                }
            }
            Limpiar();
        }
        private void Limpiar()
        {

            txtindice.Text = "-1";
            txtid.Text = "0";
            txtdescripcion.Text = "";
            txtcantidaddias.Value = 1;
        }
        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 3)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.edit16.Width;
                var h = Properties.Resources.edit16.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.edit16, new Rectangle(x, y, w, h));
                e.Handled = true;
            }

            if (e.ColumnIndex == 4)
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
            string mensaje = string.Empty;
            if (index >= 0) {



                if (dgvdata.Columns[e.ColumnIndex].Name == "btneliminar")
                {
                    int _id = int.Parse(dgvdata.Rows[index].Cells["Id"].Value.ToString());
                    int definidosistema = TipoAlquilerLogica.Instancia.ValidarDefinido(_id,out mensaje);

                    if (definidosistema > 0)
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else {

                        if (MessageBox.Show("¿Desea eliminar el tipo de alquiler?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int valida = TipoAlquilerLogica.Instancia.Validar(_id, out mensaje);

                            if (valida > 0)
                            {
                                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                int respuesta = TipoAlquilerLogica.Instancia.Eliminar(_id);

                                if (respuesta > 0)
                                {
                                    dgvdata.Rows.RemoveAt(index);
                                }
                                else
                                    MessageBox.Show("No se pudo eliminar el tipo de alquiler", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }

                    

                }
                else if (dgvdata.Columns[e.ColumnIndex].Name == "btneditar")
                {
                    int _id = int.Parse(dgvdata.Rows[index].Cells["Id"].Value.ToString());
                    int definidosistema = TipoAlquilerLogica.Instancia.ValidarDefinido(_id, out mensaje);
                    if (definidosistema > 0)
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else {
                        txtindice.Text = index.ToString();
                        txtid.Text = dgvdata.Rows[index].Cells["Id"].Value.ToString();
                        txtdescripcion.Text = dgvdata.Rows[index].Cells["Descripcion"].Value.ToString();
                        txtcantidaddias.Value = Convert.ToInt32(dgvdata.Rows[index].Cells["CantidadDias"].Value.ToString());
                    }
                }

            }
            

        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void txtcantidaddias_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
