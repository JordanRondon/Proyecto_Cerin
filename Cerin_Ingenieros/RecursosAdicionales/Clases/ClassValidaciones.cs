using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerin_Ingenieros.RecursosAdicionales.Clases
{
    public static class ClassValidaciones
    {
        public static void ValidarNumero(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        public static string SelecionarCarpeta()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    return folderDialog.SelectedPath;
                }
                return null;
            }
        }
        public static void AbrirDocumento(string path)
        {
            try
            {
                Process.Start(path);
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo abrir el documento: ","Error", MessageBoxButtons.OK);
            }
        }
        public static void AbrirCarpeta(string ruta)
        {
            try
            {
                Process.Start("explorer.exe", ruta);
            }
            catch (Exception ex)
            {
                Mensajes.MensajeError("Error al abrir la carpeta: " + ex.Message);
            }
        }
    }
}
