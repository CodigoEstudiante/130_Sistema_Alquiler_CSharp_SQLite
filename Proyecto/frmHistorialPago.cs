using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Proyecto.Logica;
using Proyecto.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class frmHistorialPago : Form
    {
        public frmHistorialPago()
        {
            InitializeComponent();
        }

        private void btnbuscarfiltro_Click(object sender, EventArgs e)
        {
            string codigoaquiler = string.Empty;
            if (txtcodigo.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un codigo de contrato", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            codigoaquiler = txtcodigo.Text;

            Alquiler obj = AlquilerLogica.Instancia.Obtener(codigoaquiler, 0);
            if (obj.IdAlquiler != 0)
            {
                txtidalquiler.Text = obj.IdAlquiler.ToString();

                dgvdata.Rows.Clear();
                List<Periodo> listaPeriodo = PeriodoLogica.Instancia.Listar(obj.IdAlquiler);
                foreach (Periodo item in listaPeriodo)
                {
                    dgvdata.Rows.Add(new object[] {
                    item.IdPeriodo,
                    item.NumeroPeriodo,
                    item.FechaLimitePeriodo,
                    item.EstadoPeriodo,
                    item.FechaPago,
                    item.Monto,
                    ""
                    });
                }

            }
            else
            {
                limpiar();
                MessageBox.Show("No se encontraron resultados con los datos de búsqueda solicitados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void limpiar()
        {

            txtcodigo.Text = "";
            txtidalquiler.Text = "0";
            dgvdata.Rows.Clear();
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0)
                return;

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

        private void frmHistorialPago_Load(object sender, EventArgs e)
        {

        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                if (dgvdata.Columns[e.ColumnIndex].Name == "btndescargar")
                {
                    if (dgvdata.Rows[index].Cells["EstadoPeriodo"].Value.ToString() != "CANCELADO" && dgvdata.Rows[index].Cells["EstadoPeriodo"].Value.ToString() != "EN DEUDA")
                        MessageBox.Show("Esta operación solo esta habilitado para periodo con estado \"CANCELADO\"", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else {
                        string _fechapago = dgvdata.Rows[index].Cells["FechaPago"].Value.ToString();
                        string _NumeroPeriodo = dgvdata.Rows[index].Cells["NumeroPeriodo"].Value.ToString();
                        string _Monto = dgvdata.Rows[index].Cells["Monto"].Value.ToString();

                        Cliente cl = ClienteLogica.Instancia.Obtener();
                        Alquiler obj = AlquilerLogica.Instancia.Listar(txtcodigo.Text, 0).FirstOrDefault();

                        if (obj != null)
                        {
                            string Texto_Html = Properties.Resources.PlantillaRecibo.ToString();

                            Texto_Html = Texto_Html.Replace("@codigoalquiler", obj.CodigoAlquiler);
                            Texto_Html = Texto_Html.Replace("@fechapago", _fechapago);

                            Texto_Html = Texto_Html.Replace("@propietarionombre", cl.Nombre);
                            Texto_Html = Texto_Html.Replace("@propietariotipodocumento", cl.TipoDocumento);
                            Texto_Html = Texto_Html.Replace("@propietariodocumento", cl.Documento);

                            Texto_Html = Texto_Html.Replace("@clientenombre", obj.NombreCliente);
                            Texto_Html = Texto_Html.Replace("@clientetipodocumento", obj.TipoDocumentoCliente);
                            Texto_Html = Texto_Html.Replace("@clientedocumento", obj.DocumentoCliente);

                            Texto_Html = Texto_Html.Replace("@codigoinmueble", obj.oInmueble.Codigo);
                            Texto_Html = Texto_Html.Replace("@tipoinmueble", obj.oInmueble.oTipoInmueble.Descripcion);
                            Texto_Html = Texto_Html.Replace("@descripcioninmueble", obj.oInmueble.Descripcion);


                            Texto_Html = Texto_Html.Replace("@nroperiodo", _NumeroPeriodo);
                            Texto_Html = Texto_Html.Replace("@importepagado", _Monto);
                            
                            SaveFileDialog savefile = new SaveFileDialog();
                            savefile.FileName = string.Format("Recibo_{0}.pdf", txtcodigo.Text);
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
        }

        private void btnborrarfiltro_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
