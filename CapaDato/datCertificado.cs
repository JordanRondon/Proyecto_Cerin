using CapaEntidad;
using iTextSharp.text.pdf.parser;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace CapaDato
{
    public class datCertificado
    {
        #region Singleton
        private static readonly datCertificado instancia = new datCertificado();
        public static datCertificado GetInstancia => instancia;
        #endregion

        public string GenerarCertificado(entEquipo equipo, DateTime fecha,string src)
        {
            entCategoria categoria = datCategoria.GetInstancia.buscarCategoriaId(equipo.id_categoria);
            entDocumento doc = datDocumento.GetInstancia.BuscarDocumentoPorId(categoria.id_documento); ;
            DateTime fin = fecha.AddMonths(categoria.tiempo_certificado);
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Certificados\\";
            string fullFilePah = folder + equipo.SerieEquipo+".docx";

            if (doc != null)
            {
                //guardamos certificado
                if (src=="")
                {
                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);
                    if (File.Exists(fullFilePah))
                        File.Delete(fullFilePah);
                    File.WriteAllBytes(fullFilePah, doc.Doc);
                }
                else
                {
                    if(File.Exists(fullFilePah))
                        File.Delete(fullFilePah);
                    File.WriteAllBytes(src,doc.Doc);
                    fullFilePah = src;
                }
                

                // Cargar plantilla de Word
                Word.Application wordApp = new Word.Application();
                Word.Document plantilla = wordApp.Documents.Open(fullFilePah);
                
                try
                {
                    // Rellenar campos del certificado
                    entModelo modelo = datModelo.GetInstancia.BuscarModeloPorId(equipo.id_modelo);
                    entMarca marca = datMarca.GetInstancia.BuscarMarcaPorId(equipo.IdMarca);
                    plantilla.Content.Find.Execute(FindText: "<Equipo>", ReplaceWith: categoria.Nombre);
                    plantilla.Content.Find.Execute(FindText: "<Marca>", ReplaceWith: marca.Nombre);
                    plantilla.Content.Find.Execute(FindText: "<Modelo>", ReplaceWith: modelo.nombre);
                    plantilla.Content.Find.Execute(FindText: "<Serie>", ReplaceWith: equipo.SerieEquipo);
                    plantilla.Content.Find.Execute(FindText: "<Fecha>", ReplaceWith: fecha.Date.ToString("dd/MM/yyyy"));
                    //plantilla.Save();
                    plantilla.Content.Find.Execute(FindText: "<Fin>", ReplaceWith: fin.Date.ToString("dd/MM/yyyy"));
                    plantilla.Save();
                }
                catch (Exception)
                {

                    
                }
                finally
                {
                    plantilla.Close(false);
                    wordApp.Quit();
                }

            }
            else return null;
            return fullFilePah;
        }
    }
}
