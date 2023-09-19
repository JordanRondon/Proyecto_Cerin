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
using iTextSharp.text.pdf.draw;
using Word = Microsoft.Office.Interop.Word;
using System.Diagnostics;
using static iTextSharp.text.pdf.AcroFields;

namespace CapaDato
{
    public class datComprobante//../../../Cerin_Ingenieros/Resources/Comprobante.docx
    {
        #region Singleton
        private static readonly datComprobante instancia = new datComprobante();
        public static datComprobante GetInstancia => instancia;
        #endregion

        public string generarComprobante(entServicio servicio, List<entEquipo_Servicio> listDet, entCliente cliente, List<entEquipo> equipos)
        {
            entDocumento doc = datDocumento.GetInstancia.BuscarDocumentoPorId(2);

            string path = datDocumento.GetInstancia.GuardarDocumentoTemporal(doc);

            // Cargar plantilla de Word
            Word.Application wordApp = new Word.Application();
            Word.Document plantilla = wordApp.Documents.Open(path);

            // Rellenar campos del certificado
            plantilla.Content.Find.Execute(FindText: "<codigo>", ReplaceWith: servicio.IdServicio);
            plantilla.Content.Find.Execute(FindText: "<Hora>", ReplaceWith: servicio.FechaRegistro.TimeOfDay.ToString());
            plantilla.Content.Find.Execute(FindText: "<Fecha>", ReplaceWith: servicio.FechaRegistro.Date.ToString());
            if (cliente.Dni!="")
                plantilla.Content.Find.Execute(FindText: "<DNI o RUC>", ReplaceWith: cliente.Dni);
            else plantilla.Content.Find.Execute(FindText: "<DNI o RUC>", ReplaceWith: cliente.Ruc);

            if (cliente.Ruc != "")
                plantilla.Content.Find.Execute(FindText: "<Cliente>", ReplaceWith: cliente.RazonSocial);
            else plantilla.Content.Find.Execute(FindText: "<Cliente>", ReplaceWith: cliente.Apellido +", "+ cliente.Nombre);
            
            plantilla.Content.Find.Execute(FindText: "<Telefono>", ReplaceWith: cliente.Telefono);

            entEmpleado empleado = datEmpleado.GetInstancia.BuscarEmpleadoId(servicio.IdEmpleado);
            plantilla.Content.Find.Execute(FindText: "<Recepcionista>", ReplaceWith: empleado.Apellido + ", " + empleado.Nombre);

            string cantequipos = "";
            foreach (var item in equipos) 
            {
                cantequipos += "<DatEquiposCompletos>^p";
            }
            plantilla.Content.Find.Execute(FindText: "<Cuerpo del comprobante>", ReplaceWith: cantequipos);

            foreach (var item in equipos)
            {
                string contenido = "";
                contenido = "<Datos equipo>^p";

                List<entEquipo_Accesorio> listAccesorios = datEquipo_Accesorio.GetInstancia.ListAccsDeEquipo(item.SerieEquipo);
                foreach (var ac in listAccesorios)
                {
                    contenido += "<Accesorio>^p";
                }
                
                contenido += "RECOMENDACIONES PRELIMINARES: <Preliminares>.^p";
                contenido += "RECOMENDACIONES FINALES: <Finales>.^p";
                //<Cuerpo del comprobante>
                plantilla.Content.Find.Execute(FindText: "<DatEquiposCompletos>", ReplaceWith: contenido);
            }

            foreach (var equipo in equipos)
            {
                entMarca marca = datMarca.GetInstancia.BuscarMarcaPorId(equipo.IdMarca);
                entModelo modelo = datModelo.GetInstancia.BuscarModeloPorId(equipo.id_modelo);
                entCategoria categoria = datCategoria.GetInstancia.buscarCategoriaId(equipo.id_categoria);

                string datosdelequipo = "";
                datosdelequipo = "Equipo: "+ categoria.Nombre + "    Modelo: " + modelo.nombre + "    Marca: " + marca.Nombre + "    Serie: " + equipo.SerieEquipo;
                // Agregar el contenido del equipo al objeto Range del cuerpo
                plantilla.Content.Find.Execute(FindText: "<Datos equipo>", ReplaceWith: datosdelequipo);

                string accesorios = "";
                List<entEquipo_Accesorio> listAccesorios = datEquipo_Accesorio.GetInstancia.ListAccsDeEquipo(equipo.SerieEquipo);
                foreach (var ac in listAccesorios)
                {
                    entAccesorio accesorio = datAccesorio.GetInstancia.BuscarAccesorioId(ac.id_accesorio);
                    accesorios = "    - " + accesorio.Nombre + " (" + ac.cantidad + ").";
                    plantilla.Content.Find.Execute(FindText: "<Accesorio>", ReplaceWith: accesorios);
                }
                string finequipo = "^p ------------------------------------------------------------------- p^";
                entEquipo_Servicio equiposervicio = datEquipo_Servicio.GetInstancia.BuscarEquipoServicioId(equipo.SerieEquipo, servicio.IdServicio);
                plantilla.Content.Find.Execute(FindText: "<Preliminares>", ReplaceWith: equiposervicio.Observaciones_preliminares);
                plantilla.Content.Find.Execute(FindText: "<Finales>", ReplaceWith: equiposervicio.observaciones_finales);
            }

            // Guardar el documento Word como PDF
            string path2 = AppDomain.CurrentDomain.BaseDirectory;
            string folder = path2 + "temp2\\";
            string fullFilePah = folder + "Comprobante.pdf";

            if (Directory.Exists(folder))
                Directory.Delete(folder, true);
            Directory.CreateDirectory(folder);
            plantilla.SaveAs2(fullFilePah, Word.WdSaveFormat.wdFormatPDF);

            // Cerrar Word
            plantilla.Close(false);
            wordApp.Quit();


            //probamos que funcione
            //Process.Start(path);

            return fullFilePah;
        }        
    }
}
