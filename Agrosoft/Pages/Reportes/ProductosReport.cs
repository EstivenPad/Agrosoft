using Agrosoft.BLL;
using Agrosoft.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace iTextSharpBlazor.Reportes
{
    public class ProductosReport
    {
        int columnas = 9;

        Document document = new Document();
        PdfPTable pdfTable;
        PdfPCell pdfCell = new PdfPCell();
        Font fontStyle, fontFecha, fontTitulo;

        MemoryStream memoryStream = new MemoryStream();

        List<Productos> listaProductos = new List<Productos>();
        RepositorioBase<UnidadesMedida> repositorioUnidades = new RepositorioBase<UnidadesMedida>();
        
        public byte[] Reporte(List<Productos> productos)
        {
            listaProductos = productos;

            document = new Document(PageSize.Letter, 25f, 25f, 20f, 20f);
            pdfTable = new PdfPTable(columnas);

            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

            fontStyle = FontFactory.GetFont("Calibri", 8f, 1);

            PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            float[] anchoColumnas = new float[columnas];

            anchoColumnas[0] = 50; //Esta sera la fila 1 
            anchoColumnas[1] = 110; //Esta sera la fila 2 
            anchoColumnas[2] = 100; //Esta sera la fila 3 
            anchoColumnas[3] = 110; //Esta sera la fila 4 
            anchoColumnas[4] = 100; //Esta sera la fila 5 
            anchoColumnas[5] = 100; //Esta sera la fila 6 
            anchoColumnas[6] = 110; //Esta sera la fila 7 
            anchoColumnas[7] = 110; //Esta sera la fila 8 
            anchoColumnas[8] = 110; //Esta sera la fila 8 

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

            pdfCell = new PdfPCell(new Phrase("Reporte de Productos", fontStyle));
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

            //Una fila en blanco
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
            fontStyle = FontFactory.GetFont("Calibri", 9f, 1);
            var _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);

            #region Table Header
            pdfCell = new PdfPCell(new Phrase("ID", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 1;
            pdfCell.BorderColorTop = BaseColor.Black;
            pdfCell.BorderColorBottom = BaseColor.Black;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Nombre", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 1;
            pdfCell.BorderColorTop = BaseColor.Black;
            pdfCell.BorderColorBottom = BaseColor.Black;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Marca", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 1;
            pdfCell.BorderColorTop = BaseColor.Black;
            pdfCell.BorderColorBottom = BaseColor.Black;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Unidad de medida", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 1;
            pdfCell.BorderColorTop = BaseColor.Black;
            pdfCell.BorderColorBottom = BaseColor.Black;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Cantidad minima", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 1;
            pdfCell.BorderColorTop = BaseColor.Black;
            pdfCell.BorderColorBottom = BaseColor.Black;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Cantidad existente", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 1;
            pdfCell.BorderColorTop = BaseColor.Black;
            pdfCell.BorderColorBottom = BaseColor.Black;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Costo", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 1;
            pdfCell.BorderColorTop = BaseColor.Black;
            pdfCell.BorderColorBottom = BaseColor.Black;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Precio", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 1;
            pdfCell.BorderColorTop = BaseColor.Black;
            pdfCell.BorderColorBottom = BaseColor.Black;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Total de inventario", fontStyle));
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
            int num = 0;
            decimal total = 0;

            foreach (var item in listaProductos)
            {
                num++;
                pdfCell = new PdfPCell(new Phrase(item.ProductoId.ToString(), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
                pdfCell.Border = 1;
                pdfCell.BorderColorBottom = BaseColor.Black;
                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(item.Nombre, _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
                pdfCell.Border = 1;
                pdfCell.BorderColorBottom = BaseColor.Black;
                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(item.Marca, _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
                pdfCell.Border = 1;
                pdfCell.BorderColorBottom = BaseColor.Black;
                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(repositorioUnidades.Buscar(item.UnidadMedida).Descripcion, _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
                pdfCell.Border = 1;
                pdfCell.BorderColorBottom = BaseColor.Black;
                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(item.CantidadMinima.ToString("N2"), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
                pdfCell.Border = 1;
                pdfCell.BorderColorBottom = BaseColor.Black;
                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(item.CantidadExistente.ToString("N2"), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
                pdfCell.Border = 1;
                pdfCell.BorderColorBottom = BaseColor.Black;
                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(item.Costo.ToString("N2"), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
                pdfCell.Border = 1;
                pdfCell.BorderColorBottom = BaseColor.Black;
                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(item.Precio.ToString("N2"), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
                pdfCell.Border = 1;
                pdfCell.BorderColorBottom = BaseColor.Black;
                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase((item.Costo * item.CantidadExistente).ToString("N2"), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
                pdfCell.Border = 1;
                pdfCell.BorderColorBottom = BaseColor.Black;
                pdfTable.AddCell(pdfCell);

                total += (item.Costo * item.CantidadExistente);

                pdfTable.CompleteRow();
            }

            pdfCell = new PdfPCell(new Phrase(("Total de registros: " + (num++.ToString())), fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_BOTTOM;
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

            pdfCell = new PdfPCell(new Phrase("Total: " + total.ToString("N2"), fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.White;
            pdfCell.Border = 1;
            pdfCell.BorderColorBottom = BaseColor.Black;
            pdfTable.AddCell(pdfCell);

            pdfTable.CompleteRow();
            #endregion
        }

    }
}

