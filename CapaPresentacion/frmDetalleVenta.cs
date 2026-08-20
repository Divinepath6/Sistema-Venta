using CapaEntidad;
using CapaNegocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
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

namespace CapaPresentacion
{
    public partial class frmDetalleVenta : Form
    {
        private object txtmontototal;
        private object txtmontopago;
        private object txtmontocambio;

        public frmDetalleVenta()
        {
            InitializeComponent();
        }

        private void frmDetalleVenta_Load(object sender, EventArgs e)
        {
            txtbusqueda.Select();
        }

        

     

        

        private void label2_Click(object sender, EventArgs e) {

        }

        private void btnbuscar_Click_1(object sender, EventArgs e) {
         
                Venta oVenta = new CN_Venta().ObtenerVenta(txtbusqueda.Text);

                if(oVenta.IdVenta != 0) {

                    txtnumerodocumento.Text = oVenta.NumeroDocumento;

                    txtfecha.Text = oVenta.FechaRegistro;
                    txttipodocumento.Text = oVenta.TipoDocumento;
                    txtusuario.Text = oVenta.oUsuario.NombreCompleto;


                    txtdoccliente.Text = oVenta.DocumentoCliente;
                    txtnombrecliente.Text = oVenta.NombreCliente;

                    dgvdata.Rows.Clear();
                    foreach(Detalle_Venta dv in oVenta.oDetalle_Venta) {
                        dgvdata.Rows.Add(new object[] { dv.oProducto.Nombre, dv.PrecioVenta, dv.Cantidad, dv.SubTotal });
                    }

                    textmontototal.Text = oVenta.MontoTotal.ToString("0.00");
                    textmontopago.Text = oVenta.MontoPago.ToString("0.00");
                    textmontocambio.Text = oVenta.MontoCambio.ToString("0.00");


                }

            

        }

        private void textmontopago_TextChanged(object sender, EventArgs e) {

        }

        private void btndescargar_Click_1(object sender, EventArgs e) 
            {
            if(txttipodocumento.Text == "") {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string Texto_Html = Properties.Resources.PlantillaVenta.ToString();
            Negocio odatos = new CN_Negocio().ObtenerDatos();

            Texto_Html = Texto_Html.Replace("@nombrenegocio", odatos.Nombre.ToUpper());
            Texto_Html = Texto_Html.Replace("@docnegocio", odatos.RUC);
            Texto_Html = Texto_Html.Replace("@direcnegocio", odatos.Direccion);

            Texto_Html = Texto_Html.Replace("@tipodocumento", txttipodocumento.Text.ToUpper());
            Texto_Html = Texto_Html.Replace("@numerodocumento", txtnumerodocumento.Text);


            Texto_Html = Texto_Html.Replace("@doccliente", txtdoccliente.Text);
            Texto_Html = Texto_Html.Replace("@nombrecliente", txtnombrecliente.Text);
            Texto_Html = Texto_Html.Replace("@fecharegistro", txtfecha.Text);
            Texto_Html = Texto_Html.Replace("@usuarioregistro", txtusuario.Text);

            string filas = string.Empty;
            foreach(DataGridViewRow row in dgvdata.Rows) {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Precio"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SubTotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            Texto_Html = Texto_Html.Replace("@filas", filas);
            Texto_Html = Texto_Html.Replace("@montototal", textmontototal.Text);
            Texto_Html = Texto_Html.Replace("@pagocon", textmontopago.Text);
            Texto_Html = Texto_Html.Replace("@cambio", textmontocambio.Text);

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Venta_{0}.pdf", txtnumerodocumento.Text);
            savefile.Filter = "Pdf Files|*.pdf";

            if(savefile.ShowDialog() == DialogResult.OK) {
                using(FileStream stream = new FileStream(savefile.FileName, FileMode.Create)) {

                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    bool obtenido = true;
                    byte[] byteImage = new CN_Negocio().ObtenerLogo(out obtenido);

                    if(obtenido) {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                        img.ScaleToFit(60, 60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                        pdfDoc.Add(img);
                    }

                    using(StringReader sr = new StringReader(Texto_Html)) {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                    MessageBox.Show("Documento Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void texttipodocumento_TextChanged(object sender, EventArgs e) {

        }

        private void btnlimpiarbusc_Click(object sender, EventArgs e) {
            txtfecha.Text = "";
            txttipodocumento.Text = "";
            txtusuario.Text = "";
            txtdoccliente.Text = "";
            txtnombrecliente.Text = "";

            dgvdata.Rows.Clear();
            textmontototal.Text = "0.00";
            textmontopago.Text = "0.00";
            textmontocambio.Text = "0.00";
        }

        private void label5_Click(object sender, EventArgs e) {

        }

        private void label4_Click(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void label11_Click(object sender, EventArgs e) {

        }
    }
}
