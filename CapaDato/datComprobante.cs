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
    public class datComprobante
    {
        #region Singleton
        private static readonly datComprobante instancia = new datComprobante();
        public static datComprobante GetInstancia => instancia;
        #endregion

        public string generarComprobante(entServicio servicio, entCliente cliente, List<entEquipo> equipos,string path)
        {
            int contadorLineas = 17;
            try
            {
                //Buscamos el comprobante en la base de datos
                entDocumento doc = datDocumento.GetInstancia.BuscarDocumentoPorNombre("Comprobante");
                //hacemos un guardado temporal del documento comprobante.docx

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
                    //abrid plantilla de documento de word
                    Word.Document plantilla = wordApp.Documents.Open(path2);
                    try
                    {
                        entEmpleado empleado = datEmpleado.GetInstancia.BuscarEmpleadoId(servicio.IdEmpleado);

                        //Insertamos datos de cabecera
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

                        // RELLENAR EQUIPO

                        //Cantidad de equipos en el servicio por cada equipo se insertara un <DatEquiposCompletos>^p
                        //y se remplazara en <Cuerpo del comprobante>
                        string cantequipos = "";
                        foreach (var item in equipos)
                        {
                            cantequipos += "<DatEquiposCompletos>^p";
                        }
                        plantilla.Content.Find.Execute(FindText: "<Cuerpo del comprobante>", ReplaceWith: cantequipos);


                        //Insertar etiquetas para cada equipo e las que remplazaremos sus datos
                        foreach (var item in equipos)
                        {
                            string contenido = "<Datos equipo>^p";

                            List<entEquipo_Accesorio> listAccesorios = datEquipo_Accesorio.GetInstancia.ListAccsDeEquipo(item.SerieEquipo);
                            foreach (var ac in listAccesorios)
                            {
                                contenido += "<Accesorio>^p";
                                contadorLineas++;
                            }

                            contenido += "RECOMENDACIONES PRELIMINARES: <Preliminares>.^p";
                            contenido += "RECOMENDACIONES FINALES: <Finales>.^p";
                            contadorLineas += 4;
                            plantilla.Content.Find.Execute(FindText: "<DatEquiposCompletos>", ReplaceWith: contenido);
                        }

                        //remplazamos datos de cada uno de los equipos en las etiquetas generadas
                        int contador= equipos.Count();
                        foreach (var equipo in equipos)
                        {
                            contador--;
                            entMarca marca = datMarca.GetInstancia.BuscarMarcaPorId(equipo.IdMarca);
                            entModelo modelo = datModelo.GetInstancia.BuscarModeloPorId(equipo.id_modelo);
                            entCategoria categoria = datCategoria.GetInstancia.buscarCategoriaId(equipo.id_categoria);

                            //datos principales del equipo
                            string datosdelequipo = $"Equipo: {categoria.Nombre}    Modelo: {modelo.nombre}    Marca: {marca.Nombre}    Serie: {equipo.SerieEquipo}";
                            plantilla.Content.Find.Execute(FindText: "<Datos equipo>", ReplaceWith: datosdelequipo);

                            //todos los accesorios de un equipo
                            string accesorios = "";
                            List<entEquipo_Accesorio> listAccesorios = datEquipo_Accesorio.GetInstancia.ListAccsDeEquipo(equipo.SerieEquipo);
                            foreach (var ac in listAccesorios)
                            {
                                entAccesorio accesorio = datAccesorio.GetInstancia.BuscarAccesorioId(ac.id_accesorio);
                                accesorios = $"    - {accesorio.Nombre} ({ac.cantidad}).";
                                plantilla.Content.Find.Execute(FindText: "<Accesorio>", ReplaceWith: accesorios);
                            }

                            //Registramos las recomendaciones preliminares y finales
                            entEquipo_Servicio equiposervicio = datEquipo_Servicio.GetInstancia.BuscarEquipoServicioId(equipo.SerieEquipo, servicio.IdServicio);
                            plantilla.Content.Find.Execute(FindText: "<Preliminares>", ReplaceWith: equiposervicio.Observaciones_preliminares);
                            if ((contadorLineas % 48) > 37 && contador == 0 )
                            {
                                int lineasFaltantes = contadorLineas%48;
                                int limite = (48 - lineasFaltantes);
                                for (int i = 0; i < limite; i++)
                                    equiposervicio.observaciones_finales += "^p";
                            }
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
