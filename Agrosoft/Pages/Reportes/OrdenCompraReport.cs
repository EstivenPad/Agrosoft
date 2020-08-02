using Agrosoft.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Agrosoft.BLL;

namespace iTextSharpBlazor.Reportes
{
    public class OrdenCompraReport
    {
        int columnas = 4;

        Document document = new Document();
        PdfPTable pdfTable;
        PdfPCell pdfCell = new PdfPCell();
        Font fontStyle, fontFecha, fontTitulo;

        MemoryStream memoryStream = new MemoryStream();

        CompraProductos compra = new CompraProductos();
        List<CompraProductosDetalle> listaCompraProductosDetalle = new List<CompraProductosDetalle>();
        RepositorioBase<Proveedores> repositorioProveedor = new RepositorioBase<Proveedores>();
        ProductosBLL repositorioProducto = new ProductosBLL();
        RepositorioBase<UnidadesMedida> repositorioUnidadMedida = new RepositorioBase<UnidadesMedida>();

        public byte[] Reporte(List<CompraProductosDetalle> CompraProductosDetalle, CompraProductos compra)
        {
            this.compra = compra;
            listaCompraProductosDetalle = CompraProductosDetalle;

            document = new Document(PageSize.Letter, 25f, 25f, 20f, 20f);
            pdfTable = new PdfPTable(columnas);

            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

            fontStyle = FontFactory.GetFont("Calibri", 8f, 1);

            PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            float[] anchoColumnas = new float[columnas];

            anchoColumnas[0] = 400; //Esta sera la columna 1 
            anchoColumnas[1] = 150; //Esta sera la columna 2 
            anchoColumnas[2] = 150; //Esta sera la columna 3 
            anchoColumnas[3] = 150; //Esta sera la columna 4 

            pdfTable.SetWidths(anchoColumnas);

            this.ReportHeader();
            this.ReportBody();

            pdfTable.HeaderRows = 1;
            document.Add(pdfTable);
            document.Close();

            return memoryStream.ToArray();
        }

        private void ReportHeader()
        {
            this.AddLogo();

            pdfTable.CompleteRow();

            pdfCell = new PdfPCell(this.setPageTitle());
            pdfCell.Colspan = columnas;
            pdfCell.Border = 0;
            pdfTable.AddCell(pdfCell);

            pdfTable.CompleteRow();
        }

        private PdfPTable AddLogo()
        {
            PdfPTable pdfPTable = new PdfPTable(1);
            string img = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\Imagenes\LogoReporte.png"}";
            Image image = Image.GetInstance(img);

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(image);
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.Colspan = 2;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfTable.AddCell(pdfCell);

            pdfPTable.CompleteRow();

            return pdfPTable;
        }

        private PdfPTable setPageTitle()
        {
            PdfPTable pdfTable = new PdfPTable(2);

            fontStyle = FontFactory.GetFont("Calibri", 18f, 1);
            fontFecha = FontFactory.GetFont("Calibri", 10f, 1);
            fontTitulo = FontFactory.GetFont("Calibri", 25f, 1);

            pdfCell = new PdfPCell(new Phrase("Agroproductores Los Cocos", fontTitulo));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Colspan = 2;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfTable.AddCell(pdfCell);

            pdfTable.CompleteRow();

            pdfCell = new PdfPCell(new Phrase("Orden de Compra", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Colspan = 2;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfTable.AddCell(pdfCell);

            pdfTable.CompleteRow();

            pdfCell = new PdfPCell(new Phrase(DateTime.Now.ToString("dd/MM/yyyy H:mm tt"), fontFecha));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Colspan = 2;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfTable.AddCell(pdfCell);

            pdfTable.CompleteRow();

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.Colspan = 2;
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfTable.AddCell(pdfCell);

            pdfTable.CompleteRow();

            return pdfTable;
        }

        private void ReportBody()
        {
            Proveedores proveedor = repositorioProveedor.Buscar(compra.ProveedorId);

            fontStyle = FontFactory.GetFont("Calibri", 9f, 1);
            var _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);

            #region Table Header
            pdfCell = new PdfPCell(new Phrase("No. de orden: " + compra.CompraId.ToString(), fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 0;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 0;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfTable.AddCell(pdfCell);

            pdfTable.CompleteRow();

            pdfCell = new PdfPCell(new Phrase("Comprado a: " + (proveedor.Nombres + " " + proveedor.Apellidos), fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 0;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 0;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfTable.AddCell(pdfCell);

            pdfTable.CompleteRow();

            pdfCell = new PdfPCell(new Phrase("Dirección: " + proveedor.Direccion, fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 0;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 0;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfTable.AddCell(pdfCell);

            pdfTable.CompleteRow();

            pdfCell = new PdfPCell(new Phrase("Teléfono: " + proveedor.Telefono, fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 0;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 0;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfTable.AddCell(pdfCell);

            pdfTable.CompleteRow();

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 0;
            pdfTable.AddCell(pdfCell);

            pdfTable.CompleteRow();

            pdfCell = new PdfPCell(new Phrase("Producto", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 1;
            pdfCell.BorderColorTop = BaseColor.Black;
            pdfCell.BorderColorBottom = BaseColor.Black;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Cantidad", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 1;
            pdfCell.BorderColorTop = BaseColor.Black;
            pdfCell.BorderColorBottom = BaseColor.Black;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Precio Unitario", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 1;
            pdfCell.BorderColorTop = BaseColor.Black;
            pdfCell.BorderColorBottom = BaseColor.Black;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Importe", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 1;
            pdfCell.BorderColorTop = BaseColor.Black;
            pdfCell.BorderColorBottom = BaseColor.Black;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfTable.AddCell(pdfCell);

            pdfTable.CompleteRow();
            #endregion

            #region Table Body

            foreach (var item in listaCompraProductosDetalle)
            {
                var producto = repositorioProducto.Buscar(item.ProductoId);
                var unidadMedida = repositorioUnidadMedida.Buscar(producto.UnidadMedida);

                pdfCell = new PdfPCell(new Phrase(producto.Nombre + " " + producto.Marca + " " + unidadMedida.Descripcion, _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
                pdfCell.Border = 1;
                pdfCell.BorderColorBottom = BaseColor.Black;
                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(item.Cantidad.ToString(), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
                pdfCell.Border = 1;
                pdfCell.BorderColorBottom = BaseColor.Black;
                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(producto.Precio.ToString("N2"), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
                pdfCell.Border = 1;
                pdfCell.BorderColorBottom = BaseColor.Black;
                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase((producto.Precio * item.Cantidad).ToString("N2"), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
                pdfCell.Border = 1;
                pdfCell.BorderColorBottom = BaseColor.Black;
                pdfTable.AddCell(pdfCell);

                pdfTable.CompleteRow();
            }

            pdfTable.CompleteRow();

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 1;
            pdfCell.BorderColorBottom = BaseColor.Black;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(" ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 1;
            pdfCell.BorderColorBottom = BaseColor.Black;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Total: ", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 1;
            pdfCell.BorderColorBottom = BaseColor.Black;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(compra.Total.ToString("N2"), fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 1;
            pdfCell.BorderColorBottom = BaseColor.Black;
            pdfTable.AddCell(pdfCell);

            pdfTable.CompleteRow();
            #endregion
        }

    }
}

