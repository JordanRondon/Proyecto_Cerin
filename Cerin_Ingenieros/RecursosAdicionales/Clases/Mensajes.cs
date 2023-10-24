
namespace Cerin_Ingenieros.RecursosAdicionales.Clases
{
    public static class Mensajes
    {
        public static void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void MensajeGeneral(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK);
        }
    }
}
