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
    public class CobrosReport
    {
        int columnas = 5;

        Document document = new Document();
        PdfPTable pdfTable;
        PdfPCell pdfCell = new PdfPCell();
        Font fontStyle, fontFecha, fontTitulo;

        MemoryStream memoryStream = new MemoryStream();

        List<Cobros> listaCobros = new List<Cobros>();

        public byte[] Reporte(List<Cobros> cobros)
        {
            listaCobros = cobros;

            document = new Document(PageSize.Letter, 25f, 25f, 20f, 20f);
            pdfTable = new PdfPTable(columnas);

            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

            fontStyle = FontFactory.GetFont("Calibri", 8f, 1);

            PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            float[] anchoColumnas = new float[columnas];

            anchoColumnas[0] = 100; //Esta sera la fila 1 
            anchoColumnas[1] = 100; //Esta sera la fila 2 
            anchoColumnas[2] = 100; //Esta sera la fila 3 
            anchoColumnas[3] = 100; //Esta sera la fila 4 
            anchoColumnas[4] = 100; //Esta sera la fila 3 

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

            pdfCell = new PdfPCell(new Phrase("Reporte de Cobros", fontStyle));
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

            pdfCell = new PdfPCell(new Phrase("Fecha", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 1;
            pdfCell.BorderColorTop = BaseColor.Black;
            pdfCell.BorderColorBottom = BaseColor.Black;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Cliente", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 1;
            pdfCell.BorderColorTop = BaseColor.Black;
            pdfCell.BorderColorBottom = BaseColor.Black;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Deposito", fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 1;
            pdfCell.BorderColorTop = BaseColor.Black;
            pdfCell.BorderColorBottom = BaseColor.Black;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Usuario", fontStyle));
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
            decimal totalBalance = 0;

            foreach (var item in listaCobros)
            {
                num++;
                pdfCell = new PdfPCell(new Phrase(item.CobroId.ToString(), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
                pdfCell.Border = 1;
                pdfCell.BorderColorBottom = BaseColor.Black;
                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(item.Fecha.ToString(), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
                pdfCell.Border = 1;
                pdfCell.BorderColorBottom = BaseColor.Black;
                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(item.ClienteId.ToString(), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
                pdfCell.Border = 1;
                pdfCell.BorderColorBottom = BaseColor.Black;
                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(item.UsuarioId.ToString(), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
                pdfCell.Border = 1;
                pdfCell.BorderColorBottom = BaseColor.Black;
                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(item.Deposito.ToString(), _fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell.VerticalAlignment = Element.ALIGN_LEFT;
                pdfCell.Border = 1;
                pdfCell.BorderColorBottom = BaseColor.Black;
                pdfTable.AddCell(pdfCell);

                totalBalance += item.Deposito;

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

            pdfCell = new PdfPCell(new Phrase(("Total: " + (totalBalance.ToString())), fontStyle));
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.VerticalAlignment = Element.ALIGN_BOTTOM;
            pdfCell.Border = 1;
            pdfCell.BorderColorBottom = BaseColor.Black;
            pdfTable.AddCell(pdfCell);

            pdfTable.CompleteRow();
            #endregion
        }

    }
}

