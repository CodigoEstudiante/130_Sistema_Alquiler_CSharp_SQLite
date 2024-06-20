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
using System.Globalization;
using Proyecto.Utilidades;
using iTextSharp.text;
using System.IO;
using iTextSharp.tool.xml;
using iTextSharp.text.pdf;

namespace Proyecto
{
    public partial class frmHistorial : Form
    {
        public frmHistorial()
        {
            InitializeComponent();
        }

        private void btnbuscarfiltro_Click(object sender, EventArgs e)
        {
            dgvdata.Rows.Clear();

            DateTime fechaInicio = Convert.ToDateTime(txtfechainicioalquiler.Text);
            DateTime fechaFin = Convert.ToDateTime(txtfechafinalquiler.Text);

            List<Alquiler> listaAlquiler = AlquilerLogica.Instancia.Listar(txtcodigo.Text, 0,
                fechaInicio.ToString("yyyy-MM-dd", new CultureInfo("en-US")),
                fechaFin.ToString("yyyy-MM-dd", new CultureInfo("en-US")));

            if (listaAlquiler.Count <1) {
                MessageBox.Show("No se encontraron resultados con los datos de filtros solicitados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (Alquiler a in listaAlquiler) {
                dgvdata.Rows.Add(new object[] {a.IdAlquiler,a.CodigoAlquiler,a.NombreCliente,a.DocumentoCliente,a.oInmueble.Codigo,a.oInmueble.oTipoInmueble.Descripcion,a.oTipoAlquiler.Descripcion,a.Estado,"","" });
            }
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {

            foreach (DataGridViewColumn cl in dgvdata.Columns)
            {
                if (cl.Visible == true && cl.Name != "btneditar" && cl.Name != "btndescargar" && cl.Name != "btncancelar")
                {
                    cbobuscar.Items.Add(new OpcionCombo() { Valor = cl.Name, Texto = cl.HeaderText });
                }
            }
            cbobuscar.DisplayMember = "Texto";
            cbobuscar.ValueMember = "Valor";
            cbobuscar.SelectedIndex = 0;
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 8)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.download20.Width;
                var h = Properties.Resources.download20.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.download20, new System.Drawing.Rectangle(x, y, w, h));
                e.Handled = true;
            }

            if (e.ColumnIndex == 9)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.editar16.Width;
                var h = Properties.Resources.editar16.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.editar16, new System.Drawing.Rectangle(x, y, w, h));
                e.Handled = true;
            }

            if (e.ColumnIndex == 10)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.cancel20.Width;
                var h = Properties.Resources.cancel20.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.cancel20, new System.Drawing.Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void btnbuscarbusqueda_Click(object sender, EventArgs e)
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

        private void btnborrarbusqueda_Click(object sender, EventArgs e)
        {
            txtbuscar.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnborrarfiltro_Click(object sender, EventArgs e)
        {
            txtfechainicioalquiler.Value = DateTime.Now;
            txtfechafinalquiler.Value = DateTime.Now;

            txtcodigo.Text = "";
            dgvdata.Rows.Clear();
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0) {
                if (dgvdata.Columns[e.ColumnIndex].Name == "btndescargar")
                {
                    if(dgvdata.Rows[index].Cells["Estado"].Value.ToString() == "CANCELADO")
                        MessageBox.Show("Esta operación no esta habilitado para contratos con estado \"CANCELADO\"", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        ProcesoDescarga(index);
                }
                else if (dgvdata.Columns[e.ColumnIndex].Name == "btneditar") {
                    if (dgvdata.Rows[index].Cells["Estado"].Value.ToString() != "EN CURSO")
                        MessageBox.Show("Esta operación solo esta habilitado para contratos en estado: \"EN CURSO\"", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        ProcesoEditar(index);
                }
                else if (dgvdata.Columns[e.ColumnIndex].Name == "btncancelar")
                {
                    if (dgvdata.Rows[index].Cells["Estado"].Value.ToString() != "EN CURSO")
                        MessageBox.Show("Esta operación solo esta habilitado para contratos en estado: \"EN CURSO\"", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        ProcesoCancelacion(index);
                }

            }
        }

        private void ProcesoEditar(int index) {

            string codigoalquiler = dgvdata.Rows[index].Cells["CodigoAlquiler"].Value.ToString();
            using (var form = new mdEditarAlquiler(codigoalquiler))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    dgvdata.Rows[index].Cells["NombreCliente"].Value = form.NombreCliente;
                    dgvdata.Rows[index].Cells["DocumentoCliente"].Value = form.Nrodocumento;
                }
            }
        }

        private void ProcesoCancelacion(int index) {

            string codigoalquiler = dgvdata.Rows[index].Cells["CodigoAlquiler"].Value.ToString();
            int id = Convert.ToInt32(dgvdata.Rows[index].Cells["id"].Value.ToString());

            using (var form = new mdCancelarContrato(codigoalquiler, id))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    dgvdata.Rows[index].Cells["Estado"].Value = "CANCELADO";
                }
            }
        }


        private void ProcesoDescarga(int index) {

            string codigoalquiler = dgvdata.Rows[index].Cells["CodigoAlquiler"].Value.ToString();

            Cliente cl = ClienteLogica.Instancia.Obtener();
            Alquiler obj = AlquilerLogica.Instancia.Listar(codigoalquiler, 0).FirstOrDefault();

            if (obj != null)
            {
                string Texto_Html = Properties.Resources.PlantillaContrato.ToString();

                Texto_Html = Texto_Html.Replace("@codigoalquiler", obj.CodigoAlquiler);
                Texto_Html = Texto_Html.Replace("@fecharegistro", obj.FechaRegistro);

                Texto_Html = Texto_Html.Replace("@propietarionombre", cl.Nombre);
                Texto_Html = Texto_Html.Replace("@propietariotipodocumento", cl.TipoDocumento);
                Texto_Html = Texto_Html.Replace("@propietariodocumento", cl.Documento);
                Texto_Html = Texto_Html.Replace("@propietariocorreo", cl.Correo);
                Texto_Html = Texto_Html.Replace("@propietariotelefono", cl.Telefono);

                Texto_Html = Texto_Html.Replace("@clientenombre", obj.NombreCliente);
                Texto_Html = Texto_Html.Replace("@clientetipodocumento", obj.TipoDocumentoCliente);
                Texto_Html = Texto_Html.Replace("@clientedocumento", obj.DocumentoCliente);
                Texto_Html = Texto_Html.Replace("@clientecorreo", obj.CorreoCliente);
                Texto_Html = Texto_Html.Replace("@clientetelefono", obj.TelefonoCliente);
                Texto_Html = Texto_Html.Replace("@clientenacionalidad", obj.NacionalidadCliente);

                Texto_Html = Texto_Html.Replace("@codigoinmueble", obj.oInmueble.Codigo);
                Texto_Html = Texto_Html.Replace("@tipoinmueble", obj.oInmueble.oTipoInmueble.Descripcion);
                Texto_Html = Texto_Html.Replace("@descripcioninmueble", obj.oInmueble.Descripcion);

                Texto_Html = Texto_Html.Replace("@fechainicioalquiler", obj.FechaInicioAlquiler);
                Texto_Html = Texto_Html.Replace("@tipoalquiler", obj.oTipoAlquiler.Descripcion);
                Texto_Html = Texto_Html.Replace("@cantidadperiodo", obj.CantidadPeriodo.ToString());
                Texto_Html = Texto_Html.Replace("@tipomoneda", obj.oTipoMoneda.Descripcion);
                Texto_Html = Texto_Html.Replace("@precioalquiler", obj.PrecioAlquiler.ToString("0.00"));

                Texto_Html = Texto_Html.Replace("@clausulas", obj.Clausulas);


                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("Contrato_{0}.pdf", codigoalquiler);
                savefile.Filter = "Pdf Files|*.pdf";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                    {
                        //Creamos un nuevo documento y lo definimos como PDF
                        Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        using (StringReader sr = new StringReader(Texto_Html))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        }

                        pdfDoc.Close();
                        stream.Close();
                        MessageBox.Show("Documento Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No se pudo generar el documento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

    }
}
