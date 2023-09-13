using CapaEntidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CapaDato
{
    public class datComprobante//../../../Cerin_Ingenieros/Resources/LOGO_CCI_LABS.png
    {
        #region Singleton
        private static readonly datComprobante instancia = new datComprobante();
        public static datComprobante GetInstancia => instancia;
        #endregion

        public void generarComprobante(entServicio servicio)
        {
            // Crear un documento PDF
            Document doc = new Document();
            string filePath = "../../../Comprobantes/comprobante.pdf"; // Ruta donde se guardará el PDF
            string imageLogo = "../../../Cerin_Ingenieros/Resources/LOGO_CCI_LABS.png";

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));


            //espacio
            Paragraph espacio = new Paragraph("\n");

            // Configurar una tabla para la cabecera
            PdfPTable cabeceraTable = new PdfPTable(new float[] { 0.9f, 0.1f, 2.2f, 0.1f, 0.9f }); // Especificar anchos de columna
            cabeceraTable.DefaultCell.Border = Rectangle.NO_BORDER; // Eliminar bordes por defecto
            cabeceraTable.WidthPercentage = 100;

            // Logo de la empresa (reemplaza "logo.png" con la ruta de tu imagen)
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(imageLogo);
            logo.ScaleToFit(100f, 100f);
            PdfPCell logoCell = new PdfPCell(logo);
            logoCell.Border = Rectangle.NO_BORDER; // Eliminar borde
            cabeceraTable.AddCell(logoCell);

            // Celda de línea
            PdfPCell lineaCell1 = new PdfPCell();
            lineaCell1.Border = Rectangle.NO_BORDER; // Eliminar borde
            cabeceraTable.AddCell(lineaCell1);

            // Información de la empresa
            string infoempresa = "calibracion - mantenimiento - reparacion de equipos Topograficos - " +
                "compra - venta - alquiler de equipos topograficos";
            PdfPCell empresaCell = new PdfPCell(new Phrase(infoempresa, new Font(Font.FontFamily.HELVETICA, 9)));
            empresaCell.HorizontalAlignment = Element.ALIGN_CENTER;
            empresaCell.Border = Rectangle.NO_BORDER; // Eliminar borde
            cabeceraTable.AddCell(empresaCell);

            // Celda de línea
            PdfPCell lineaCell2 = new PdfPCell();
            lineaCell2.Border = Rectangle.NO_BORDER; // Eliminar borde
            cabeceraTable.AddCell(lineaCell2);

            // RUC de la empresa
            string fecha_hora = "Hora\n"+"11:22:00" 
                + "\n\nDia/mes/año"+ "\n21/" + "08/" + "2023";
            PdfPCell rucCell = new PdfPCell(new Phrase(fecha_hora, new Font(Font.FontFamily.HELVETICA, 10, Font.NORMAL)));
            rucCell.HorizontalAlignment = Element.ALIGN_CENTER;
            rucCell.Border = Rectangle.NO_BORDER; // Eliminar borde
            cabeceraTable.AddCell(rucCell);

            // abrimos el documento
            doc.Open();

            //nombre de la empresa
            Paragraph empresa = new Paragraph("CORPORACION CERIN INGENIEROS S.A.C.", new Font(Font.FontFamily.HELVETICA, 20, Font.BOLD));
            empresa.Alignment = Element.ALIGN_CENTER;
            doc.Add(empresa);

            //ruc de la empresa
            Paragraph ruc = new Paragraph("RUC:20600681541", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD));
            ruc.Alignment = Element.ALIGN_CENTER;
            doc.Add(ruc);


            //epacios en blanco
            doc.Add(espacio);

            //cabecera
            doc.Add(cabeceraTable);

            // Resto del contenido del comprobante
            doc.Add(new Paragraph("Datos del Cliente:", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
            doc.Add(new Paragraph("Cliente: Juan Pérez"));
            doc.Add(new Paragraph("RUC: 10201020201"));
            doc.Add(new Paragraph("Razon social: Juan Pérez"));
            doc.Add(new Paragraph("DNI: 71691662"));
            doc.Add(new Paragraph("Celular: 963258741"));
            doc.Add(new Paragraph("Recepcionista: Juan Pérez"));
            doc.Add(espacio);
            // Lista de equipos con accesorios y recomendaciones
            doc.Add(new Paragraph("Equipos Prestados:", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
            doc.Add(espacio);
            PdfPTable equiposTable = new PdfPTable(3);
            equiposTable.WidthPercentage = 100;
            equiposTable.AddCell("Equipo");
            equiposTable.AddCell("Accesorios");
            equiposTable.AddCell("Recomendaciones");

            // Agregar filas de equipos (reemplaza con tus datos)
            for (int i = 0; i < 3; i++)
            {
                equiposTable.AddCell("Equipo " + (i + 1));
                equiposTable.AddCell("Accesorio " + (i + 1));
                equiposTable.AddCell("Recomendación para el equipo " + (i + 1));
            }

            doc.Add(equiposTable);

            doc.Close();
            writer.Close();
        }

        public class MyHeaderFooter : PdfPageEventHelper
        {
            public override void OnEndPage(PdfWriter writer, Document document)
            {
                base.OnEndPage(writer, document);

                // Posiciona el nombre de la empresa en la parte superior de la página
                PdfPTable headerTable = new PdfPTable(1);
                headerTable.TotalWidth = document.PageSize.Width;
                headerTable.DefaultCell.Border = Rectangle.NO_BORDER;

                PdfPCell empresaCell = new PdfPCell(new Phrase("CORPORACION CERIN INGENIEROS S.A.C.", new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD)));
                empresaCell.HorizontalAlignment = Element.ALIGN_CENTER;
                empresaCell.Border = Rectangle.NO_BORDER;
                headerTable.AddCell(empresaCell);

                headerTable.WriteSelectedRows(0, -1, 0, document.PageSize.Height - 10, writer.DirectContent);
            }
        }
    }
}
