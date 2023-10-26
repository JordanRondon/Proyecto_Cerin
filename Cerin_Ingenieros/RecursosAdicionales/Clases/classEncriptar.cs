
using System.Security.Cryptography;
using System.Text;

namespace Cerin_Ingenieros.RecursosAdicionales.Clases
{
    public static class classEncriptar
    {
        public static string EncriptarContraseña(string contraseña)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(contraseña);
                byte[] hash = sha256.ComputeHash(bytes);

                // Convierte el hash en una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
