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

        public string generarComprobante(entServicio servicio, entCliente cliente, List<entEquipo> equipos,string path)
        {
            try
            {
                //Buscamos el comprobante en la base de datos
                entDocumento doc = datDocumento.GetInstancia.BuscarDocumentoPorNombre("Comprobante");
                //hacemos un guardado temporal 
                string aux = path;
                string path2 = datDocumento.GetInstancia.GuardarDocumentoTemporal(doc);
                if (path != "")
                {
                    path += "\\" + doc.RealName;
                }


                // Cargar plantilla de Word
                Word.Application wordApp = new Word.Application();
                try
                {
                    Word.Document plantilla = wordApp.Documents.Open(path2);
                    try
                    {
                        entEmpleado empleado = datEmpleado.GetInstancia.BuscarEmpleadoId(servicio.IdEmpleado);

                        Dictionary<string, string> reemplazos = new Dictionary<string, string>
                        {
                            { "<codigo>", servicio.IdServicio.ToString() },
                            { "<Hora>", servicio.FechaRegistro.ToString("HH:mm:ss") },
                            { "<Fecha>", servicio.FechaRegistro.Date.ToString("dd/MM/yyyy") },
                            { "<DNI o RUC>", cliente.Ruc != "" ? cliente.Ruc : cliente.Dni },
                            { "<Cliente>", cliente.Ruc != "" ? cliente.RazonSocial : cliente.Apellido + ", " + cliente.Nombre },
                            { "<Telefono>", cliente.Telefono },
                            { "<Recepcionista>", empleado.Apellido + ", " + empleado.Nombre },
                            
                        };
                        foreach (var kvp in reemplazos)
                        {
                            plantilla.Content.Find.Execute(FindText: kvp.Key, ReplaceWith: kvp.Value);
                        }

                        // Rellenar equipos
                        string cantequipos = "";
                        foreach (var item in equipos)
                        {
                            cantequipos += "<DatEquiposCompletos>^p";
                        }
                        plantilla.Content.Find.Execute(FindText: "<Cuerpo del comprobante>", ReplaceWith: cantequipos);

                        foreach (var item in equipos)
                        {
                            string contenido = "<Datos equipo>^p";

                            List<entEquipo_Accesorio> listAccesorios = datEquipo_Accesorio.GetInstancia.ListAccsDeEquipo(item.SerieEquipo);
                            foreach (var ac in listAccesorios)
                            {
                                contenido += "<Accesorio>^p";
                            }

                            contenido += "RECOMENDACIONES PRELIMINARES: <Preliminares>.^p";
                            contenido += "RECOMENDACIONES FINALES: <Finales>.^p";

                            plantilla.Content.Find.Execute(FindText: "<DatEquiposCompletos>", ReplaceWith: contenido);
                        }

                        foreach (var equipo in equipos)
                        {
                            entMarca marca = datMarca.GetInstancia.BuscarMarcaPorId(equipo.IdMarca);
                            entModelo modelo = datModelo.GetInstancia.BuscarModeloPorId(equipo.id_modelo);
                            entCategoria categoria = datCategoria.GetInstancia.buscarCategoriaId(equipo.id_categoria);

                            string datosdelequipo = $"Equipo: {categoria.Nombre}    Modelo: {modelo.nombre}    Marca: {marca.Nombre}    Serie: {equipo.SerieEquipo}";

                            plantilla.Content.Find.Execute(FindText: "<Datos equipo>", ReplaceWith: datosdelequipo);

                            string accesorios = "";
                            List<entEquipo_Accesorio> listAccesorios = datEquipo_Accesorio.GetInstancia.ListAccsDeEquipo(equipo.SerieEquipo);
                            foreach (var ac in listAccesorios)
                            {
                                entAccesorio accesorio = datAccesorio.GetInstancia.BuscarAccesorioId(ac.id_accesorio);
                                accesorios = $"    - {accesorio.Nombre} ({ac.cantidad}).";
                                plantilla.Content.Find.Execute(FindText: "<Accesorio>", ReplaceWith: accesorios);
                            }

                            entEquipo_Servicio equiposervicio = datEquipo_Servicio.GetInstancia.BuscarEquipoServicioId(equipo.SerieEquipo, servicio.IdServicio);
                            plantilla.Content.Find.Execute(FindText: "<Preliminares>", ReplaceWith: equiposervicio.Observaciones_preliminares);
                            plantilla.Content.Find.Execute(FindText: "<Finales>", ReplaceWith: equiposervicio.observaciones_finales);
                        }

                        // Verificar si está terminado y generar fecha final
                        if (servicio.estado == 'T')
                        {
                            if (servicio.FechaEntrega != null)
                            {
                                DateTime fecha = (DateTime)servicio.FechaEntrega;
                                plantilla.Content.Find.Execute(FindText: "<Hora_fin>", ReplaceWith: fecha.ToString("HH:mm:ss"));
                                plantilla.Content.Find.Execute(FindText: "<Fecha_fin>", ReplaceWith: fecha.Date.ToString("dd/MM/yyyy"));
                            }
                        }
                        else
                        {
                            plantilla.Content.Find.Execute(FindText: "<Hora_fin>", ReplaceWith: "________");
                            plantilla.Content.Find.Execute(FindText: "<Fecha_fin>", ReplaceWith: "________");
                        }

                        if (cliente.Ruc != "")
                            plantilla.Content.Find.Execute(FindText: "<Cliente_nombre>", ReplaceWith: cliente.RazonSocial);
                        else
                            plantilla.Content.Find.Execute(FindText: "<Cliente_nombre>", ReplaceWith: cliente.Apellido + ", " + cliente.Nombre);
                        if (aux == "")
                        {
                            // Guardar el documento Word como PDF
                            string path3 = AppDomain.CurrentDomain.BaseDirectory;
                            string folder = path3 + "temp2\\";
                            string fullFilePath = folder + "Comprobante.pdf";
                            path = fullFilePath;
                            if (Directory.Exists(folder))
                                Directory.Delete(folder, true);
                            Directory.CreateDirectory(folder);
                        }
                        else
                        {
                            path = Path.ChangeExtension(path, ".pdf");
                        }
                        plantilla.SaveAs2(path, Word.WdSaveFormat.wdFormatPDF);

                        // Cerrar Word
                        plantilla.Close(false);
                        wordApp.Quit();

                        return path;




                    }
                    catch (Exception)
                    {

                        plantilla.Close();
                        return null;
                    }
                }
                catch (Exception)
                {
                    wordApp.Quit();
                    return null;
                }
                

                //// Rellenar campos del certificado
                //plantilla.Content.Find.Execute(FindText: "<codigo>", ReplaceWith: servicio.IdServicio);
                //plantilla.Content.Find.Execute(FindText: "<Hora>", ReplaceWith: servicio.FechaRegistro.ToString("HH:mm:ss"));
                //plantilla.Content.Find.Execute(FindText: "<Fecha>", ReplaceWith: servicio.FechaRegistro.Date.ToString("dd/MM/yyyy"));
                //if (cliente.Ruc != "")
                //    plantilla.Content.Find.Execute(FindText: "<DNI o RUC>", ReplaceWith: cliente.Ruc);
                //else plantilla.Content.Find.Execute(FindText: "<DNI o RUC>", ReplaceWith: cliente.Dni);

                //if (cliente.Ruc != "")
                //    plantilla.Content.Find.Execute(FindText: "<Cliente>", ReplaceWith: cliente.RazonSocial);
                //else plantilla.Content.Find.Execute(FindText: "<Cliente>", ReplaceWith: cliente.Apellido + ", " + cliente.Nombre);

                //plantilla.Content.Find.Execute(FindText: "<Telefono>", ReplaceWith: cliente.Telefono);

                ////entEmpleado empleado = datEmpleado.GetInstancia.BuscarEmpleadoId(servicio.IdEmpleado);
                //plantilla.Content.Find.Execute(FindText: "<Recepcionista>", ReplaceWith: empleado.Apellido + ", " + empleado.Nombre);


                ////remplzar equipos
                //string cantequipos = "";
                //foreach (var item in equipos)
                //{
                //    cantequipos += "<DatEquiposCompletos>^p";
                //}
                //plantilla.Content.Find.Execute(FindText: "<Cuerpo del comprobante>", ReplaceWith: cantequipos);

                //foreach (var item in equipos)
                //{
                //    string contenido = "";
                //    contenido = "<Datos equipo>^p";

                //    List<entEquipo_Accesorio> listAccesorios = datEquipo_Accesorio.GetInstancia.ListAccsDeEquipo(item.SerieEquipo);
                //    foreach (var ac in listAccesorios)
                //    {
                //        contenido += "<Accesorio>^p";
                //    }

                //    contenido += "RECOMENDACIONES PRELIMINARES: <Preliminares>.^p";
                //    contenido += "RECOMENDACIONES FINALES: <Finales>.^p";
                //    //<Cuerpo del comprobante>
                //    plantilla.Content.Find.Execute(FindText: "<DatEquiposCompletos>", ReplaceWith: contenido);
                //}

                //foreach (var equipo in equipos)
                //{
                //    entMarca marca = datMarca.GetInstancia.BuscarMarcaPorId(equipo.IdMarca);
                //    entModelo modelo = datModelo.GetInstancia.BuscarModeloPorId(equipo.id_modelo);
                //    entCategoria categoria = datCategoria.GetInstancia.buscarCategoriaId(equipo.id_categoria);

                //    string datosdelequipo = "";
                //    datosdelequipo = "Equipo: " + categoria.Nombre + "    Modelo: " + modelo.nombre + "    Marca: " + marca.Nombre + "    Serie: " + equipo.SerieEquipo;
                //    // Agregar el contenido del equipo al objeto Range del cuerpo
                //    plantilla.Content.Find.Execute(FindText: "<Datos equipo>", ReplaceWith: datosdelequipo);

                //    string accesorios = "";
                //    List<entEquipo_Accesorio> listAccesorios = datEquipo_Accesorio.GetInstancia.ListAccsDeEquipo(equipo.SerieEquipo);
                //    foreach (var ac in listAccesorios)
                //    {
                //        entAccesorio accesorio = datAccesorio.GetInstancia.BuscarAccesorioId(ac.id_accesorio);
                //        accesorios = "    - " + accesorio.Nombre + " (" + ac.cantidad + ").";
                //        plantilla.Content.Find.Execute(FindText: "<Accesorio>", ReplaceWith: accesorios);
                //    }
                //    entEquipo_Servicio equiposervicio = datEquipo_Servicio.GetInstancia.BuscarEquipoServicioId(equipo.SerieEquipo, servicio.IdServicio);
                //    plantilla.Content.Find.Execute(FindText: "<Preliminares>", ReplaceWith: equiposervicio.Observaciones_preliminares);
                //    plantilla.Content.Find.Execute(FindText: "<Finales>", ReplaceWith: equiposervicio.observaciones_finales);
                //}
                /////////////////Verificar si esta terminado y generar fecha final
                //if (servicio.estado == 'T')
                //{
                //    if (servicio.FechaEntrega != null)
                //    {
                //        DateTime fecha = (DateTime)servicio.FechaEntrega;
                //        plantilla.Content.Find.Execute(FindText: "<Hora_fin>", ReplaceWith: fecha.ToString("HH:mm:ss"));
                //        plantilla.Content.Find.Execute(FindText: "<Fecha_fin>", ReplaceWith: fecha.Date.ToString("dd/MM/yyyy"));
                //    }
                //}
                //else
                //{
                //    plantilla.Content.Find.Execute(FindText: "<Hora_fin>", ReplaceWith: "________");
                //    plantilla.Content.Find.Execute(FindText: "<Fecha_fin>", ReplaceWith: "________");

                //}
                //if (cliente.Ruc != "")
                //    plantilla.Content.Find.Execute(FindText: "<Cliente_nombre>", ReplaceWith: cliente.RazonSocial);
                //else plantilla.Content.Find.Execute(FindText: "<Cliente_nombre>", ReplaceWith: cliente.Apellido + ", " + cliente.Nombre);

                //// Guardar el documento Word como PDF
                //string path2 = AppDomain.CurrentDomain.BaseDirectory;
                //string folder = path2 + "temp2\\";
                //string fullFilePah = folder + "Comprobante.pdf";

                //if (Directory.Exists(folder))
                //    Directory.Delete(folder, true);
                //Directory.CreateDirectory(folder);
                //plantilla.SaveAs2(fullFilePah, Word.WdSaveFormat.wdFormatPDF);

                //// Cerrar Word
                //plantilla.Close(false);
                //wordApp.Quit();


                ////probamos que funcione
                ////Process.Start(path);

                //return fullFilePah;
            }
            catch (Exception ex)
            {
                // Manejar la excepción de manera apropiada
                Console.WriteLine("Error al generar el comprobante: " + ex.Message);
                return null;
            }
        }        
    }
}
