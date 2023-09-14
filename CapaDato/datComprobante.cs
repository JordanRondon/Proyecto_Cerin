﻿using CapaEntidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

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
            string filePath = "../../../Comprobantes/comprobante.pdf";
            string imageLogo = "../../../Cerin_Ingenieros/Resources/LOGO_CCI_LABS.png";

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));


            //Salto de linea
            Paragraph espacio = new Paragraph("\n");

            // Configurar una tabla para la cabecera
            PdfPTable cabeceraTable = new PdfPTable(new float[] { 0.8f, 0.1f, 2.4f, 0.1f, 0.8f }); // Especificar anchos de columna
            cabeceraTable.DefaultCell.Border = Rectangle.NO_BORDER; // Eliminar bordes por defecto
            cabeceraTable.WidthPercentage = 100;

            // Logo de la empresa (reemplaza "logo.png" con la ruta de tu imagen)
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(imageLogo);
            logo.ScaleToFit(80f, 80f);
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

            

            // Fecha y hora
            string fecha_hora = "Hora\n" + "11:22:00"
                + "\n\nDia/mes/año" + "\n21/" + "08/" + "2023";
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

            //Configuracion de numero de boleta
            string boleta = "Nº  " + "000001\n";
            Paragraph ncomprobante = new Paragraph(boleta, new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD,BaseColor.RED));
            ncomprobante.Alignment = Element.ALIGN_RIGHT;
            doc.Add(ncomprobante);
            doc.Add(espacio);

            //cabecera
            doc.Add(cabeceraTable);

            // Crear una tabla de dos columnas
            PdfPTable contenidoTable = new PdfPTable(2);
            contenidoTable.WidthPercentage = 100;
            contenidoTable.SpacingBefore = 10f;
            contenidoTable.SpacingAfter = 10f;

            // Primera columna: Datos del Cliente
            PdfPCell clienteCell = new PdfPCell();
            clienteCell.Border = Rectangle.NO_BORDER; // Eliminar borde
            clienteCell.AddElement(new Paragraph("Datos del Cliente:", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));
            clienteCell.AddElement(new Paragraph("DNI: 71691662"));
            clienteCell.AddElement(new Paragraph("Cliente: Juan Pérez"));
            clienteCell.AddElement(new Paragraph("Celular: 963258741"));
            contenidoTable.AddCell(clienteCell);

            // Segunda columna: Datos de la Empresa
            PdfPCell empresaCell2 = new PdfPCell();
            empresaCell2.Border = Rectangle.NO_BORDER; // Eliminar borde
            empresaCell2.AddElement(new Paragraph("\n"));
            empresaCell2.AddElement(new Paragraph("RUC: 10201020201"));
            empresaCell2.AddElement(new Paragraph("Razon social: Juan Pérez"));
            empresaCell2.AddElement(new Paragraph("Recepcionista: Juan Pérez"));
            contenidoTable.AddCell(empresaCell2);

            // Agregar la tabla de contenido al documento
            doc.Add(contenidoTable);

            // Agregar una línea separadora
            doc.Add(new Chunk(new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -5f)));
            doc.Add(espacio);

            // Título "Equipos"
            doc.Add(new Paragraph("Equipos:", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD)));

            for (int i = 0; i < 3; i++)
            {
                Paragraph equipo = new Paragraph("Serie: " + "23we34r      " + "Modelo: " + "exus11      " + "Marca: " + "Eros");
                doc.Add(equipo);
                for (int j = 0; j < 5; j++)
                {
                    Paragraph accsesorios = new Paragraph();
                    accsesorios.FirstLineIndent = 20; // Establecer la sangría en puntos (ajusta según tus necesidades)
                    accsesorios.Add("Accesorio" + (j + 1));
                    doc.Add(accsesorios);
                }

                // Crear una tabla de dos columnas
                PdfPTable TableRecomendaciones = new PdfPTable(2);
                TableRecomendaciones.WidthPercentage = 100;
                TableRecomendaciones.SpacingBefore = 10f;
                TableRecomendaciones.SpacingAfter = 10f;

                string prelminares = "La informática, ​ también llamada computación, ​ es el área de la ciencia que se encarga de estudiar la administración de métodos, técnicas y procesos con el fin de almacenar, procesar y transmitir información y datos en formato digital. La informática abarca desde disciplinas teóricas hasta disciplinas prácticas.​";

                // Primera columna: Cabecera Datos del Cliente
                PdfPCell cabeceraPreliminares = new PdfPCell();
                cabeceraPreliminares.Border = PdfPCell.BOX; // Eliminar borde
                Paragraph tituloPreliminares = new Paragraph("Recomendaciones preliminares", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD));
                tituloPreliminares.Alignment = Element.ALIGN_CENTER;
                cabeceraPreliminares.AddElement(tituloPreliminares);
                TableRecomendaciones.AddCell(cabeceraPreliminares);

                // Segunda columna: Cabecera Datos de la Empresa
                PdfPCell cabeceraFinales = new PdfPCell();
                cabeceraFinales.Border = PdfPCell.BOX; // Eliminar borde
                Paragraph tituloFinales = new Paragraph("Recomendaciones finales", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD));
                tituloFinales.Alignment = Element.ALIGN_CENTER; // Centrar el texto
                cabeceraFinales.AddElement(tituloFinales);
                TableRecomendaciones.AddCell(cabeceraFinales);

                // Primera columna: Datos del Cliente
                PdfPCell preliminares = new PdfPCell();
                preliminares.Border = PdfPCell.BOX; // Establecer todos los bordes
                preliminares.AddElement(new Paragraph(prelminares));
                TableRecomendaciones.AddCell(preliminares);

                // Segunda columna: Datos de la Empresa
                PdfPCell finales = new PdfPCell();
                finales.Border = PdfPCell.BOX; // Establecer todos los bordes
                finales.AddElement(new Paragraph(prelminares));
                TableRecomendaciones.AddCell(finales);

                // Agregar la tabla de contenido al documento
                doc.Add(TableRecomendaciones);

                doc.Add(espacio);

            }

            //doc.Add(equiposTable);

            doc.Close();
            writer.Close();
        }

        
    }
}