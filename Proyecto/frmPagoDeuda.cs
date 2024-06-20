using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Proyecto.Logica;
using Proyecto.Modelo;
using Proyecto.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class frmPagoDeuda : Form
    {
        public frmPagoDeuda()
        {
            InitializeComponent();
        }

        private void frmPagoDeuda_Load(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            rbcodigocontrato.Checked = true;
            rbcodigoinmueble.Checked = false;
            txtcodigoalquiler.Enabled = true;
            cbocodigoinmueble.Enabled = false;

            var listainmueble = InmuebleLogica.Instancia.Listar(out mensaje);
            if (listainmueble.Count > 0)
            {
                foreach (Inmueble item in listainmueble)
                {
                    cbocodigoinmueble.Items.Add(new OpcionCombo() { Valor = item.IdInmueble, Texto = item.Codigo });
                }
                cbocodigoinmueble.DisplayMember = "Texto";
                cbocodigoinmueble.ValueMember = "Valor";
                cbocodigoinmueble.SelectedIndex = 0;
            }
        }

        private void rbcodigocontrato_CheckedChanged(object sender, EventArgs e)
        {

            txtcodigoalquiler.Enabled = true;
            cbocodigoinmueble.Enabled = false;
            txtcodigoalquiler.Text = "";
            if (cbocodigoinmueble.Items.Count > 0)
                cbocodigoinmueble.SelectedIndex = 0;
        }

        private void rbcodigoinmueble_CheckedChanged(object sender, EventArgs e)
        {
            txtcodigoalquiler.Enabled = false;
            cbocodigoinmueble.Enabled = true;
            txtcodigoalquiler.Text = "";
            if (cbocodigoinmueble.Items.Count > 0)
                cbocodigoinmueble.SelectedIndex = 0;
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string codigoaquiler = string.Empty;
            int idinmueble = 0;



            if (rbcodigocontrato.Checked)
            {
                if (txtcodigoalquiler.Text.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar un codigo de contrato", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                codigoaquiler = txtcodigoalquiler.Text;
            }
            else
            {
                if (cbocodigoinmueble.Items.Count > 0)
                    idinmueble = Convert.ToInt32(((OpcionCombo)cbocodigoinmueble.SelectedItem).Valor.ToString());
            }

            Alquiler obj = AlquilerLogica.Instancia.Obtener(codigoaquiler, idinmueble);

            if (obj.IdAlquiler != 0)
            {
                txtidalquiler.Text = obj.IdAlquiler.ToString();
                txtcodigo.Text = obj.CodigoAlquiler;

                List<Deuda> olista = DeudaLogica.Instancia.Listar(obj.IdAlquiler);
                if (olista.Count > 0)
                {
                    foreach (Deuda item in olista)
                    {
                        dgvdata.Rows.Add(new object[] {
                            item.IdDeuda,
                            item.IdPeriodo,
                            item.NumeroPeriodo,
                            item.MontoDeuda,
                            item.EstadoDeuda,
                            "",
                            "",
                            item.FechaPago
                        });
                    }
                }
                else {
                    MessageBox.Show("No se encontraron deudas para el codigo de contrato: " + obj.CodigoAlquiler, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("No se encontraron resultados con los datos de búsqueda solicitados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void limpiar()
        {

            txtcodigoalquiler.Text = "";
            if (cbocodigoinmueble.Items.Count > 0)
                cbocodigoinmueble.SelectedIndex = 0;

            txtidalquiler.Text = "0";
            txtcodigo.Text = "";
            dgvdata.Rows.Clear();

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 5)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.cash16.Width;
                var h = Properties.Resources.cash16.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.cash16, new System.Drawing.Rectangle(x, y, w, h));
                e.Handled = true;
            }

            if (e.ColumnIndex == 6)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.download20.Width;
                var h = Properties.Resources.download20.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.download20, new System.Drawing.Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            if (index >= 0)
            {
                if (dgvdata.Columns[e.ColumnIndex].Name == "btnpagar")
                {

                    if (dgvdata.Rows[index].Cells["EstadoDeuda"].Value.ToString() == "PENDIENTE")
                    {

                        if (MessageBox.Show("¿Desea cancelar la deuda?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int _id = int.Parse(dgvdata.Rows[index].Cells["Id"].Value.ToString());
                            int _idperiodo = int.Parse(dgvdata.Rows[index].Cells["IdPeriodo"].Value.ToString());
                            string mensaje = string.Empty;

                            int respuesta = DeudaLogica.Instancia.Pagar(new Deuda()
                            {
                                IdDeuda = _id,
                                IdPeriodo = _idperiodo,
                                FechaPago = DateTime.Now.ToString("yyyy-MM-dd", new CultureInfo("en-US"))
                            }, int.Parse(txtidalquiler.Text), out mensaje);

                            if (respuesta < 1)
                                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            else
                                dgvdata.Rows[index].Cells["EstadoDeuda"].Value = "CANCELADO";
                        }

                    }
                    else
                    {
                        MessageBox.Show("Esta opción solo esta habilitado para deudas con estado \"PENDIENTE\"", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (dgvdata.Columns[e.ColumnIndex].Name == "btndescargar") {
                    if (dgvdata.Rows[index].Cells["EstadoDeuda"].Value.ToString() == "CANCELADO")
                    {

                        string codigoalquiler = txtcodigo.Text;

                        Cliente cl = ClienteLogica.Instancia.Obtener();
                        Alquiler obj = AlquilerLogica.Instancia.Listar(codigoalquiler, 0).FirstOrDefault();

                        if (obj != null)
                        {
                            string Texto_Html = Properties.Resources.PlantillaPagoDeuda.ToString();

                            Texto_Html = Texto_Html.Replace("@codigoalquiler", obj.CodigoAlquiler);
                            Texto_Html = Texto_Html.Replace("@fechapago", dgvdata.Rows[index].Cells["FechaPago"].Value.ToString());

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

                            Texto_Html = Texto_Html.Replace("@importepagado", dgvdata.Rows[index].Cells["MontoDeuda"].Value.ToString());
                            Texto_Html = Texto_Html.Replace("@nroperiodo",  dgvdata.Rows[index].Cells["NumeroPeriodo"].Value.ToString());


                            SaveFileDialog savefile = new SaveFileDialog();
                            savefile.FileName = string.Format("ReciboDeuda_{0}.pdf", codigoalquiler);
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
                    else
                    {
                        MessageBox.Show("Esta opción solo esta habilitado para deudas con estado \"CANCELADO\"", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            
        }
    }
}
