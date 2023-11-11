using CapaEntidad;
using System;
using System.Collections.Generic;
using System.IO;
using Word = Microsoft.Office.Interop.Word;

namespace CapaDato
{
    public class datComprobante
    {
        #region Singleton
        private static readonly datComprobante instancia = new datComprobante();
        public static datComprobante GetInstancia => instancia;
        #endregion

        public string generarComprobante(entServicio servicio, entCliente cliente, List<entEquipo> equipos, string path)
        {
            try
            {
                entDocumento doc = datDocumento.GetInstancia.BuscarDocumentoPorNombre("Comprobante");

                string aux = path;
                string path2 = datDocumento.GetInstancia.GuardarDocumentoTemporal(doc);
                if (path != "")
                {
                    path += "\\" + doc.RealName;
                }


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

                        Word.Table nuevaTabla = plantilla.Tables[3];

                        // Llenar la tabla con los datos de los equipos
                        foreach (var equipo in equipos)
                        {
                            entMarca marca = datMarca.GetInstancia.BuscarMarcaPorId(equipo.IdMarca);
                            entModelo modelo = datModelo.GetInstancia.BuscarModeloPorId(equipo.id_modelo);
                            entCategoria categoria = datCategoria.GetInstancia.buscarCategoriaId(equipo.id_categoria);

                            string datosEquipo = categoria.Nombre + "\n" +
                                                 marca.Nombre + "\n" +
                                                 modelo.nombre + "\n" +
                                                equipo.SerieEquipo;

                            string accesorios = "";
                            List<entEquipo_Accesorio> listAccesorios = datEquipo_Accesorio.GetInstancia.ListAccsDeEquipo(equipo.SerieEquipo);
                            foreach (var ac in listAccesorios)
                            {
                                entAccesorio accesorio = datAccesorio.GetInstancia.BuscarAccesorioId(ac.id_accesorio);
                                accesorios += $"- {accesorio.Nombre} ({ac.cantidad}).\n";
                            }

                            entEquipo_Servicio equiposervicio = datEquipo_Servicio.GetInstancia.BuscarEquipoServicioId(equipo.SerieEquipo, servicio.IdServicio);

                            Word.Row newRow = nuevaTabla.Rows.Add();
                            newRow.Cells[1].Range.Text = datosEquipo;
                            newRow.Cells[2].Range.Text = accesorios;
                            newRow.Cells[3].Range.Text = equiposervicio.Observaciones_preliminares;
                            newRow.Cells[4].Range.Text = equiposervicio.observaciones_finales;

                            foreach (Word.Cell cell in newRow.Cells)
                            {
                                cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                                cell.Range.Font.Bold = 0; // Sin negrita
                                cell.Range.Font.Size = 11; // Tamaño de fuente
                            }

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